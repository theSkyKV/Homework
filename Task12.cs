using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            char frameSymbol;
            int frameWidth;
            int frameHeight = 3;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter the symbol of frame: ");
            char.TryParse(Console.ReadLine(), out frameSymbol);

            frameWidth = name.Length + 2;
            for (int i = 0; i < frameHeight; i++)
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
