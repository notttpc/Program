using System.Numerics;
using System.Threading;
using DungeonLibrary;

namespace Special_dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ("Anime World");
            Console.WriteLine("Welcome to Anime Adventures");

            //TODO Create and display characters for person to choose

            //TODO Create and display Weapons for Characters to choose

            bool exit = false;
            do
            {
                //TODO create monster
                Monster monster = Monster.GetMonster();
                //TODO Generate Room
                Console.WriteLine(GetRoom() + $" \nYour opponent is {monster.Name}!");

                bool relaod = false;
                do
                {
                    Console.WriteLine($"\nSelect an action\n" +
                                      $"A) Attack\n" +
                                      $"B) Run Away\n" +
                                      $"C) Player Info\n" +
                                      $"D) Monster Info\n" +
                                      $"E) Exit");
                    ConsoleKey choice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Something attack");
                            //TODO Combat funcionality
                            relaod = Combat.DoBattle(player, monster);
                            break;
                        case ConsoleKey.B:
                            Console.WriteLine("Something run away");
                            //TODO attack opp
                            Console.WriteLine($"{monster.Name} attacks you as you turn.");
                            Combat.DoAttack(monster, player);
                            relaod = true;
                            break;
                        case ConsoleKey.C:
                            Console.WriteLine("Character info: ");
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Monster Info: ");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.WriteLine("You dont like anime?");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("How did you not hit the correct keys?? Try again?");
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude. You died!");
                        exit = true;
                    }

                    //TODO Check player life line 101
                } while (!relaod && !exit);
            } while (!exit);

            //TODO display final score and exit message
            Console.WriteLine($"You defeated {player.Score} being {(player.Score == 1 ? "." : "s.")}");
            //TODO console.writeline("Do you want to play again?";
            //TODO input == "y" them main(args)
        }//end main
        private static string GetRoom()
        {
            string[] rooms =
            {
                #region
                "Sakura Chamber: A serene room adorned with cherry blossom motifs,\n featuring soft pink hues and delicate sakura petals scattered\n on the floor.",
                "Dragon's Den: An impressive chamber decorated with dragon statues,\n fiery tapestries, and a large dragon-scale rug, creating an\n atmosphere of power and mystique.",
                "Moonlit Terrace: A balcony-like room with large windows overlooking\n a moonlit landscape, adorned with silver drapes, twinkling\n lights, and a cozy seating area.",
                "Wonderland Lounge: Step into a whimsical room inspired by Alice in\n Wonderland, with oversized furniture, colorful patterns, and\n a teacup-shaped seating area.",
                "Starry Sky Observatory: A room designed like an observatory, complete\n with a domed ceiling painted to resemble a starry night sky,\n telescope, and plush seating for stargazing.",
                "Fairy Tail Parlor: Enter a magical room filled with enchanting fairy lights,\n mystical artifacts, and shelves stocked with spellbooks\n and potions.",
                "Ninja Hideout: A secret room concealed behind sliding panels and trapdoors,\n equipped with training equipment, weapon racks, and a\n stealthy atmosphere.",
                "Pirate's Cove: Immerse yourself in a room reminiscent of a pirate ship's interior,\n featuring wooden planks, nautical decor, treasure\n chests, and a ship's wheel.",
                "Phantom Manor: Step into an eerie room inspired by ghosts and haunted mansions, with\n cobweb-covered furniture, creaky floors, and eerie\n portraits on the walls.",
                "Angelic Haven: A room bathed in soft white and gold tones, decorated with angelic\n wings, fluffy clouds, and ethereal ornaments, evoking\n a sense of heavenly peace.",
                "Demon's Lair: Delve into a dark and mysterious room featuring gothic architecture,\n dim lighting, and ominous decorations, reflecting the\n atmosphere of a demon's domain.",
                "Samurai Dojo: Experience the spirit of ancient Japan in a traditional training room,\n adorned with samurai armor, swords, and calligraphy\n scrolls.",
                "Magical Library: Lose yourself in a vast library filled with towering bookshelves,\n dusty tomes, rolling ladders, and cozy reading nooks,\n inviting you to explore enchanted worlds.",
                "Cosmic Arena: Step into a futuristic room with a holographic arena floor, neon lights,\n and high-tech displays, providing an immersive experience\n for virtual battles.",
                "Gundam Hangar: Enter a room dedicated to mecha enthusiasts, showcasing life-sized\n Gundam models, equipment racks, and a cockpit simulator for\n an authentic experience.",
                "Studio Ghibli Lounge: Pay homage to beloved Ghibli films in a room adorned with\n framed movie posters, plush Totoro chairs, and a display of\n iconic Studio Ghibli collectibles.",
                "Pokemon Training Ground: Immerse yourself in a vibrant room inspired by the\n Pokemon world, featuring Pokemon-themed artwork, plushies, and a\n battle arena for friendly matchups.",
                "Sailor Moon Sanctuary: Step into a room adorned with crystal motifs, moon-shaped\n furniture, and Sailor Moon memorabilia, capturing the essence\n of the beloved magical girl series.",
                "One Piece Treasure Vault: Explore a room filled with pirate treasures, map fragments,\n and nautical artifacts, reminiscent of the adventurous world\n of the One Piece anime.",
                "Attack on Titan Watchtower: Ascend to a tower-like room adorned with recon corps\n banners, scout gear, and a commanding view of a miniature cityscape,\n reminiscent of the Attack on Titan series."
                #endregion
            };
            return rooms[new Random().Next(rooms.Length)];
        }
    }
}