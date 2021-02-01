using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();

            supermarket.CreateQueue();
            Console.WriteLine($"В очереди {supermarket.QueueLength} человек.");
            while (supermarket.QueueLength > 0)
            {
                supermarket.ServeClient();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey(true);
            }
        }
    }

    class Supermarket
    {
        private Random _rand;
        private Queue<Customer> _customers;

        public int QueueLength
        {
            get
            {
                return _customers.Count;
            }
        }

        public Supermarket()
        {
            _rand = new Random();
            _customers = new Queue<Customer>();
        }

        public void CreateQueue()
        {
            int queueLength = _rand.Next(3, 10);
            for (var i = 0; i < queueLength; i++)
            {
                Customer customer = new Customer(_rand.Next(100, 1000));
                int itemsAmount = _rand.Next(5, 10);

                for (var j = 0; j < itemsAmount; j++)
                {
                    customer.TakeRandomItem();
                }
                _customers.Enqueue(customer);
            }
        }

        public void ServeClient()
        {
            Customer customer = _customers.Peek();
            int purchaseAmount = customer.GetPurchaseAmount();

            Console.WriteLine("Список Ваших покупок:");
            customer.ShowBag();
            Console.WriteLine($"С Вас {purchaseAmount} $ (Денег у клиента {customer.Money} $)");

            while (customer.TryToPay(purchaseAmount) == false)
            {
                customer.DropRandomItem();
                purchaseAmount = customer.GetPurchaseAmount();
                Console.WriteLine($"Теперь сумма покупок составляет {purchaseAmount} $");
            }
            Console.WriteLine("Итоговая покупка:");
            customer.ShowBag();
            _customers.Dequeue();
        }
    }

    class Customer
    {
        private Random _rand;
        private List<Item> _bag;

        public int Money { get; private set; }

        public Customer(int money)
        {
            _rand = new Random();
            _bag = new List<Item>();
            Money = money;
        }

        public void TakeRandomItem()
        {
            string name = "item" + _rand.Next(0, 1000);
            int price = _rand.Next(20, 200);
            Item item = new Item(name, price);

            _bag.Add(item);
        }

        public void DropRandomItem()
        {
            int index = _rand.Next(0, _bag.Count);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Вы выкладываете {_bag[index].Name} ценой в {_bag[index].Price} $");
            Console.ForegroundColor = ConsoleColor.Gray;

            _bag.RemoveAt(index);
        }

        public int GetPurchaseAmount()
        {
            int purchaseAmount = 0;
            foreach (var item in _bag)
            {
                purchaseAmount += item.Price;
            }

            return purchaseAmount;
        }

        public bool TryToPay(int purchaseAmount)
        {
            if (Money >= purchaseAmount)
            {
                Money -= purchaseAmount;
                Console.WriteLine("Покупка успешно оплачена.");
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно денег.");
                return false;
            }
        }

        public void ShowBag()
        {
            if (_bag.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in _bag)
                {
                    Console.WriteLine($"{item.Name} - {item.Price} $");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В Вашей сумке ничего нет...");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
