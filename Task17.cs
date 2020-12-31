using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];

            Random rand = new Random();

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 100);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (var i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    if (array[i] > array[i + 1])
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                else if (i > 0 && i < array.Length - 1)
                {
                    if (array[i] > array[i + 1] && array[i] > array[i - 1])
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                else
                {
                    if (array[i] > array[i - 1])
                    {
                        Console.Write(array[i] + " ");
                    }
                }
            }
        }
    }
}
