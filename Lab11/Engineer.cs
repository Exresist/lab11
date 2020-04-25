using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    public sealed class Engineer : Person, ICloneable, IPerson, IComparer, IComparable
    {
        public int GuildNum; // Номер подразделения

        // Конструктор класса без параметров
        public Engineer()
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
            GuildNum = random.Next(1,10);
        }

        // Конструктор класса с параметрами
        public Engineer(string name, string surname, string patronymic, DateTime dateOfBirth, string gender, int experience, int guildNum)
            :base(name,surname,patronymic,dateOfBirth,gender,experience)
        {
            GuildNum = guildNum;
        }

        public Person BasePerson => new Person(Name, Surname, Patronymic, DateOfBirth, Gender, Experience);

        // Метод класса, позволяющий поверхостное копирование
        public Engineer ShallowCopy()
        {
            return (Engineer)MemberwiseClone();
        }

        // Метод класса, позволяющий клонировать объект Engineer
        public object Clone()
        {
            return new Engineer("Клон " + Name, Surname, Patronymic, DateOfBirth,
                Gender, Experience, GuildNum);
        }

        // Метод наследуемого класса показывающий информацию о Engineer
        public override void Show()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic}:");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Дата рождения - {DateOfBirth.Day}.{DateOfBirth.Month}.{DateOfBirth.Year};");
            Console.WriteLine($"Пол - {Gender};\nСтаж - {Experience}.");
            Console.WriteLine($"Номер подразделения - {GuildNum}");
            Console.WriteLine("------------------------------");
        }

        // Метод наследуемого класса, создающий информацию о Engineer
        public override void Create()
        {
            Console.Write("Введите имя: "); Name = Console.ReadLine();
            Console.Write("Введите фамилию: "); Surname = Console.ReadLine();
            Console.Write("Введите отчество: "); Patronymic = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");

            Console.Write("Введите День: "); int day = int.Parse(Console.ReadLine());
            Console.Write("Введите Месяц: "); int month = int.Parse(Console.ReadLine());
            Console.Write("Введите Год: "); int year = int.Parse(Console.ReadLine());

            DateOfBirth = new DateTime(year, month, day);

            Console.Write("Введите гендер (пол): "); Gender = Console.ReadLine();
            Console.Write("Введите стаж (в лет): "); Experience = int.Parse(Console.ReadLine());

            Console.Write("Введите номер подразделения: "); GuildNum = int.Parse(Console.ReadLine());
        }

        // Метод наследуемого класса, который проверяет, принадлежит ли Engineer заданному подразделению
        public bool Search(object search)
        {
            if (search is int searchGuildNum)
            {
                return GuildNum == searchGuildNum;
            }

            return false;
        }
    }
}