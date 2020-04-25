using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    // Класс рабочий
    public class Worker : Person, ICloneable, IPerson, IComparer, IComparable
    {
        public int WorkshopNumber; // Номер цеха
        public string Profession; // Профессия

        // Конструктор класса без параметров
        public Worker()
        {
            List<string> ManName = new List<string>()
                {"Андрей", "Олег", "Василий", "Дмитрий", "Николай"};

            List<string> ManFamily = new List<string>()
                {"Попов", "Иванов", "Сидоров", "Петров", "Кузнецов"};

            List<string> ManPatronymic = new List<string>()
                {"Андреевич", "Олегович", "Васильевич", "Дмитриевич", "Николаевич"};

            List<string> WomanName = new List<string>()
                {"Ольга", "Светлана", "Елена", "Ксения", "Екатерина"};

            List<string> WomanFamily = new List<string>()
                {"Попова", "Иванова", "Сидорова", "Петрова", "Кузнецова"};

            List<string> WomanPatronymic = new List<string>()
                {"Андреевна", "Олеговна", "Васильевна", "Дмитриевна", "Николаевна"};

            Random random = new Random();

            int gender = random.Next(0, 1);

            if (gender == 0)
            {
                Gender = "Мужской";
            }
            else
            {
                Gender = "Женский";
            }

            if (Gender == "Мужской")
            {
                int pos = random.Next(0, ManName.Count);
                Name = ManName[pos];

                pos = random.Next(0, ManFamily.Count);
                Surname = ManFamily[pos];

                pos = random.Next(0, ManPatronymic.Count);
                Patronymic = ManPatronymic[pos];
            }
            else
            {
                int pos = random.Next(0, WomanName.Count);
                Name = WomanName[pos];

                pos = random.Next(0, WomanFamily.Count);
                Surname = WomanFamily[pos];

                pos = random.Next(0, WomanPatronymic.Count);
                Patronymic = WomanPatronymic[pos];
            }

            WorkshopNumber = random.Next(1, 10);
            Profession = "Рабочий";
        }

        // Конструктор класса с параметрами
        public Worker(string name, string surname, string patronymic, DateTime dateOfBirth, string gender,
            int experience, int workshopNumber, string profession)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Experience = experience;
            WorkshopNumber = workshopNumber;
            Profession = profession;
        }

        public Person BasePerson => new Person(Name, Surname, Patronymic, DateOfBirth, Gender, Experience);

        // Метод класса, позволяющий поверхостное копирование
        public Worker ShallowCopy()
        {
            return (Worker) MemberwiseClone();
        }

        // Метод класса, позволяющий клонировать объект Worker
        public object Clone()
        {
            return new Worker("Клон " + Name, Surname, Patronymic, DateOfBirth,
                Gender, Experience, WorkshopNumber, Profession);
        }

        // Метод наследуемого класса показывающий информацию о Worker
        public override void Show()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic}:");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Дата рождения - {DateOfBirth.Day}.{DateOfBirth.Month}.{DateOfBirth.Year};");
            Console.WriteLine($"Пол - {Gender};\nСтаж - {Experience};");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Место работы:");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Номер цеха - {WorkshopNumber};");
            Console.WriteLine($"Профессия - {Profession}.");
        }

        // Метод наследуемого класса создающий информацию о Worker
        public override void Create()
        {
            Console.Write("Введите имя: ");
            Name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            Surname = Console.ReadLine();
            Console.Write("Введите отчество: ");
            Patronymic = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");

            Console.Write("Введите День: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Введите Месяц: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Введите Год: ");
            int year = int.Parse(Console.ReadLine());

            DateOfBirth = new DateTime(year, month, day);

            Console.Write("Введите гендер (пол): ");
            Gender = Console.ReadLine();
            Console.Write("Введите стаж (в лет): ");
            Experience = int.Parse(Console.ReadLine());
            Console.Write("Введите номер цеха: ");
            WorkshopNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите должность: ");
            Profession = Console.ReadLine();
        }

        // Метод наследуемого класса, который проверяет, принадлежит ли Worker заданному цеху
        public bool Search(object search)
        {
            if (!(search is int searchWorkshopNumber)) return false;
            return WorkshopNumber == searchWorkshopNumber;
        }
    }
}