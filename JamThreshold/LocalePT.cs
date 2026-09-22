namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocalePT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Substituição" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Limites" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Estatísticas" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Ativado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Quando ligado, a verificação original de veículos presos do jogo é desligada e esta substituição usa os controles abaixo. Quando desligado, o comportamento vanilla volta. Isso não redefine todo o tráfego." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profundidade da cadeia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Uma cadeia de veículos bloqueados é marcada como presa se for um loop ou for mais longa que este valor. Vanilla é 100. Padrão 40 para que congestionamentos mais curtos comecem a desaparecer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Limite de velocidade" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte bruto de velocidade do Blocker (~0,2 m/s por unidade). A varredura da cadeia para se algum veículo estiver neste valor ou acima. Vanilla 6 é cerca de 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Liberados nesta sessão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objetos que esta substituição marcou como presos desde que a cidade foi carregada. Reabra esta página se os números parecerem desatualizados." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Ritmo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Objetos liberados por hora de jogo, não por hora real. O tempo em pausa não conta. Aparece quando passa tempo de jogo suficiente." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BreakdownText)), "Por tipo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BreakdownText)), "O mesmo total dividido por tipo de objeto. Passageiros dentro de um veículo são contados uma vez, pelo veículo." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Redefinir estatísticas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Zera todos os contadores e reinicia a medição das horas de jogo. Não altera seus limites e não remove veículos." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Zerar as estatísticas? Isso limpa apenas os contadores. Seus limites e o trânsito da cidade ficam intactos." },
                { ClearanceStats.ClearedId, "{TOTAL} objetos" },
                { ClearanceStats.RateId, "~{RATE} objetos / hora de jogo" },
                { ClearanceStats.RateUnknownId, "—" },
                { ClearanceStats.BreakdownId, "Carros {CARS}  ·  Caminhões {TRUCKS}  ·  Trens {TRAINS}  ·  Transporte {TRANSIT}  ·  Bicicletas {BICYCLES}  ·  Pedestres {PEDESTRIANS}  ·  Outros {OTHER}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Redefinir para vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Desliga esta substituição e usa a verificação original do jogo (cadeia 100, velocidade 6). Não remove o tráfego da cidade inteira. Seus controles são mantidos se você ativar a substituição de novo." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Usar a verificação original de veículos presos do jogo? Congestionamentos curtos vão ficar de novo até você reativar este mod. Isso não remove veículos." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
