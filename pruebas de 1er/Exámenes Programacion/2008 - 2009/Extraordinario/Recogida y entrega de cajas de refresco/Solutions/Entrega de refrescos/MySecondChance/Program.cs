using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondChance
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente[] listado = new Cliente[] { new Cliente(4, 2), new Cliente(5, 3), new Cliente(6, 3), new Cliente(2, 7), new Cliente(0, 0) };
            int[] ruta = Ruteo.EncontrarRuta(listado, 10);
        }
    }
}
