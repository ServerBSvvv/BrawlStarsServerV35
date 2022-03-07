using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectBrawl.Logic.Slots.Items
{
    public class Brawler
    {
        [JsonProperty] public int CardId { get; set; }
        [JsonProperty] public int CharId { get; set; }

        [JsonProperty] public bool IsUnlocked { get; set; }
        [JsonProperty] public int Score { get; set; }
        [JsonProperty] public int HighScore { get; set; }
        [JsonProperty] public int PowerLevel { get; set; }
        [JsonProperty] public int PowerPoints { get; set; }
        [JsonProperty] public bool Disabled { get; set; }

        public Brawler(int CharId, int CardId)
        {
            this.CharId = CharId;
            this.CardId = CardId;
        }

        public void Reset()
        {
            if (CharId == 0)
            {
                IsUnlocked = true;
            }
            else
            {
                IsUnlocked = false;
            }
            
            Score = 0;
            HighScore = 0;
            PowerLevel = 0;
            PowerPoints = 0;
        }
    }
}
