using System;
using System.Diagnostics;

namespace MatCom.Exam
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Exam.Nombre);
            Console.WriteLine(Exam.Grupo);
            ExampleCase();
        }

        static void ExampleCase()
        {
            IMovieCatalog catalog = Exam.GetMovieCatalog();

            // Referencia al género raíz
            IGenre root = catalog.Root;

            // Crear los géneros iniciales
            IGenre comedia = root.CreateSubgenre("Comedia");
            IGenre terror = root.CreateSubgenre("Terror");

            // Crear los subgéneros
            IGenre romantica = comedia.CreateSubgenre("Romántica");
            IGenre negra = comedia.CreateSubgenre("Negra");
            IGenre psicologico = terror.CreateSubgenre("Psicológico");
            IGenre sobrenatural = terror.CreateSubgenre("Sobrenatural");

            // Crear las películas
            romantica.UpdateRating("Todos los días de mi vida", 85);
            romantica.UpdateRating("La propuesta", 95);
            romantica.UpdateRating("Crazy, Stupid, Love", 80);

            negra.UpdateRating("El gran Lebowski", 93);
            negra.UpdateRating("Malditos vecinos", 71);
            negra.UpdateRating("Pineapple Express", 75);

            psicologico.UpdateRating("El silencio de los corderos", 98);
            psicologico.UpdateRating("Memento", 95);
            psicologico.UpdateRating("El club de la pelea", 92);

            sobrenatural.UpdateRating("El conjuro", 84);
            sobrenatural.UpdateRating("Insidious", 77);
            sobrenatural.UpdateRating("Poltergeist", 72);

            // Hasta aquí tenemos el catálogo del ejemplo

            // Crear un nuevo género
            IGenre absurda = comedia.CreateSubgenre("Absurda");
            Debug.Assert(absurda == catalog.GetGenre("Comedia", "Absurda"));

            // Disminuye en 10 la calificación de Malditos vecinos
            negra.UpdateRating("Malditos vecinos", -10);
            Debug.Assert(catalog.GetMovie("Malditos vecinos", "Comedia", "Negra").Rating == 61);

            // Crea una nueva película
            negra.UpdateRating("El gran golpe", 80);
            Debug.Assert(catalog.GetMovie("El gran golpe", "Comedia", "Negra").Rating == 80);

            // Obtener todas las películas que tienen menos de 85 de calificación
            foreach (var movie in catalog.FindAll(s => s.Rating < 85))
            {
                // Verificando que efectivamente tiene menos de 85
                Debug.Assert(movie.Rating < 85);
            }
        }
    }
}