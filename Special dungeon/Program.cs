using System.Numerics;
using System.Threading;
using DungeonLibrary;
using Library;

namespace Special_dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ("Anime World");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("Welcome to Anime Adventures");
            Console.ResetColor();

            Player player = Player.ChoosePlayer();

            Weapon weapon = Player.ChooseWeapon();
            player.EquippedWeapon = weapon;
            bool exit = false;
            do
            {
                //TODO create monster
                Monster monster = Monster.GetMonster();
                //TODO Generate Room
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(GetRoom() + $" \n\nYour opponent is {monster.Name}!\n");
                Console.ResetColor();
                bool relaod = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSelect an action\n" +
                                      $"A) Attack\n" +
                                      $"R) Run Away\n" +
                                      $"P) Player Info\n" +
                                      $"M) Monster Info\n" +
                                      $"W) Weapon Info\n" +
                                      $"E) Exit");
                    Console.ResetColor();
                    ConsoleKey choice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Battle is UnderWay!\n");
                            relaod = Combat.DoBattle(player, monster);
                            Console.ResetColor();
                            break;
                        case ConsoleKey.R:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You begin to turn around\n");
                            Console.ResetColor();
                            Console.WriteLine($"{monster.Name} attacks you as you turn.");
                            Combat.DoAttack(monster, player);
                            Console.ResetColor();
                            relaod = true;
                            break;
                        case ConsoleKey.P:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Character info: \n");
                            Console.WriteLine(player);
                            Console.ResetColor();
                            break;
                        case ConsoleKey.M:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Monster Info: \n");
                            Console.WriteLine(monster);
                            Console.ResetColor();
                            break;
                        case ConsoleKey.W:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Weapon Info: \n");
                            Console.WriteLine(weapon);
                            Console.ResetColor();
                            break;
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You dont like anime?");
                            #region
                            Console.WriteLine("                                    /@\r\n                     __        __   /\\/\r\n                    /==\\      /  \\_/\\/   \r\n                  /======\\    \\/\\__ \\__\r\n                /==/\\  /\\==\\    /\\_|__ \\\r\n             /==/    ||    \\=\\ / / / /_/\r\n           /=/    /\\ || /\\   \\=\\/ /     \r\n        /===/   /   \\||/   \\   \\===\\\r\n      /===/   /_________________ \\===\\\r\n   /====/   / |                /  \\====\\\r\n /====/   /   |  _________    /  \\   \\===\\    THE LEGEND OF \r\n /==/   /     | /   /  \\ / / /  __________\\_____      ______       ___\r\n|===| /       |/   /____/ / /   \\   _____ |\\   /      \\   _ \\      \\  \\\r\n \\==\\             /\\   / / /     | |  /= \\| | |        | | \\ \\     / _ \\\r\n \\===\\__    \\    /  \\ / / /   /  | | /===/  | |        | |  \\ \\   / / \\ \\\r\n   \\==\\ \\    \\\\ /____/   /_\\ //  | |_____/| | |        | |   | | / /___\\ \\\r\n   \\===\\ \\   \\\\\\\\\\\\\\/   /////// /|  _____ | | |        | |   | | |  ___  |\r\n     \\==\\/     \\\\\\\\/ / //////   \\| |/==/ \\| | |        | |   | | | /   \\ |\r\n     \\==\\     _ \\\\/ / /////    _ | |==/     | |        | |  / /  | |   | |\r\n       \\==\\  / \\ / / ///      /|\\| |_____/| | |_____/| | |_/ /   | |   | |\r\n       \\==\\ /   / / /________/ |/_________|/_________|/_____/   /___\\ /___\\\r\n         \\==\\  /               | /==/\r\n         \\=\\  /________________|/=/    OCARINA OF TIME\r\n           \\==\\     _____     /==/ \r\n          / \\===\\   \\   /   /===/\r\n         / / /\\===\\  \\_/  /===/\r\n        / / /   \\====\\ /====/\r\n       / / /      \\===|===/\r\n       |/_/         \\===/\r\n                      =");
                            #endregion
                            Console.ResetColor();
                            exit = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("How did you not hit the correct keys?? Try again?");
                            #region
                            Console.WriteLine("                              .\\\r\n                        .\\   / _\\   .\\\r\n                       /_ \\   ||   / _\\\r\n                        ||    ||    ||\r\n                 ; ,     \\`.__||__.'/\r\n         |\\     /( ;\\_.;  `./|  __.'\r\n         ' `.  _|_\\/_;-'_ .' '||\r\n          \\ _/`       `.-\\_ / ||      _\r\n      , _ _`; ,--.   ,--. ;'_ _|,     |\r\n      '`''\\| /  ,-\\ | _,-\\ |/''`'  _  |\r\n       \\ .-- \\__\\_/ /` )_/ --. /   |  |       _\r\n       /    .         -'  .    \\ --|--|--.  .' \\\r\n      |     /             \\     |  |  |   \\ |---'\r\n   .   .  -' `-..____...-' `-  .   |  |    |\\  _\r\n.'`'.__ `._      `-..-''    _.'|   |  | _  | `-'      _\r\n \\ .--.`.  `-..__    _,..-'   L|   |    |             |\r\n  '    \\ \\      _,| |,_      /_7)  |    |   _       _ |  _\r\n        \\ \\    /       \\ _.-'/||        | .' \\     _| |  |\r\n         \\ \\  /.'|   |`.__.'` ||     .--| |--- _   /| |  |\r\n          \\ `//_/     \\       ||    /   | \\  _ \\  / | |  |\r\n           `/ \\|       |      ||   |    |  `-'  \\/  | '--|      _\r\n            `\"`'.  _  .'      ||    `--'|                |   .--/\r\n                 \\ | /        ||                         '--'\r\n                  |'|  mx     'J        made me do it! ;)\r\n               .-.|||.-.\r\n              '----\"----'");
                            #endregion
                            Console.ResetColor();
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude. You died. Resurect yourself and try again!");
                        #region art
                        Console.WriteLine("                (                           )\r\n          ) )( (                           ( ) )( (\r\n       ( ( ( )  ) )                     ( (   (  ) )(\r\n      ) )     ,,\\\\\\                     ///,,       ) (\r\n   (  ((    (\\\\\\\\//                     \\\\////)      )\r\n    ) )    (-(__//                       \\\\__)-)     (\r\n   (((   ((-(__||                         ||__)-))    ) )\r\n  ) )   ((-(-(_||           ```\\__        ||_)-)-))   ((\r\n  ((   ((-(-(/(/\\\\        ''; 9.- `      //\\)\\)-)-))    )\r\n   )   (-(-(/(/(/\\\\      '';;;;-\\~      //\\)\\)\\)-)-)   (   )\r\n(  (   ((-(-(/(/(/\\======,:;:;:;:,======/\\)\\)\\)-)-))   )\r\n    )  '(((-(/(/(/(//////:%%%%%%%:\\\\\\\\\\\\)\\)\\)\\)-)))`  ( (\r\n   ((   '((-(/(/(/('uuuu:WWWWWWWWW:uuuu`)\\)\\)\\)-))`    )\r\n     ))  '((-(/(/(/('|||:wwwwwwwww:|||')\\)\\)\\)-))`    ((\r\n  (   ((   '((((/(/('uuu:WWWWWWWWW:uuu`)\\)\\))))`     ))\r\n        ))   '':::UUUUUU:wwwwwwwww:UUUUUU:::``     ((   )\r\n          ((      '''''''\\uuuuuuuu/``````         ))\r\n           ))            `JJJJJJJJJ`           ((\r\n             ((            LLLLLLLLLLL         ))\r\n               ))         ///|||||||\\\\\\       ((\r\n                 ))      (/(/(/(^)\\)\\)\\)       ((\r\n                  ((                           ))\r\n                    ((                       ((\r\n                      ( )( ))( ( ( ) )( ) (()");
                        #endregion
                        exit = true;
                    }

                    
                } while (!relaod && !exit);
            } while (!exit);

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou defeated {player.Score} being{(player.Score == 1 ? "." : "s.")}");
            Console.ResetColor();
        }//end main
        private static string GetRoom()
        {
            string[] rooms =
            {
                #region
                "Sakura Chamber:\n\n A serene room adorned with cherry blossom motifs,\n featuring soft pink hues and delicate sakura petals scattered\n on the floor.",
                "Dragon's Den:\n\n An impressive chamber decorated with dragon statues,\n fiery tapestries, and a large dragon-scale rug, creating an\n atmosphere of power and mystique.",
                "Moonlit Terrace:\n\n A balcony-like room with large windows overlooking\n a moonlit landscape, adorned with silver drapes, twinkling\n lights, and a cozy seating area.",
                "Wonderland Lounge:\n\n Step into a whimsical room inspired by Alice in\n Wonderland, with oversized furniture, colorful patterns, and\n a teacup-shaped seating area.",
                "Starry Sky Observatory:\n\n A room designed like an observatory, complete\n with a domed ceiling painted to resemble a starry night sky,\n telescope, and plush seating for stargazing.",
                "Fairy Tail Parlor:\n\n Enter a magical room filled with enchanting fairy lights,\n mystical artifacts, and shelves stocked with spellbooks\n and potions.",
                "Ninja Hideout: A secret room concealed behind sliding panels and trapdoors,\n equipped with training equipment, weapon racks, and a\n stealthy atmosphere.",
                "Pirate's Cove:\n\n Immerse yourself in a room reminiscent of a pirate ship's interior,\n featuring wooden planks, nautical decor, treasure\n chests, and a ship's wheel.",
                "Phantom Manor:\n\n Step into an eerie room inspired by ghosts and haunted mansions, with\n cobweb-covered furniture, creaky floors, and eerie\n portraits on the walls.",
                "Angelic Haven:\n\n A room bathed in soft white and gold tones, decorated with angelic\n wings, fluffy clouds, and ethereal ornaments, evoking\n a sense of heavenly peace.",
                "Demon's Lair:\n\n Delve into a dark and mysterious room featuring gothic architecture,\n dim lighting, and ominous decorations, reflecting the\n atmosphere of a demon's domain.",
                "Samurai Dojo:\n\n Experience the spirit of ancient Japan in a traditional training room,\n adorned with samurai armor, swords, and calligraphy\n scrolls.",
                "Magical Library:\n\n Lose yourself in a vast library filled with towering bookshelves,\n dusty tomes, rolling ladders, and cozy reading nooks,\n inviting you to explore enchanted worlds.",
                "Cosmic Arena:\n\n Step into a futuristic room with a holographic arena floor, neon lights,\n and high-tech displays, providing an immersive experience\n for virtual battles.",
                "Gundam Hangar:\n\n Enter a room dedicated to mecha enthusiasts, showcasing life-sized\n Gundam models, equipment racks, and a cockpit simulator for\n an authentic experience.",
                "Studio Ghibli Lounge:\n\n Pay homage to beloved Ghibli films in a room adorned with\n framed movie posters, plush Totoro chairs, and a display of\n iconic Studio Ghibli collectibles.",
                "Pokemon Training Ground:\n\n Immerse yourself in a vibrant room inspired by the\n Pokemon world, featuring Pokemon-themed artwork, plushies, and a\n battle arena for friendly matchups.",
                "Sailor Moon Sanctuary:\n\n Step into a room adorned with crystal motifs, moon-shaped\n furniture, and Sailor Moon memorabilia, capturing the essence\n of the beloved magical girl series.",
                "One Piece Treasure Vault:\n\n Explore a room filled with pirate treasures, map fragments,\n and nautical artifacts, reminiscent of the adventurous world\n of the One Piece anime.",
                "Attack on Titan Watchtower:\n\n Ascend to a tower-like room adorned with recon corps\n banners, scout gear, and a commanding view of a miniature cityscape,\n reminiscent of the Attack on Titan series."
                #endregion
            };
            return rooms[new Random().Next(rooms.Length)];
        }
    }
}