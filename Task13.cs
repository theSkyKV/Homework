using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "12345";
            string userInput;
            int attemptsCount = 3;

            while (attemptsCount > 0)
            {
                Console.Write("Enter the password: ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Secret message");
                    break;
                }
                else
                {
                    attemptsCount--;
                    Console.WriteLine($"Access denied. You have {attemptsCount} attempts.");
                }
            }
        }
    }
}
