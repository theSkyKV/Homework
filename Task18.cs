using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];

            bool onWork = true;
            string userMessage = "";
            int sum = 0;

            while (onWork)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Введите целое число");
                Console.WriteLine("2) Введите команду sum для подсчета суммы всех введенных чисел");
                Console.WriteLine("3) Введите команду exit для прекращения работы");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.SetCursorPosition(0, 10);
                foreach(var number in numbers)
                {
                    Console.Write(number + " ");
                }

                Console.SetCursorPosition(0, 6);
                userMessage = Console.ReadLine();

                switch(userMessage)
                {
                    case "exit":
                        onWork = false;
                        break;
                    case "sum":
                        foreach(var number in numbers)
                        {
                            sum += number;
                        }

                        Console.WriteLine($"Сумма элементов массива - {sum}");
                        Console.Write("Нажмите любую кнопку для продолжения...");
                        Console.ReadKey();
                        break;
                    default:
                        int num = Convert.ToInt32(userMessage);
                        int[] tempArray = new int[numbers.Length + 1];
                        for (var i = 0; i < numbers.Length; i++)
                        {
                            tempArray[i] = numbers[i];
                        }
                        tempArray[tempArray.Length - 1] = num;
                        numbers = tempArray;
                        break;
                }

                Console.Clear();
            }
        }
    }
}
