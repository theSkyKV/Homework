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
            int sum;
            List<int> numbers = new List<int>();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Введите целое число, sum для подсчета суммы чисел или exit для выхода.");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "sum":
                        if (numbers.Count > 0)
                        {
                            sum = 0;
                            foreach (var number in numbers)
                            {
                                sum += number;
                            }
                            Console.WriteLine($"Сумма всех введенных чисел - {sum}");
                        }
                        else
                        {
                            Console.WriteLine("Вы не ввели ни одного числа...");
                        }
                        break;
                    case "exit":
                        Console.WriteLine("До скорого!");
                        isWork = false;
                        break;
                    default:
                        if (int.TryParse(userInput, out int value))
                        {
                            numbers.Add(value);
                        }
                        else
                        {
                            Console.WriteLine("Некорректное действие...");
                        }
                        break;
                }
                PressAnyKey();
            }
        }

        static void PressAnyKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }
    }
}
