using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    public class SortedDictionaryCollection : AbstractCollection
    {
        private SortedDictionary<Person, Person> SortedDictionary = new SortedDictionary<Person, Person>();

        public virtual int PersonCount()
        {
            return SortedDictionary.Count;
        }

        public override int AdministrationCount()
        {
            return SortedDictionary.Values.OfType<Administration>().Count();
        }

        public override int WorkerCount()
        {
            return SortedDictionary.Values.OfType<Worker>().Count();
        }

        public override int EngineerCount()
        {
            return SortedDictionary.Values.OfType<Engineer>().Count();
        }

        public override void AdministrationGet()
        {
        }

        public override void WorkerGet()
        {
            throw new System.NotImplementedException();
        }

        public override void EngineerGet()
        {
            throw new System.NotImplementedException();
        }

        public override Person[] GetAll()
        {
            return SortedDictionary.Keys.ToArray();
        }

        public override object CloneAll()
        {
            Person[] personArray = new Person[SortedDictionary.Count];
            SortedDictionary.Keys.CopyTo(personArray, 0);
            return personArray;
        }

        public override bool Search(Person person)
        {
            return PersonExist(person);
        }

        protected override bool PersonExist(Person person)
        {
            return SortedDictionary.Values.Contains(person);
        }

        protected override void AddPerson(Person person)
        {
            SortedDictionary.Add(person.BasePerson, person);
        }

        protected override void RemovePerson(Person person)
        {
            SortedDictionary.Remove(person.BasePerson);
        }

        public void Clear()
        {
            SortedDictionary.Clear();
        }
    }
}