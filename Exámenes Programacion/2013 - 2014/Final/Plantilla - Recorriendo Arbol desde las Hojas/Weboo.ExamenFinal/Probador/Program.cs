using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Arboles;
using Weboo.Examen.Final;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {

            Arbol<string> a2 = new Arbol<string>("Hola",
                        new Arbol<string>("Mundo",
                            new Arbol<string>("Prueba")),
                        new Arbol<string>("Programa"),
                        new Arbol<string>("CS",
                            new Arbol<string>("5"),
                            new Arbol<string>("2",
                                new Arbol<string>("Aprobado"))));

            IEnumerable<int> longitudes = Recorridos.IteraPrimeroHojas(a2, s => s.Length);

            foreach (var x in longitudes)
                Console.Write("  {0},", x);
            //6, 8, 1, 8, 5, 1, 2, 4

            Arbol<int> a3 = new Arbol<int>(13,
                    new Arbol<int>(12,
                        new Arbol<int>(1),
                        new Arbol<int>(11,
                            new Arbol<int>(9,
                                new Arbol<int>(2),
                                new Arbol<int>(3)))),
                    new Arbol<int>(4),
                    new Arbol<int>(10,
                        new Arbol<int>(5),
                        new Arbol<int>(6),
                        new Arbol<int>(7),
                        new Arbol<int>(8)));

            IEnumerable<bool> sonPrimos = Recorridos.IteraPrimeroHojas(a3, x => EsPrimo(x));

            foreach (var x in sonPrimos)
                Console.Write("  {0},", x);
            //false, true, true, false, true, false, true, false, false, false, true, false, true

            Arbol<int> a = new Arbol<int>(0,
                    new Arbol<int>(0),
                    new Arbol<int>(0));

            var e = Recorridos.IteraPrimeroHojas(a, x => 1 / x); // hacer esto no debe tener problemas

            //foreach (var x in e) // la excepción ocurre aquí al tratar de acceder al primero
            //    Console.WriteLine(x);

        }

        public static bool EsPrimo(int p)
        {
            if (p <= 1) return false;

            for (int d = 2; d <= (int)Math.Sqrt(p); d++)
                if (p % d == 0) return false;

            return true;
        }
    }
}
