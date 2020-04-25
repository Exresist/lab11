using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    public sealed class Administration : Person, ICloneable
    {
        // Тип компании, в которой работает сотрудник администрации
        public string CompanyType;

        // Конструктор класса без параметров
        public Administration()
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

            CompanyType = "Завод";
        }

        // Конструктор класса с параметрами
        public Administration(string name, string surname, string patronymic, DateTime dateOfBirth, string gender,
            int experience, string companyType)
            : base(name, surname, patronymic, dateOfBirth, gender, experience)
        {
            CompanyType = companyType;
        }

        public Person BasePerson => new Person(Name, Surname, Patronymic, DateOfBirth, Gender, Experience);

        // Метод класса, позволяющий поверхостное копирование
        public Administration ShallowCopy()
        {
            return (Administration) MemberwiseClone();
        }

        // Метод класса, позволяющий клонировать объект Administration
        public object Clone()
        {
            return new Administration("Клон " + Name, Surname, Patronymic, DateOfBirth, Gender, Experience,
                CompanyType);
        }

        // Метод наследуемого класса показывающий информацию о Administration
        public override void Show()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic}:");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Дата рождения - {DateOfBirth.Day}.{DateOfBirth.Month}.{DateOfBirth.Year};");
            Console.WriteLine($"Пол - {Gender};\nСтаж - {Experience}.");
            Console.WriteLine($"Имя компании - {CompanyType}");
            Console.WriteLine("------------------------------");
        }

        // Метод наследуемого класса создающий информацию о Administrarion
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

            Console.Write("Введите тип компании, в которой работает сотрудник администрации: ");
            CompanyType = Console.ReadLine();
        }

        // Метод наследуемого класса, который проверяет, принадлежит ли Administration заданной компании
        public bool Search(object search)
        {
            if (search is string searchCompanyType)
            {
                return CompanyType == searchCompanyType;
            }

            return false;
        }
    }
}