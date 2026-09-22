namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "대체" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "임계값" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "사용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "켜면 게임의 원래 정체 검사가 꺼지고 아래 슬라이더로 이 대체가 실행됩니다. 끄면 바닐라 동작으로 돌아갑니다. 도시 전체 교통은 초기화하지 않습니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "체인 깊이" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "막힌 차량 체인은 루프이거나 이 값보다 길면 정체로 표시됩니다. 바닐라는 100입니다. 기본값 40으로 더 짧은 정체부터 사라지기 시작합니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "속도 임계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "원시 Blocker 속도 바이트(단위당 약 0.2 m/s). 어느 차량이 이 값 이상이면 체인 탐색이 멈춥니다. 바닐라 6은 약 1.2 m/s입니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "바닐라로 되돌리기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "이 대체를 끄고 게임의 원래 정체 검사(체인 100, 속도 6)를 사용합니다. 도시 전체 교통은 제거하지 않습니다. 다시 켜면 슬라이더는 유지됩니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "게임의 원래 정체 검사를 사용할까요? 이 모드를 다시 켤 때까지 짧은 정체는 다시 그대로 남습니다. 차량은 제거되지 않습니다." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
