using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }
        public Player(string name, Race playerRace, string description, int hitChance, int block, int maxLife, int life )
        {
            Name = name;
            PlayerRace = playerRace;
            Description = description;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
           // EquippedWeapon = equippedWeapon;
            switch (PlayerRace)
            {
                case Race.Draconite:
                    HitChance += 5;
                    break;
                case Race.Saiyan:
                    Block += 4;
                    break;
                case Race.Demon:
                    Life += 5;
                    MaxLife += 5;
                    break;
                case Race.Ghoul:
                    MaxLife -= 5;
                    Life -= 5;
                    Block += 6;
                    break;
                case Race.Celestial_Being:
                    MaxLife += 5;
                    Life += 5;
                    HitChance += 2;
                    break;
                default:
                    break;
            }
        }
        public static Player ChoosePlayer()
        {
            Player p1 = new Player("Ken Kaneki", Race.Ghoul, "\nA human turned ghoul with hidden abilities", 50, 10, 40, 40);
            Player p2 = new Player("Nezuko Kamado", Race.Demon, "\nHalf human, Half Demon", 45, 20, 40, 40);
            Player p3 = new Player("Goku", Race.Saiyan, "\nA human form with immense power", 55, 10, 40, 40);
            Player p4 = new Player("Zephyr", Race.Draconite, "\nA human tainted with dragon blood", 40, 30, 40, 40);
            Player p5 = new Player("Shibai Otsutsuki", Race.Celestial_Being, "\nPlanet eater", 35, 50, 40, 40);

            List<Player> selections = new List<Player>() { p1, p2, p3, p4, p5 };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30,1);
            #region art
            Console.WriteLine("\n\n\n\n\n\n\n\n\t\t\t\t\t\t              _______\r\n\t\t\t\t\t\t         ..-'`       ````---.\r\n\t\t\t\t\t\t       .'          ___ .'````.'SS'.\r\n\t\t\t\t\t\t      /        ..-SS####'.  /SSHH##'.\r\n\t\t\t\t\t\t     |       .'SSSHHHH##|/#/#HH#H####'.\r\n\t\t\t\t\t\t    /      .'SSHHHHH####/||#/: \\SHH#####\\\r\n\t\t\t\t\t\t   /      /SSHHHHH#####/!||;`___|SSHH###\\\r\n\t\t\t\t\t\t-..__    /SSSHHH######.         \\SSSHH###\\\r\n\t\t\t\t\t\t`.'-.''--._SHHH#####.'           '.SH####/\r\n\t\t\t\t\t\t  '. ``'-  '/SH####`/_             `|H##/\r\n\t\t\t\t\t\t  | '.     /SSHH###|`'==.       .=='/\\H|\r\n\t\t\t\t\t\t  |   `'-.|SHHHH##/\\__\\/        /\\//|~|/\r\n\t\t\t\t\t\t  |    |S#|/HHH##/             |``  |\r\n\t\t\t\t\t\t  |    \\H' |H#.'`              \\    |\r\n\t\t\t\t\t\t  |        ''`|               -     /\r\n\t\t\t\t\t\t  |          /H\\          .----    /\r\n\t\t\t\t\t\t  |         |H#/'.           `    /\r\n\t\t\t\t\t\t  |          \\| | '..            /\r\n\t\t\t\t\t\t  |    ^~DLF   /|    ''..______.'\r\n\t\t\t\t\t\t   \\          //\\__    _..-. | \r\n\t\t\t\t\t\t    \\         ||   ````     \\ |_\r\n\t\t\t\t\t\t     \\    _.-|               \\| |_\r\n\t\t\t\t\t\t     _\\_.-'   `'''''-.        |   `--.\r\n\t\t\t\t\t\t ''``    \\            `''-;    \\ /\r\n\t\t\t\t\t\t          \\      .-'|     ````.' -\r\n\t\t\t\t\t\t          |    .'  `--'''''-.. |/\r\n\t\t\t\t\t\t          |  .'               \\|\r\n\t\t\t\t\t\t          |.'");
            #endregion
            Console.SetCursorPosition(49, 3);
            Console.WriteLine("Select a character");
            Console.SetCursorPosition(44, 4);
            Console.WriteLine("Press 1, 2, 3, 4, 0r 5 [ENTER]");
            Console.ResetColor();
            for (int i = 1; i <= selections.Count; i++)
            {
                //Console.SetCursorPosition(49, 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i}) {selections[i - 1]}");
                Console.ResetColor();
            }
            int.TryParse(Console.ReadLine(), out int choice);
            try
            {
                Player player = selections[choice - 1];
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(45, 3);
                Console.WriteLine("Is this the chracter you want? Y/N\n");
                Console.SetCursorPosition(50, 5);
                Console.WriteLine(player);
                Console.ResetColor();
                string option = Console.ReadKey().Key.ToString();
                Console.Clear();
                switch (option)
                {
                    case "Y":
                        break;
                    default:
                        return ChoosePlayer();

                }
                return player;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice\n");
                #region art
                Console.WriteLine("              ...                            \u0003\r\n             ;::::;                           \u0003\r\n           ;::::; :;                          \u0003\r\n         ;:::::'   :;                         \u0003\r\n        ;:::::;     ;.                        \u0003\r\n       ,:::::'       ;           OOO\\         \u0003\r\n       ::::::;       ;          OOOOO\\        \u0003\r\n       ;:::::;       ;         OOOOOOOO       \u0003\r\n      ,;::::::;     ;'         / OOOOOOO      \u0003\r\n    ;:::::::::`. ,,,;.        /  / DOOOOOO    \u0003\r\n  .';:::::::::::::::::;,     /  /     DOOOO   \u0003\r\n ,::::::;::::::;;;;::::;,   /  /        DOOO  \u0003\r\n;`::::::`'::::::;;;::::: ,#/  /          DOOO \u0003\r\n:`:::::::`;::::::;;::: ;::#  /            DOOO\u0003\r\n::`:::::::`;:::::::: ;::::# /              DOO\u0003\r\n`:`:::::::`;:::::: ;::::::#/               DOO\u0003\r\n :::`:::::::`;; ;:::::::::##                OO\u0003\r\n ::::`:::::::`;::::::::;:::#                OO\u0003\r\n `:::::`::::::::::::;'`:;::#                O \u0003\r\n  `:::::`::::::::;' /  / `:#                  \u0003\r\n   ::::::`:::::;'  /  /   `#              ");
                #endregion
                Console.WriteLine("\nPress any button to try again");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                return ChoosePlayer();
            }
          
        }
        public static Weapon ChooseWeapon()
        {
            Weapon w1 = new Weapon("Yoriichi' nichirin", 10, 1, 5, true, WeaponType.Sword);
            Weapon w2 = new Weapon("Giant Club", 5, 3, 8, false, WeaponType.Club);
            Weapon w3 = new Weapon("Rinkaku Kagune", 9, 2, 7, false, WeaponType.Kagune);
            Weapon w4 = new Weapon("Demon King's Daggers", 5, 5, 9, true, WeaponType.Dagger);
            Weapon w5 = new Weapon("Silene Glaive", 6, 4, 9, true, WeaponType.Polearm);

            List<Weapon> selections = new List<Weapon>() { w1, w2, w3, w4, w5 };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(25, 2);
            Console.WriteLine(".______________________________________________________|_._._._._._._._._._.\r\n\t\t\t  \\_____________________________________________________|_#_#_#_#_#_#_#_#_#_|\r\n                                                       \t\t\t\tl");
            Console.SetCursorPosition(49, 6);
            Console.WriteLine("Select a Weapon");
            Console.SetCursorPosition(43, 7);
            Console.WriteLine("Press 1, 2, 3, 4 or 5 [ENTER}");
            Console.ResetColor();
            for (int i = 1; i <= selections.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i}) {selections[i - 1]}");
                Console.ResetColor();
            }
            int.TryParse(Console.ReadLine(), out int choice);
            try
            {
                Weapon weapon = selections[choice - 1];
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(45, 3);
                Console.WriteLine("Is this the Weapon you want? Y/N");
                Console.SetCursorPosition(50, 5);
                Console.WriteLine(weapon);
                Console.ResetColor();
                string option = Console.ReadKey().Key.ToString();
                Console.Clear();
                switch (option)
                {
                    case "Y":
                        break;
                    default:
                        return ChooseWeapon();

                }
                return weapon;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice\n");
                #region art
                Console.WriteLine("                                         .\"\"--..__\r\n                     _                     []       ``-.._\r\n                  .'` `'.                  ||__           `-._\r\n                 /    ,-.\\                 ||_ ```---..__     `-.\r\n                /    /:::\\\\               /|//}          ``--._  `.\r\n                |    |:::||              |////}                `-. \\\r\n                |    |:::||             //'///                    `.\\\r\n                |    |:::||            //  ||'                      `|\r\n                /    |:::|/        _,-//\\  ||\r\n               /`    |:::|`-,__,-'`  |/  \\ ||\r\n             /`  |   |'' ||           \\   |||\r\n           /`    \\   |   ||            |  /||\r\n         |`       |  |   |)            \\ | ||\r\n        |          \\ |   /      ,.__    \\| ||\r\n        /           `         /`    `\\   | ||\r\n       |                     /        \\  / ||\r\n       |                     |        | /  ||\r\n       /         /           |        `(   ||\r\n      /          .           /          )  ||\r\n     |            \\          |     ________||\r\n    /             |          /     `-------.|\r\n   |\\            /          |              ||\r\n   \\/`-._       |           /              ||\r\n    //   `.    /`           |              ||\r\n   //`.    `. |             \\              ||\r\n  ///\\ `-._  )/             |              ||\r\n //// )   .(/               |              ||\r\n ||||   ,'` )               /              //\r\n ||||  /                    /             || \r\n `\\\\` /`                    |             // \r\n     |`                     \\            ||  \r\n    /                        |           //  \r\n  /`                          \\         //   \r\n/`                            |        ||    \r\n`-.___,-.      .-.        ___,'        (/    \r\n         `---'`   `'----'`");
                #endregion
                Console.WriteLine("\nPress any button to try again");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                return ChooseWeapon();
            }
        }
        //public static string GetRaceDesc(Race race)
        //{
        //    string desc = "";
        //    switch (race)
        //    {
        //        case Race.Draconite:
        //            Console.WriteLine("Zephr - gets +5 extra hit chance");
        //            break;
        //        case Race.Saiyan:
        //            desc = "Goku - gets +4 extra hit chance";
        //            break;
        //        case Race.Demon:
        //            break;
        //        case Race.Ghoul:
        //            break;
        //        case Race.Celestial_Being:
        //            break;
        //        default:
        //            break;
        //    }
        //    return desc;
        //}
        public override string ToString()
        {
            return
                $"----- {Name} -----\n" +
                $"Race: {PlayerRace}\n" +
                $"Description: {Description}\n" +
                $"Health: {Life} of {MaxLife}\n" +
                $"Hit Chance: {HitChance}%\n" +
                $"Block: {Block}%\n";
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance();
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }
    }
}
