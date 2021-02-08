using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Npc npc = new Npc();
            Player player = new Player(10000);
            string userInput;
            bool isOpen = true;

            npc.CreateRandomItem(5);

            while (isOpen)
            {
                int id;

                Console.Clear();
                Console.WriteLine("1 - Купить товар, 2 - Посмотреть ассортимент, 3 - Посмотреть инвентарь, 4 - Выход");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Введите id предмета:");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            npc.Sell(player, id);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                        break;
                    case "2":
                        npc.ShowGoods();
                        break;
                    case "3":
                        player.ShowInventory();
                        break;
                    case "4":
                        Console.WriteLine("До встречи!");
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey(true);
            }
        }
    }

    class Player
    {
        public int Money { get; private set; }

        private Inventory _inventory = new Inventory();

        public Player(int money)
        {
            Money = money;
        }

        public void Buy(Item item, int amount)
        {
            if (_inventory.FindElementOnId(item.Id) == null)
            {
                Cell cell = new Cell(item, amount);
                _inventory.AddCell(cell);
                Money -= item.Price * amount;
            }
            else
            {
                _inventory.FindElementOnId(item.Id).ChangeAmount(amount);
            }
        }

        public void ShowInventory()
        {
            _inventory.ShowInventory();
            Console.WriteLine($"Осталось на счету: {Money} $");
        }
    }

    class Npc
    {
        private Inventory _inventory = new Inventory();
        private Random _rand = new Random();

        public void CreateRandomItem(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                Item item = new Item("item" + i, _rand.Next(30, 100));
                Cell cell = new Cell(item, _rand.Next(10, 50));
                _inventory.AddCell(cell);
            }
        }

        public void Sell(Player player, int id)
        {
            Cell cell = _inventory.FindElementOnId(id);
            if (cell != null)
            {
                int amount;

                Console.WriteLine("Введите количество:");
                if (int.TryParse(Console.ReadLine(), out amount))
                {
                    if (amount <= cell.Amount && player.Money >= amount * cell.Item.Price)
                    {
                        player.Buy(cell.Item, amount);
                        cell.ChangeAmount(-amount);

                        if (cell.Amount == 0)
                        {
                            _inventory.RemoveCell(cell);
                        }
                        Console.WriteLine("Успешно!");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно предметов или денег.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            else
            {
                Console.WriteLine("Такого товара нет.");
            }
        }

        public void ShowGoods()
        {
            _inventory.ShowInventory();
        }
    }

    class Item
    {
        private static int _itemId = 1;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
            Id = _itemId++;
        }
    }

    class Inventory
    {
        private List<Cell> _inventory = new List<Cell>();

        public void AddCell(Cell cell)
        {
            _inventory.Add(cell);
        }

        public void RemoveCell(Cell cell)
        {
            _inventory.Remove(cell);
        }

        public Cell FindElementOnId(int id)
        {
            foreach (var cell in _inventory)
            {
                if (cell.Item.Id == id)
                {
                    return cell;
                }
            }
            return null;
        }

        public void ShowInventory()
        {
            foreach (var cell in _inventory)
            {
                Console.WriteLine($"{cell.Item.Id} | {cell.Item.Name} | {cell.Item.Price} $/шт. | {cell.Amount} шт.");
            }
        }
    }

    class Cell
    {
        public Item Item { get; private set; }
        public int Amount { get; private set; }

        public Cell(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public void ChangeAmount(int amount)
        {
            Amount += amount;
        }
    }
}
