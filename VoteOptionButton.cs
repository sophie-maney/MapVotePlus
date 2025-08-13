using MenuLib.MonoBehaviors;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MapVotePlus
{
    internal sealed class VoteOptionButton(string _level, REPOButton _button, bool _isRandomButton = false)
    {
        public string Level { get; set; } = _level;
        public REPOButton Button { get; set; } = _button;
        public bool IsRandomButton { get; set; } = _isRandomButton;

        public int GetVotes(Dictionary<int, string> votes)
        {
            var votesNum = 0;

            foreach (var entry in votes)
            {
                if (entry.Value == Level)
                {
                    votesNum++;
                }
            }

            return votesNum;
        }

        public void UpdateLabel(bool _highlight = false, bool _disabled = false)
        {
            var votes = MapVotePlus.CurrentVotes.Values;
            var ownVote = MapVotePlus.OwnVoteLevel == Level;

            var playerCount = Math.Max(Math.Min(GameDirector.instance.PlayerList.Count, 12), 4);
            var votesCount = GetVotes(votes);
            Color mainColor = _disabled ? Color.gray : Color.white;
            string levelColor = _highlight ? $"#{Color.green.ToHexString()}" : (ownVote ? $"#{Color.yellow.ToHexString()}" : LevelColorDictionary.GetColor(Level));

            StringBuilder sb = new();

            if (_disabled) sb.Append("<s>");

            sb.Append($"<mspace=0.25em>[{Utilities.ColorString((ownVote ? "X" : " "), mainColor)}]</mspace>  ");
            if (!_disabled) sb.Append($"<color={levelColor}>");
            sb.Append($"{(IsRandomButton ? MapVotePlus.VOTE_RANDOM_LABEL : Utilities.RemoveLevelPrefix(Level))}");
            if (!_disabled)
            {
                sb.Append("</color>");
            }

            if (_disabled) sb.Append("</s>");

            var votesLabel = Button.transform.GetChild(1);
            votesLabel.GetComponent<TextMeshProUGUI>().text = $"{Utilities.ColorString(new string('I', votesCount), Color.green)}{Utilities.ColorString(new string('I', playerCount - votesCount), Color.gray)}";

            Button.labelTMP.text =
                $"{sb}";
        }
    }
}
