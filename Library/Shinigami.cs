using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Shinigami : Monster
    {
        public bool IsMad { get; set; }
        public int IsMadChance { get; set; }

        public Shinigami(string name, string description, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, int isMadChance) : base(name, description, maxLife, life, hitChance, block, maxDamage, minDamage)
        {
            IsMadChance = isMadChance;
            IsMad = new Random().Next(100) < isMadChance;
        }

        public Shinigami() : base("Ryuk", "skeletal, lanky figure with pale skin and elongated limbs, dont make it mad", 45, 45, 30, 35, 9, 4)
        {
            Name = "Ryuk";
            Description = "skeletal, lanky figure with pale skin and elongated limbs, dont make it mad";
            MaxLife = 45;
            Life = 45;
            HitChance = 30;
            Block = 35;
            MaxDamage = 9;
            MinDamage = 4;
            IsMadChance = 25;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nLost Owner Chance: {IsMadChance}\n" +
                                     $"With Its Owner: {(IsMad ? "Yes" : "No")}";
        }

        public override int CalcBlock()
        {
            if (IsMad)
            {
                Console.WriteLine("He's lost his temper...again...sorry");
                IsMad = new Random().Next(100) < IsMadChance;
                return Block - (Block / 2);
            }
            else return Block;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + (IsMad ? 10 : 0);
        }
        public override int CalcDamage()
        {
            return base.CalcDamage() + (IsMad ? 6 : 0);
        }

    }
}

