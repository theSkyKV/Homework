// Сначала идет последовательный рандом новых индексов, т.е.
// Для 0-го элемента изначальный индекс 0.
// Для 1-го элемента выбирается индекс 0 или 1.
// Для 2-го - 0, 1 или 2 и т.д.
// Далее, начиная с последнего элемента, просматриваются все элементы на наличие одинаковых.
// К каждому следующему одинаковому элементу прибавляется coincidencesCount (количество совпадений до текущего момента).
// Пока есть совпадения, операция продолжается.
// После того, как совпадения не обнаруживаются, элементы массива встают на новые места.
using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("До: ");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Shuffle(ref numbers);

            Console.WriteLine("\nПосле: ");
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
    }
}
