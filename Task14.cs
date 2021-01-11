using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            int playerMaxHealth = 1000;
            int playerHealth = playerMaxHealth;
            int playerDamage;
            int rainCooldown = 2;
            int bossMaxHealth = 10000;
            int bossHealth = bossMaxHealth;
            int bossDamage;
            int mountainCooldown = 2;
            int bossDamageRate = 2;
            int burnChance;
            bool isBurn = false;
            Random rand = new Random();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Способности босса:");
            Console.WriteLine("Оползень - наносит урон землей.");
            Console.WriteLine("Ревущая гора - наносит большой урон землей.");
            Console.WriteLine("Ярость - когда хп падает ниже 30 % увеличивает атаку вдвое. Также увеличивается входящий урон.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Огненный шар. Наносит средний урон огнем. Вероятность поджечь.");
            Console.WriteLine("2 - Адское пламя. Если враг подожжен, позволяет нанести большой урон.");
            Console.WriteLine("3 - Огненный дождь. Наносит большой урон огнем. Вероятность поджечь.");
            Console.WriteLine("4 - Последняя надежда. Оставляет 1 хп. С вероятностью 50 % наносит врагу колоссальный урон. " +
                "Можно использовать, если здоровье персонажа менее 10 %.");

            Console.ForegroundColor = ConsoleColor.Gray;

            while (bossHealth > 0 && playerHealth > 0)
            {
                rainCooldown--;
                mountainCooldown--;

                playerDamage = 0;

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        playerDamage = rand.Next(350, 600);

                        burnChance = rand.Next(0, 100);
                        if (burnChance < 30)
                        {
                            isBurn = true;
                            Console.WriteLine("Враг подожжен");
                        }
                        break;
                    case "2":
                        if (isBurn == true)
                        {
                            playerDamage = rand.Next(800, 1100);
                            isBurn = false;
                            Console.WriteLine("Враг больше не горит");
                        }
                        else
                        {
                            playerDamage = 0;
                            Console.WriteLine("Неудачная атака");
                        }
                        break;
                    case "3":
                        if (rainCooldown <= 0)
                        {
                            playerDamage = rand.Next(1100, 1500);
                            rainCooldown = 4;

                            burnChance = rand.Next(0, 100);
                            if (burnChance < 30)
                            {
                                isBurn = true;
                                Console.WriteLine("Враг подожжен");
                            }
                        }
                        else
                        {
                            playerDamage = 0;
                            Console.WriteLine("Умение еще не готово");
                        }
                        break;
                    case "4":
                        if (playerHealth < (playerMaxHealth / 10))
                        {
                            int chance = rand.Next(0, 100);
                            if (chance < 50)
                            {
                                playerDamage = rand.Next(5000, 7000);
                            }
                            else
                            {
                                playerDamage = 0;
                                Console.WriteLine("Неудачная атака");
                            }
                        }
                        else
                        {
                            playerDamage = 0;
                            Console.WriteLine("Слишком много хп");
                        }

                        playerHealth = 1;
                        break;
                }

                if (mountainCooldown <= 0)
                {
                    Console.WriteLine("Умение босса - ревущая гора");
                    mountainCooldown = 6;
                    bossDamage = rand.Next(150, 250);
                }
                else
                {
                    bossDamage = rand.Next(30, 70);
                }

                if (bossHealth < (0.3f * bossMaxHealth))
                {
                    Console.WriteLine("Босс впал в ярость. Урон увеличен.");
                    bossDamage *= bossDamageRate;
                    playerDamage *= bossDamageRate;
                }

                bossHealth -= playerDamage;

                if (bossHealth > 0)
                {
                    playerHealth -= bossDamage;
                }

                Console.WriteLine($"Здоровье босса - {bossHealth}, здоровье игрока - {playerHealth}");
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("Игрок убит");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Босс уничтожен");
            }
        }
    }
}
