namespace JamThreshold
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    /// <summary>
    /// Official CS2 <see cref="IMod"/> entry (no Harmony). Disables vanilla
    /// <c>StuckMovingObjectSystem</c> and registers <see cref="JamThresholdSystem"/>
    /// in GameSimulation with configurable chain-depth and speed thresholds.
    /// </summary>
    public class Mod : IMod
    {
        public const string Id = "JamThreshold";

        /// <summary>
        /// Live mod instance. Options and the system reach logger/settings through this;
        /// cleared in <see cref="OnDispose"/> so a leftover reference cannot outlive unload.
        /// </summary>
        public static Mod Instance { get; private set; }

        /// <summary>Writes <c>Mods_JamThreshold.log</c> under the game's Logs folder.</summary>
        internal ILog Logger { get; private set; }

        internal Setting Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            Logger = LogManager.GetLogger("Mods_JamThreshold").SetShowsErrorsInUI(false);
            Logger.Info(nameof(OnLoad));

            Settings = new Setting(this);
            Settings.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Settings));
            GameManager.instance.localizationManager.AddSource("de-DE", new LocaleDE(Settings));
            GameManager.instance.localizationManager.AddSource("es-ES", new LocaleES(Settings));
            GameManager.instance.localizationManager.AddSource("fr-FR", new LocaleFR(Settings));
            GameManager.instance.localizationManager.AddSource("it-IT", new LocaleIT(Settings));
            GameManager.instance.localizationManager.AddSource("ja-JP", new LocaleJA(Settings));
            GameManager.instance.localizationManager.AddSource("ko-KR", new LocaleKO(Settings));
            GameManager.instance.localizationManager.AddSource("pl-PL", new LocalePL(Settings));
            GameManager.instance.localizationManager.AddSource("pt-BR", new LocalePT(Settings));
            GameManager.instance.localizationManager.AddSource("ru-RU", new LocaleRU(Settings));
            GameManager.instance.localizationManager.AddSource("zh-HANS", new LocaleZHHans(Settings));
            GameManager.instance.localizationManager.AddSource("zh-HANT", new LocaleZHHant(Settings));
            AssetDatabase.global.LoadSettings(nameof(JamThreshold), Settings, new Setting(this));

            updateSystem.UpdateAt<JamThresholdSystem>(SystemUpdatePhase.GameSimulation);
            JamThresholdSystem.ApplyOwnership(Settings.Enabled);
            Logger.Info($"{nameof(OnLoad)} complete. Enabled={Settings.Enabled} ChainDepth={Settings.ClampedChainDepth()} MaxStuckSpeed={Settings.ClampedMaxStuckSpeed()}.");
        }

        public void OnDispose()
        {
            Logger?.Info("Disposing.");
            // Restore vanilla so unloading this mod cannot leave stuck-check permanently off.
            JamThresholdSystem.ApplyOwnership(false);
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }

            Instance = null;
        }
    }
}
