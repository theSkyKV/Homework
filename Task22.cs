using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7 };

            Shuffle(ref numbers);
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }

        static void Shuffle(ref int[] array)
        {
            Random rand = new Random();
            int[] newIndexes = new int[0];

            for (var i = 0; i < array.Length; i++)
            {
                int[] tempArray = new int[newIndexes.Length + 1];
                for (var j = 0; j < newIndexes.Length; j++)
                {
                    tempArray[j] = newIndexes[j];
                }
                int index = rand.Next(0, tempArray.Length);
                tempArray[tempArray.Length - 1] = index;
                newIndexes = tempArray;
            }

            for (var i = 0; i < newIndexes.Length; i++)
            {
                Console.Write(newIndexes[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

