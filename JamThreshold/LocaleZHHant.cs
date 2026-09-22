namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleZHHant : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZHHant(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "替代" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "閾值" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "啟用" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "開啟時，遊戲原本的卡住檢測會關閉，此替代項依下方滑桿運作。關閉時恢復原版行為。這不會重置全城交通。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "鏈條深度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "被堵住的車輛鏈如果是環，或長度超過此值，就會被標記為卡住。原版為 100。預設 40，讓較短的壅塞開始消失。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度閾值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "原始 Blocker 速度位元組（每單位約 0.2 m/s）。若有車輛達到或超過此值，鏈條遍歷會停止。原版 6 約為 1.2 m/s。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "恢復原版" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "關閉此替代項並使用遊戲原本的卡住檢測（鏈條 100，速度 6）。不會清除全城車輛。再次啟用時滑桿會保留。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "使用遊戲原本的卡住檢測？在你再次啟用此模組之前，短壅塞會再次一直停著。這不會移除車輛。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
