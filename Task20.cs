using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            int maxValue;
            int position;
            while (true)
            {
                Console.Write("Введите значение: ");
                int.TryParse(Console.ReadLine(), out value);
                Console.Write("Введите максимальное значение: ");
                int.TryParse(Console.ReadLine(), out maxValue);
                Console.Write("Введите позицию: ");
                int.TryParse(Console.ReadLine(), out position);
                DrawBar(value, maxValue, position);
            }
        }

        static void DrawBar(int value, int maxValue, int position = 1)
        {
            Console.Clear();

            if (value < 0 || maxValue < 0 || position < 0 || value > maxValue)
            {
                Console.WriteLine("Некорректное значение");
                return;
            }

            Console.SetCursorPosition(0, position);
            
            Console.Write("[");
            for (var i = 0; i < value; i++)
            {
                Console.Write("#");
            }
            for (var i = value; i < maxValue; i++)
            {
                Console.Write("_");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
