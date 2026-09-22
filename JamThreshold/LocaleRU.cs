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
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Статистика" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kRateGroup), "Темп" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Включено" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Если включено, оригинальная проверка затора отключается, и эта замена работает с ползунками ниже. Если выключено, возвращается поведение vanilla. Это не сбрасывает весь трафик." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Глубина цепочки" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Цепочка заблокированных машин помечается как застрявшая, если это петля или она длиннее этого значения. Vanilla — 100. По умолчанию 40, чтобы более короткие пробки начинали исчезать." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Порог скорости" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Сырой байт скорости Blocker (~0,2 м/с за единицу). Обход цепочки останавливается, если какая-то машина на этом значении или выше. Vanilla 6 — около 1,2 м/с." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Убрано за сессию" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Объекты, которые эта замена пометила как застрявшие с момента загрузки города. Пассажиры в транспорте считаются один раз — через сам транспорт. Откройте страницу заново, если числа выглядят устаревшими." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Все объекты" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Убранные объекты за игровой час, а не за реальный. Время на паузе не учитывается. Показывается, когда прошло достаточно игрового времени." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarText)), "Автомобили" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckText)), "Грузовики доставки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckText)), "Мусоровозы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckText)), "Грузовые грузовики" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceText)), "Дорожная служба" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceText)), "Обслуживание парков" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceText)), "Служебный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineText)), "Пожарные машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarText)), "Полицейские машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanText)), "Почтовые фургоны" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceText)), "Скорые" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseText)), "Катафалки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportText)), "Перевозка заключённых" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationText)), "Эвакуационный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiText)), "Такси" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitText)), "Транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainText)), "Пассажирские поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainText)), "Грузовые поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainText)), "Поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneText)), "Самолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterText)), "Вертолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftText)), "Воздушные суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftText)), "Суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleText)), "Велосипеды" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianText)), "Пешеходы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherText)), "Прочее" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CarRateText)), "Автомобили" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryTruckRateText)), "Грузовики доставки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckRateText)), "Мусоровозы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTruckRateText)), "Грузовые грузовики" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceRateText)), "Дорожная служба" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceRateText)), "Обслуживание парков" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaintenanceRateText)), "Служебный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineRateText)), "Пожарные машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceCarRateText)), "Полицейские машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanRateText)), "Почтовые фургоны" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceRateText)), "Скорые" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseRateText)), "Катафалки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrisonerTransportRateText)), "Перевозка заключённых" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EvacuationRateText)), "Эвакуационный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiRateText)), "Такси" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TransitRateText)), "Транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PassengerTrainRateText)), "Пассажирские поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoTrainRateText)), "Грузовые поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainRateText)), "Поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplaneRateText)), "Самолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HelicopterRateText)), "Вертолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AircraftRateText)), "Воздушные суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WatercraftRateText)), "Суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BicycleRateText)), "Велосипеды" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PedestrianRateText)), "Пешеходы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OtherRateText)), "Прочее" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Сбросить статистику" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Обнуляет все счётчики и заново запускает отсчёт игровых часов. Не меняет пороги и не удаляет транспорт." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Обнулить статистику? Это очистит только счётчики. Пороги и движение в городе останутся нетронутыми." },
                { ClearanceStats.ClearedId, "{TOTAL} объектов" },
                { ClearanceStats.RateId, "~{RATE} объектов / игровой час" },
                { ClearanceStats.KindRateId, "~{RATE} / игровой час" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Подробные журналы заторов в Mods_JamThreshold.log. Замедляет игру, пока включено. Выключите для обычной скорости." },
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
