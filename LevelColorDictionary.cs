using System.Collections.Generic;

namespace MapVotePlus
{
    internal static class LevelColorDictionary
    {
        private static readonly Dictionary<string, string> _dictionary = new()
        {
            { MapVotePlus.VOTE_RANDOM_LABEL, "#ff0000" },
            { "Level - Manor", "#ff7330" },
            { "Level - Arctic", "#01ffe6" },
            { "Level - Wizard", "#a55bf1" },
            { "Level - Museum", "#ff7373" },
            { "Level - Hospital", "#95ff92" },
            { "Level - Stronghold", "#a89400" },
            { "Level - Garden", "#5f8e00"},
            { "Level - Bunker", "#bd955d"},
        };

        public static string GetColor(string key) => _dictionary.TryGetValue(key, out var value) ? value : "#ffffff";
    }
}
