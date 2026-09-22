namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleZHHans : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZHHans(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "替代" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "阈值" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "统计" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "启用" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "开启时，游戏原来的卡住检测会关闭，此替代项按下方滑块运行。关闭时恢复原版行为。这不会重置全城交通。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "链条深度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "被堵住的车辆链如果是环，或长度超过此值，就会被标记为卡住。原版为 100。默认 40，让更短的拥堵开始消失。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "原始 Blocker 速度字节（每单位约 0.2 m/s）。若有车辆达到或超过此值，链条遍历会停止。原版 6 约为 1.2 m/s。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "本次会话已清除" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "自载入城市以来，本替换判定为堵死的对象数量。车内乘客只通过车辆计一次。若数字看起来没有刷新，请重新打开本页。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "每游戏小时清除的对象数，不是现实小时。暂停时不计。游戏时间足够后才会显示。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "汽车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "配送卡车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "垃圾车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "货运卡车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "道路养护" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "公园养护" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "养护车辆" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "消防车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "警车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "邮政车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "救护车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "灵车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "囚犯运输" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "疏散车辆" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "出租车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "客运列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "货运列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "飞机" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "直升机" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "航空器" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "船只" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "自行车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "行人" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "其他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "重置统计" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "把所有计数器归零并重新开始游戏小时计时。不会改动你的阈值，也不会移除车辆。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "要把统计归零吗？这只会清空计数器，你的阈值和城市里的交通都不受影响。" },
                { ClearanceStats.ClearedId, "{TOTAL} 个对象" },
                { ClearanceStats.RateId, "约 {RATE} 个对象 / 游戏小时" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "恢复原版" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "关闭此替代项并使用游戏原来的卡住检测（链条 100，速度 6）。不会清除全城车辆。再次启用时滑块会保留。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "使用游戏原来的卡住检测？在你再次启用此模组之前，短拥堵会再次一直停着。这不会移除车辆。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
