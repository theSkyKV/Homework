using System;
using System.Collections.Generic;

namespace AutoService
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            AutoService autoService = new AutoService();

            while (isOpen)
            {
                autoService.Work(ref isOpen);
            }
        }
    }

    class AutoService
    {
        private static Random _rand = new Random();
        private Warehouse _warehouse;
        private int _accountBalance;
        private Car _carInService = null;

        public AutoService()
        {
            _warehouse = new Warehouse();
            _accountBalance = 1000;
        }

        public void Work(ref bool isOpen)
        {

            Console.Clear();
            Console.WriteLine($"Денег на счету: {_accountBalance} $");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Следующая машина, 2 - Заменить нужную деталь, 3 - Поставить другую деталь");
            Console.WriteLine("4 - Показать детали на складе, 5 - Оплатить неустойку, 6 - Закрыть сервис.");
            if (_carInService != null)
            {
                _carInService.ShowInfo();
            }
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        if (_carInService == null)
                        {
                            _carInService = new Car();
                        }
                        else
                        {
                            Console.WriteLine("Сначала закончите с предыдущим клиентом.");
                        }
                        break;
                    case 2:
                        if (_carInService == null)
                        {
                            Console.WriteLine("Нет машины для обслуживания");
                            break;
                        }

                        bool isReplace = _warehouse.UseDetail(_carInService.BrokenDetailId, 1);
                        if (isReplace)
                        {
                            Console.WriteLine("Деталь заменена. Клиент доволен.");
                            var detail = _warehouse.GetDetailById(_carInService.BrokenDetailId);
                            _accountBalance += detail.DetailPrice + detail.WorkPrice;
                            _carInService = null;
                        }
                        break;
                    case 3:
                        if (_carInService == null)
                        {
                            Console.WriteLine("Нет машины для обслуживания");
                            break;
                        }

                        _warehouse.UseDetail(_rand.Next(0, _warehouse.DetailsTypeAmount + 1), 1);
                        if (PayFine(1000))
                        {
                            Console.WriteLine("Клиент не доволен.");
                            _carInService = null;
                        }
                        else
                        {
                            Console.WriteLine("У вас нет денег для оплаты неустойки. Вы банкрот");
                            isOpen = false;
                        }
                        break;
                    case 4:
                        _warehouse.ShowInfo();
                        break;
                    case 5:
                        if (_carInService == null)
                        {
                            Console.WriteLine("Нет машины для обслуживания");
                            break;
                        }

                        PayFine(500);
                        _carInService = null;
                        break;
                    case 6:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }

        public bool PayFine(int fine)
        {
            if (fine < 0)
            {
                Console.WriteLine("Некорректая сумма штрафа.");
                return false;
            }

            if (_accountBalance >= fine)
            {
                Console.WriteLine("Вы откупились от клиента деньгами.");
                _accountBalance -= fine;
                return true;
            }
            else
            {
                Console.WriteLine("У вас недостаточно денег, чтобы оплатить штраф.");
                return false;
            }
        }
    }

    class Car
    {
        private static Random _rand = new Random();

        public int BrokenDetailId { get; private set; }

        public Car()
        {
            BrokenDetailId = _rand.Next(0, 15);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Сломана деталь {BrokenDetailId}");
        }
    }

    class Warehouse
    {
        private List<Detail> _details;

        public int DetailsTypeAmount
        {
            get
            {
                return _details.Count;
            }
        }

        public Warehouse()
        {
            _details = new List<Detail>();
            for (var i = 0; i < 10; i++)
            {
                AddDetail();
            }
        }

        public void AddDetail(int id = -1, int amount = 0)
        {
            foreach (var detail in _details)
            {
                if (detail.Id == id)
                {
                    detail.Add(amount);
                    return;
                }
            }

            _details.Add(new Detail());
        }

        public bool UseDetail(int id, int amount)
        {
            foreach (var detail in _details)
            {
                if (detail.Id == id)
                {
                    detail.Remove(amount);
                    return true;
                }
            }
            Console.WriteLine("Такой детали на складе нет.");
            return false;
        }

        public Detail GetDetailById(int id)
        {
            return _details[id];
        }

        public void ShowInfo()
        {
            foreach (var detail in _details)
            {
                Console.WriteLine($"{detail.Id} | {detail.Name} | {detail.DetailPrice} | {detail.WorkPrice} | {detail.Amount}");
            }
        }
    }

    class Detail
    {
        private static Random _rand = new Random();
        private static int _id = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int DetailPrice { get; private set; }
        public int WorkPrice { get; private set; }
        public int Amount { get; private set; }

        public Detail()
        {
            Id = _id++;
            Name = "Detail" + Id;
            DetailPrice = _rand.Next(30, 200);
            WorkPrice = _rand.Next(20, 70);
            Amount = _rand.Next(5, 15);
        }

        public void Add(int amount)
        {
            Amount += amount;
        }

        public void Remove(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Неверное количество деталей.");
                return;
            }

            if (Amount >= amount)
            {
                Amount -= amount;
            }
            else
            {
                Console.WriteLine("В таком количестве детали отсутствуют.");
            }
        }
    }
}
