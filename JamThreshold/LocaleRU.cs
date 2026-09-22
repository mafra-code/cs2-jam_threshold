namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleRU : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleRU(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Замена" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Пороги" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Включено" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Если включено, оригинальная проверка затора отключается, и эта замена работает с ползунками ниже. Если выключено, возвращается поведение vanilla. Это не сбрасывает весь трафик." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Глубина цепочки" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Цепочка заблокированных машин помечается как застрявшая, если это петля или она длиннее этого значения. Vanilla — 100. По умолчанию 40, чтобы более короткие пробки начинали исчезать." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Порог скорости" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Сырой байт скорости Blocker (~0,2 м/с за единицу). Обход цепочки останавливается, если какая-то машина на этом значении или выше. Vanilla 6 — около 1,2 м/с." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Сбросить к vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Выключает эту замену и использует оригинальную проверку затора (цепочка 100, скорость 6). Не убирает трафик по всему городу. Ползунки сохраняются, если включить замену снова." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Использовать оригинальную проверку затора? Короткие пробки снова останутся, пока вы не включите мод снова. Транспорт не удаляется." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
