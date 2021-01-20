using System;
using System.Collections.Generic;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Dictionary<string, string> vocabulary = new Dictionary<string, string>
            {
                ["Слово1"] = "Значение1",
                ["Слово2"] = "Значение2",
                ["Слово3"] = "Значение3"
            };

            while (true)
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
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey(true);
            }
        }
    }
}
