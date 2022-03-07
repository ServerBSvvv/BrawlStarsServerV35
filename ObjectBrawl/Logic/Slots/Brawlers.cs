using ObjectBrawl.Logic.Slots.Items;
using System.Collections.Generic;

namespace ObjectBrawl.Logic.Slots
{
    public class Brawlers : List<Brawler>
    {
        public Brawlers() : base()
        {

        }

        public void Reset()
        {
            this.Add(new Brawler(0, 0) {
                IsUnlocked = true
            }); // Shelly
            this.Add(new Brawler(1, 4)); // Colt
            this.Add(new Brawler(2, 8)); // Bull
            this.Add(new Brawler(3, 12)); // Brock
            this.Add(new Brawler(4, 16)); // Rico
            this.Add(new Brawler(5, 20)); // Spike
            this.Add(new Brawler(6, 24)); // Barley
            this.Add(new Brawler(7, 28)); // Jessie
            this.Add(new Brawler(8, 32)); // Nita
            this.Add(new Brawler(9, 36)); // Dynamike
            this.Add(new Brawler(10, 40)); // El Primo
            this.Add(new Brawler(11, 44)); // Mortis
            this.Add(new Brawler(12, 48)); // Crow
            this.Add(new Brawler(13, 52)); // Poco
            this.Add(new Brawler(14, 56)); // Bo
            this.Add(new Brawler(15, 60)); // Piper
            this.Add(new Brawler(16, 64)); // Pam
            this.Add(new Brawler(17, 68)); // Tara
            this.Add(new Brawler(18, 72)); // Darryl
            this.Add(new Brawler(19, 95)); // Pennys
            this.Add(new Brawler(20, 100)); // Frank
            this.Add(new Brawler(21, 105)); // Hook Dudnik Gene
            this.Add(new Brawler(22, 110)); // Tick
            this.Add(new Brawler(23, 115)); // leon
            this.Add(new Brawler(24, 120)); // Rosa
            this.Add(new Brawler(25, 125)); // Carl
            this.Add(new Brawler(26, 130)); // Bibi
            this.Add(new Brawler(27, 177)); // 8-Bit
            this.Add(new Brawler(28, 182)); // Sandy
            this.Add(new Brawler(29, 188)); // Bea
            this.Add(new Brawler(30, 194)); // Emz
            this.Add(new Brawler(31, 200)); // Mr Pidor
            this.Add(new Brawler(32, 206)); // Max
            this.Add(new Brawler(33, 212) {
                Disabled = true
            }); // Homer (disabled)
            this.Add(new Brawler(34, 218)); // Jacky
            this.Add(new Brawler(35, 224)); // Gale
            this.Add(new Brawler(36, 230)); // Nani
            this.Add(new Brawler(37, 236)); // Sprout
            this.Add(new Brawler(38, 279)); // Surge
            this.Add(new Brawler(39, 296)); // Colette
            this.Add(new Brawler(40, 303)); // Amber
            this.Add(new Brawler(41, 320)); // Lou
        }
    }
}
