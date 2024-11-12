using System;
using System.Collections.Generic;
using System.Text;

namespace Estera
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] estera = {{5,2,3,4,8},
                             {7,0,1,2,9}};

            ImprimeEstera(estera);

            Estera.Rota(estera);
            Console.WriteLine("===========================================");

            ImprimeEstera(estera);
            Console.ReadKey(true);

            Estera.Rota(estera);
            Console.WriteLine("===========================================");

            ImprimeEstera(estera);
            Console.ReadKey(true);
        }

        private static void ImprimeEstera(int[,] estera) 
        {
            for (int i = 0; i < estera.GetLength(1); i++)
                Console.Write("   " + estera[0, i]);

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < estera.GetLength(1); i++)
                Console.Write("   " + estera[1, i]);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
