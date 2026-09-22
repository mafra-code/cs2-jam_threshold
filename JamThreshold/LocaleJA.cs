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
                { m_Setting.GetOptionGroupLocaleID(Setting.kRateGroup), "ペース" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "有効" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "オンのとき、ゲーム本来の立ち往生判定はオフになり、下のスライダーでこの置換が動きます。オフのとき、バニラの動作に戻ります。交通全体はリセットしません。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "チェーンの深さ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "塞がれた車両の連鎖は、ループであるか、この値より長い場合に立ち往生と判定されます。バニラは 100。既定 40 で、より短い渋滞から消滅し始めます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Blocker の生の速度バイト（1 単位あたり約 0.2 m/s）。いずれかの車両がこの値以上なら連鎖の走査は止まります。バニラの 6 は約 1.2 m/s です。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "このセッションで解消" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "街を読み込んでから、この置換が立ち往生と判定したオブジェクトの数です。車両に乗っている人は、その車両として一度だけ数えます。数値が古く見える場合は、このページを開き直してください。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "すべてのオブジェクト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "ゲーム内1時間あたりの解消オブジェクト数で、実時間あたりではありません。一時停止中は進みません。ゲーム内時間が十分に経つと表示されます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "乗用車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "配送トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "ゴミ収集車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "貨物トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "道路維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "公園維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "維持車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "消防車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "パトカー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "郵便バン" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "救急車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "霊柩車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "囚人輸送" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "避難車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "タクシー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "旅客列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "貨物列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "飛行機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "ヘリコプター" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "航空機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "船舶" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "自転車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "歩行者" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "その他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarRateText)), "乗用車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckRateText)), "配送トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckRateText)), "ゴミ収集車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckRateText)), "貨物トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceRateText)), "道路維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceRateText)), "公園維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceRateText)), "維持車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineRateText)), "消防車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarRateText)), "パトカー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanRateText)), "郵便バン" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceRateText)), "救急車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseRateText)), "霊柩車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportRateText)), "囚人輸送" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationRateText)), "避難車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiRateText)), "タクシー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitRateText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainRateText)), "旅客列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainRateText)), "貨物列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainRateText)), "列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneRateText)), "飛行機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterRateText)), "ヘリコプター" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftRateText)), "航空機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftRateText)), "船舶" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleRateText)), "自転車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianRateText)), "歩行者" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherRateText)), "その他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "統計をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "すべてのカウンターをゼロに戻し、ゲーム内時間の計測をやり直します。しきい値は変わらず、車両も削除されません。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "統計をゼロに戻しますか？ カウンターを消すだけで、しきい値や街の交通はそのままです。" },
                { ClearanceStats.ClearedId, "{TOTAL} 個" },
                { ClearanceStats.RateId, "約 {RATE} 個 / ゲーム内1時間" },
                { ClearanceStats.KindRateId, "約 {RATE} / ゲーム内1時間" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Mods_JamThreshold.logに詳細な立ち往生ログを書き込みます。オンの間はゲームが遅くなります。通常速度にするにはオフにしてください。" },
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
