namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Remplacement" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Seuils" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Statistiques" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kRateGroup), "Cadence" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Activé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Lorsque c'est activé, le contrôle d'immobilisation d'origine du jeu est coupé et ce remplacement utilise les curseurs ci-dessous. Lorsque c'est désactivé, le comportement vanilla est rétabli. Cela ne réinitialise pas tout le trafic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profondeur de chaîne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Une chaîne de véhicules bloqués est marquée coincée si c'est une boucle ou si elle est plus longue que cette valeur. Vanilla est 100. Par défaut 40 pour que les embouteillages plus courts commencent à disparaître." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Seuil de vitesse" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Octet de vitesse Blocker brut (~0,2 m/s par unité). Le parcours de la chaîne s'arrête si un véhicule est à cette valeur ou au-dessus. Vanilla 6 vaut environ 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Dégagés cette session" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objets que ce remplacement a marqués comme bloqués depuis le chargement de la ville. Les passagers d'un véhicule sont comptés une fois, via le véhicule. Rouvrez cette page si les nombres semblent figés." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Tous les objets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Objets dégagés par heure de jeu, pas par heure réelle. Le temps en pause ne compte pas. Affiché dès qu'assez de temps de jeu s'est écoulé." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "Voitures" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "Camions de livraison" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "Camions-poubelles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "Camions de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "Entretien des routes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "Entretien des parcs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "Véhicules d'entretien" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "Camions de pompiers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "Voitures de police" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "Camionnettes postales" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "Ambulances" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "Corbillards" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "Transport de détenus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "Véhicules d'évacuation" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "Transports" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "Trains de passagers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "Trains de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "Trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "Avions" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "Hélicoptères" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "Aéronefs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "Bateaux" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "Vélos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "Piétons" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "Autres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarRateText)), "Voitures" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckRateText)), "Camions de livraison" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckRateText)), "Camions-poubelles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckRateText)), "Camions de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceRateText)), "Entretien des routes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceRateText)), "Entretien des parcs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceRateText)), "Véhicules d'entretien" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineRateText)), "Camions de pompiers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarRateText)), "Voitures de police" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanRateText)), "Camionnettes postales" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceRateText)), "Ambulances" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseRateText)), "Corbillards" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportRateText)), "Transport de détenus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationRateText)), "Véhicules d'évacuation" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiRateText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitRateText)), "Transports" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainRateText)), "Trains de passagers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainRateText)), "Trains de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainRateText)), "Trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneRateText)), "Avions" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterRateText)), "Hélicoptères" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftRateText)), "Aéronefs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftRateText)), "Bateaux" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleRateText)), "Vélos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianRateText)), "Piétons" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherRateText)), "Autres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Réinitialiser les statistiques" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Remet tous les compteurs à zéro et redémarre la mesure des heures de jeu. Ne change pas vos seuils et ne supprime aucun véhicule." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Remettre les statistiques à zéro ? Cela efface seulement les compteurs. Vos seuils et le trafic de votre ville ne sont pas touchés." },
                { ClearanceStats.ClearedId, "{TOTAL} objets" },
                { ClearanceStats.RateId, "~{RATE} objets / heure de jeu" },
                { ClearanceStats.KindRateId, "~{RATE} / heure de jeu" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Journaux détaillés de blocage dans Mods_JamThreshold.log. Ralentit le jeu tant que c'est activé. Désactivez pour la vitesse normale." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Réinitialiser à vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Désactive ce remplacement et utilise le contrôle d'immobilisation d'origine (chaîne 100, vitesse 6). N'enlève pas le trafic dans toute la ville. Vos curseurs sont conservés si vous réactivez le remplacement." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Utiliser le contrôle d'immobilisation d'origine du jeu ? Les petits embouteillages resteront à nouveau jusqu'à ce que vous réactiviez ce mod. Cela n'enlève aucun véhicule." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
