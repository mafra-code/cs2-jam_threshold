namespace JamThreshold
{
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

    /// <summary>
    /// Replacement for vanilla <see cref="StuckMovingObjectSystem"/>: same query, UpdateFrame
    /// scheduling, Crossing/RequestSpace side effect, and parked handling, but chain depth and
    /// speed cutoff are job fields (vanilla hard-codes 100 and byte 6).
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
                            value.m_State |= PathFlags.Stuck;
                            nativeArray7[i] = value;
                        }
                    }
                    else if (nativeArray8.Length != 0)
                    {
                        AnimalCurrentLane value2 = nativeArray8[i];
                        value2.m_Flags |= CreatureLaneFlags.Stuck;
                        nativeArray8[i] = value2;
                    }
                }
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

        protected override void OnUpdate()
        {
            Setting settings = Mod.Instance?.Settings;
            if (settings == null || !settings.Enabled)
            {
                return;
            }

            uint index = (m_SimulationSystem.frameIndex >> 2) % 16;
            m_ObjectQuery.ResetFilter();
            m_ObjectQuery.SetSharedComponentFilter(new UpdateFrame(index));

            StuckCheckJob jobData = new StuckCheckJob
            {
                m_ChainDepth = settings.ClampedChainDepth(),
                m_MaxStuckSpeed = settings.ClampedMaxStuckSpeed(),
                m_EntityType = GetEntityTypeHandle(),
                m_BlockerType = GetComponentTypeHandle<Blocker>(true),
                m_GroupMemberType = GetComponentTypeHandle<GroupMember>(true),
                m_CurrentVehicleType = GetComponentTypeHandle<CurrentVehicle>(true),
                m_RideNeederType = GetComponentTypeHandle<RideNeeder>(true),
                m_TargetType = GetComponentTypeHandle<Target>(true),
                m_CarType = GetComponentTypeHandle<Car>(true),
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
        }
    }
}
