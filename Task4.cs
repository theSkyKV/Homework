using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int coinsCount;
            int diamondsCount;
            int diamondPrice = 10;
            bool enoughCoins;

            Console.Write("Enter your balance: ");
            coinsCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of diamonds to buy: ");
            diamondsCount = Convert.ToInt32(Console.ReadLine());

            enoughCoins = coinsCount >= diamondPrice * diamondsCount;
            diamondsCount *= Convert.ToInt32(enoughCoins);
            coinsCount -= diamondPrice * diamondsCount;

            Console.WriteLine($"You have {coinsCount} coins and {diamondsCount} diamonds");
        }
    }
}
