using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMessage;
            int printCount;

            Console.Write("Enter your message: ");
            userMessage = Console.ReadLine().ToString();
            Console.Write("Enter print count: ");
            printCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < printCount; i++)
            {
                Console.WriteLine(userMessage);
            }
        }
    }
}
