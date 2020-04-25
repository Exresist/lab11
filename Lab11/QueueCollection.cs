using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    public sealed class QueueCollection: AbstractCollection
    {
        private Queue<Person> PersonQueue = new Queue<Person>();
        private Queue<string> StringQueue = new Queue<string>();


        public int PersonCount()
        {
            return PersonQueue.Count;
        }

        public override int AdministrationCount()
        {
            return PersonQueue.OfType<Administration>().Count();
        }

        public override int WorkerCount()
        {
            return PersonQueue.OfType<Worker>().Count();
        }

        public override int EngineerCount()
        {
            return PersonQueue.OfType<Engineer>().Count();
        }
        

        public override void AdministrationGet()
        {
            foreach (var administration in PersonQueue.Where(administration => administration is Administration))
            {
                administration.Show();
            }
        }

        public override void WorkerGet()
        {
            foreach (var worker in PersonQueue.Where(worker => worker.GetType() == typeof(Worker)))
            {
                worker.Show();
            }
        }

        public override void EngineerGet()
        {
            throw new System.NotImplementedException();
        }

        public override Person[] GetAll()
        {
            return PersonQueue.ToArray();
        }

        public override object CloneAll()
        {
            Person[] personArray = new Person[PersonQueue.Count];
            PersonQueue.CopyTo(personArray, 0);
            return personArray;
        }

        public override bool Search(Person o)
        {
            return PersonExist(o);
        }

        protected override bool PersonExist(Person person)
        {
            return PersonQueue.Contains(person);
        }

        protected override void AddPerson(Person person)
        {
            PersonQueue.Enqueue(person);
            StringQueue.Enqueue(person.ToString());
        }

        protected override void RemovePerson(Person person)
        {
            Queue<Person> myQueue = new Queue<Person>(PersonQueue.Where(x => x != person));
            Queue<string> myStringQueue = new Queue<string>(StringQueue.Where(x => x != person.ToString()));
            PersonQueue = myQueue;
            StringQueue = myStringQueue;
        }

        public void Clear()
        {
            PersonQueue.Clear();
        }
    }
}