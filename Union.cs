using System;
using System.Collections.Generic;
using System.Linq;

namespace Union
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Transfer();
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Soldier> _soldiers1;
        private List<Soldier> _soldiers2;

        public Database()
        {
            _soldiers1 = new List<Soldier>();
            _soldiers2 = new List<Soldier>();

            for (var i = 0; i < 30; i++)
            {
                string name = Convert.ToChar(_rand.Next(65, 70)) + "name" + i;

                if (i % 2 == 0)
                    _soldiers1.Add(new Soldier(name));
                else
                    _soldiers2.Add(new Soldier(name));
            }
        }

        public void Transfer()
        {
            var soldiers = _soldiers1.Where(soldier => soldier.Name.StartsWith("B")).Union(_soldiers2);
            ShowDatabase(soldiers);
        }

        public void ShowDatabase(IEnumerable<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name}");
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}
