using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetNumber());
        }

        static int GetNumber()
        {
            int userInput;
            do
            {
                Console.Write("Введите целое число: ");
            } while (!int.TryParse(Console.ReadLine(), out userInput));

            return userInput;
        }
    }
}
