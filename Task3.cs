using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int picturesInRow = 3;
            int picturesCount = 52;
            int fullRowsCount;
            int picturesCountInIncompleteRow;

            fullRowsCount = picturesCount / picturesInRow;
            picturesCountInIncompleteRow = picturesCount % picturesInRow;

            Console.WriteLine($"Полных рядов - {fullRowsCount}, картинок в неполном ряду - {picturesCountInIncompleteRow}");
        }
    }
}
