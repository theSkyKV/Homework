using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            int sum = 0;
            int mult = 1;

            Random rand = new Random();

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(0, 10);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (var i = 0; i < array.GetLength(1); i++)
            {
                sum += array[2, i];
            }

            for (var i = 0; i < array.GetLength(0); i++)
            {
                mult *= array[i, 1];
            }

            Console.WriteLine($"Сумма - {sum}, произведение - {mult}");
        }
    }
}
