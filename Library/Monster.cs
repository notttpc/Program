using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;


        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > 0 && value <= MaxDamage ? value : 1; }
        }
        public string Description { get; set; }

        public Monster(string name, string description, int maxLife, int life, int hitChance, int block, int maxDamage, int minDamage) : base(name, description, hitChance, block, maxLife)
        {
            Name = name;
            Description = description;
            MaxLife = maxLife;
            Life = maxLife;
            HitChance = hitChance;
            Block = block;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
        public override string ToString()
        {
            return $"***** {Name} *****\n" +
                $"Description: {Description}\n" +
                $"Health: {Life} of {MaxLife}\n" +
                $"HitChance: {HitChance}\n" +
                $"Block: {Block}\n" +
                $"Damage: {MinDamage} - {MaxDamage}";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }
        public static Monster GetMonster()
        {
            Titan titan = new Titan("Eren Yeager", "When he transforms into a Titan, he gains incredible strength", 40, 40, 30, 25, 8, 2, 20);
            Barbarois barb = new Barbarois("Komurasaki", "She is calm, collected, and highly intelligent, never leaves her owner", 34, 34, 40, 20, 7, 1, 35);
            Shinigami shin = new Shinigami("Ryuk", "skeletal, lanky figure with pale skin and elongated limbs, dont make it mad", 45, 45, 30, 35, 9, 4, 25);
            List<Monster> monsters = new()
            {
                titan
            };
            int index = new Random().Next(monsters.Count);
            return monsters[index];

            
        }
    }
}
