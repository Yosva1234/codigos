using System;
using System.Collections.Generic;
using System.Text;
using SumandoNumeros;

namespace Probando
{
    class Program
    {
        static void Main(string[] args)
        {
            // Una forma de probar su método. Para probar otros caso adicione el codigo.
            string[] nums = { "1984", "666", "12345678900000000000000000000000000000000000000000" };
            string resultado = Prueba.Suma(nums);
            Console.WriteLine(resultado);
        }
    }
}
