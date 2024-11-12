namespace MatCom.Exam;

using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using zoologico;

public class Exam
{
    public static IRecord CreateRecord()
    {
        // Devuelva aquí su instancia de IRecord
        return new Record();
    }

    // Borre esta excepción y ponga su nombre como string, e.j.
    // Nombre => "Fulano Pérez Pérez";
    public static string Nombre => "Alejandro Echevarria Brunet";

    // Borre esta excepción y ponga su grupo como string, e.j.
    // Grupo => "C2XX";
    public static string Grupo => "C112";

    public class Record : IRecord
    {
        public Area Root { get; set; }

        public Record(Area? root = null)
        {
            Root = root is null ? new Area("Zoologico") : root;
        }

        public IEnumerable<IAnimal> Find(Func<IAnimal, bool> predicate)
        {
            List<Animal> result = new List<Animal>();
            Find(Root, predicate, result);
            return result;
        }

        void Find(Area actualArea, Func<IAnimal, bool> predicate, List<Animal> result)
        {
            foreach (var animal in actualArea.Animals)
                if (predicate(animal)) result.Add(animal);

            foreach (var area in actualArea.Areas)
                Find(area, predicate, result);
        }

        public IAnimal GetAnimal(string description)
        {
            var address = description.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var rootAddress = GetRootAddress(description);
            var rootArea = GetArea(rootAddress);
            foreach (var animal in rootArea.GetAnimals())
                if (animal.Name == address.Last())
                    return animal;

            throw new ArgumentException($"Specified animal {address.Last()} does not exists.");
        }

        string GetRootAddress(string description)
        {
            for (int i = description.Length - 1; i >= 0; i--)
            {
                if (description[i] == '/') break;
                else description = description.Substring(0, i);
            }

            return description;
        }

        public IArea GetArea(string description)
        {
            var address = description.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (address.Length == 1 && address.First() == "Zoologico") return Root;
            else return GetArea(Root, 1, address);
        }

        Area GetArea(Area actualArea, int index, string[] address)
        {
            if (index == address.Length)
                return actualArea;

            foreach (var area in actualArea.Areas)
                if (area.Name == address[index])
                    return GetArea(area, index + 1, address);

            throw new ArgumentException($"Specified area {address.Last()} does not exists.");
        }

        public IRecord GetRoot(string description)
        {
            var newRoot = (Area)GetArea(description);
            return new Record(newRoot);
        }

        public void Move(string origin, string destination)
        {
            var address = origin.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var originRoot = GetRootAddress(origin);
            var originArea = (Area)GetArea(originRoot);
            var destinationArea = (Area)GetArea(destination);

            Area area = null!;
            Animal animal = null!;

            if (IsArea(originArea, address, out area))
            {
                var match = destinationArea.Areas.Where(a => a.Name == area.Name).FirstOrDefault();
                if (match is null)
                {
                    area.Parent.Areas.Remove(area);
                    area.Parent = destinationArea;
                    destinationArea.Areas.Add(area);
                }
                else Merge(area, match);
            }
            else if (IsAnimal(originArea, address, out animal))
            {
                var match = destinationArea.Animals.Where(a => a.Name == animal.Name).FirstOrDefault();
                if (match is null)
                {
                    animal.Parent.Animals.Remove(animal);
                    animal.Parent = destinationArea;
                    destinationArea.Animals.Add(animal);
                }
                else
                {
                    animal.Parent.Animals.Remove(animal);
                    animal.Parent = null!;
                    match.Age = animal.Age;
                }
            }

            else throw new ArgumentException($"Specified area or animal does not exists");
        }

        void Merge(Area a1, Area a2)
        {
            List<int> indexes = new List<int>();
            foreach (var animal in a1.Animals)
            {
                indexes.Add(a1.Animals.IndexOf(animal));
                var match = a2.Animals.Where(a => a.Name == animal.Name).FirstOrDefault();
                if (match is null)
                {
                    animal.Parent = a2;
                    a2.Animals.Add(animal);
                }
                else
                {
                    animal.Parent = null!;
                    match.Age = animal.Age;
                }
            }

            for (int i = indexes.Count - 1; i >= 0; i--)
                a1.Animals.RemoveAt(indexes[i]);

            indexes.Clear();

            foreach (var area in a1.Areas)
            {
                indexes.Add(a1.Areas.IndexOf(area));
                var match = a2.Areas.Where(a => a.Name == area.Name).FirstOrDefault();
                if (match is null)
                {
                    area.Parent = a2;
                    a2.Areas.Add(area);
                }
                else Merge(area, match);
            }

            for (int i = indexes.Count - 1; i >= 0; i--)
                a1.Areas.RemoveAt(indexes[i]);
        }

        bool IsArea(Area actualArea, string[] address, out Area area)
        {
            foreach (var item in actualArea.Areas)
                if (item.Name == address.Last())
                {
                    area = item;
                    return true;
                }

            area = null!;
            return false;
        }

        bool IsAnimal(Area actualArea, string[] address, out Animal animal)
        {
            foreach (var item in actualArea.Animals)
                if (item.Name == address.Last())
                {
                    animal = item;
                    return true;
                }

            animal = null!;
            return false;
        }

        public void Remove(string description)
        {
            // System.Console.WriteLine("Removing");
            var originRoot = GetRootAddress(description);
            var address = description.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var originAddress = originRoot.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var originArea = (Area)GetArea(originRoot);

            if (address.Length == 1 && address.First() is "Zoologico")
                throw new ArgumentException("Cannot remove root Area.");

            Area area = null!;
            Animal animal = null!;

            if (IsArea(originArea, address, out area))
            {
                area.Parent.Areas.Remove(area);
                area.Parent = null!;
                area.Animals.Clear();
                area.Areas.Clear();
            }

            else if (IsAnimal(originArea, address, out animal))
            {
                animal.Parent.Animals.Remove(animal);
                animal.Parent = null!;
            }

            else throw new ArgumentException($"Specified area or animal does not exists.");
        }
    }

    public class Area : IArea
    {
        public string Name { get; }

        public List<Animal> Animals { get; set; }

        public List<Area> Areas { get; set; }

        public Area Parent { get; set; }

        public Area(string name)
        {
            Name = name;
            Animals = new List<Animal>();
            Areas = new List<Area>();
        }

        public IAnimal CreateAnimal(string name, int size, string specie)
        {
            var animal = new Animal(name, size, specie);
            Animals.Add(animal);
            animal.Parent = this;
            return animal;
        }

        public IArea CreateArea(string name)
        {
            var area = new Area(name);
            area.Parent = this;
            Areas.Add(area);
            return area;
        }

        public IEnumerable<IAnimal> GetAnimals()
        {
            return Animals.OrderBy(x => x.Name);
        }

        public IEnumerable<IArea> GetAreas()
        {
            return Areas.OrderBy(x => x.Name);
        }

        public int MeanAge()
        {
            int totalAge = GetTotalAge(this);
            int totalCount = GetTotalCount(this);
            if (totalAge == 0 || totalCount == 0) return 0;
            else return totalAge / totalCount;
        }

        int GetTotalAge(Area actualArea)
        {
            int totalAge = 0;
            foreach (var animal in actualArea.Animals)
                totalAge += animal.Age;

            foreach (var area in actualArea.Areas)
                totalAge += GetTotalAge(area);

            return totalAge;
        }

        int GetTotalCount(Area actualArea)
        {
            int totalCount = actualArea.Animals.Count;

            foreach (var area in actualArea.Areas)
                totalCount += GetTotalCount(area);

            return totalCount;
        }
    }

    public class Animal : IAnimal
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Specie { get; set; }

        public Area Parent { get; set; }

        public Animal(string name, int age, string specie)
        {
            (Name, Age, Specie) = (name, age, specie);
        }

        public Animal Clone()
        {
            return new Animal(Name, Age, Specie);
        }

    }
}