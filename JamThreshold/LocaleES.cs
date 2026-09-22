namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Reemplazo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Umbrales" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Estadísticas" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kRateGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Activado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Si está activado, la comprobación original de atasco del juego se apaga y este reemplazo usa los deslizadores de abajo. Si está desactivado, vuelve el comportamiento vanilla. Esto no reinicia todo el tráfico." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profundidad de cadena" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Una cadena de vehículos bloqueados se marca como atascada si es un bucle o es más larga que este valor. Vanilla es 100. Predeterminado 40 para que los atascos más cortos empiecen a desaparecer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Umbral de velocidad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte de velocidad de Blocker en crudo (~0,2 m/s por unidad). El recorrido de la cadena se detiene si algún vehículo está en este valor o por encima. Vanilla 6 es unos 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Despejados en esta sesión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objetos que este reemplazo marcó como atascados desde que se cargó la ciudad. Los pasajeros que van en un vehículo se cuentan una vez, a través del vehículo. Vuelve a abrir esta página si los números parecen desactualizados." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Todos los objetos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Objetos despejados por hora del juego, no por hora real. El tiempo en pausa no cuenta. Se muestra cuando ha pasado suficiente tiempo de juego." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "Coches" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "Camiones de reparto" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "Camiones de basura" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "Camiones de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "Mantenimiento de carreteras" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "Mantenimiento de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "Vehículos de mantenimiento" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "Camiones de bomberos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "Coches de policía" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "Furgonetas de correos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "Ambulancias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "Coches fúnebres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "Vehículos de evacuación" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "Trenes de pasajeros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "Trenes de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "Trenes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "Aviones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "Embarcaciones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "Peatones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "Otros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarRateText)), "Coches" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckRateText)), "Camiones de reparto" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckRateText)), "Camiones de basura" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckRateText)), "Camiones de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceRateText)), "Mantenimiento de carreteras" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceRateText)), "Mantenimiento de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceRateText)), "Vehículos de mantenimiento" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineRateText)), "Camiones de bomberos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarRateText)), "Coches de policía" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanRateText)), "Furgonetas de correos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceRateText)), "Ambulancias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseRateText)), "Coches fúnebres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportRateText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationRateText)), "Vehículos de evacuación" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiRateText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitRateText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainRateText)), "Trenes de pasajeros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainRateText)), "Trenes de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainRateText)), "Trenes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneRateText)), "Aviones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterRateText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftRateText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftRateText)), "Embarcaciones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleRateText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianRateText)), "Peatones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherRateText)), "Otros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Restablecer estadísticas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Pone todos los contadores a cero y reinicia la medición de horas del juego. No cambia tus umbrales y no elimina vehículos." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "¿Poner las estadísticas a cero? Esto solo borra los contadores. Tus umbrales y el tráfico de tu ciudad no se tocan." },
                { ClearanceStats.ClearedId, "{TOTAL} objetos" },
                { ClearanceStats.RateId, "~{RATE} objetos / hora del juego" },
                { ClearanceStats.KindRateId, "~{RATE} / hora del juego" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Registros detallados de atasco en Mods_JamThreshold.log. Ralentiza el juego mientras está activo. Apágalo para velocidad normal." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Restablecer a vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Desactiva este reemplazo y usa la comprobación original del juego (cadena 100, velocidad 6). No elimina el tráfico de toda la ciudad. Tus deslizadores se conservan si vuelves a activar el reemplazo." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "¿Usar la comprobación original de atasco del juego? Los atascos cortos volverán a quedarse quietos hasta que reactives esta mod. Esto no elimina vehículos." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
