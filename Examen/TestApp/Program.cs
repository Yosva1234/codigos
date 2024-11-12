using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int k, f, c, s, n;

            k = 1; f = 2; c = 2; s = 12;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 2; f = 2; c = 2; s = 24;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 1; f = 2; c = 3; s = 26;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 1; f = 4; c = 4; s = 172;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 2; f = 4; c = 4; s = 1744;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 3; f = 4; c = 4; s = 16880;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 4; f = 4; c = 4; s = 154680;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Iniciando exploración...");
            Explore(interactive: true);
        }

        static void Explore(int maxFilas = 4, int maxColumnas = 4, int maxK = 4, bool interactive = true)
        {
            for(int filas = 2; filas <= maxFilas; filas++) {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine();
                for(int columnas = 2; columnas <= maxColumnas; columnas++) {
                    for(int k = 0; k <= filas * columnas && k <= maxK; k++) {
                        Console.WriteLine("K:{0} --> Filas: {1}, Columnas: {2}", k, filas, columnas);
                        int n = Patrones.CantidadValidos(k, filas, columnas);
                        Console.WriteLine("Patrones válidos: {0}", n);
                        if(interactive) {
                            Console.WriteLine("...");
                            Console.ReadLine();
                        }
                        else {
                            Console.WriteLine();
                        }
                    }
                }

            }
            Console.WriteLine("Done!!!");
        }
    }
}
