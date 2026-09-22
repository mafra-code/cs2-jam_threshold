namespace JamThreshold
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;

    /// <summary>
    /// Options page: enable the replacement stuck-check, set chain depth and raw
    /// speed threshold, read the session statistics, or hand ownership back to vanilla
    /// <c>StuckMovingObjectSystem</c>. This is not a city-wide traffic reset.
    /// </summary>
    // Saved as Mods_JamThreshold.coc under the game's userdata root (same [FileLocation] pattern as Reset Traffic).
    [FileLocation("Mods_JamThreshold")]
    [SettingsUIGroupOrder(kToggleGroup, kThresholdGroup, kStatsGroup, kVanillaGroup)]
    [SettingsUIShowGroupName(kToggleGroup, kThresholdGroup, kStatsGroup, kVanillaGroup)]
    public class Setting : ModSetting
    {
        public const string kSection = "Main";
        public const string kToggleGroup = "Toggle";
        public const string kThresholdGroup = "Thresholds";
        public const string kStatsGroup = "Statistics";
        public const string kVanillaGroup = "Vanilla";

        public const int DefaultChainDepth = 40;
        public const int VanillaChainDepth = 100;
        public const int MinChainDepth = 1;
        public const int MaxChainDepth = 200;

        public const int DefaultMaxStuckSpeed = 6;
        public const int VanillaMaxStuckSpeed = 6;
        public const int MinMaxStuckSpeed = 0;
        public const int MaxMaxStuckSpeed = 255;

        public Setting(IMod mod)
            : base(mod)
        {
        }

        /// <summary>
        /// When on, vanilla <c>StuckMovingObjectSystem</c> is disabled and
        /// <see cref="JamThresholdSystem"/> runs with the sliders below.
        /// </summary>
        [SettingsUISection(kSection, kToggleGroup)]
        [SettingsUISetter(typeof(Setting), nameof(OnEnabledChanged))]
        public bool Enabled { get; set; }

        /// <summary>
        /// A blocked chain is flagged stuck if it is a loop or this many vehicles long.
        /// Vanilla is 100. Default 40 so shorter jams clear.
        /// </summary>
        [SettingsUISection(kSection, kThresholdGroup)]
        [SettingsUISlider(min = MinChainDepth, max = MaxChainDepth, step = 1, scalarMultiplier = 1)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsVanillaActive))]
        public int ChainDepth { get; set; }

        /// <summary>
        /// Raw <c>Blocker.m_MaxSpeed</c> byte. The chain walk stops if any vehicle is at or
        /// above this. Vanilla 6 (about 1.2 m/s at ~0.2 m/s per unit).
        /// </summary>
        [SettingsUISection(kSection, kThresholdGroup)]
        [SettingsUISlider(min = MinMaxStuckSpeed, max = MaxMaxStuckSpeed, step = 1, scalarMultiplier = 1)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsVanillaActive))]
        public int MaxStuckSpeed { get; set; }

        /// <summary>
        /// Objects flagged stuck this session. A plain string (not MultilineText, not disabled)
        /// so Options actually shows the getter value; getter-only keeps it out of the .coc.
        /// </summary>
        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        public string ClearedText => ClearanceStats.FormatCleared();

        /// <summary>Those objects per in-game hour, not per real-time hour.</summary>
        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        public string RateText => ClearanceStats.FormatRate();

        // One row per subtype. Hidden while the count is zero so a fresh city is not a wall of zeros.
        // Getter-only, same as the totals, so none of these are written to Mods_JamThreshold.coc.

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideCar))]
        public string CarText => ClearanceStats.FormatCount(ClearedKind.Car);

        public bool HideCar => ClearanceStats.IsZero(ClearedKind.Car);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideDeliveryTruck))]
        public string DeliveryTruckText => ClearanceStats.FormatCount(ClearedKind.DeliveryTruck);

        public bool HideDeliveryTruck => ClearanceStats.IsZero(ClearedKind.DeliveryTruck);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideGarbageTruck))]
        public string GarbageTruckText => ClearanceStats.FormatCount(ClearedKind.GarbageTruck);

        public bool HideGarbageTruck => ClearanceStats.IsZero(ClearedKind.GarbageTruck);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideCargoTruck))]
        public string CargoTruckText => ClearanceStats.FormatCount(ClearedKind.CargoTruck);

        public bool HideCargoTruck => ClearanceStats.IsZero(ClearedKind.CargoTruck);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideRoadMaintenance))]
        public string RoadMaintenanceText => ClearanceStats.FormatCount(ClearedKind.RoadMaintenance);

        public bool HideRoadMaintenance => ClearanceStats.IsZero(ClearedKind.RoadMaintenance);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideParkMaintenance))]
        public string ParkMaintenanceText => ClearanceStats.FormatCount(ClearedKind.ParkMaintenance);

        public bool HideParkMaintenance => ClearanceStats.IsZero(ClearedKind.ParkMaintenance);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideMaintenance))]
        public string MaintenanceText => ClearanceStats.FormatCount(ClearedKind.Maintenance);

        public bool HideMaintenance => ClearanceStats.IsZero(ClearedKind.Maintenance);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideFireEngine))]
        public string FireEngineText => ClearanceStats.FormatCount(ClearedKind.FireEngine);

        public bool HideFireEngine => ClearanceStats.IsZero(ClearedKind.FireEngine);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HidePoliceCar))]
        public string PoliceCarText => ClearanceStats.FormatCount(ClearedKind.PoliceCar);

        public bool HidePoliceCar => ClearanceStats.IsZero(ClearedKind.PoliceCar);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HidePostVan))]
        public string PostVanText => ClearanceStats.FormatCount(ClearedKind.PostVan);

        public bool HidePostVan => ClearanceStats.IsZero(ClearedKind.PostVan);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideAmbulance))]
        public string AmbulanceText => ClearanceStats.FormatCount(ClearedKind.Ambulance);

        public bool HideAmbulance => ClearanceStats.IsZero(ClearedKind.Ambulance);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideHearse))]
        public string HearseText => ClearanceStats.FormatCount(ClearedKind.Hearse);

        public bool HideHearse => ClearanceStats.IsZero(ClearedKind.Hearse);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HidePrisonerTransport))]
        public string PrisonerTransportText => ClearanceStats.FormatCount(ClearedKind.PrisonerTransport);

        public bool HidePrisonerTransport => ClearanceStats.IsZero(ClearedKind.PrisonerTransport);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideEvacuation))]
        public string EvacuationText => ClearanceStats.FormatCount(ClearedKind.Evacuation);

        public bool HideEvacuation => ClearanceStats.IsZero(ClearedKind.Evacuation);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideTaxi))]
        public string TaxiText => ClearanceStats.FormatCount(ClearedKind.Taxi);

        public bool HideTaxi => ClearanceStats.IsZero(ClearedKind.Taxi);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideTransit))]
        public string TransitText => ClearanceStats.FormatCount(ClearedKind.Transit);

        public bool HideTransit => ClearanceStats.IsZero(ClearedKind.Transit);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HidePassengerTrain))]
        public string PassengerTrainText => ClearanceStats.FormatCount(ClearedKind.PassengerTrain);

        public bool HidePassengerTrain => ClearanceStats.IsZero(ClearedKind.PassengerTrain);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideCargoTrain))]
        public string CargoTrainText => ClearanceStats.FormatCount(ClearedKind.CargoTrain);

        public bool HideCargoTrain => ClearanceStats.IsZero(ClearedKind.CargoTrain);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideTrain))]
        public string TrainText => ClearanceStats.FormatCount(ClearedKind.Train);

        public bool HideTrain => ClearanceStats.IsZero(ClearedKind.Train);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideAirplane))]
        public string AirplaneText => ClearanceStats.FormatCount(ClearedKind.Airplane);

        public bool HideAirplane => ClearanceStats.IsZero(ClearedKind.Airplane);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideHelicopter))]
        public string HelicopterText => ClearanceStats.FormatCount(ClearedKind.Helicopter);

        public bool HideHelicopter => ClearanceStats.IsZero(ClearedKind.Helicopter);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideAircraft))]
        public string AircraftText => ClearanceStats.FormatCount(ClearedKind.Aircraft);

        public bool HideAircraft => ClearanceStats.IsZero(ClearedKind.Aircraft);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideWatercraft))]
        public string WatercraftText => ClearanceStats.FormatCount(ClearedKind.Watercraft);

        public bool HideWatercraft => ClearanceStats.IsZero(ClearedKind.Watercraft);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideBicycle))]
        public string BicycleText => ClearanceStats.FormatCount(ClearedKind.Bicycle);

        public bool HideBicycle => ClearanceStats.IsZero(ClearedKind.Bicycle);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HidePedestrian))]
        public string PedestrianText => ClearanceStats.FormatCount(ClearedKind.Pedestrian);

        public bool HidePedestrian => ClearanceStats.IsZero(ClearedKind.Pedestrian);

        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideOther))]
        public string OtherText => ClearanceStats.FormatCount(ClearedKind.Other);

        public bool HideOther => ClearanceStats.IsZero(ClearedKind.Other);

        /// <summary>
        /// Options button. Zeroes the counters and restarts the in-game-hour window.
        /// Does not touch thresholds and does not despawn traffic.
        /// </summary>
        [SettingsUISection(kSection, kStatsGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        public bool ResetStats
        {
            set
            {
                ClearanceStats.RequestReset();
                Mod.Instance?.Logger?.Info("Statistics reset; counting restarts from zero.");
            }
        }

        /// <summary>
        /// Options button. Re-enables vanilla <c>StuckMovingObjectSystem</c> and disables
        /// the replacement. Does not despawn traffic.
        /// </summary>
        [SettingsUISection(kSection, kVanillaGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsVanillaActive))]
        public bool ResetToVanilla
        {
            set
            {
                Enabled = false;
                ApplyAndSave();
                JamThresholdSystem.ApplyOwnership(false);
                Mod.Instance?.Logger?.Info("Reset to vanilla StuckMovingObjectSystem (replacement disabled).");
            }
        }

        public bool IsVanillaActive => !Enabled;

        /// <summary>Bumped by <see cref="ClearanceStats"/> so Options rebinds the statistics lines.</summary>
        public int GetStatsVersion()
        {
            return ClearanceStats.UiVersion;
        }

        public override void SetDefaults()
        {
            Enabled = true;
            ChainDepth = DefaultChainDepth;
            MaxStuckSpeed = DefaultMaxStuckSpeed;
        }

        public void OnEnabledChanged(bool value)
        {
            JamThresholdSystem.ApplyOwnership(value);
            Mod.Instance?.Logger?.Info(value
                ? "Replacement stuck-check ON (vanilla StuckMovingObjectSystem disabled)."
                : "Replacement stuck-check OFF (vanilla StuckMovingObjectSystem re-enabled).");
        }

        // Clamp because Mods_JamThreshold.coc can be edited by hand outside the slider range.
        internal int ClampedChainDepth()
        {
            int value = ChainDepth;
            if (value < MinChainDepth)
            {
                return MinChainDepth;
            }

            if (value > MaxChainDepth)
            {
                return MaxChainDepth;
            }

            return value;
        }

        internal byte ClampedMaxStuckSpeed()
        {
            int value = MaxStuckSpeed;
            if (value < MinMaxStuckSpeed)
            {
                return (byte)MinMaxStuckSpeed;
            }

            if (value > MaxMaxStuckSpeed)
            {
                return (byte)MaxMaxStuckSpeed;
            }

            return (byte)value;
        }
    }
}
