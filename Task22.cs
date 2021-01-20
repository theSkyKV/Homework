using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("До: ");
            PrintArray(numbers);

            Shuffle(ref numbers);

            Console.WriteLine("\nПосле: ");
            PrintArray(numbers);
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

            int sameElementsCount;
            do
            {
                sameElementsCount = 0;
                for (var i = newIndexes.Length - 1; i >= 0; i--)
                {
                    int coincidencesCount = 0;
                    for (var j = i - 1; j >= 0; j--)
                    {
                        if (newIndexes[i] == newIndexes[j])
                        {
                            coincidencesCount++;
                            newIndexes[j] += coincidencesCount;
                            sameElementsCount++;
                        }
                    }
                }
            } while (sameElementsCount > 0);

            int[] newArray = new int[newIndexes.Length];
            for (var i = 0; i < newIndexes.Length; i++)
            {
                newArray[newIndexes[i]] = array[i];
            }

            array = newArray;
        }

        static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
        }
    }
}
