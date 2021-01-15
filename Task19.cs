using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool onWork = true;
            string[] names = new string[0];
            string[] positions = new string[0];

            while(onWork)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.Write("1 - Добавить досье.\n2 - Вывести все досье.\n3 - Поиск по фамилии.\n" +
                    "4 - Удалить досье.\n5 - Выход.\n");

                switch(Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        AddElement(ref names, Console.ReadLine());
                        Console.Write("Введите должность: ");
                        AddElement(ref positions, Console.ReadLine());
                        break;
                    case "2":
                        DisplayElements(names, positions);
                        PressAnyKey();
                        break;
                    case "3":
                        Console.Write("Введите имя: ");
                        FindElement(names, Console.ReadLine());
                        PressAnyKey();
                        break;
                    case "4":
                        Console.Write("Введите номер удаляемого элемента: ");
                        int index;
                        if (int.TryParse(Console.ReadLine(), out index))
                        {
                            DeleteElement(ref names, index - 1);
                            DeleteElement(ref positions, index - 1);
                        }
                        break;
                    case "5":
                        onWork = false;
                        Console.WriteLine("До встречи!");
                        break;
                    default:
                        Console.WriteLine("Некорректное действие");
                        PressAnyKey();
                        break;
                }
            }
        }

        static void AddElement(ref string[] array, string newElement)
        {
            string[] tempArray = new string[array.Length + 1];

            for (var i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[tempArray.Length - 1] = newElement;
            array = tempArray;
        }

        static void DisplayElements(string[] array1, string[] array2)
        {
            if (array1.Length > 0)
            {
                for (var i = 0; i < array1.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {array1[i]} - {array2[i]}");
                }
            }
            else
            {
                Console.WriteLine("Данные отсутствуют");
            }
        }

        static void FindElement(string[] array, string keyword)
        {
            bool isFind = false;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i].ToLower() == keyword.ToLower())
                {
                    isFind = true;
                    Console.WriteLine($"Заданный элемент находится под номером {i + 1}");
                }
            }
            if (!isFind)
            {
                Console.WriteLine("Поиск не дал результатов");
            }
        }

        static void DeleteElement(ref string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];
            for (int i = 0, j = 0; i < array.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    continue;
                }
                tempArray[j] = array[i];
            }
            array = tempArray;
        }

        static void PressAnyKey()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey(true);
        }
    }
}
