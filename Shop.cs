using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Player
    {
        private List<Goods> _bag = new List<Goods>();
    }

    class Seller
    {
        private List<Goods> _goods = new List<Goods>();

        public void AddGoods()
        {
            Goods goods;
            string name;
            int price;
            int amount;

            Console.WriteLine("Введите название товара:");
            name = Console.ReadLine();
            Console.WriteLine("Введите цену:");
            if (int.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Введите количество товара на складе:");
                if (int.TryParse(Console.ReadLine(), out amount))
                    goods = new Goods(name, price, amount);
                else
                    return;
            }
            else
            {
                return;
            }
            _goods.Add(goods);
        }
    }

    class Goods
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Amount { get; private set; }

        public Goods(string name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}
