using ExitGames.Client.Photon;
using HarmonyLib;
using REPOLib.Modules;

namespace MapVotePlus.Patches
{
    [HarmonyPatch(typeof(MenuPageLobby))]
    internal class SteamManagerPatch
    {
        [HarmonyPatch(nameof(MenuPageLobby.PlayerAdd))]
        [HarmonyPostfix]
        public static void PostfixJoiningPlayer()
        {
            if (SemiFunc.IsMasterClient())
            {
                MapVotePlus.OnSyncVotes?.RaiseEvent(MapVotePlus.CurrentVotes.Values, NetworkingEvents.RaiseAll, SendOptions.SendReliable);
                MapVotePlus.OnSyncLastMapPlayed?.RaiseEvent(MapVotePlus.LastMapPlayed, NetworkingEvents.RaiseOthers, SendOptions.SendReliable);
            }
            else
            {
                MapVotePlus.OnPlayerConnected?.RaiseEvent("", NetworkingEvents.RaiseAll, SendOptions.SendReliable);
            }
        }
    }
}
