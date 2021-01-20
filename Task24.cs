using System;
using System.Collections.Generic;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int account = 0;
            Queue<int> customers = CreateQueue();

            while (customers.Count > 0)
            {
                Console.Clear();
                int purchaseAmount = customers.Dequeue();
                Console.WriteLine($"Добавлено {purchaseAmount} $ на счет.");
                account += purchaseAmount;
                Console.WriteLine($"Всего денег на счету - {account} $");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey(true);
            }

            Console.Clear();
            Console.WriteLine($"Рабочий день окончен! Вы заработали {account} $");
        }

        static Queue<int> CreateQueue()
        {
            Queue<int> queue = new Queue<int>();
            Random rand = new Random();
            int queueLength = rand.Next(5, 10);

            for (var i = 0; i < queueLength; i++)
            {
                queue.Enqueue(rand.Next(50, 1000));
            }

            return queue;
        }
    }
}
