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
                { m_Setting.GetOptionGroupLocaleID(Setting.kRateGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Ativado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Quando ligado, a verificação original de veículos presos do jogo é desligada e esta substituição usa os controles abaixo. Quando desligado, o comportamento vanilla volta. Isso não redefine todo o tráfego." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profundidade da cadeia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Uma cadeia de veículos bloqueados é marcada como presa se for um loop ou for mais longa que este valor. Vanilla é 100. Padrão 40 para que congestionamentos mais curtos comecem a desaparecer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Limite de velocidade" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte bruto de velocidade do Blocker (~0,2 m/s por unidade). A varredura da cadeia para se algum veículo estiver neste valor ou acima. Vanilla 6 é cerca de 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Liberados nesta sessão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objetos que esta substituição marcou como presos desde que a cidade foi carregada. Passageiros dentro de um veículo são contados uma vez, pelo veículo. Reabra esta página se os números parecerem desatualizados." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Todos os objetos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Objetos liberados por hora de jogo, não por hora real. O tempo em pausa não conta. Aparece quando passa tempo de jogo suficiente." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "Carros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "Caminhões de entrega" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "Caminhões de lixo" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "Caminhões de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "Manutenção de vias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "Manutenção de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "Veículos de manutenção" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "Caminhões de bombeiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "Viaturas policiais" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "Furgões dos correios" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "Ambulâncias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "Carros funerários" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "Veículos de evacuação" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "Táxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "Trens de passageiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "Trens de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "Trens" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "Aviões" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "Embarcações" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "Pedestres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "Outros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarRateText)), "Carros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckRateText)), "Caminhões de entrega" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckRateText)), "Caminhões de lixo" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckRateText)), "Caminhões de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceRateText)), "Manutenção de vias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceRateText)), "Manutenção de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceRateText)), "Veículos de manutenção" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineRateText)), "Caminhões de bombeiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarRateText)), "Viaturas policiais" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanRateText)), "Furgões dos correios" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceRateText)), "Ambulâncias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseRateText)), "Carros funerários" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportRateText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationRateText)), "Veículos de evacuação" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiRateText)), "Táxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitRateText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainRateText)), "Trens de passageiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainRateText)), "Trens de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainRateText)), "Trens" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneRateText)), "Aviões" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterRateText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftRateText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftRateText)), "Embarcações" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleRateText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianRateText)), "Pedestres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherRateText)), "Outros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Redefinir estatísticas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Zera todos os contadores e reinicia a medição das horas de jogo. Não altera seus limites e não remove veículos." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Zerar as estatísticas? Isso limpa apenas os contadores. Seus limites e o trânsito da cidade ficam intactos." },
                { ClearanceStats.ClearedId, "{TOTAL} objetos" },
                { ClearanceStats.RateId, "~{RATE} objetos / hora de jogo" },
                { ClearanceStats.KindRateId, "~{RATE} / hora de jogo" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Logs detalhados de congestionamento em Mods_JamThreshold.log. Deixa o jogo mais lento enquanto ligado. Desligue para velocidade normal." },
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
