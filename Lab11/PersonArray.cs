using System;
using System.Collections;

namespace Lab11
{
    public class PersonArray
    {
        public Person[] Arr;
        public int Count;

        // Конструктор класса без параметров
        public PersonArray()
        {
            Arr = null;
            Count = 0;
        }

        // Конструктор класса с параметрами
        public PersonArray(int size)
        {
            Arr = new Person[size];
            Count = size;
        }

        // Индексация к элементу масива 
        public Person this[int index]
        {
            get => Arr[index];
            set => Arr[index] = value;
        }

        // Ввод размера массива
        public static int InputSize()
        {
            int number;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите рамер массива:");
            Console.ForegroundColor = ConsoleColor.White;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка. Вы неверно ввели размер массива. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return number;
        }

        // Вывод всей инфорамции о персонах, информация о которых хранится в PersonArray
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Персоны:\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < Arr.Length; i++)
            {
                this[i].Show();
                Console.WriteLine();
            }
        }

        public Person[] RandomGeneration(int size)
        {
            Random random = new Random();
            Person[] people = new Person[size];
            for (int i = 0; i <size; i++)
            {
                switch (random.Next(1,3))
                {
                    case 1: people[i] = new Administration();
                        break;
                    case 2: people[i] = new Engineer();
                        break;
                    case 3: people[i] = new Worker();
                        break;
                }
            }

            return people;
        }
    }
}