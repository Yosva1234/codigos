using System;
using System.Reflection.Metadata.Ecma335;

namespace MatCom.Exam
{
    public class Exam
    {
        public static ISpeciesOrganizer GetSpeciesOrganizer()
        {
            return new SpeciesOrganizer();
        }

        // Borre esta excepción y ponga su nombre como string, e.j.
        // Nombre => "Fulano Pérez Pérez";
        public static string Nombre => "Alejandro Echevarria Brunet";

        // Borre esta excepción y ponga su grupo como string, e.j.
        // Grupo => "C2XX";
        public static string Grupo => "C112";

        public class SpeciesOrganizer : ISpeciesOrganizer
        {
            public ITaxonomicGroup Root { get; }

            public SpeciesOrganizer()
            {
                Root = new TaxonomicGroup(string.Empty);
            }

            public IEnumerable<ISpecies> FindAll(Filter<ISpecies> filter)
            {
                List<Specie> result = new List<Specie>();
                FindAll(filter, (TaxonomicGroup)Root, result);
                return result;
            }

            void FindAll(Filter<ISpecies> filter, TaxonomicGroup actualGroup, List<Specie> result)
            {
                foreach (var subGroup in actualGroup.SubGroups)
                {
                    foreach (var specie in subGroup.Species_)
                        if (filter(specie))
                            result.Add(specie);

                    FindAll(filter, subGroup, result);
                }
            }

            public ISpecies GetSpecies(string name, params string[] taxonomicGroups)
            {
                return GetSpecies(name, (TaxonomicGroup)Root, 0, taxonomicGroups);
            }

            Specie GetSpecies(string name, TaxonomicGroup actualGroup, int index, params string[] taxonomicGroups)
            {
                if (index == taxonomicGroups.Length)
                {
                    foreach (var specie in actualGroup.Species_)
                    {
                        if (specie.Name == name)
                            return specie;
                    }
                }

                foreach (var group in actualGroup.SubGroups)
                {
                    if (group.Name == taxonomicGroups[index])
                        return GetSpecies(name, group, index + 1, taxonomicGroups);
                }

                throw new ArgumentException();
            }

            public ITaxonomicGroup GetTaxonomicGroup(params string[] taxonomicGroups)
            {
                return GetTaxonomicGroup((TaxonomicGroup)Root, 0, taxonomicGroups);
            }

            TaxonomicGroup GetTaxonomicGroup(TaxonomicGroup actualGroup, int index, params string[] taxonomicGroups)
            {
                if (index == taxonomicGroups.Length)
                {
                    return actualGroup;
                }

                foreach (var group in actualGroup.SubGroups)
                {
                    if (group.Name == taxonomicGroups[index])
                        return GetTaxonomicGroup(group, index + 1, taxonomicGroups);
                }

                throw new Exception();
            }
        }

        public class TaxonomicGroup : ITaxonomicGroup
        {
            public string Name { get; }

            public IEnumerable<ITaxonomicGroup> SubtaxonomicGroups { get; }

            public IEnumerable<ISpecies> Species { get; }

            public ITaxonomicGroup Parent { get; set; }

            public List<TaxonomicGroup> SubGroups { get; }

            public List<Specie> Species_ { get; }

            public TaxonomicGroup(string name)
            {
                Name = name;
                SubGroups = new List<TaxonomicGroup>();
                Species_ = new List<Specie>();
                SubtaxonomicGroups = SubGroups;
                Species = Species_;

            }

            public ITaxonomicGroup CreateSubtaxonomicGroup(string name)
            {
                foreach (var group in SubGroups)
                    if (group.Name == name)
                        throw new ArgumentException();

                var subGroup = new TaxonomicGroup(name);
                subGroup.Parent = this;
                SubGroups.Add(subGroup);
                return subGroup;
            }

            public void UpdateSpecimen(string name, int change)
            {
                foreach (var specie in Species_)
                {
                    if (specie.Name == name)
                    {
                        if (specie.Count + change < 0)
                            throw new ArgumentException();

                        specie.Count += change;
                        return;
                    }
                }

                if (change < 0) throw new ArgumentException();
                var specimen = new Specie(name, change, this);
                Species_.Add(specimen);
            }
        }

        public class Specie : ISpecies
        {
            public string Name { get; }

            public int Count { get; set; }

            public ITaxonomicGroup Parent { get; }

            public Specie(string name, int count, TaxonomicGroup parent)
            {
                (Name, Count, Parent) = (name, count, parent);
            }
        }
    }
}