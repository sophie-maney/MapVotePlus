using HarmonyLib;

namespace MapVotePlus.Patches
{
    [HarmonyPatch(typeof(HealthUI))]
    public class HealthUIPatch
    {
        [HarmonyPatch(nameof(HealthUI.Start))]
        [HarmonyPostfix]
        static void PostfixStart(HealthUI __instance)
        {
            if (RunManager.instance.levelCurrent.name == MapVotePlus.REQUEST_VOTE_LEVEL)
            {
                MapVotePlus.Instance.StartCoroutine(MapVotePlus.WaitForVote());
                MapVotePlus.CreateVotePopup(false);
            }
        }
    }
}
