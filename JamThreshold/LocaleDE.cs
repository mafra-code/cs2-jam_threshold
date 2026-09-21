namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German Options strings. Keys match <see cref="LocaleEN"/> so both languages bind to the
    /// same <see cref="Setting"/> properties.
    /// </summary>
    public class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Ersatz" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Schwellen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Aktiv" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Wenn an, ist die originale Feststeck-Prüfung des Spiels aus und dieser Ersatz läuft mit den Schiebern darunter. Wenn aus, gilt wieder Vanilla. Das setzt nicht den ganzen Verkehr zurück." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Kettentiefe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Eine Kette blockierter Fahrzeuge gilt als feststeckend, wenn sie eine Schleife ist oder länger als dieser Wert. Vanilla ist 100. Standard 40, damit kürzere Staus despawnen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Geschwindigkeitsschwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Roher Blocker-Geschwindigkeitsbyte (~0,2 m/s pro Einheit). Der Kettenlauf stoppt, wenn ein Fahrzeug darauf oder darüber liegt. Vanilla 6 sind etwa 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Auf Vanilla zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Schaltet diesen Ersatz aus und nutzt die originale Feststeck-Prüfung des Spiels (Kette 100, Tempo 6). Entfernt keinen Verkehr stadtweit. Deine Schieber bleiben, wenn du den Ersatz wieder einschaltest." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Die originale Feststeck-Prüfung des Spiels nutzen? Kurze Staus bleiben dann wieder sitzen, bis du die Mod wieder aktivierst. Es werden keine Fahrzeuge entfernt." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
