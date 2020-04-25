using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    public class Person : IPerson, IComparer, IComparable
    {
        public int CompareTo(object o)
        {
            if (o is Person person)
                return DateOfBirth.CompareTo(person.DateOfBirth);
            throw new Exception("Невозможно сравнить два объекта");
        }

        public int Compare(object o1, object o2)
        {
            Person p1 = o1 as Person;
            Person p2 = o2 as Person;
            int p1Age = p1.Age();
            int p2Age = p2.Age();
            if (p1Age > p2Age)
                return 1;
            if (p1Age < p2Age)
                return -1;
            return 0;
        }

        // Структура "Полное ИМЯ (ФИО)"
        protected String Name; // Имя
        protected String Surname; // Фамилия
        protected String Patronymic; // Отчество
        public DateTime DateOfBirth; // Дата рождения
        public string Gender; // Пол
        public int Experience; // Стаж

        // Конструктор класса без параметров
        protected Person()
        {
            List<string> ManName = new List<string> {"Андрей", "Олег", "Василий", "Дмитрий", "Николай"};

            List<string> ManFamily = new List<string> {"Попов", "Иванов", "Сидоров", "Петров", "Кузнецов"};

            List<string> ManPatronymic = new List<string>
                {"Андреевич", "Олегович", "Васильевич", "Дмитриевич", "Николаевич"};

            List<string> WomanName = new List<string> {"Ольга", "Светлана", "Елена", "Ксения", "Екатерина"};

            List<string> WomanFamily = new List<string> {"Попова", "Иванова", "Сидорова", "Петрова", "Кузнецова"};

            List<string> WomanPatronymic = new List<string>
                {"Андреевна", "Олеговна", "Васильевна", "Дмитриевна", "Николаевна"};

            Random random = new Random();

            int gender = random.Next(0, 1);

            Gender = gender == 0 ? "Мужской" : "Женский";

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
                Patronymic = ManPatronymic[pos];
            }

            DateOfBirth = new DateTime(random.Next(1940, 1990), random.Next(1, 12), random.Next(1, 28));
            Experience = random.Next(0, 10);
        }

        // Конструктор класса с параметрами
        public Person(string name, string surname, string patronymic, DateTime dateOfBirth, string gender,
            int experience)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Experience = experience;
        }
        public Person BasePerson => new Person(Name, Surname, Patronymic, DateOfBirth, Gender, Experience);

        // Метод класса, который вычисляет возраст персоны в зависимости от текущей даты и дня рождения
        public int Age()
        {
            DateTime date = DateTime.Now;
            return date.Year - DateOfBirth.Year;
        }

        // Виртуальный метод класса, показывающий информацию о Person


        public virtual void Show()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic}:");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Дата рождения - {DateOfBirth.Day}.{DateOfBirth.Month}.{DateOfBirth.Year};");
            Console.WriteLine($"Пол - {Gender};\nСтаж - {Experience}.");
            Console.WriteLine("------------------------------");
        }

        public bool Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Create()
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
        }


        public int CompareTo(Person other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            var surnameComparison = string.Compare(Surname, other.Surname, StringComparison.Ordinal);
            if (surnameComparison != 0) return surnameComparison;
            var patronymicComparison = string.Compare(Patronymic, other.Patronymic, StringComparison.Ordinal);
            if (patronymicComparison != 0) return patronymicComparison;
            var dateOfBirthComparison = DateOfBirth.CompareTo(other.DateOfBirth);
            if (dateOfBirthComparison != 0) return dateOfBirthComparison;
            var genderComparison = string.Compare(Gender, other.Gender, StringComparison.Ordinal);
            if (genderComparison != 0) return genderComparison;
            return Experience.CompareTo(other.Experience);
        }
    }
}