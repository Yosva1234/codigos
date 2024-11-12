using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weboo.PrimerExamen.Tester
{
    class Program
    {
        
        private static int caso = 4;

        static void Main(string[] args)
        {
            // Casos del documento
            Probar(new[] { 3, 1, -4, 9, -5, -2, 0, 11, -4, 3, -7, 8 }, new[] { 5, 3, 4, 1 }, -1);
            Probar(new[] { 3, 1, -4, 9, -5, -2, 0, 11, -4, 3, -7, 8 }, new[] { 5, 3, 4, 3 }, 6);
            Probar(new[] { 3, 1, -4, 9, -5, -2, 0, 11, -4, 3, -7, 8 }, new[] { 5, 3, 4, 4 }, 12);
            Probar(new[] { 3, 1, -4, 9, -5, -2, 0, 11, -4, 3, -7, 8 }, new[] { 5, 3, 4, 9 }, 12);

            // Otros casos
            Probar(new[] { 0, 0, 0, 0, 0 }, new[] { 1, 1, 1 }, 3);
            Probar(new[] { 1, -1, 2, -2, 10, -10 }, new[] { 1, 3, 4 }, -1);
            Probar(new[] { 871623, -615341, 7612453 }, new[] { 1 }, -1);
            Probar(new[] { 658678, -451250, 9876742 }, new[] { 2 }, 3);
        }

        private static void Probar(int[] array, int[] tiradas, int correcto)
        {
            int resultado = Juego.PosicionFinal(array, tiradas);

            Console.Write("Caso {0} => ", caso++);

            if (resultado == correcto)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Correcto");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrecto: Se esperaba {0} pero se obtuvo {1}.", correcto, resultado);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
