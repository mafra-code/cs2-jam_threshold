namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Sostituzione" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Soglie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Statistiche" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Attivo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Quando è attivo, il controllo originale di blocco del gioco è disattivato e questa sostituzione usa i cursori sotto. Quando è disattivo, torna il comportamento vanilla. Questo non reimposta tutto il traffico." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profondità della catena" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Una catena di veicoli bloccati viene segnalata come bloccata se è un loop o è più lunga di questo valore. Vanilla è 100. Predefinito 40 così gli ingorghi più corti iniziano a sparire." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Soglia di velocità" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte di velocità Blocker grezzo (~0,2 m/s per unità). Il percorso della catena si ferma se un veicolo è a questo valore o sopra. Vanilla 6 è circa 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Liberati in questa sessione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Oggetti che questa sostituzione ha segnato come bloccati da quando è stata caricata la città. Riapri questa pagina se i numeri sembrano fermi." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Ritmo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Oggetti liberati per ora di gioco, non per ora reale. Il tempo in pausa non conta. Viene mostrato quando è passato abbastanza tempo di gioco." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BreakdownText)), "Per tipo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BreakdownText)), "Lo stesso totale diviso per tipo di oggetto. I passeggeri a bordo di un veicolo sono contati una volta, tramite il veicolo." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Azzera statistiche" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Riporta tutti i contatori a zero e riavvia la misura delle ore di gioco. Non cambia le tue soglie e non rimuove veicoli." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Azzerare le statistiche? Questo cancella solo i contatori. Le tue soglie e il traffico della città restano intatti." },
                { ClearanceStats.ClearedId, "{TOTAL} oggetti" },
                { ClearanceStats.RateId, "~{RATE} oggetti / ora di gioco" },
                { ClearanceStats.RateUnknownId, "—" },
                { ClearanceStats.BreakdownId, "Auto {CARS}  ·  Camion {TRUCKS}  ·  Treni {TRAINS}  ·  Trasporti {TRANSIT}  ·  Biciclette {BICYCLES}  ·  Pedoni {PEDESTRIANS}  ·  Altro {OTHER}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Ripristina vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Disattiva questa sostituzione e usa il controllo originale del gioco (catena 100, velocità 6). Non rimuove il traffico in tutta la città. I cursori restano se riattivi la sostituzione." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Usare il controllo originale di blocco del gioco? Gli ingorghi corti resteranno di nuovo fermi finché non riattivi questa mod. Questo non rimuove veicoli." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
