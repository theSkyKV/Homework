using System;
using System.Collections.Generic;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();
            terminal.OpenTerminal();

            while (terminal.isOpen)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Информация о текущем рейсе отсутствует.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, 5);

                terminal.SetRoute();
                terminal.SellTickets();
                terminal.CreateTrain();
                terminal.GetTrainAway();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Нажмите любую кнопку, чтобы создать новый маршрут или 'q' для выхода...");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    terminal.CloseTerminal();
                }
            }
        }
    }

    class Terminal
    {
        private Random _rand = new Random();
        private string _departure;
        private string _destination;
        private int _passengersNumber;
        private int _seatsNumberRequired;

        public Train Train { get; private set; }
        public bool isOpen { get; private set; }

        public void OpenTerminal()
        {
            isOpen = true;
        }

        public void CloseTerminal()
        {
            isOpen = false;
        }

        public void SetRoute()
        {
            Console.WriteLine("Введите пункт отправления:");
            _departure = Console.ReadLine();
            Console.WriteLine("Введите пункт назначения:");
            _destination = Console.ReadLine();
        }

        public void SellTickets()
        {
            _passengersNumber = _rand.Next(50, 500);
        }

        public void CreateTrain()
        {
            Train = new Train(_departure, _destination, _passengersNumber);

            _seatsNumberRequired = _passengersNumber;

            while (_seatsNumberRequired > 0)
            {
                int seatsNumber = _rand.Next(20, 80);
                Carriage carriage = new Carriage(seatsNumber);
                Train.AddCarriage(carriage);
                _seatsNumberRequired -= seatsNumber;
            }
        }

        public void GetTrainAway()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Train.ShowTrainInfo();
        }
    }

    class Train
    {
        private List<Carriage> _carriages = new List<Carriage>();

        public string Departure { get; private set; }
        public string Destination { get; private set; }
        public int PassengersNumber { get; private set; }

        public Train(string departure, string destination, int passengersNumber)
        {
            Departure = departure;
            Destination = destination;
            PassengersNumber = passengersNumber;
        }

        public void AddCarriage(Carriage carriage)
        {
            _carriages.Add(carriage);
        }

        public void ShowTrainInfo()
        {
            Console.WriteLine($"Поезд: {Departure} - {Destination} (вагонов: {_carriages.Count} шт.)");
            Console.WriteLine($"Куплено билетов на поезд: {PassengersNumber} шт.");
        }
    }

    class Carriage
    {
        public int SeatsNumder { get; private set; }

        public Carriage(int seatsNumder)
        {
            SeatsNumder = seatsNumder;
        }
    }
}
