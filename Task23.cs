using System;
using System.Collections.Generic;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userInput;
            Dictionary<string, string> vocabulary = new Dictionary<string, string>
            {
                ["Слово1"] = "Значение1",
                ["Слово2"] = "Значение2",
                ["Слово3"] = "Значение3"
            };

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Введите слово: ");
                userInput = Console.ReadLine();

                if (vocabulary.ContainsKey(userInput))
                {
                    Console.WriteLine($"{userInput} - {vocabulary[userInput]}");
                }
                else
                {
                    Console.WriteLine("Такого слова нет...");
                }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить, или q для выхода...");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                {
                    isWork = false;
                }
            }
        }
    }
}
