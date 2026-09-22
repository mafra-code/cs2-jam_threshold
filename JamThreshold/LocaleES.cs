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
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Activado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Si está activado, la comprobación original de atasco del juego se apaga y este reemplazo usa los deslizadores de abajo. Si está desactivado, vuelve el comportamiento vanilla. Esto no reinicia todo el tráfico." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profundidad de cadena" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Una cadena de vehículos bloqueados se marca como atascada si es un bucle o es más larga que este valor. Vanilla es 100. Predeterminado 40 para que los atascos más cortos empiecen a desaparecer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Umbral de velocidad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte de velocidad de Blocker en crudo (~0,2 m/s por unidad). El recorrido de la cadena se detiene si algún vehículo está en este valor o por encima. Vanilla 6 es unos 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Despejados en esta sesión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objetos que este reemplazo marcó como atascados desde que se cargó la ciudad. Vuelve a abrir esta página si los números parecen desactualizados." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Ritmo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Objetos despejados por hora del juego, no por hora real. El tiempo en pausa no cuenta. Se muestra cuando ha pasado suficiente tiempo de juego." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BreakdownText)), "Por tipo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BreakdownText)), "El mismo total repartido por tipo de objeto. Los pasajeros que van en un vehículo se cuentan una vez, a través del vehículo." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Restablecer estadísticas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Pone todos los contadores a cero y reinicia la medición de horas del juego. No cambia tus umbrales y no elimina vehículos." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "¿Poner las estadísticas a cero? Esto solo borra los contadores. Tus umbrales y el tráfico de tu ciudad no se tocan." },
                { ClearanceStats.ClearedId, "{TOTAL} objetos" },
                { ClearanceStats.RateId, "~{RATE} objetos / hora del juego" },
                { ClearanceStats.RateUnknownId, "—" },
                { ClearanceStats.BreakdownId, "Coches {CARS}  ·  Camiones {TRUCKS}  ·  Trenes {TRAINS}  ·  Transporte {TRANSIT}  ·  Bicicletas {BICYCLES}  ·  Peatones {PEDESTRIANS}  ·  Otros {OTHER}" },
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
