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
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Statystyki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Włączone" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Gdy włączone, oryginalne sprawdzanie zatorów jest wyłączone, a ten zamiennik działa z suwakami poniżej. Gdy wyłączone, wraca zachowanie vanilla. To nie resetuje całego ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Głębokość łańcucha" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Łańcuch zablokowanych pojazdów jest oznaczany jako zablokowany, jeśli jest pętlą lub dłuższy niż ta wartość. Vanilla to 100. Domyślnie 40, żeby krótsze korki zaczynały znikać." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Próg prędkości" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Surowy bajt prędkości Blocker (~0,2 m/s na jednostkę). Przechodzenie łańcucha kończy się, gdy jakiś pojazd jest na tej wartości lub powyżej. Vanilla 6 to około 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Usunięte w tej sesji" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Obiekty oznaczone jako zakorkowane przez ten zamiennik od wczytania miasta. Otwórz tę stronę ponownie, jeśli liczby wyglądają na nieaktualne." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Tempo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Obiekty usunięte na godzinę w grze, nie na godzinę rzeczywistą. Czas pauzy się nie liczy. Pojawia się, gdy minie dość czasu w grze." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BreakdownText)), "Według typu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BreakdownText)), "Ta sama suma w podziale na typ obiektu. Pasażerowie jadący pojazdem liczą się raz, przez pojazd." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Zresetuj statystyki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Zeruje wszystkie liczniki i zaczyna pomiar godzin w grze od nowa. Nie zmienia progów i nie usuwa pojazdów." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Wyzerować statystyki? To czyści tylko liczniki. Twoje progi i ruch w mieście pozostają nietknięte." },
                { ClearanceStats.ClearedId, "{TOTAL} obiektów" },
                { ClearanceStats.RateId, "~{RATE} obiektów / godzinę w grze" },
                { ClearanceStats.RateUnknownId, "—" },
                { ClearanceStats.BreakdownId, "Samochody {CARS}  ·  Ciężarówki {TRUCKS}  ·  Pociągi {TRAINS}  ·  Transport {TRANSIT}  ·  Rowery {BICYCLES}  ·  Piesi {PEDESTRIANS}  ·  Inne {OTHER}" },
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
