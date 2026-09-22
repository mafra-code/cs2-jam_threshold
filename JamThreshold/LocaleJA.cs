namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "置換" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "しきい値" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "統計" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "有効" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "オンのとき、ゲーム本来の立ち往生判定はオフになり、下のスライダーでこの置換が動きます。オフのとき、バニラの動作に戻ります。交通全体はリセットしません。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "チェーンの深さ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "塞がれた車両の連鎖は、ループであるか、この値より長い場合に立ち往生と判定されます。バニラは 100。既定 40 で、より短い渋滞から消滅し始めます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Blocker の生の速度バイト（1 単位あたり約 0.2 m/s）。いずれかの車両がこの値以上なら連鎖の走査は止まります。バニラの 6 は約 1.2 m/s です。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "このセッションで解消" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "街を読み込んでから、この置換が立ち往生と判定したオブジェクトの数です。数値が古く見える場合は、このページを開き直してください。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "ペース" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "ゲーム内1時間あたりの解消オブジェクト数で、実時間あたりではありません。一時停止中は進みません。ゲーム内時間が十分に経つと表示されます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BreakdownText)), "種類別" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BreakdownText)), "同じ合計を種類別に分けたものです。車両に乗っている人は、その車両として一度だけ数えます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "統計をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "すべてのカウンターをゼロに戻し、ゲーム内時間の計測をやり直します。しきい値は変わらず、車両も削除されません。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "統計をゼロに戻しますか？ カウンターを消すだけで、しきい値や街の交通はそのままです。" },
                { ClearanceStats.ClearedId, "{TOTAL} 個" },
                { ClearanceStats.RateId, "約 {RATE} 個 / ゲーム内1時間" },
                { ClearanceStats.RateUnknownId, "—" },
                { ClearanceStats.BreakdownId, "乗用車 {CARS}  ·  トラック {TRUCKS}  ·  列車 {TRAINS}  ·  公共交通 {TRANSIT}  ·  自転車 {BICYCLES}  ·  歩行者 {PEDESTRIANS}  ·  その他 {OTHER}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "バニラに戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "この置換をオフにし、ゲーム本来の立ち往生判定（チェーン 100、速度 6）を使います。街全体の交通は消しません。再び有効にするとスライダーはそのままです。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "ゲーム本来の立ち往生判定を使いますか？ この Mod を再び有効にするまで、短い渋滞はまた残り続けます。車両は削除されません。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
