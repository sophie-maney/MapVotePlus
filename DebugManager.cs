namespace MapVotePlus
{
    internal class DebugManager
    {
        public static void InitializeDebug()
        {
            PopulateMockData();
        }

        private static void PopulateMockData()
        {
            MapVotePlus.CurrentVotes[10] = "Level - Arctic";
            MapVotePlus.CurrentVotes[11] = "Level - Manor";
            MapVotePlus.CurrentVotes[12] = "Level - Wizard";
            MapVotePlus.CurrentVotes[13] = "Level - Wizard";
            MapVotePlus.CurrentVotes[14] = "Level - Wizard";
            MapVotePlus.CurrentVotes[15] = MapVotePlus.VOTE_RANDOM_LABEL;
        }
    }
}
