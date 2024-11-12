using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Examen;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Suministro.SePuedeAbastecer(3, 4, new int[] {2, 2, 1}));
            Console.WriteLine(Suministro.SePuedeAbastecer(8, 8, new int[] { 2, 1, 2, 1, 3, 1, 1, 1 }));

            Console.ReadLine();
        }
    }
}
