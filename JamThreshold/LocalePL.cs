namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Zamiennik" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Progi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Włączone" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Gdy włączone, oryginalne sprawdzanie zatorów jest wyłączone, a ten zamiennik działa z suwakami poniżej. Gdy wyłączone, wraca zachowanie vanilla. To nie resetuje całego ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Głębokość łańcucha" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Łańcuch zablokowanych pojazdów jest oznaczany jako zablokowany, jeśli jest pętlą lub dłuższy niż ta wartość. Vanilla to 100. Domyślnie 40, żeby krótsze korki zaczynały znikać." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Próg prędkości" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Surowy bajt prędkości Blocker (~0,2 m/s na jednostkę). Przechodzenie łańcucha kończy się, gdy jakiś pojazd jest na tej wartości lub powyżej. Vanilla 6 to około 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Przywróć vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Wyłącza ten zamiennik i używa oryginalnego sprawdzania zatorów (łańcuch 100, prędkość 6). Nie usuwa ruchu w całym mieście. Suwaki zostają, jeśli włączysz zamiennik ponownie." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Użyć oryginalnego sprawdzania zatorów gry? Krótkie korki znów zostaną, aż ponownie włączysz ten mod. To nie usuwa pojazdów." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
