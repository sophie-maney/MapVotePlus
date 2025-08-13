using System.Collections.Generic;

namespace MapVotePlus
{
    public class VotesDictionary
    {
        public readonly Dictionary<int, string> Values = [];

        public string this[int key]
        {
            get { return Values[key]; }
            set
            {
                Values[key] = value;
                MapVotePlus.UpdateButtonLabels();
            }
        }
    }
}
