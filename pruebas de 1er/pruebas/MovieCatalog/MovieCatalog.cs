using System.Collections.Generic;

namespace MatCom.Exam
{
    public interface IMovieCatalog
    {
        // Género raíz
        IGenre Root { get; }

        // Navegar por los géneros y películas
        IGenre GetGenre(params string[] genres);
        IMovie GetMovie(string movie, params string[] genres);

        // Buscar las películas que cumplen con una condición
        IEnumerable<IMovie> FindAll(Filter<IMovie> filter);
    }

    public interface IGenre
    {
        string Name { get; }

        // Crear subgéneros
        IGenre CreateSubgenre(string name);

        // Crear o actualizar la calificación de una película
        void UpdateRating(string name, int change);

        // Enumerar todos los subgéneros (en este nivel)
        IEnumerable<IGenre> Subgenres { get; }

        // Enumerar todas los películas (en este nivel)
        IEnumerable<IMovie> Movies { get; }

        // Género padre
        IGenre Parent { get; }
    }

    public interface IMovie
    {
        string Name { get; }
        int Rating { get; set; }
        IGenre Parent { get; }
    }

    public delegate bool Filter<T>(T item);
}