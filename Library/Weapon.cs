using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private string _name;
        //private string _description;
        private int _bonusHitChance;
        private int _minDamage;
        private int _maxDamage;
        private bool _isTwoHanded;
        private WeaponType _type;

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        //public string Description
        //{
        //    get { return _description; }
        //    set { _description = value; }
        //}
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Weapon(string name, /*string description*/ int bonusHitChance, int minDamage, int maxDamage, bool isTwoHanded, WeaponType type)
        {
            Name = name;
            //Description = description;
            BonusHitChance = bonusHitChance;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            IsTwoHanded = isTwoHanded;
            Type = type;
        }//end FQCTOR

        public Weapon()
        {
            //Name = "Astra Blade";
            //BonusHitChance = 15;
            //MaxDamage = 7;
            //MinDamage = 3;
            //IsTwoHanded = true;
            //Type = WeaponType.Sword;
        }
        public override string ToString()
        {
            return $"----- {Name} -----\n" +
                //$"Description: {Description}\n" +
                $"Damage: {MinDamage} to {MaxDamage}\n" +
                $"Bonus HitChance: {BonusHitChance}%\n" +
                $"{(IsTwoHanded ? "Two" : "One")}-Handed {Type.ToString().Replace('_', ' ')}\n";
        }
    }
}
