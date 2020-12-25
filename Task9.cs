using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMessage = "";
            float usdToRub = 75.0f;
            float eurToRub = 90.0f;
            float roubleBalance, usdBalance, euroBalance;
            float moneyForExchange;
            float usdToEur = usdToRub / eurToRub;

            Console.Write("Enter your rouble balance: ");
            roubleBalance = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter your dollar balance: ");
            usdBalance = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter your euro balance: ");
            euroBalance = Convert.ToSingle(Console.ReadLine());

            while (userMessage != "quit")
            {
                Console.Write("Enter the action: ");
                Console.WriteLine("1 - usd to rub, 2 - rub to usd, 3 - eur to rub");
                Console.WriteLine("4 - rub to eur, 5 - usd to eur, 6 - eur to usd, quit - to quit");
                userMessage = Console.ReadLine();

                switch(userMessage)
                {
                    case "1":
                        Console.Write("How much money do you want to exchange? ");
                        moneyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (usdBalance >= moneyForExchange)
                        {
                            usdBalance -= moneyForExchange;
                            roubleBalance += moneyForExchange * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;
                    case "2":
                        Console.Write("How much money do you want to exchange? ");
                        moneyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (roubleBalance >= moneyForExchange)
                        {
                            roubleBalance -= moneyForExchange;
                            usdBalance += moneyForExchange / usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;
                    case "3":
                        Console.Write("How much money do you want to exchange? ");
                        moneyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (euroBalance >= moneyForExchange)
                        {
                            euroBalance -= moneyForExchange;
                            roubleBalance += moneyForExchange * eurToRub;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;
                    case "4":
                        Console.Write("How much money do you want to exchange? ");
                        moneyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (roubleBalance >= moneyForExchange)
                        {
                            roubleBalance -= moneyForExchange;
                            euroBalance += moneyForExchange / eurToRub;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;
                    case "5":
                        Console.Write("How much money do you want to exchange? ");
                        moneyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (usdBalance >= moneyForExchange)
                        {
                            usdBalance -= moneyForExchange;
                            euroBalance += moneyForExchange * usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;
                    case "6":
                        Console.Write("How much money do you want to exchange? ");
                        moneyForExchange = Convert.ToSingle(Console.ReadLine());
                        if (euroBalance >= moneyForExchange)
                        {
                            euroBalance -= moneyForExchange;
                            usdBalance += moneyForExchange / usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;
                    case "quit":
                        Console.WriteLine("Good bye");
                        break;
                    default:
                        Console.WriteLine("Incorrect action. Try again.");
                        break;
                }

                Console.WriteLine($"Your balance: Rouble - {roubleBalance}, USD - {usdBalance}, Euro - {euroBalance}");
            }
        }
    }
}
