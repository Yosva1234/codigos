namespace zoologico
{
    public interface IAnimal
    {
        int Age { get; }
        string Name { get; }
        string Specie { get; }
    }

    public interface IArea
    {
        string Name { get; }

        IAnimal CreateAnimal(string name, int size, string specie);
        IArea CreateArea(string name);

        IEnumerable<IAnimal> GetAnimals();
        IEnumerable<IArea> GetAreas();
        int MeanAge();
    }

    public interface IRecord
    {
        IArea GetArea(string description);
        IAnimal GetAnimal(string description);
        IRecord GetRoot(string description);

        IEnumerable<IAnimal> Find(Func<IAnimal, bool> predicate);

        void Move(string origin, string destination);
        void Remove(string description);
    }
}
