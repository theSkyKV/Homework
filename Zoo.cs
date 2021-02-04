using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            bool isOpen = true;
            
            while (isOpen)
            {
                zoo.VisitZoo(ref isOpen);
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;

        public Zoo()
        {
            _aviaries = new List<Aviary>();
            CreateAviary<Tiger>();
            CreateAviary<Wolf>();
            CreateAviary<Bear>();
            CreateAviary<Elephant>();
        }

        public void CreateAviary<T>() where T : Animal, new()
        {
            _aviaries.Add(new Aviary());
            _aviaries[_aviaries.Count - 1].FillAviary<T>();
        }

        public void VisitZoo(ref bool isOpen)
        {
            Console.Clear();
            ShowInfo();
            Console.WriteLine("Введите номер вольера, к которому хотите подойти или любую клавишу, чтобы покинуть зоопарк.");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                try
                {
                    _aviaries[userInput - 1].ShowInfo();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Такого вольера нет.");
                }
            }
            else
            {
                Console.WriteLine("Спасибо за визит!");
                isOpen = false;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }

        public void ShowInfo()
        {
            for (var i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"Вольер № {i + 1}. Животное в вольере - {_aviaries[i].AnimalName}");
            }
        }
    }

    class Aviary
    {
        private static Random _rand = new Random();
        private List<Animal> _animals;
        private string _animalSound;

        public string AnimalName { get; private set; }

        public Aviary()
        {
            _animals = new List<Animal>();
        }

        public void FillAviary<T>() where T : Animal, new()
        {
            for (var i = 0; i < _rand.Next(1, 10); i++)
            {
                _animals.Add(new T());
            }
            AnimalName = _animals[0].Name;
            _animalSound = _animals[0].Sound;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Животное в вольере - {AnimalName}. Количество - {_animals.Count}. Звук - {_animalSound}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Name} {animal.Sex}");
            }
        }
    }

    abstract class Animal
    {
        protected static Random Rand = new Random();

        public abstract string Name { get; }
        public abstract string Sound { get; }
        public AnimalSex Sex { get; protected set; }

        public enum AnimalSex
        {
            Male,
            Female
        }
    }

    class Tiger : Animal
    {
        public override string Name
        {
            get
            {
                return "Тигр";
            }
        }
        public override string Sound
        {
            get
            {
                return "Р-р-р";
            }
        }

        public Tiger()
        {
            Sex = (AnimalSex)Rand.Next(0, 2);
        }
    }

    class Wolf : Animal
    {
        public override string Name
        {
            get
            {
                return "Волк";
            }
        }
        public override string Sound
        {
            get
            {
                return "Ау-у-у";
            }
        }

        public Wolf()
        {
            Sex = (AnimalSex)Rand.Next(0, 2);
        }
    }

    class Bear : Animal
    {
        public override string Name
        {
            get
            {
                return "Медведь";
            }
        }
        public override string Sound
        {
            get
            {
                return "Р-р-р";
            }
        }

        public Bear()
        {
            Sex = (AnimalSex)Rand.Next(0, 2);
        }
    }

    class Elephant : Animal
    {
        public override string Name
        {
            get
            {
                return "Слон";
            }
        }
        public override string Sound
        {
            get
            {
                return "У-у-у";
            }
        }

        public Elephant()
        {
            Sex = (AnimalSex)Rand.Next(0, 2);
        }
    }
}
