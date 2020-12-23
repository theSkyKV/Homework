using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMessage;

            do
            {
                Console.Write("Enter your message or 'exit' to exit: ");
                userMessage = Console.ReadLine().ToString();
            } while (userMessage != "exit");
        }
    }
}
