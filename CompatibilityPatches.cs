using Sirenix.Serialization.Utilities;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapVotePlus
{
    internal class CompatibilityPatches
    {
        private static readonly Dictionary<string, Action> Patches = [];

        public static void PopulatePatches()
        { 
            Patches.Add("ViViKo.StartInShop", () =>
            {
                MapVotePlus.HideInMenu.Value = true;
            });
        }

        public static void RunPatches(List<string> pluginGUIDs)
        {
            PopulatePatches();

            Patches.Where(x => pluginGUIDs.Contains(x.Key)).ForEach(plugin =>
            {
                plugin.Value();
                MapVotePlus.Logger.LogInfo($"Ran Compatibility Patch for {plugin.Key}");
            });
        }
    }
}
