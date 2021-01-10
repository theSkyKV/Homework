using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "12345";
            string userInput;
            int attemptsCount = 3;

            for (int i = 0; i < attemptsCount;)
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
                    Console.WriteLine($"Access denied. You have {--attemptsCount} attempts.");
                }
            }
        }
    }
}
