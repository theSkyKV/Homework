using System;
using System.Collections.Generic;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int account = 0;

            Queue<int> customers = new Queue<int>();
            CreateQueue(ref customers);

            while (customers.Count > 0)
            {
                Console.Clear();
                int purchaseAmount = customers.Dequeue();
                Console.WriteLine($"Добавлено {purchaseAmount} $ на счет.");
                Console.WriteLine($"Всего денег на счету - {account += purchaseAmount} $");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey(true);
            }

            Console.Clear();
            Console.WriteLine($"Рабочий день окончен! Вы заработали {account} $");
        }

        static void CreateQueue(ref Queue<int> queue)
        {
            Random rand = new Random();
            int queueLength = rand.Next(5, 10);
            
            for (var i = 0; i < queueLength; i++)
            {
                queue.Enqueue(rand.Next(50, 1000));
            }
        }
    }
}
