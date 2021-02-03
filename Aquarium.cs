using System;
using System.Collections.Generic;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium(10);
            bool isWork = true;

            while (isWork)
            {
                aquarium.Live(ref isWork);
            }
        }
    }

    class Aquarium
    {
        private Random _rand;
        private List<Fish> _fishes;
        private int _maxFishesAmount;

        public Aquarium(int maxFishesAmount)
        {
            _fishes = new List<Fish>();
            _rand = new Random();
            _maxFishesAmount = maxFishesAmount;
        }

        public void Live(ref bool isWork)
        {
            string userInput;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сейчас в акввариуме:");
            ShowInfo();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ввыберите действие:");
            Console.WriteLine("1 - Заполнить аквариум (с удалением текущего), 2 - Очистить аквариум, 3 - Добавить рыбу,");
            Console.WriteLine("4 - Удалить рыбу, 5 - Закончить ход, 6 - Выход");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ClearAquarium();
                    FillAquarium();
                    break;
                case "2":
                    ClearAquarium();
                    break;
                case "3":
                    Console.WriteLine("Введите название рыбы:");
                    AddFish(new Fish(Console.ReadLine()));
                    break;
                case "4":
                    Console.WriteLine("Введите индекс рыбы:");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        RemoveFish(index);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                    break;
                case "5":
                    ToLiveDay();
                    ShowMortalityInfo();
                    break;
                case "6":
                    isWork = false;
                    break;
                default:
                    ToLiveDay();
                    ShowMortalityInfo();
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }

        public void AddFish(Fish fish)
        {
            if (_fishes.Count == _maxFishesAmount)
            {
                Console.WriteLine("В аквариуме максимальное число рыб.");
                return;
            }
            _fishes.Add(fish);
        }

        public void RemoveFish(Fish fish)
        {
            if (_fishes.Remove(fish))
            {
                Console.WriteLine("Рыба удалена");
            }
            else
            {
                Console.WriteLine("Такой рыбы нет");
            }
        }

        public void RemoveFish(int index)
        {
            try
            {
                _fishes.RemoveAt(index - 1);
                Console.WriteLine("Рыба удалена");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Такой рыбы нет.");
            }
        }

        public void FillAquarium()
        {
            int fishesAmount = _rand.Next(1, _maxFishesAmount + 1);
            for (var i = 0; i < fishesAmount; i++)
            {
                AddFish(new Fish("fish" + i));
            }
            Console.WriteLine("Аквариум успешно заполнен.");
        }

        public void ClearAquarium()
        {
            _fishes.Clear();
            Console.WriteLine("Аквариум успешно очищен.");
        }

        public void ToLiveDay()
        {
            Console.WriteLine("Ход окончен.");
            foreach (var fish in _fishes)
            {
                fish.Grow();
            }
        }

        public void ShowInfo()
        {
            int index = 1;

            if (_fishes.Count == 0)
            {
                Console.WriteLine("Рыб нет.");
                return;
            }

            foreach (var fish in _fishes)
            {
                fish.ShowInfo(index);
                index++;
            }
        }

        public void ShowMortalityInfo()
        {
            for (var i = 0; i < _fishes.Count; i++)
            {
                foreach (var fish in _fishes)
                {
                    if (fish.IsAlive == false)
                    {
                        RemoveFish(fish);
                        fish.ShowInfo();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Умерла");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    }
                }
            }
        }
    }

    class Fish
    {
        private static Random _rand = new Random();

        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsAlive { get; private set; }

        public Fish(string name)
        {
            Name = name;
            Age = 0;
            IsAlive = true;
        }

        public void Grow()
        {
            Age++;
            IsAlive = TryToAlive();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Age}");
        }

        public void ShowInfo(int index)
        {
            Console.WriteLine($"{index}) {Name} - {Age}");
        }

        public bool TryToAlive()
        {
            int deathRate = (int)Math.Pow(Age, 2) + _rand.Next(0, 101);
            if (deathRate > 100)
            {
                return false;
            }    

            return true;
        }
    }
}
