using System.Collections.Generic;

namespace MatCom.Exam
{
    public interface ISpeciesOrganizer
    {
        // Grupo taxonómico raíz
        ITaxonomicGroup Root { get; }

        // Navegar por los grupos taxonómicos y especies
        ITaxonomicGroup GetTaxonomicGroup(params string[] taxonomicGroups);
        ISpecies GetSpecies(string name, params string[] taxonomicGroups);

        // Buscar las especies que cumplen con una condición
        IEnumerable<ISpecies> FindAll(Filter<ISpecies> filter);
    }

    public interface ITaxonomicGroup
    {
        string Name { get; }

        // Crear subgrupos taxonómicos
        ITaxonomicGroup CreateSubtaxonomicGroup(string name);

        // Crear o actualizar la cantidad de especimen de una especie
        void UpdateSpecimen(string name, int change);

        // Enumerar todos los subgrupos taxonómicos (en este nivel)
        IEnumerable<ITaxonomicGroup> SubtaxonomicGroups { get; }

        // Enumerar todas los especies (en este nivel)
        IEnumerable<ISpecies> Species { get; }

        // Grupo taxonómico padre
        ITaxonomicGroup Parent { get; }
    }

    public interface ISpecies
    {
        string Name { get; }
        int Count { get; set; }
        ITaxonomicGroup Parent { get; }
    }

    public delegate bool Filter<T>(T item);
}