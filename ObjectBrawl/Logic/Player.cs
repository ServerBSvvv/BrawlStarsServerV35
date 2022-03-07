using ObjectBrawl.Helpers;
using ObjectBrawl.Logic.Slots;
using ObjectBrawl.Logic.Slots.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Logic
{
    public class Player
    {

        public async Task LogicClientHome(MemoryStream Stream)
        {
            var UtcNow = DateTime.UtcNow;

            await Stream.WriteVInt(UtcNow.Year * 1000 + UtcNow.DayOfYear);
            await Stream.WriteVInt(UtcNow.Second + UtcNow.Minute * 60 + UtcNow.Hour * 3600);
            await Stream.WriteVInt(Score);
            await Stream.WriteVInt(Score);
            await Stream.WriteVInt(122);
            await Stream.WriteVInt(200);
            await Stream.WriteVInt(500); // exp

            await Stream.WriteScId(28, Thumbnail);
            await Stream.WriteScId(43, NameColor);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0); // Unlocked Skins
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteBool(false);
            await Stream.WriteVInt(1000);
            await Stream.WriteVInt(10);
            await Stream.WriteVInt(20);
            await Stream.WriteVInt(30);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteBool(false);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0); // tokens available
            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteScId(16, SelectedBrawler);
            await Stream.WriteString("RU");
            await Stream.WriteString("ServerBSvvv");

            await Stream.WriteVInt(0); // Array rewards

            await Stream.WriteVInt(0); // Array

            await Stream.WriteVInt(1); // Season Data
            {
                await Stream.WriteVInt(5); // Season
                await Stream.WriteVInt(10);
                await Stream.WriteBool(true);
                await Stream.WriteVInt(5);
                await Stream.WriteBool(false);
            }

            await Stream.WriteVInt(0);

            await Stream.WriteBool(true); // Quests enabled
            await Stream.WriteVInt(0); // Quests Array

            await Stream.WriteBool(true); // Pins Enabled
            await Stream.WriteVInt(0); // Pins Array

            await Stream.WriteVInt(0);

            await Stream.WriteInt(0);

            // Second chunk
            await Stream.WriteVInt(0);

            await Stream.WriteVInt(21);
            for (int i = 0; i < 21; i++)
            {
                await Stream.WriteVInt(i);
            }

            await Stream.WriteVInt(1); // LogicEvents
            {
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(1);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(75992); // Seconds left
                await Stream.WriteVInt(10); // Tokens reward

                await Stream.WriteScId(15, 7); // Map Id

                await Stream.WriteVInt(0);
                await Stream.WriteVInt(3); // State
                await Stream.WriteString(null); // Event description

                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);

                await Stream.WriteVInt(0); // Modifiers

                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);

                await Stream.WriteBool(false);

                await Stream.WriteVInt(0);

                await Stream.WriteBool(false);
            }

            await Stream.WriteVInt(0); // LogicEventsComingUp

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteBool(false);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteInt(HighID);
            await Stream.WriteInt(LowID);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteBool(false);
            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0);
        }

        public async Task LogicClientAvatar(MemoryStream Stream)
        {
            await Stream.WriteVInt(HighID);
            await Stream.WriteVInt(LowID);
            await Stream.WriteVInt(HighID);
            await Stream.WriteVInt(LowID);
            await Stream.WriteVInt(HighID);
            await Stream.WriteVInt(LowID);

            await Stream.WriteString("ServerBSvvv");
            await Stream.WriteBool(true);
            await Stream.WriteInt(0);

            await Stream.WriteVInt(8); // Commodity Arrays

            await Stream.WriteVInt(Brawlers.Count + 1);
            foreach (Brawler b in Brawlers)
            {
                await Stream.WriteScId(23, b.CardId);
                await Stream.WriteBool(b.IsUnlocked);
            }
            await Stream.WriteScId(5, 8);
            await Stream.WriteVInt(Gold);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            //

            await Stream.WriteVInt(Diamonds); // Diamonds
            await Stream.WriteVInt(Diamonds); // Free Diamonds
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(2);
            await Stream.WriteVInt(2);
        }

        public int HighID;
        public int LowID;
        public string UserToken;

        public Brawlers Brawlers;

        public int Diamonds;
        public int Gold;
        public string Name;
        public bool NameSet;

        public int NameColor;
        public int Thumbnail;
        public int SelectedBrawler;
        public int Experience;
        public int TrophyRoadProgress;

        public bool Banned;
        public bool Premium;

        public int AllianceHigh, AllianceLow;

        public int Score {
            get
            {
                int result = 0;
                foreach (Brawler b in Brawlers)
                {
                    result += b.Score;
                }
                return result;
            }
        }

        public Player()
        {

        }

        public Player(int LowID)
        {
            this.LowID = LowID;
            this.Reset();
        }

        public void Reset()
        {
            Gold = 100;
            Diamonds = 500;
            NameSet = false;

            Brawlers = new Brawlers();
            Brawlers.Reset();
        }
    }
}
