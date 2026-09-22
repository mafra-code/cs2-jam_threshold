namespace JamThreshold
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Common;
    using Game.Creatures;
    using Game.Pathfind;
    using Game.Simulation;
    using Game.Tools;
    using Game.Vehicles;
    using Unity.Burst;
    using Unity.Burst.Intrinsics;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;

    /// <summary>
    /// Replacement for vanilla <see cref="StuckMovingObjectSystem"/>: same query, UpdateFrame
    /// scheduling, Crossing/RequestSpace side effect, and parked handling, but chain depth and
    /// speed cutoff are job fields (vanilla hard-codes 100 and byte 6). Newly flagged objects are
    /// also reported to <see cref="ClearanceStats"/> for the Options statistics lines.
    /// </summary>
    public partial class JamThresholdSystem : GameSystemBase
    {
        /// <summary>
        /// Burst clone of vanilla <c>StuckCheckJob</c>. Thresholds are fields because the
        /// original literals cannot be patched with Harmony.
        /// </summary>
        [BurstCompile]
        public struct StuckCheckJob : IJobChunk
        {
            public int m_ChainDepth;

            public byte m_MaxStuckSpeed;

            /// <summary>One <see cref="ClearedKind"/> slot per newly flagged object.</summary>
            public NativeQueue<int>.ParallelWriter m_ClearedKinds;

            [ReadOnly]
            public EntityTypeHandle m_EntityType;

            [ReadOnly]
            public ComponentTypeHandle<Blocker> m_BlockerType;

            [ReadOnly]
            public ComponentTypeHandle<GroupMember> m_GroupMemberType;

            [ReadOnly]
            public ComponentTypeHandle<CurrentVehicle> m_CurrentVehicleType;

            [ReadOnly]
            public ComponentTypeHandle<RideNeeder> m_RideNeederType;

            [ReadOnly]
            public ComponentTypeHandle<Target> m_TargetType;

            [ReadOnly]
            public ComponentTypeHandle<Car> m_CarType;

            // Statistics only: these decide which ClearedKind slot a chunk belongs to.
            [ReadOnly]
            public ComponentTypeHandle<Human> m_HumanType;

            [ReadOnly]
            public ComponentTypeHandle<Train> m_TrainType;

            [ReadOnly]
            public ComponentTypeHandle<Bicycle> m_BicycleType;

            [ReadOnly]
            public ComponentTypeHandle<Taxi> m_TaxiType;

            [ReadOnly]
            public ComponentTypeHandle<PublicTransport> m_PublicTransportType;

            [ReadOnly]
            public ComponentTypeHandle<PassengerTransport> m_PassengerTransportType;

            [ReadOnly]
            public ComponentTypeHandle<DeliveryTruck> m_DeliveryTruckType;

            [ReadOnly]
            public ComponentTypeHandle<GarbageTruck> m_GarbageTruckType;

            [ReadOnly]
            public ComponentTypeHandle<FireEngine> m_FireEngineType;

            [ReadOnly]
            public ComponentTypeHandle<PoliceCar> m_PoliceCarType;

            [ReadOnly]
            public ComponentTypeHandle<PostVan> m_PostVanType;

            [ReadOnly]
            public ComponentTypeHandle<Ambulance> m_AmbulanceType;

            [ReadOnly]
            public ComponentTypeHandle<Hearse> m_HearseType;

            [ReadOnly]
            public ComponentTypeHandle<MaintenanceVehicle> m_MaintenanceVehicleType;

            [ReadOnly]
            public ComponentTypeHandle<CargoTransport> m_CargoTransportType;

            [ReadOnly]
            public ComponentTypeHandle<PersonalCar> m_PersonalCarType;

            [ReadOnly]
            public ComponentLookup<Blocker> m_BlockerData;

            [ReadOnly]
            public ComponentLookup<Controller> m_ControllerData;

            [ReadOnly]
            public ComponentLookup<ParkedCar> m_ParkedCarData;

            [ReadOnly]
            public ComponentLookup<ParkedTrain> m_ParkedTrainData;

            [ReadOnly]
            public ComponentLookup<CurrentVehicle> m_CurrentVehicleData;

            [ReadOnly]
            public ComponentLookup<Dispatched> m_DispatchedData;

            public ComponentTypeHandle<PathOwner> m_PathOwnerType;

            public ComponentTypeHandle<AnimalCurrentLane> m_AnimalCurrentLaneType;

            [NativeDisableParallelForRestriction]
            public ComponentLookup<CarCurrentLane> m_CarCurrentLaneData;

            public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
            {
                NativeArray<Entity> nativeArray = chunk.GetNativeArray(m_EntityType);
                NativeArray<Blocker> nativeArray2 = chunk.GetNativeArray(ref m_BlockerType);
                NativeArray<GroupMember> nativeArray3 = chunk.GetNativeArray(ref m_GroupMemberType);
                NativeArray<CurrentVehicle> nativeArray4 = chunk.GetNativeArray(ref m_CurrentVehicleType);
                NativeArray<RideNeeder> nativeArray5 = chunk.GetNativeArray(ref m_RideNeederType);
                NativeArray<Target> nativeArray6 = chunk.GetNativeArray(ref m_TargetType);
                NativeArray<PathOwner> nativeArray7 = chunk.GetNativeArray(ref m_PathOwnerType);
                NativeArray<AnimalCurrentLane> nativeArray8 = chunk.GetNativeArray(ref m_AnimalCurrentLaneType);
                bool flag = chunk.Has(ref m_CarType);
                int clearedKind = ClassifyChunk(in chunk, flag);
                for (int i = 0; i < nativeArray2.Length; i++)
                {
                    Blocker blocker = nativeArray2[i];
                    if (blocker.m_Blocker == Entity.Null || blocker.m_Type == BlockerType.Temporary)
                    {
                        continue;
                    }

                    if (flag && blocker.m_Type == BlockerType.Crossing)
                    {
                        Entity entity = blocker.m_Blocker;
                        if (m_ControllerData.TryGetComponent(entity, out var componentData))
                        {
                            entity = componentData.m_Controller;
                        }

                        if (m_CarCurrentLaneData.TryGetComponent(entity, out var componentData2))
                        {
                            componentData2.m_LaneFlags |= CarLaneFlags.RequestSpace;
                            m_CarCurrentLaneData[entity] = componentData2;
                        }
                    }

                    if (blocker.m_MaxSpeed >= m_MaxStuckSpeed)
                    {
                        continue;
                    }

                    Entity entity2 = nativeArray[i];
                    Entity entity3 = Entity.Null;
                    bool flag2;
                    if (m_ParkedTrainData.HasComponent(blocker.m_Blocker) || (!flag && m_ParkedCarData.HasComponent(blocker.m_Blocker)))
                    {
                        flag2 = true;
                    }
                    else
                    {
                        if (nativeArray4.Length != 0)
                        {
                            entity3 = nativeArray4[i].m_Vehicle;
                        }
                        else if (nativeArray5.Length != 0)
                        {
                            RideNeeder rideNeeder = nativeArray5[i];
                            if (m_DispatchedData.TryGetComponent(rideNeeder.m_RideRequest, out var componentData3))
                            {
                                entity3 = componentData3.m_Handler;
                            }
                        }
                        else if (nativeArray3.Length != 0)
                        {
                            GroupMember groupMember = nativeArray3[i];
                            if (m_CurrentVehicleData.TryGetComponent(groupMember.m_Leader, out var componentData4))
                            {
                                entity3 = componentData4.m_Vehicle;
                            }
                        }

                        if (nativeArray6.Length != 0 && entity3 == Entity.Null)
                        {
                            entity3 = nativeArray6[i].m_Target;
                        }

                        if (entity3 != Entity.Null)
                        {
                            if (m_ControllerData.TryGetComponent(entity3, out var componentData5))
                            {
                                entity3 = componentData5.m_Controller;
                            }

                            flag2 = IsBlocked(entity2, entity3, blocker);
                        }
                        else
                        {
                            flag2 = IsBlocked(entity2, blocker);
                        }
                    }

                    if (!flag2)
                    {
                        continue;
                    }

                    if (nativeArray7.Length != 0)
                    {
                        PathOwner value = nativeArray7[i];
                        if ((value.m_State & PathFlags.Pending) == 0)
                        {
                            // Count the transition only: a chain stays flagged across updates.
                            bool wasStuck = (value.m_State & PathFlags.Stuck) != 0;
                            value.m_State |= PathFlags.Stuck;
                            nativeArray7[i] = value;
                            if (!wasStuck && clearedKind >= 0)
                            {
                                m_ClearedKinds.Enqueue(clearedKind);
                            }
                        }
                    }
                    else if (nativeArray8.Length != 0)
                    {
                        AnimalCurrentLane value2 = nativeArray8[i];
                        bool wasStuck = (value2.m_Flags & CreatureLaneFlags.Stuck) != 0;
                        value2.m_Flags |= CreatureLaneFlags.Stuck;
                        nativeArray8[i] = value2;
                        if (!wasStuck && clearedKind >= 0)
                        {
                            m_ClearedKinds.Enqueue(clearedKind);
                        }
                    }
                }
            }

            /// <summary>
            /// Picks the <see cref="ClearedKind"/> slot for a whole chunk - entities in one chunk
            /// share an archetype, so this costs one pass instead of one test per entity.
            /// Returns -1 for riders, which are counted through the vehicle carrying them.
            /// </summary>
            private int ClassifyChunk(in ArchetypeChunk chunk, bool isCar)
            {
                if (chunk.Has(ref m_HumanType))
                {
                    return chunk.Has(ref m_CurrentVehicleType) ? -1 : (int)ClearedKind.Pedestrian;
                }

                if (chunk.Has(ref m_TrainType))
                {
                    return (int)ClearedKind.Train;
                }

                if (chunk.Has(ref m_BicycleType))
                {
                    return (int)ClearedKind.Bicycle;
                }

                if (chunk.Has(ref m_TaxiType)
                    || chunk.Has(ref m_PublicTransportType)
                    || chunk.Has(ref m_PassengerTransportType))
                {
                    return (int)ClearedKind.Transit;
                }

                if (chunk.Has(ref m_DeliveryTruckType)
                    || chunk.Has(ref m_GarbageTruckType)
                    || chunk.Has(ref m_FireEngineType)
                    || chunk.Has(ref m_PoliceCarType)
                    || chunk.Has(ref m_PostVanType)
                    || chunk.Has(ref m_AmbulanceType)
                    || chunk.Has(ref m_HearseType)
                    || chunk.Has(ref m_MaintenanceVehicleType)
                    || chunk.Has(ref m_CargoTransportType))
                {
                    return (int)ClearedKind.Truck;
                }

                if (chunk.Has(ref m_PersonalCarType) || isCar)
                {
                    return (int)ClearedKind.Car;
                }

                // Aircraft, watercraft, animals, and anything else with a Blocker.
                return (int)ClearedKind.Other;
            }

            public bool IsBlocked(Entity entity, Blocker blocker)
            {
                int num = 0;
                if (m_ControllerData.TryGetComponent(blocker.m_Blocker, out var componentData))
                {
                    blocker.m_Blocker = componentData.m_Controller;
                }

                Blocker componentData2;
                while (m_BlockerData.TryGetComponent(blocker.m_Blocker, out componentData2))
                {
                    if ((long)(++num) == m_ChainDepth || blocker.m_Blocker == entity)
                    {
                        return true;
                    }

                    blocker = componentData2;
                    if (blocker.m_Blocker == Entity.Null)
                    {
                        return false;
                    }

                    if (blocker.m_Type == BlockerType.Temporary)
                    {
                        return false;
                    }

                    if (blocker.m_MaxSpeed >= m_MaxStuckSpeed)
                    {
                        return false;
                    }

                    if (m_ControllerData.TryGetComponent(blocker.m_Blocker, out componentData))
                    {
                        blocker.m_Blocker = componentData.m_Controller;
                    }
                }

                return false;
            }

            public bool IsBlocked(Entity entity1, Entity entity2, Blocker blocker)
            {
                int num = 0;
                if (m_ControllerData.TryGetComponent(blocker.m_Blocker, out var componentData))
                {
                    blocker.m_Blocker = componentData.m_Controller;
                }

                Blocker componentData2;
                while (m_BlockerData.TryGetComponent(blocker.m_Blocker, out componentData2))
                {
                    if ((long)(++num) == m_ChainDepth || blocker.m_Blocker == entity1 || blocker.m_Blocker == entity2)
                    {
                        return true;
                    }

                    blocker = componentData2;
                    if (blocker.m_Blocker == Entity.Null)
                    {
                        return false;
                    }

                    if (blocker.m_Type == BlockerType.Temporary)
                    {
                        return false;
                    }

                    if (blocker.m_MaxSpeed >= m_MaxStuckSpeed)
                    {
                        return false;
                    }

                    if (m_ControllerData.TryGetComponent(blocker.m_Blocker, out componentData))
                    {
                        blocker.m_Blocker = componentData.m_Controller;
                    }
                }

                return false;
            }

            void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
            {
                Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
            }
        }

        private SimulationSystem m_SimulationSystem;

        private EntityQuery m_ObjectQuery;

        // Filled by the parallel job, drained on the main thread one update later.
        private NativeQueue<int> m_ClearedKinds;

        private JobHandle m_ClearedKindsHandle;

        // Simulation frame the current statistics window started on.
        private uint m_StartFrame;

        private bool m_HasStartFrame;

        /// <summary>
        /// Exclusive ownership of stuck-check: at most one of vanilla or this replacement is on.
        /// Never disables vanilla unless this system already exists.
        /// </summary>
        public static void ApplyOwnership(bool replacementEnabled)
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return;
            }

            StuckMovingObjectSystem vanilla = world.GetOrCreateSystemManaged<StuckMovingObjectSystem>();
            JamThresholdSystem replacement = world.GetExistingSystemManaged<JamThresholdSystem>();
            if (replacementEnabled)
            {
                if (replacement == null)
                {
                    Mod.Instance?.Logger?.Warn("Replacement system not found; leaving vanilla stuck-check enabled.");
                    return;
                }

                vanilla.Enabled = false;
                replacement.Enabled = true;
                return;
            }

            vanilla.Enabled = true;
            if (replacement != null)
            {
                replacement.Enabled = false;
            }
        }

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return 4;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            m_ClearedKinds = new NativeQueue<int>(Allocator.Persistent);
            m_SimulationSystem = World.GetOrCreateSystemManaged<SimulationSystem>();
            m_ObjectQuery = GetEntityQuery(
                ComponentType.ReadOnly<Blocker>(),
                ComponentType.ReadOnly<UpdateFrame>(),
                ComponentType.Exclude<Deleted>(),
                ComponentType.Exclude<Temp>());
            RequireForUpdate(m_ObjectQuery);

            Setting settings = Mod.Instance?.Settings;
            ApplyOwnership(settings == null || settings.Enabled);
        }

        protected override void OnDestroy()
        {
            m_ClearedKindsHandle.Complete();
            if (m_ClearedKinds.IsCreated)
            {
                m_ClearedKinds.Dispose();
            }

            base.OnDestroy();
        }

        /// <summary>
        /// Statistics cover one city session, so a newly loaded save must not inherit the
        /// totals of the previous one.
        /// </summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            if (mode != GameMode.Game)
            {
                return;
            }

            DiscardPendingCounts();
            ClearanceStats.ResetNow();
        }

        protected override void OnUpdate()
        {
            // The job from the previous update is long finished; this only makes queue access safe.
            m_ClearedKindsHandle.Complete();
            if (ClearanceStats.ConsumePendingReset())
            {
                DiscardPendingCounts();
            }
            else
            {
                while (m_ClearedKinds.TryDequeue(out int kind))
                {
                    ClearanceStats.Add(kind);
                }
            }

            Setting settings = Mod.Instance?.Settings;
            if (settings == null || !settings.Enabled)
            {
                return;
            }

            uint frameIndex = m_SimulationSystem.frameIndex;
            if (!m_HasStartFrame)
            {
                m_StartFrame = frameIndex;
                m_HasStartFrame = true;
            }

            ClearanceStats.Publish(ElapsedInGameHours(m_StartFrame, frameIndex));

            uint index = (frameIndex >> 2) % 16;
            m_ObjectQuery.ResetFilter();
            m_ObjectQuery.SetSharedComponentFilter(new UpdateFrame(index));

            StuckCheckJob jobData = new StuckCheckJob
            {
                m_ChainDepth = settings.ClampedChainDepth(),
                m_MaxStuckSpeed = settings.ClampedMaxStuckSpeed(),
                m_ClearedKinds = m_ClearedKinds.AsParallelWriter(),
                m_EntityType = GetEntityTypeHandle(),
                m_BlockerType = GetComponentTypeHandle<Blocker>(true),
                m_GroupMemberType = GetComponentTypeHandle<GroupMember>(true),
                m_CurrentVehicleType = GetComponentTypeHandle<CurrentVehicle>(true),
                m_RideNeederType = GetComponentTypeHandle<RideNeeder>(true),
                m_TargetType = GetComponentTypeHandle<Target>(true),
                m_CarType = GetComponentTypeHandle<Car>(true),
                m_HumanType = GetComponentTypeHandle<Human>(true),
                m_TrainType = GetComponentTypeHandle<Train>(true),
                m_BicycleType = GetComponentTypeHandle<Bicycle>(true),
                m_TaxiType = GetComponentTypeHandle<Taxi>(true),
                m_PublicTransportType = GetComponentTypeHandle<PublicTransport>(true),
                m_PassengerTransportType = GetComponentTypeHandle<PassengerTransport>(true),
                m_DeliveryTruckType = GetComponentTypeHandle<DeliveryTruck>(true),
                m_GarbageTruckType = GetComponentTypeHandle<GarbageTruck>(true),
                m_FireEngineType = GetComponentTypeHandle<FireEngine>(true),
                m_PoliceCarType = GetComponentTypeHandle<PoliceCar>(true),
                m_PostVanType = GetComponentTypeHandle<PostVan>(true),
                m_AmbulanceType = GetComponentTypeHandle<Ambulance>(true),
                m_HearseType = GetComponentTypeHandle<Hearse>(true),
                m_MaintenanceVehicleType = GetComponentTypeHandle<MaintenanceVehicle>(true),
                m_CargoTransportType = GetComponentTypeHandle<CargoTransport>(true),
                m_PersonalCarType = GetComponentTypeHandle<PersonalCar>(true),
                m_BlockerData = GetComponentLookup<Blocker>(true),
                m_ControllerData = GetComponentLookup<Controller>(true),
                m_ParkedCarData = GetComponentLookup<ParkedCar>(true),
                m_ParkedTrainData = GetComponentLookup<ParkedTrain>(true),
                m_CurrentVehicleData = GetComponentLookup<CurrentVehicle>(true),
                m_DispatchedData = GetComponentLookup<Dispatched>(true),
                m_PathOwnerType = GetComponentTypeHandle<PathOwner>(false),
                m_AnimalCurrentLaneType = GetComponentTypeHandle<AnimalCurrentLane>(false),
                m_CarCurrentLaneData = GetComponentLookup<CarCurrentLane>(false),
            };
            Dependency = jobData.ScheduleParallel(m_ObjectQuery, Dependency);
            m_ClearedKindsHandle = Dependency;
        }

        // Drops counts the job already queued and restarts the in-game-hour window.
        private void DiscardPendingCounts()
        {
            m_ClearedKindsHandle.Complete();
            if (m_ClearedKinds.IsCreated)
            {
                m_ClearedKinds.Clear();
            }

            m_HasStartFrame = false;
        }

        // TimeSystem.kTicksPerDay simulation frames are one in-game day. Pausing stops frameIndex,
        // so this measures in-game time rather than wall-clock time.
        private static double ElapsedInGameHours(uint startFrame, uint frameIndex)
        {
            if (frameIndex <= startFrame)
            {
                return 0.0;
            }

            return (frameIndex - startFrame) * 24.0 / TimeSystem.kTicksPerDay;
        }
    }
}
