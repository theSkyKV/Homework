using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("До амнистии:");
            database.ShowDatabase();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("После амнистии:");
            database.MakeAmnesty();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Criminal> _criminals;
        private List<string> _crimes;

        public Database()
        {
            _criminals = new List<Criminal>();
            _crimes = new List<string>() { "Кража", "Убийство", "Мошенничество", "Антиправительственное"};

            for (var i = 0; i < 30; i++)
            {
                string name = "Name" + i;
                string crime = _crimes[_rand.Next(0, _crimes.Count)];
                _criminals.Add(new Criminal(name, crime));
            }
        }

        public void MakeAmnesty()
        {
            var criminals = from Criminal criminal in _criminals
                            where criminal.Crime != "Антиправительственное"
                            select criminal;

            ShowDatabase(criminals);
        }

        public void ShowDatabase(IEnumerable<Criminal> criminals)
        {
            foreach (var criminal in criminals)
            {
                Console.WriteLine($"{criminal.Name} - {criminal.Crime}");
            }
        }

        public void ShowDatabase()
        {
            foreach (var criminal in _criminals)
            {
                Console.WriteLine($"{criminal.Name} - {criminal.Crime}");
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }
        
        public Criminal(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}
