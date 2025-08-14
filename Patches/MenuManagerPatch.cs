using HarmonyLib;

namespace MapVotePlus.Patches
{
    [HarmonyPatch(typeof(MenuManager))]
    internal class MenuManagerPatch
    {
        [HarmonyPatch(nameof(MenuManager.PageOpen))]
        [HarmonyPostfix]
        private static void PageOpenPostfix(MenuPageIndex menuPageIndex)
        {
            if(menuPageIndex == MenuPageIndex.Lobby)
            {
                if(SemiFunc.IsMasterClientOrSingleplayer())
                {
                    MapVotePlus.Reset();
                    MapVotePlus.WonMap = null;
                }

                if(!MapVotePlus.HideInMenu.Value)
                {
                    MapVotePlus.CreateVotePopup(true, true);
                }
                
                if (MapVotePlus.IS_DEBUG && SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.RunIsLobbyMenu())
                {
                    DebugManager.InitializeDebug();
                }
            }
        }
    }
}
