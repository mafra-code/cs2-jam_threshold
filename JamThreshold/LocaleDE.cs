namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German Options strings. Keys match <see cref="LocaleEN"/> so all languages bind to the
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Statistik" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Aktiv" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Wenn an, ist die originale Feststeck-Prüfung des Spiels aus und dieser Ersatz läuft mit den Schiebern darunter. Wenn aus, gilt wieder Vanilla. Das setzt nicht den ganzen Verkehr zurück." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Kettentiefe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Eine Kette blockierter Fahrzeuge gilt als feststeckend, wenn sie eine Schleife ist oder länger als dieser Wert. Vanilla ist 100. Standard 40, damit kürzere Staus despawnen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Geschwindigkeitsschwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Roher Blocker-Geschwindigkeitsbyte (~0,2 m/s pro Einheit). Der Kettenlauf stoppt, wenn ein Fahrzeug darauf oder darüber liegt. Vanilla 6 sind etwa 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "In dieser Sitzung geräumt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objekte, die dieser Ersatz seit dem Laden der Stadt als feststeckend markiert hat. Mitfahrende in einem Fahrzeug werden einmal gezählt, über das Fahrzeug. Seite neu öffnen, falls die Zahlen veraltet aussehen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Geräumte Objekte pro Spielstunde, nicht pro echter Stunde. Pausierte Zeit zählt nicht. Wird angezeigt, sobald genug Spielzeit vergangen ist." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "Autos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "Lieferwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "Müllwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "Fracht-Lkw" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "Straßenwartung" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "Parkwartung" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "Wartungsfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "Feuerwehr" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "Polizeiwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "Postwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "Krankenwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "Leichenwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "Gefangenentransport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "Evakuierungsfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "ÖPNV" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "Personenzüge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "Güterzüge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "Züge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "Flugzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "Hubschrauber" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "Luftfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "Wasserfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "Fahrräder" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "Fußgänger" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "Sonstige" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Statistik zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Setzt alle Zähler auf null und startet die Messung der Spielstunden neu. Ändert deine Schwellen nicht und entfernt keine Fahrzeuge." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Die Statistik auf null zurücksetzen? Das leert nur die Zähler. Deine Schwellen und der Verkehr in deiner Stadt bleiben unberührt." },
                { ClearanceStats.ClearedId, "{TOTAL} Objekte" },
                { ClearanceStats.RateId, "~{RATE} Objekte / Spielstunde" },
                { ClearanceStats.RateUnknownId, "—" },
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
