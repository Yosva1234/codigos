using System;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace MatCom.Exam
{
    public class Exam
    {
        public static IMovieCatalog GetMovieCatalog()
        {
            return new MovieCatalog();
        }

        public class MovieCatalog : IMovieCatalog
        {
            public IGenre Root { get; }

            public MovieCatalog()
            {
                Root = new Genre(string.Empty, Root!);
            }

            public IGenre GetGenre(params string[] genres)
            {
                return GetGenre(Root, 0, genres);
            }

            IGenre GetGenre(IGenre genre, int currentGenre, params string[] genres)
            {
                foreach (var subgenre in genre.Subgenres)
                {
                    if (subgenre.Name == genres[currentGenre] && currentGenre == genres.Length - 1)
                        return subgenre;

                    if (subgenre.Name == genres[currentGenre])
                    {
                        currentGenre++;
                        return GetGenre(subgenre, currentGenre, genres);
                    }
                }

                throw new ArgumentException();
            }

            public IMovie GetMovie(string movie, params string[] genres)
            {
                return GetMovie(movie, Root, 0, genres);
            }

            IMovie GetMovie(string movie, IGenre genre, int currentGenre, params string[] genres)
            {
                foreach (var subgenre in genre.Subgenres)
                {
                    if (subgenre.Name == genres[currentGenre] && currentGenre == genres.Length - 1)
                        foreach (var _movie in subgenre.Movies)
                        {
                            if (_movie.Name == movie)
                            {
                                return _movie;
                            }
                        }

                    if (subgenre.Name == genres[currentGenre])
                    {
                        currentGenre++;
                        return GetMovie(movie, subgenre, currentGenre, genres);
                    }
                }

                throw new ArgumentException();
            }

            public IEnumerable<IMovie> FindAll(Filter<IMovie> filter)
            {
                List<IMovie> found = new List<IMovie>();
                FindAll(filter, Root, found);
                return found;
            }

            void FindAll(Filter<IMovie> filter, IGenre genre, List<IMovie> movies)
            {
                foreach (var movie in genre.Movies)
                {
                    if (filter(movie))
                        movies.Add(movie);
                }

                foreach (var subgenre in genre.Subgenres)
                {
                    FindAll(filter, subgenre, movies);
                }
            }
        }


        public class Movie : IMovie
        {
            public string Name { get; }

            public int Rating
            {
                get;
                set;
            }

            public IGenre Parent { get; }

            public Movie(string name, int rating, IGenre parent)
            {
                Name = name;
                Rating = rating;
                Parent = parent;
            }
        }

        public class Genre : IGenre
        {
            public string Name { get; }

            public IEnumerable<IGenre> Subgenres { get; }

            public IEnumerable<IMovie> Movies { get; }

            public IGenre Parent { get; }

            public List<Genre> _Subgenres { get; }

            public List<Movie> _Movies { get; }

            public Genre(string name, IGenre parent)
            {
                Name = name;
                _Subgenres = new List<Genre>();
                _Movies = new List<Movie>();
                Subgenres = _Subgenres;
                Movies = _Movies;
                Parent = parent;
            }

            public IGenre CreateSubgenre(string name)
            {
                Genre subgenre = new Genre(name, this);
                _Subgenres.Add(subgenre);
                return subgenre;
            }


            public void UpdateRating(string name, int change)
            {

                var movies = _Movies.Where(x => x.Name == name);
                var movie = movies.LastOrDefault();

                if (movies.Count() == 0)
                {
                    movie = new Movie(name, 0, this);
                    _Movies.Add(movie);
                }

                if (movie.Rating + change < 0 || movie.Rating + change > 100) { throw new ArgumentException(); }
                else movie.Rating += change;
            }

        }

        // Borre esta excepción y ponga su nombre como string, e.j.
        // Nombre => "Fulano Pérez Pérez";
        public static string Nombre => "Alejandro Echevarria Brunet";

        // Borre esta excepción y ponga su grupo como string, e.j.
        // Grupo => "C2XX";
        public static string Grupo => "C112";
    }
}