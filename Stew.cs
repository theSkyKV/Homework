using System;
using System.Collections.Generic;
using System.Linq;

namespace Stew
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.GetExpiredProduct(2021);
        }
    }

    class Warehouse
    {
        private static Random _rand = new Random();
        private List<Stew> _stews;

        public Warehouse()
        {
            _stews = new List<Stew>();

            for (var i = 0; i < 30; i++)
            {
                string name = Convert.ToChar(_rand.Next(65, 91)) + "name" + i;
                int productionYear = _rand.Next(2000, 2021);
                int shelfLife = _rand.Next(5, 25);
                _stews.Add(new Stew(name, productionYear, shelfLife));
            }
        }

        public void GetExpiredProduct(int currentYear)
        {
            var expiredStews = _stews.Where(stew => stew.ProductionYear + stew.ShelfLife <= currentYear);

            if (expiredStews.Count() > 0)
            {
                ShowWarehouse(expiredStews);
            }
            else
            {
                Console.WriteLine("Продуктов с истекшим сроком годности нет");
            }
        }

        public void ShowWarehouse(IEnumerable<Stew> stews)
        {
            foreach (var stew in stews)
            {
                Console.WriteLine($"{stew.Name} | {stew.ProductionYear} | {stew.ShelfLife}");
            }
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ShelfLife { get; private set; }

        public Stew(string name, int productionYear, int shelfLife)
        {
            Name = name;
            ProductionYear = productionYear;
            ShelfLife = shelfLife;
        }
    }
}
