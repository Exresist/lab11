namespace Lab11
{
    public interface IAbstractCollection
    {
        public void Add(Person p);

        public void Remove(Person p);

        public int AdministrationCount();

        public int WorkerCount();

        public int EngineerCount();

        public void AdministrationGet();

        public void WorkerGet();

        public void EngineerGet();
        
        public Person[] GetAll();
        
        public object CloneAll();

        public bool Search(Person o);
    }

    public interface CopyOfIAbstractCollection
    {
        public void Add(Person p);

        public void Remove(Person p);

        public int AdministrationCount();

        public int WorkerCount();

        public int EngineerCount();

        public void AdministrationGet();

        public void WorkerGet();

        public void EngineerGet();

        public Person[] GetAll();

        public object CloneAll();

        public void Search(Person o);
    }
}