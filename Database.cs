using System;
using System.Collections.Generic;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Canvas canvas = new Canvas();
            Database database = new Database();
            canvas.Render(database);
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string name, int level = 1)
        {
            Name = name;
            Level = level;
            IsBanned = false;
        }

        public void BanOrUnban()
        {
            IsBanned = !IsBanned;
        }
    }

    class Database
    {
        private Dictionary<int, Player> _database = new Dictionary<int, Player>();
        private int _playerId = 1;
        public enum State
        {
            Unbanned,
            Banned
        }

        public enum Action
        {
            Unban,
            Ban
        }

        public void AddPlayer()
        {
            Player player;
            string name;
            int level;

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

        public void BanOrUnban(int id, Action action)
        {
            if (_database.ContainsKey(id))
            {
                State state = (State)Convert.ToInt32(_database[id].IsBanned);
                if ((int)state != (int)action)
                {
                    _database[id].BanOrUnban();
                }
                else
                {
                    Console.WriteLine("Некорректное действие.");
                }
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
                Console.WriteLine($"{element.Key} | {element.Value.Name} | {element.Value.Level} | {element.Value.IsBanned}");
            }
        }
    }

    class Canvas
    {
        public void Render(Database database)
        {
            bool isWork = true;
            string userInput;

            while (isWork)
            {
                int id;

                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить игрока, 2 - Удалить игрока, 3 - Забанить игрока");
                Console.WriteLine("4 - Разбанить игрока, 5 - Показать базу данных, 6 - Выход");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        database.AddPlayer();
                        break;
                    case "2":
                        Console.WriteLine("Введите ID игрока:");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            database.DeletePlayer(id);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите ID игрока:");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            database.BanOrUnban(id, Database.Action.Ban);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Введите ID игрока:");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            database.BanOrUnban(id, Database.Action.Unban);
                        }
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
    }
}
