using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            int maxElement = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            Random rand = new Random();

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(-999, 999);

                    if (maxElement < array[i, j])
                    {
                        maxElement = array[i, j];
                        rowIndex = i;
                        colIndex = j;
                    }

                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nНаибольший элемент - {maxElement} ({rowIndex}, {colIndex})\n");

            array[rowIndex, colIndex] = 0;

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
