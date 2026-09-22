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
                { m_Setting.GetOptionGroupLocaleID(Setting.kStatsGroup), "Statistiques" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Enabled)), "Activé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Enabled)), "Lorsque c'est activé, le contrôle d'immobilisation d'origine du jeu est coupé et ce remplacement utilise les curseurs ci-dessous. Lorsque c'est désactivé, le comportement vanilla est rétabli. Cela ne réinitialise pas tout le trafic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profondeur de chaîne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Une chaîne de véhicules bloqués est marquée coincée si c'est une boucle ou si elle est plus longue que cette valeur. Vanilla est 100. Par défaut 40 pour que les embouteillages plus courts commencent à disparaître." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Seuil de vitesse" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Octet de vitesse Blocker brut (~0,2 m/s par unité). Le parcours de la chaîne s'arrête si un véhicule est à cette valeur ou au-dessus. Vanilla 6 vaut environ 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Dégagés cette session" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objets que ce remplacement a marqués comme bloqués depuis le chargement de la ville. Rouvrez cette page si les nombres semblent figés." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RateText)), "Cadence" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RateText)), "Objets dégagés par heure de jeu, pas par heure réelle. Le temps en pause ne compte pas. Affiché dès qu'assez de temps de jeu s'est écoulé." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BreakdownText)), "Par type" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BreakdownText)), "Le même total réparti par type d'objet. Les passagers d'un véhicule sont comptés une fois, via le véhicule." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetStats)), "Réinitialiser les statistiques" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetStats)), "Remet tous les compteurs à zéro et redémarre la mesure des heures de jeu. Ne change pas vos seuils et ne supprime aucun véhicule." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetStats)), "Remettre les statistiques à zéro ? Cela efface seulement les compteurs. Vos seuils et le trafic de votre ville ne sont pas touchés." },
                { ClearanceStats.ClearedId, "{TOTAL} objets" },
                { ClearanceStats.RateId, "~{RATE} objets / heure de jeu" },
                { ClearanceStats.RateUnknownId, "—" },
                { ClearanceStats.BreakdownId, "Voitures {CARS}  ·  Camions {TRUCKS}  ·  Trains {TRAINS}  ·  Transports {TRANSIT}  ·  Vélos {BICYCLES}  ·  Piétons {PEDESTRIANS}  ·  Autres {OTHER}" },
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
