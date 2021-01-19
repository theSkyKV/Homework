using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadNumber());
        }

        static int ReadNumber()
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
