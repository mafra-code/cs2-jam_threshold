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
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "启用" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "开启时，游戏原来的卡住检测会关闭，此替代项按下方滑块运行。关闭时恢复原版行为。这不会重置全城交通。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "链条深度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "被堵住的车辆链如果是环，或长度超过此值，就会被标记为卡住。原版为 100。默认 40，让更短的拥堵开始消失。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "原始 Blocker 速度字节（每单位约 0.2 m/s）。若有车辆达到或超过此值，链条遍历会停止。原版 6 约为 1.2 m/s。" },
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
