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
            //EJEMPLO 1
            int n1 = 6;
            int[] i1 = { 0, 5, 4, 3, 3 };
            int[] d1 = { 2, 1, 4, 1, 0 };
            int[] regalos1 = Inviertebot.EjecutaInstrucciones(n1, i1, d1);
            //ImprimeArray(regalos1);
            Test(1, new[] { 6, 4, 1, 5, 2, 3 }, regalos1);


            //EJEMPLO 2
            int n2 = 10;
            int[] i2 = { 0, 0, 3 };
            int[] d2 = { 5, 5, 3 };
            int[] regalos2 = Inviertebot.EjecutaInstrucciones(n2, i2, d2);
            //ImprimeArray(regalos2);
            Test(2, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, regalos2);


            //EJEMPLO 3
            int n3 = 8;
            int[] i3 = { 4, 1, 6, 3, 7 };
            int[] d3 = { 5, 7, 1, 2, 1 };
            int[] regalos3 = Inviertebot.EjecutaInstrucciones(n3, i3, d3);
            //ImprimeArray(regalos3);
            Test(3, new[] { 4, 8, 5, 7, 3, 2, 1, 6 }, regalos3);


            //EJEMPLO 4
            int n4 = 2;
            int[] i4 = { 1, 0, 0, 1, 1 };
            int[] d4 = { 0, 1, 1, 0, 0 };
            int[] regalos4 = Inviertebot.EjecutaInstrucciones(n4, i4, d4);
            //ImprimeArray(regalos4);
            Test(4, new[] { 2, 1 }, regalos4);


            //EJEMPLO 5
            int n5 = 6;
            int[] i5 = { 2, 3, 3, 4, 5 };
            int[] d5 = { 3, 5, 4, 5, 1 };
            int[] regalos5 = Inviertebot.EjecutaInstrucciones(n5, i5, d5);
            //ImprimeArray(regalos5);
            Test(5, new[] { 1, 6, 4, 5, 3, 2 }, regalos5);
        }

        #region Utilidades

        private static void ImprimeArray(int[] a)
        {
            Console.WriteLine(ArrayToString(a));
        }

        private static string ArrayToString(int[] a)
        {
            if (a == null) return "null";

            string r = "{ ";

            if (a.Length > 0)
            {
                r += a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    r += ", ";
                    r += a[i];
                }
            }
            r += " }";

            return r;
        }

        private static void Test(int ejemplo, int[] ok, int[] estudiante)
        {
            var okToString = ArrayToString(ok);
            var estudianteToString = ArrayToString(estudiante);

            if (okToString != estudianteToString)
            {
                NotificaError(string.Format("[Ejemplo {0} INCORRECTO] Se esperaba: {1} pero ud devolvió {2}", ejemplo, okToString, estudianteToString));
            }
            else
            {
                NotificaOk(string.Format("[Ejemplo {0} CORRECTO] {1} es correcto", ejemplo, estudianteToString));
            }
        }

        private static void NotificaError(string msg)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine(" " + msg + " ");

            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }

        private static void NotificaOk(string msg)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine(" " + msg + " ");

            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }

        #endregion
    }
}
