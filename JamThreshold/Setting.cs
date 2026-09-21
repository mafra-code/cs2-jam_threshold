namespace JamThreshold
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;

    /// <summary>
    /// Options page: enable the replacement stuck-check, set chain depth and raw
    /// speed threshold, or hand ownership back to vanilla <c>StuckMovingObjectSystem</c>.
    /// This is not a city-wide traffic reset.
    /// </summary>
    // Saved as Mods_JamThreshold.coc under the game's userdata root (same [FileLocation] pattern as Reset Traffic).
    [FileLocation("Mods_JamThreshold")]
    [SettingsUIGroupOrder(kToggleGroup, kThresholdGroup, kVanillaGroup)]
    [SettingsUIShowGroupName(kToggleGroup, kThresholdGroup, kVanillaGroup)]
    public class Setting : ModSetting
    {
        public const string kSection = "Main";
        public const string kToggleGroup = "Toggle";
        public const string kThresholdGroup = "Thresholds";
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
