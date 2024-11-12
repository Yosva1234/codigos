using System;
using System.Collections.Generic;
using System.Text;
using LibEjercicioMitad;
using EjercicioMitad;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol<int> a = new Arbol<int>(5, new Arbol<int>(1, new Arbol<int>(2, new Arbol<int>(3), new Arbol<int>(9))),
                                new Arbol<int>(7), new Arbol<int>(2, new Arbol<int>(5), new Arbol<int>(4)
                                )
                            );

            Arbol<int> t = new Arbol<int>(4,
                                new Arbol<int>(4),
                                new Arbol<int>(2,
                                    new Arbol<int>(1),
                                    new Arbol<int>(4,
                                        new Arbol<int>(4),
                                        new Arbol<int>(2,
                                            new Arbol<int>(1),
                                            new Arbol<int>(7),
                                            new Arbol<int>(9)
                                        )
                                    ),
                                    new Arbol<int>(7),
                                    new Arbol<int>(9)
                                )
                            );

            Arbol<int> o = new Arbol<int>(6,
                                new Arbol<int>(6),
                                new Arbol<int>(6,
                                    new Arbol<int>(6)
                                )
                            );

            Console.WriteLine("Mitad(A) : " + ComoTexto(Solucion.Mitad(a)));
            Console.WriteLine("Mitad(T) : " + ComoTexto(Solucion.Mitad(t)));
            Console.WriteLine("Mitad(O) : " + ComoTexto(Solucion.Mitad(o)));

            Console.ReadKey();
        }
        public static string ComoTexto<T>(Arbol<T> a)
        {
            if (a == null)
                return "NULL";

            string result = "(" + a.Valor;
            if (a.Hijos.Count > 0)
            {
                result += " - " + ComoTexto(a.Hijos[0]);
                for (int i = 1; i < a.Hijos.Count; i++)
                    result += ", " + ComoTexto(a.Hijos[i]);
            }
            result += ")";
            return result;
        }
        
    }
}