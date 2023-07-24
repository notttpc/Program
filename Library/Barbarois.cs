

namespace DungeonLibrary
{
    public class Barbarois : Monster
    {
        public bool LostOwner { get; set; }
        public int LostOnwerChance { get; set; }

        public Barbarois(string name, string description, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, int lostOwnerChance) : base(name, description, maxLife, life, hitChance, block, maxDamage, minDamage)
        {
            //! Add your custom prop(s) to the parameter list and assign them here.
            LostOnwerChance = lostOwnerChance;
            LostOwner = new Random().Next(100) < lostOwnerChance;
        }

        //! Default CTOR (creates a basic version of this monster)
        public Barbarois() : base("Komurasaki", "She is calm, collected, and highly intelligent, never leaves her owner", 34, 34, 40, 20, 7, 1)
        {
            Name = "Komurasaki";
            Description = "She is calm, collected, and highly intelligent, never leaves her owner";
            MaxLife = 34;
            Life = 34;
            HitChance = 40;
            Block = 25;
            MaxDamage = 7;
            MinDamage = 1;
            LostOnwerChance = 35;
        }

        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + $"\nLost Owner Chance: {LostOnwerChance}\n" +
                                     $"With Its Owner: {(LostOwner ? "Yes" : "No")}";
        }

        //Override at least one parent method to change the functionality based on your custom prop
        public override int CalcBlock()
        {
            //return base.CalcBlock();
            if (LostOwner)
            {
                Console.WriteLine("Has lost its owner, watch out for those attacks...");
                LostOwner = new Random().Next(100) < LostOnwerChance;
                return Block - (Block / 2);
            }
            else return Block;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + (LostOwner ? 5 : 0);
        }
        public override int CalcDamage()
        {
            return base.CalcDamage() + (LostOwner ? 5 : 0);
        }

    }
}