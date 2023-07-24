

namespace DungeonLibrary
{
    public class Titan : Monster
    {
        public bool DidGrow { get; set; }
        public int GrowthChance { get; set; }

        public Titan(string name, string description, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage, int growthChance) : base(name, description, maxLife, life, hitChance, block, maxDamage, minDamage)
        {
            GrowthChance = growthChance;
            DidGrow = new Random().Next(100) < growthChance;
        }

        public Titan() : base("Eren Yeager", "When he transforms into a Titan, he gains incredible strength", 40, 40, 30, 25, 8, 2)
        {
            Name = "Eren Yeager";
            Description = "When he transforms into a Titan, he gains incredible strength";
            MaxLife = 40;
            Life = 40;
            HitChance = 30;
            Block = 25;
            MaxDamage = 8;
            MinDamage = 2;
            GrowthChance = 20;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nGrowthChance: {GrowthChance}\n" +
                                     $"Transformed: {(DidGrow ? "Yes" : "No")}";
        }

        public override int CalcBlock()
        {
            if (DidGrow)
            {
                Console.WriteLine("Activated his ingrown ability - Growth");
                DidGrow = new Random().Next(100) < GrowthChance;
                return Block - (Block / 2);
            }
            else return Block;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + (DidGrow ? 10 : 0);
        }
        public override int CalcDamage()
        {
            return base.CalcDamage() + (DidGrow ? 5 : 0);
        }

    }
}