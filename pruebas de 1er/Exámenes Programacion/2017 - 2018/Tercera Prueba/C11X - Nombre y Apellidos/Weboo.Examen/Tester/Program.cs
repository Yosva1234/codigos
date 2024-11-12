using ConceptosSocraticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            ITorneoFilosofico torneo = new TorneoFilosofico();
            Console.WriteLine($"Numero de escuelas: {torneo.DameEscuelas().Count()}");
            // ~> Número de escuelas: 0

            Console.WriteLine($"Tales pertenece a: {torneo.PerteneceAEscuela(new Filosofo("Tales"))}");
            // ~> Tales pertenece a: 

            torneo.RegistraEscuela("Escuela de Mileto", new Filosofo[3] {
                new Filosofo("Tales", 5),
                new Filosofo("Anaximandro", 4),
                new Filosofo("Anaximenes", 3)
            });

            Console.WriteLine($"Numero de escuelas: {torneo.DameEscuelas().Count()}");
            // ~> Número de escuelas: 1

            Console.WriteLine($"Tales pertenece a: {torneo.PerteneceAEscuela(new Filosofo("Tales"))}");
            // ~> Tales pertenece a: Escuela de Mileto

            torneo.RegistraEscuela("Escuela eleatica", new Filosofo[2] {
                new Filosofo("Parmenides", 6),
                new Filosofo("Zenon de Elea", 2),
            });

            Console.WriteLine($"Numero de escuelas: {torneo.DameEscuelas().Count()}");
            // ~> Número de escuelas: 2

            Console.WriteLine("Parmenides pertenece a: {0}", torneo.PerteneceAEscuela(new Filosofo("Parmenides")));
            // ~> Parmenides pertenece a: Escuela eleatica

            Console.Write("Miembros de la escuela eleatica: ");
            foreach(var filosofo in torneo.Miembros("Escuela eleatica"))
            {
                Console.Write($"{filosofo.Nombre} ({filosofo.Conocimiento}), ");
            }
            Console.Write("\n");
            // ~> Miembros de la escuela eleatica: Parmenides (6), Zenon de Elea (2), 

            Console.WriteLine("Ganador entre Escuela de Mileto y Escuela eleatica es: {0}",
                torneo.Compite("Escuela de Mileto", "Escuela eleatica"));
            // ~> Ganador entre Escuela de Mileto y Escuela eleatica es: Escuela eleatica

            Console.WriteLine("Numero de escuelas: {0}", torneo.DameEscuelas().Count());
            // ~> Número de escuelas: 1

            Console.Write("Miembros de la escuela eleatica: ");
            foreach (var filosofo in torneo.Miembros("Escuela eleatica"))
            {
                Console.Write($"{filosofo.Nombre} ({filosofo.Conocimiento}), ");
            }
            Console.Write("\n");
            // ~> Miembros de la escuela eleatica: Parmenides (6), Tales (5), Anaximandro (4), Anaximenes (3), Zenon de Elea (2), 

            torneo.RegistraEscuela("Escuela Pitagorica", new Filosofo[4] {
                new Filosofo("Pitagoras", 6),
                new Filosofo("Epicarmo", 5),
                new Filosofo("Alcmeon", 4),
                new Filosofo("Hipaso", 4)
            });

            Console.WriteLine("Numero de escuelas: {0}", torneo.DameEscuelas().Count());
            // ~> Número de escuelas: 2

            Console.Write("Filosofos mas destacados: ");
            foreach (var filosofo in torneo.FilosofosMasDestacados())
            {
                Console.Write($"{filosofo.Nombre} ({filosofo.Conocimiento}), ");
            }
            Console.Write("\n");
            // ~> Filosofos mas destacados: Parmenides (6), Pitagoras (6), 

            Console.Write("Escuelas: ");
            foreach (var escuela in torneo.DameEscuelas())
            {
                Console.Write($"{escuela}, ");
            }
            Console.Write("\n");
            // ~> Escuelas: Escuela eleatica, Escuela Pitagorica

            Console.WriteLine("Ganador entre Escuela elaetica y Escuela Pitagorica es: {0}",
                torneo.Compite("Escuela eleatica", "Escuela Pitagorica"));
            // ~> Ganador entre Escuela eleatica y Escuela Pitgorica es: Escuela Pitagorica

            Console.WriteLine("Numero de escuelas: {0}", torneo.DameEscuelas().Count());
            // ~> Número de escuelas: 1

            Console.Write("Miembros de la Escuela Pitagorica: ");
            foreach (var filosofo in torneo.Miembros("Escuela Pitagorica"))
            {
                Console.Write($"{filosofo.Nombre} ({filosofo.Conocimiento}), ");
            }
            Console.Write("\n");
            // ~> Miembros de la escuela Pitagorica: Pitagoras (6), Parmenides (6), Epicarmo (5), Tales (5), Anaximandro (4), Alcmeon (4), Hipaso (4), Anaximenes (3), Zenon de Elea (2), 

            torneo.RegistraEscuela("Escuela peripatetica", new Filosofo[] {
                new Filosofo("Aristoteles", 7),
                new Filosofo("Teofrasto", 6),
                new Filosofo("Aristoxeno", 4),
            });

            torneo.RegistraEscuela("Escuela del epicureismo", new Filosofo[] {
                new Filosofo("Epicuro", 7),
                new Filosofo("Filodemo", 6),
            });

            Console.WriteLine("Numero de escuelas: {0}", torneo.DameEscuelas().Count());
            // ~> Número de escuelas: 3

            Console.Write("Filosofos mas destacados: ");
            foreach (var filosofo in torneo.FilosofosMasDestacados())
            {
                Console.Write($"{filosofo.Nombre} ({filosofo.Conocimiento}), ");
            }
            Console.Write("\n");
            // ~> Filosofos mas destacados: Pitagoras (6), Epicuro (7), Aristoteles (7), 

            Console.WriteLine("Epicuro pertenece a: {0}", torneo.PerteneceAEscuela(new Filosofo("Epicuro")));
            // ~> Epicuro pertenece a: Escuela del epicureismo

            Console.WriteLine("Ganador entre Escuela peripatetica y Escuela del epicureismo es: {0}",
                torneo.Compite("Escuela peripatetica", "Escuela del epicureismo"));
            // ~> Ganador entre Escuela peripatetica y Escuela del epicureismo es: Escuela peripatetica

            Console.WriteLine("Epicuro pertenece a: {0}", torneo.PerteneceAEscuela(new Filosofo("Epicuro")));
            // ~> Epicuro pertenece a: Escuela peripatetica

            Console.Write("Escuelas: ");
            foreach (var escuela in torneo.DameEscuelas())
            {
                Console.Write($"{escuela}, ");
            }
            Console.Write("\n");
            // ~> Escuelas: Escuela peripatetica, Escuela Pitagorica

            torneo.RegistraEscuela("Escuela cinica", new Filosofo[] {
                new Filosofo("Antistenes ", 5),
                new Filosofo("Diogenes", 4),
            });

            torneo.RegistraEscuela("Escuela del estoicismo", new Filosofo[] {
                new Filosofo("Zenon de Citio ", 5),
                new Filosofo("Cleantes", 4),
            });

            Console.WriteLine("Numero de escuelas: {0}", torneo.DameEscuelas().Count());
            // ~> Número de escuelas: 4

            Console.WriteLine("Ganador entre Escuela cinica y Escuela del estoicismo es: {0}",
                torneo.Compite("Escuela cinica", "Escuela del estoicismo"));
            // ~> Ganador entre Escuela cinica y Escuela del estoicismo es: EMPATE

            Console.Write("Escuelas: ");
            foreach (var escuela in torneo.DameEscuelas())
            {
                Console.Write($"{escuela}, ");
            }
            Console.Write("\n");
            // ~> Escuelas: Escuela peripatetica, Escuela Pitagorica, Escuela cinica, Escuela del estoicismo
        }
    }
}
