using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string frameSymbol;
            int frameWidth;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter the symbol of frame: ");
            frameSymbol = Console.ReadLine();

            frameWidth = name.Length + 2;
            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                {
                    Console.Write($"{frameSymbol}{name}{frameSymbol}");
                }
                else
                {
                    for (int j = 0; j < frameWidth; j++)
                    {
                        Console.Write(frameSymbol);
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
