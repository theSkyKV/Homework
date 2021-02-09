using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            Database database = new Database();

            while (isOpen)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Отсортировать по имени, 2 - Отсортировать по возрасту");
                Console.WriteLine("3 - Вывести больных с определенным заболеванием, 4 - Выйти");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        database.SortByName();
                        break;
                    case "2":
                        database.SortByAge();
                        break;
                    case "3":
                        Console.WriteLine("Введите название болезни:");
                        database.GetPatientsByDisease(Console.ReadLine());
                        break;
                    case "4":
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey(true);
            }
        }
    }

    class Database
    {
        private static Random _rand = new Random();
        private List<Patient> _patients;
        private List<string> _diseases;

        public Database()
        {
            _patients = new List<Patient>();
            _diseases = new List<string>() { "Язва", "Рак", "Пневмония", "Перелом" };

            for (var i = 0; i < 30; i++)
            {
                string name = Convert.ToChar(_rand.Next(65, 91)) + "name" + i;
                int age = _rand.Next(15, 60);
                string disease = _diseases[_rand.Next(0, _diseases.Count)];
                _patients.Add(new Patient(name, age, disease));
            }
        }

        public void SortByName()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Name);
            ShowDatabase(sortedPatients);
        }

        public void SortByAge()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Age);
            ShowDatabase(sortedPatients);
        }

        public void GetPatientsByDisease(string disease)
        {
            var patients = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower());

            if (patients.Count() > 0)
            {
                ShowDatabase(patients);
            }
            else
            {
                Console.WriteLine("Пациентов с таким заболеванием нет");
            }
        }

        public void ShowDatabase(IEnumerable<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Name} | {patient.Age} | {patient.Disease}");
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}
