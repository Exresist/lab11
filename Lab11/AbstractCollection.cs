namespace Lab11
{
    public abstract  class AbstractCollection : IAbstractCollection
    {
        public void Add(Person person)
        {
            if (!PersonExist(person))
            {
                AddPerson(person);
            }
        }

        public void Remove(Person person)
        {
            if (PersonExist(person))
            {
                RemovePerson(person);
            }
        }

        public abstract int AdministrationCount();
        public abstract int WorkerCount();
        public abstract int EngineerCount();
        public abstract void AdministrationGet();
        public abstract void WorkerGet();
        public abstract void EngineerGet();
        public abstract Person[] GetAll();
        public abstract object CloneAll();
        public abstract bool Search(Person o);

        protected abstract bool PersonExist(Person person);
        protected abstract void AddPerson(Person o);
        protected abstract void RemovePerson(Person person);
    }
}