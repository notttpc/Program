using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS - Funny
        private string _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;
        private int _life;
        private string _description;

        //PROPERTIES - People
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }

        //CONSTRUCTORS - Collect
        public Character(string name, string description, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            Description = description;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }

        public Character(string name, string description, int hitChance, int block, int maxLife/*, int life*/)
        {
            Name = name;
            Description = description;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = maxLife;
        }

        public Character()
        {

        }

        //METHODS - Monkeys
        public override string ToString()
        {
            return $"----- {Name} -----\n" +
                $"Life: {Life} of {MaxLife}\n" +
                $"Hit Chance: {HitChance}%\n" +
                $"Block: {Block}%\n";
        }

        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public abstract int CalcDamage();
    }
}
