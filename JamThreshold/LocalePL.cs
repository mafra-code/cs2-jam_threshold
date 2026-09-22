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
                { m_Setting.GetOptionGroupLocaleID(Setting.kRateGroup), "Tempo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Włączone" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Gdy włączone, oryginalne sprawdzanie zatorów jest wyłączone, a ten zamiennik działa z suwakami poniżej. Gdy wyłączone, wraca zachowanie vanilla. To nie resetuje całego ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Głębokość łańcucha" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Łańcuch zablokowanych pojazdów jest oznaczany jako zablokowany, jeśli jest pętlą lub dłuższy niż ta wartość. Vanilla to 100. Domyślnie 40, żeby krótsze korki zaczynały znikać." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Próg prędkości" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Surowy bajt prędkości Blocker (~0,2 m/s na jednostkę). Przechodzenie łańcucha kończy się, gdy jakiś pojazd jest na tej wartości lub powyżej. Vanilla 6 to około 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Usunięte w tej sesji" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Obiekty oznaczone jako zakorkowane przez ten zamiennik od wczytania miasta. Pasażerowie jadący pojazdem liczą się raz, przez pojazd. Otwórz tę stronę ponownie, jeśli liczby wyglądają na nieaktualne." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Wszystkie obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Obiekty usunięte na godzinę w grze, nie na godzinę rzeczywistą. Czas pauzy się nie liczy. Pojawia się, gdy minie dość czasu w grze." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "Samochody" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "Ciężarówki dostawcze" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "Śmieciarki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "Ciężarówki towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "Utrzymanie dróg" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "Utrzymanie parków" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "Pojazdy utrzymania" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "Wozy strażackie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "Radiowozy" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "Furgonetki pocztowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "Karetki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "Karawany" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "Transport więźniów" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "Pojazdy ewakuacyjne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "Taksówki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "Transport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "Pociągi pasażerskie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "Pociągi towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "Pociągi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "Samoloty" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "Śmigłowce" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "Statki powietrzne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "Jednostki pływające" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "Rowery" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "Piesi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "Inne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarRateText)), "Samochody" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckRateText)), "Ciężarówki dostawcze" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckRateText)), "Śmieciarki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckRateText)), "Ciężarówki towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceRateText)), "Utrzymanie dróg" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceRateText)), "Utrzymanie parków" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceRateText)), "Pojazdy utrzymania" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineRateText)), "Wozy strażackie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarRateText)), "Radiowozy" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanRateText)), "Furgonetki pocztowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceRateText)), "Karetki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseRateText)), "Karawany" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportRateText)), "Transport więźniów" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationRateText)), "Pojazdy ewakuacyjne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiRateText)), "Taksówki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitRateText)), "Transport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainRateText)), "Pociągi pasażerskie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainRateText)), "Pociągi towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainRateText)), "Pociągi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneRateText)), "Samoloty" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterRateText)), "Śmigłowce" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftRateText)), "Statki powietrzne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftRateText)), "Jednostki pływające" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleRateText)), "Rowery" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianRateText)), "Piesi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherRateText)), "Inne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Zresetuj statystyki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Zeruje wszystkie liczniki i zaczyna pomiar godzin w grze od nowa. Nie zmienia progów i nie usuwa pojazdów." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Wyzerować statystyki? To czyści tylko liczniki. Twoje progi i ruch w mieście pozostają nietknięte." },
                { ClearanceStats.ClearedId, "{TOTAL} obiektów" },
                { ClearanceStats.RateId, "~{RATE} obiektów / godzinę w grze" },
                { ClearanceStats.KindRateId, "~{RATE} / godzinę w grze" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Szczegółowe logi zatorów w Mods_JamThreshold.log. Spowalnia grę, gdy włączone. Wyłącz dla normalnej prędkości." },
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
