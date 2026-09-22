namespace JamThreshold
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Remplacement" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kThresholdGroup), "Seuils" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Activé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Lorsque c'est activé, le contrôle d'immobilisation d'origine du jeu est coupé et ce remplacement utilise les curseurs ci-dessous. Lorsque c'est désactivé, le comportement vanilla est rétabli. Cela ne réinitialise pas tout le trafic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profondeur de chaîne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Une chaîne de véhicules bloqués est marquée coincée si c'est une boucle ou si elle est plus longue que cette valeur. Vanilla est 100. Par défaut 40 pour que les embouteillages plus courts commencent à disparaître." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Seuil de vitesse" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Octet de vitesse Blocker brut (~0,2 m/s par unité). Le parcours de la chaîne s'arrête si un véhicule est à cette valeur ou au-dessus. Vanilla 6 vaut environ 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Réinitialiser à vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Désactive ce remplacement et utilise le contrôle d'immobilisation d'origine (chaîne 100, vitesse 6). N'enlève pas le trafic dans toute la ville. Vos curseurs sont conservés si vous réactivez le remplacement." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Utiliser le contrôle d'immobilisation d'origine du jeu ? Les petits embouteillages resteront à nouveau jusqu'à ce que vous réactiviez ce mod. Cela n'enlève aucun véhicule." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
