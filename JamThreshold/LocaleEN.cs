namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// English Options strings. Keys are built from <see cref="Setting"/> locale IDs so labels
    /// stay bound if a property is renamed.
    /// </summary>
    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Replacement" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Thresholds" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Enabled" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "When on, the game's original stuck-mover check is turned off and this replacement runs with the sliders below. When off, vanilla behavior is restored. This does not reset all traffic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Chain depth" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "A chain of blocked vehicles is flagged stuck if it is a loop or longer than this. Vanilla is 100. Default 40 so shorter jams start despawning." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Speed threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Raw Blocker speed byte (~0.2 m/s per unit). The chain walk stops if any vehicle is at or above this. Vanilla 6 is about 1.2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Reset to vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Turn this replacement off and use the game's original stuck check (chain 100, speed 6). Does not despawn traffic city-wide. Your sliders are kept if you enable the replacement again." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Use the game's original stuck check? Short jams will sit again until you re-enable this mod. This does not remove vehicles." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
