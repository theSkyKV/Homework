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
            Dictionary<string, string> employeesList = new Dictionary<string, string>();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить досье, 2 - Вывести все досье,");
                Console.WriteLine("3 - Удалить досье, 4 - Выход.");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите должность: ");
                        string position = Console.ReadLine();
                        employeesList.Add(name, position);
                        Console.WriteLine("Досье успешно добавлено.");
                        break;
                    case "2":
                        if (employeesList.Count > 0)
                        {
                            foreach (var employee in employeesList)
                            {
                                Console.WriteLine($"{employee.Key} - {employee.Value}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список досье пуст...");
                        }
                        break;
                    case "3":
                        Console.Write("Введите имя: ");
                        userInput = Console.ReadLine();
                        if (employeesList.ContainsKey(userInput))
                        {
                            employeesList.Remove(userInput);
                            Console.WriteLine("Досье успешно удалено.");
                        }
                        else
                        {
                            Console.WriteLine("Такого досье не существует...");
                        }
                        break;
                    case "4":
                        isWork = false;
                        Console.WriteLine("До встречи!");
                        break;
                    default:
                        Console.WriteLine("Некорректное действие...");
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
