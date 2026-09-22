namespace JamThreshold
{
    using System;
    using Game.SceneFlow;

    /// <summary>
    /// Exclusive object classes for the Options rows. Values double as slot indices,
    /// so the order here is the order of the counter slots and of the statistics rows.
    /// </summary>
    internal enum ClearedKind
    {
        Car = 0,
        DeliveryTruck = 1,
        GarbageTruck = 2,
        CargoTruck = 3,
        RoadMaintenance = 4,
        ParkMaintenance = 5,
        Maintenance = 6,
        FireEngine = 7,
        PoliceCar = 8,
        PostVan = 9,
        Ambulance = 10,
        Hearse = 11,
        PrisonerTransport = 12,
        Evacuation = 13,
        Taxi = 14,
        Transit = 15,
        PassengerTrain = 16,
        CargoTrain = 17,
        Train = 18,
        Airplane = 19,
        Helicopter = 20,
        Aircraft = 21,
        Watercraft = 22,
        Bicycle = 23,
        Pedestrian = 24,
        Other = 25,
    }

    /// <summary>
    /// Session statistics for the objects <see cref="JamThresholdSystem"/> flagged stuck:
    /// totals per <see cref="ClearedKind"/> plus the rate per in-game hour. Main thread only —
    /// the Burst job reports through a NativeQueue that the system drains.
    /// Deliberately not persisted: counts belong to one city session, never to Mods_JamThreshold.coc.
    /// </summary>
    internal static class ClearanceStats
    {
        internal const int KindCount = (int)ClearedKind.Other + 1;

        // Player-visible value strings. The unit words live in the locale text, not in C#.
        internal const string ClearedId = "JamThreshold.Stats.Cleared";
        internal const string RateId = "JamThreshold.Stats.Rate";
        internal const string RateUnknownId = "JamThreshold.Stats.RateUnknown";

        // Below this the sample is too short for an honest per-hour figure.
        private const double MinHoursForRate = 0.05;

        private static readonly int[] s_Counts = new int[KindCount];

        private static int s_Total;
        private static double s_ElapsedHours;

        // -1 so the first publish always bumps the UI version.
        private static int s_PublishedTotal = -1;
        private static int s_PublishedRate = -1;

        private static bool s_ResetPending;

        /// <summary>Options reads this via SettingsUIValueVersion so the statistics lines rebind.</summary>
        internal static int UiVersion { get; private set; }

        /// <summary>Records one newly flagged object. Out-of-range kinds fall back to Other.</summary>
        internal static void Add(int kind)
        {
            if (kind < 0 || kind >= KindCount)
            {
                kind = (int)ClearedKind.Other;
            }

            s_Counts[kind]++;
            s_Total++;
        }

        /// <summary>
        /// Stores the elapsed in-game hours and bumps the UI version only when the displayed
        /// total or the rounded rate actually changed, so Options does not rebind every tick.
        /// </summary>
        internal static void Publish(double elapsedHours)
        {
            s_ElapsedHours = elapsedHours;
            int rate = CurrentRate();
            if (s_Total == s_PublishedTotal && rate == s_PublishedRate)
            {
                return;
            }

            s_PublishedTotal = s_Total;
            s_PublishedRate = rate;
            UiVersion++;
        }

        /// <summary>
        /// Options button path. Zeroes what the player sees right away and asks the system to
        /// drop in-flight counts and restart the hour clock on its next update.
        /// </summary>
        internal static void RequestReset()
        {
            ResetNow();
            s_ResetPending = true;
        }

        /// <summary>Zeroes counters and the clock. Used on city load and by <see cref="RequestReset"/>.</summary>
        internal static void ResetNow()
        {
            for (int i = 0; i < KindCount; i++)
            {
                s_Counts[i] = 0;
            }

            s_Total = 0;
            s_ElapsedHours = 0.0;
            s_PublishedTotal = -1;
            s_PublishedRate = -1;
            s_ResetPending = false;
            UiVersion++;
        }

        /// <summary>True once per <see cref="RequestReset"/>, for the system to clear its queue.</summary>
        internal static bool ConsumePendingReset()
        {
            if (!s_ResetPending)
            {
                return false;
            }

            s_ResetPending = false;
            return true;
        }

        internal static string FormatCleared()
        {
            return TryLocalize(ClearedId, "{TOTAL} objects")
                .Replace("{TOTAL}", s_Total.ToString());
        }

        internal static string FormatRate()
        {
            int rate = CurrentRate();
            if (rate < 0)
            {
                // No unit while the sample is too short - a bare dash cannot be misread as a count.
                return TryLocalize(RateUnknownId, "—");
            }

            return TryLocalize(RateId, "~{RATE} objects / in-game hour")
                .Replace("{RATE}", rate.ToString());
        }

        /// <summary>The count for one Options row. Digits only; the label lives on the setting.</summary>
        internal static string FormatCount(ClearedKind kind)
        {
            return s_Counts[(int)kind].ToString();
        }

        /// <summary>True while that row should stay off the Options page.</summary>
        internal static bool IsZero(ClearedKind kind)
        {
            return s_Counts[(int)kind] == 0;
        }

        // Objects per in-game hour, or -1 while the elapsed time is too short to divide by.
        private static int CurrentRate()
        {
            if (s_ElapsedHours < MinHoursForRate)
            {
                return -1;
            }

            return (int)Math.Round(s_Total / s_ElapsedHours);
        }

        private static string TryLocalize(string id, string fallback)
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager?.localizationManager?.activeDictionary != null
                && gameManager.localizationManager.activeDictionary.TryGetValue(id, out string value)
                && !string.IsNullOrEmpty(value))
            {
                return value;
            }

            return fallback;
        }
    }
}
