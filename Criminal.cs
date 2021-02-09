using System;
using System.Collections.Generic;
using System.Linq;

namespace Criminal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            Database database = new Database();
            
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Введите рост, см:");
                if (int.TryParse(Console.ReadLine(), out int height) == false)
                {
                    continue;
                }
                Console.WriteLine("Введите вес, кг:");
                if (int.TryParse(Console.ReadLine(), out int weight) == false)
                {
                    continue;
                }
                Console.WriteLine("Введите национальность:");
                string nationaliny = Console.ReadLine();

                Console.Clear();
                Console.WriteLine($"Рост >= {height} | Вес >= {weight} | Национальность - {nationaliny}:");
                database.MakeRequest(height, weight, nationaliny);

                Console.WriteLine("Нажмите любую клавишу для продолжения или q для выхода.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Удачи в поимке преступника!");
                    isWork = false;
                }
            }
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Criminal> _criminals;
        private List<string> _nationalities;

        public Database()
        {
            _criminals = new List<Criminal>();
            _nationalities = new List<string> { "Русский", "Украинец", "Белорус", "Казах" };

            for (var i = 0; i < 200; i++)
            {
                string name = "Name" + i;
                bool isArrest = Convert.ToBoolean(_rand.Next(0, 2));
                int height = _rand.Next(170, 190);
                int weight = _rand.Next(70, 90);
                string nationality = _nationalities[_rand.Next(0, _nationalities.Count)];
                _criminals.Add(new Criminal(name, isArrest, height, weight, nationality));
            }
        }

        public void MakeRequest(int height, int weight, string nationality)
        {
            var criminals = from Criminal criminal in _criminals
                            where criminal.Height >= height &
                                  criminal.Weight >= weight &
                                  criminal.Nationality.ToLower() == nationality.ToLower() &
                                  criminal.IsArrest == false
                            select criminal;

            if (criminals.Count() > 0)
            {
                ShowDatabase(criminals);
            }
            else
            {
                Console.WriteLine("Нет данных для отображения.");
            }
        }

        public void ShowDatabase(IEnumerable<Criminal> criminals)
        {
            foreach (var criminal in criminals)
            {
                Console.WriteLine($"{criminal.Name} | {criminal.IsArrest} | {criminal.Height} | {criminal.Weight} | {criminal.Nationality}");
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public bool IsArrest { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string name, bool isArrest, int height, int weight, string nationality)
        {
            Name = name;
            IsArrest = isArrest;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
    }
}
