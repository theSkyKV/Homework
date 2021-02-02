using System;
using System.Collections.Generic;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium(10);
            GameMenu gameMenu = new GameMenu(aquarium);
            bool isWork = true;

            while (isWork)
            {
                gameMenu.ShowMenu(ref isWork);
            }
        }
    }

    class GameMenu
    {
        private Aquarium _aquarium;
        private string userInput;

        public GameMenu(Aquarium aquarium)
        {
            _aquarium = aquarium;
        }

        public void ShowMenu(ref bool isWork)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сейчас в акввариуме:");
            _aquarium.ShowInfo();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ввыберите действие:");
            Console.WriteLine("1 - Заполнить аквариум (с удалением текущего), 2 - Очистить аквариум, 3 - Добавить рыбу,");
            Console.WriteLine("4 - Удалить рыбу, 5 - Закончить ход, 6 - Выход");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    _aquarium.ClearAquarium();
                    _aquarium.FillAquarium();
                    Console.WriteLine("Аквариум успешно заполнен.");
                    break;
                case "2":
                    _aquarium.ClearAquarium();
                    Console.WriteLine("Аквариум успешно очищен.");
                    break;
                case "3":
                    Console.WriteLine("Введите название рыбы:");
                    _aquarium.AddFish(new Fish(Console.ReadLine()));
                    break;
                case "4":
                    Console.WriteLine("Введите индекс рыбы:");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        _aquarium.RemoveFish(index);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                    break;
                case "5":
                    _aquarium.EndMove();
                    _aquarium.ShowMortalityInfo();
                    break;
                case "6":
                    isWork = false;
                    break;
                default:
                    _aquarium.EndMove();
                    _aquarium.ShowMortalityInfo();
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }
    }

    class Aquarium
    {
        private Random _rand;
        private List<Fish> _fishes;

        public int MaxFishesAmount { get; private set; }
        public int CurrentFishesAmount
        {
            get
            {
                return _fishes.Count;
            }
        }

        public Aquarium(int maxFishesAmount)
        {
            _fishes = new List<Fish>();
            _rand = new Random();
            MaxFishesAmount = maxFishesAmount;
        }

        public void AddFish(Fish fish)
        {
            if (_fishes.Count == MaxFishesAmount)
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
            int fishesAmount = _rand.Next(1, MaxFishesAmount + 1);
            for (var i = 0; i < fishesAmount; i++)
            {
                AddFish(new Fish("fish" + i));
            }
        }

        public void ClearAquarium()
        {
            _fishes.RemoveRange(0, _fishes.Count);
        }

        public void EndMove()
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

            if (CurrentFishesAmount == 0)
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
            int deathRate = _rand.Next(0, 100);
            if (Age < 5)
            {
                if (deathRate < 10)
                {
                    return false;
                }
            }
            else if (Age >= 5 & Age < 10)
            {
                if (deathRate < 30)
                {
                    return false;
                }
            }
            else
            {
                if (deathRate < 70)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
