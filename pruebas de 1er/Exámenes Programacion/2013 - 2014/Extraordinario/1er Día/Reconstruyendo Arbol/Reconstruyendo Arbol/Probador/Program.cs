using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Colleciones;
using Weboo.Examen.Extraordinario;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A continuación se probarán los casos de prueba del documento. Usted debería crear sus propios casos" +
                              "de prueba para garantizar un total funcionamiento de sus algoritmo");
           

            #region Caso 1
            Console.WriteLine();
            Console.WriteLine("Probando Ejemplo 1");
            int[] valores1 = Case1.Valores;
            int[] indicePadres1 = Case1.Padres;
            Console.Write("Valores: ");
            Imprime(valores1);
            Console.Write("Índices Padres: ");
            Imprime(indicePadres1);

            Arbol<int> arbol1 = BuscandoPadre.Reconstruye(valores1, indicePadres1);
            IEnumerable<int> a1 = PreOrden(arbol1);
            string s1 = "";
            foreach (var i in a1)
                s1 += i + " ";
            Console.WriteLine(s1);

            #endregion
          
            #region Caso 2

            Console.WriteLine();
            Console.WriteLine("Probando Ejemplo 2");
            int[] valores2 = Case2.Valores;
            int[] indicePadres2 = Case2.Padres;
            Console.Write("Valores: ");
            Imprime(valores2);
            Console.Write("Índices Padres: ");
            Imprime(indicePadres2);

            Arbol<int> arbol2 = BuscandoPadre.Reconstruye(valores2, indicePadres2);
            IEnumerable<int> a2 = PreOrden(arbol2);
            string s2 = "";
            foreach (var i in a2)
                s2 += i + " ";
            Console.WriteLine(s2);

            #endregion

            #region Caso 3

            Console.WriteLine();
            Console.WriteLine("Probando Ejemplo 3");
            int[] valores3 = Case3.Valores;
            int[] indicePadres3 = Case3.Padres;
            Console.Write("Valores: ");
            Imprime(valores3);
            Console.Write("Índices Padres: ");
            Imprime(indicePadres3);

            Arbol<int> arbol3 = BuscandoPadre.Reconstruye(valores3, indicePadres3);
            IEnumerable<int> a3 = PreOrden(arbol3);
            string s3 = "";
            foreach (var i in a3)
                s3 += i + " ";
            Console.WriteLine(s3);

            #endregion


        }
        static CasoPrueba<int> Case1 = new CasoPrueba<int>(
           new int[] { 3, 11, 7, 2, 5 },
           new int[] { 2, 3, 3, -1, 3 });
        static CasoPrueba<int> Case2 = new CasoPrueba<int>(
            new int[] { 9, 29, 2, 19, 31, 7, 23, 45, 3, 37, 11, 51, 3, 9 },
            new int[] { 3, 3, 10, -1, 3, 7, 7, 0, 4, 1, 9, 10, 7, 4 });
        static CasoPrueba<int> Case3 = new CasoPrueba<int>(
            new int[] { 12, 7, 8, 9, 9, 11, 7, 1, 2, 3, 2, 1 },
            new int[] { 7, 9, 3, 9, 3, 9, 0, 9, 0, 11, 0, -1 });

        private static void Imprime<T>(T[] elems)
        {
            Console.Write("{");
            for (int i = 0; i < elems.Length; i++)
                Console.Write(elems[i] + ", ");
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.WriteLine("}");
        }

        public static IEnumerable<T> PreOrden<T>(Arbol<T> arbol)
        {
            yield return arbol.Valor;
            foreach (var hijo in arbol.Children)
                foreach (var a in PreOrden(hijo))
                    yield return a;
        }

    }

    internal class CasoPrueba<T>
    {
        public T[] Valores { get; set; }
        public int[] Padres { get; set; }

        public CasoPrueba(T[] valores, int[] padres)
        {
            Valores = valores;
            Padres = padres;
        }
    }

}
