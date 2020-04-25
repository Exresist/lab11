using System;

namespace Lab11
{
    public static class Program
         {
            
             // Функция ввода номера части лабораторной работы
             private static int InputMode()
             {
                 int number;
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Введите часть (1-3) лабораторной работы (0 - выход из программы):");
                 Console.ForegroundColor = ConsoleColor.White;
                 while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 3)
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Ошибка. Вы неверно ввели часть лабораторной работы");
                     Console.ForegroundColor = ConsoleColor.White;
                 }
     
                 return number;
             }
     
             // Функция ввода номера типа персоны
             private static int InputClass()
             {
                 int number;
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Выберите тип персоны, который хотите добавить:");
                 Console.WriteLine("1) Рабочий\n2) Инженер\n3) Администрация");
                 Console.ForegroundColor = ConsoleColor.White;
                 while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 3)
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Ошибка. Вы неверно выбрали тип персоны. Повторите ввод");
                     Console.ForegroundColor = ConsoleColor.White;
                 }
     
                 return number;
             }
     
             private static int InputSizeCollection()
             {
                 int number;
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Введите количеств элементов в коллекции:");
                 Console.ForegroundColor = ConsoleColor.White;
                 while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 100)
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Ошибка. Вы неверно ввели количество элементов. Повторите ввод.");
                     Console.ForegroundColor = ConsoleColor.White;
                 }
     
                 return number;
             }
     
             static void Main()
             {
                 int mode = InputMode();
                 while (mode != 0)
                 {
                     switch (mode)
                     {
                         case 1:
                         {
     
                                 QueueCollection queueCollection = new QueueCollection();
                                 SortedDictionaryCollection sortedDictionaryCollection = new SortedDictionaryCollection();
                                 int num = InputSizeCollection();
                             for (int i = 0; i < num ; i++)
                             {
                                 int type = InputClass();
                                 switch (type)
                                 {
                                     case 1:
                                     {
                                         Worker worker = new Worker();
                                         queueCollection.Add(worker);
                                                 sortedDictionaryCollection.Add(worker);
     
                                     }
                                         break;
                                     case 2:
                                     {
                                         Engineer engineer = new Engineer();
                                         queueCollection.Add(engineer);
                                                 sortedDictionaryCollection.Add(engineer);
                                     }
                                         break;
                                     case 3:
                                     {
                                         Administration administration = new Administration();
                                         queueCollection.Add(administration);
                                                 sortedDictionaryCollection.Add(administration);
                                     }
                                         break;
                                 }
                             }
     
                             Console.WriteLine(queueCollection.AdministrationCount());
                             Person[] all = queueCollection.GetAll();
                             Console.WriteLine("----------------------------");
                             if (all.Length == 0) {
                                 Console.WriteLine("Empty");
                             } else
                             {
                                 foreach (Person person in all)
                                 {
                                     person.Show();
                                 }
                             }
                             Console.WriteLine("----------------------------");
                             mode = InputMode();
                             break;
                         }
                         case 2:
                         {
                             Console.WriteLine("Работы без виртуальных методов не будет, т.к. студент все понял :)");
                             mode = InputMode();
                             break;
                         }
                         case 3:
                         {
                             // 1.Составить иерархию классов в соответствии с вариантом. Иерархия должна содержать хотя бы один интерфейс и хотя бы один абстрактный класс.
                             Console.WriteLine("Иерархия классов:");
                             Console.WriteLine("Person - абстрактный класс, является 'родителем' остальных классов.");
                             Console.WriteLine("Engineer, Administration, worker - классы, наследующие методы от Person.");
     
                             //2.Создать массив интерфейсных элементов и поместить в него экземпляры различных классов иерархии.
     
                             //3.Реализовать сортировку элементов массива, используя стандартные интерфейсы и методы класса Array.
     
                             //4.Реализовать поиск элемента в массиве, используя стандартные интерфейсы и методы класса Array.
     
                             //5.Реализовать в одном из классов метод клонирования объектов.Показать клонирование объектов.
                             mode = InputMode();
                             break;
                         }
                     }
                 }
             }
         }
}