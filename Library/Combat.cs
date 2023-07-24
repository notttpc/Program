using DungeonLibrary;
using System.Security.Cryptography.X509Certificates;

namespace Library
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            int chance = attacker.CalcHitChance() - defender.CalcBlock();

            int roll = new Random().Next(1, 101);
            Thread.Sleep(300);
            if (roll <= chance)
            {
                int damage = attacker.CalcDamage();

                defender.Life -= damage;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(attacker.Name + "has missed there attack.");
                Console.ResetColor();
            }
        }
        public static bool DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);

            if (monster.Life > 0)
            {
                DoAttack(monster, player);
                return false;
            }
            else
            {
                if (player.Score % 2 == 0)
                {
                    player.Life += 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You have gained 10 health for killing a enemie!");
                    Console.ResetColor();
                }
                player.Score++;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou killed {monster.Name}");
                Console.ResetColor();
                return true;
            }
        }
    }
}