using System;
using System.Collections.Generic;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            bool isWork = true;
            string userInput;

            while (isWork)
            {
                Player player;
                string name;
                int level;

                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить игрока, 2 - Удалить игрока, 3 - Забанить игрока");
                Console.WriteLine("4 - Разбанить игрока, 5 - Показать базу данных, 6 - Выход");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Введите имя игрока:");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите уровень игрока:");
                        if (int.TryParse(Console.ReadLine(), out level))
                        {
                            player = new Player(name, level);
                        }
                        else
                        {
                            player = new Player(name);
                        }
                        database.AddPlayer(player);
                        break;
                    case "2":
                        TryToAct(database.DeletePlayer);
                        break;
                    case "3":
                        TryToAct(database.BanPlayer);
                        break;
                    case "4":
                        TryToAct(database.UnbanPlayer);
                        break;
                    case "5":
                        database.ShowList();
                        break;
                    case "6":
                        Console.WriteLine("До встречи!");
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey(true);
            }
        }

        private static void TryToAct(Action<int> action)
        {
            int id;
            Console.WriteLine("Введите ID игрока:");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                action(id);
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; set; }

        public Player(string name, int level = 1)
        {
            Name = name;
            Level = level;
            IsBanned = false;
        }
    }

    class Database
    {
        private Dictionary<int, Player> _database = new Dictionary<int, Player>();
        private int _playerId = 1;

        public void AddPlayer(Player player)
        {
            _database.Add(_playerId, player);
            Console.WriteLine("Игрок успешно добавлен.");
            _playerId++;
        }

        public void DeletePlayer(int id)
        {
            if (_database.ContainsKey(id))
            {
                _database.Remove(id);
                Console.WriteLine("Игрок успешно удален.");
            }
            else
            {
                Console.WriteLine("Игрок не найден.");
            }
        }

        public void BanPlayer(int id)
        {
            if (_database.ContainsKey(id))
            {
                if (_database[id].IsBanned)
                {
                    Console.WriteLine("Игрок уже забанен.");
                    return;
                }
                _database[id].IsBanned = true;
                Console.WriteLine("Игрок успешно забанен.");
            }
            else
            {
                Console.WriteLine("Игрок не найден.");
            }
        }

        public void UnbanPlayer(int id)
        {
            if (_database.ContainsKey(id))
            {
                if (!_database[id].IsBanned)
                {
                    Console.WriteLine("Игрок и так не забанен.");
                    return;
                }
                _database[id].IsBanned = false;
                Console.WriteLine("Игрок успешно разбанен.");
            }
            else
            {
                Console.WriteLine("Игрок не найден.");
            }
        }

        public void ShowList()
        {
            foreach (var element in _database)
            {
                Console.WriteLine($"{element.Key} {element.Value.Name} {element.Value.Level} {element.Value.IsBanned}");
            }
        }
    }
}
