using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Examen.Supermercado;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            // El siguiente código reproduce el ejemplo mostrado en el documento
            // Siéntase libre de añadir tantas pruebas como sea necesario.

            var supermercado = new Supermercado(2);

            // Inicio
            Verifica(supermercado.ClientesEnCaja(0), 0);
            Verifica(supermercado.ClientesEnCaja(1), 0);

            //ClienteAPagar(8)
            Cliente A = new Cliente(8);
            supermercado.ClienteAPagar(A);
            Verifica(supermercado.ClientesEnCaja(0), 1);
            Verifica(supermercado.ClientesEnCaja(1), 0);

            //ClienteAPagar(5)
            Cliente B = new Cliente(5);
            supermercado.ClienteAPagar(B);
            Verifica(supermercado.ClientesEnCaja(0), 1);
            Verifica(supermercado.ClientesEnCaja(1), 1);

            //ClienteAPagar(2)
            Cliente C = new Cliente(2);
            supermercado.ClienteAPagar(C);
            Verifica(supermercado.ClientesEnCaja(0), 2);
            Verifica(supermercado.ClientesEnCaja(1), 1);

            //Proximo
            Verifica(supermercado.Proximo(), true);
            Verifica(supermercado.EnLaPuerta, B);
            Verifica(supermercado.ClientesEnCaja(0), 2);
            Verifica(supermercado.ClientesEnCaja(1), 0);

            //ClienteAPagar(3)
            Cliente D = new Cliente(3);
            supermercado.ClienteAPagar(D);
            Verifica(supermercado.EnLaPuerta, B);
            Verifica(supermercado.ClientesEnCaja(0), 2);
            Verifica(supermercado.ClientesEnCaja(1), 1);

            //ClienteAPagar(1)
            Cliente E = new Cliente(1);
            supermercado.ClienteAPagar(E);
            Verifica(supermercado.EnLaPuerta, B);
            Verifica(supermercado.ClientesEnCaja(0), 2);
            Verifica(supermercado.ClientesEnCaja(1), 2);
            
            //Proximo
            Verifica(supermercado.Proximo(), true);
            Verifica(supermercado.EnLaPuerta, A);
            Verifica(supermercado.ClientesEnCaja(0), 1);
            Verifica(supermercado.ClientesEnCaja(1), 2);
            
            //Proximo
            Verifica(supermercado.Proximo(), true);
            Verifica(supermercado.EnLaPuerta, D);
            Verifica(supermercado.ClientesEnCaja(0), 1);
            Verifica(supermercado.ClientesEnCaja(1), 1);
            
            //Proximo
            Verifica(supermercado.Proximo(), true);
            Verifica(supermercado.EnLaPuerta, E);
            Verifica(supermercado.ClientesEnCaja(0), 1);
            Verifica(supermercado.ClientesEnCaja(1), 0);
            
            //Proximo
            Verifica(supermercado.Proximo(), true);
            Verifica(supermercado.EnLaPuerta, C);
            Verifica(supermercado.ClientesEnCaja(0), 0);
            Verifica(supermercado.ClientesEnCaja(1), 0);

            //Proximo
            Verifica(supermercado.Proximo(), false);
            Verifica(supermercado.Proximo(), false); // Comprobar más de una vez...
            Verifica(supermercado.ClientesEnCaja(0), 0);
            Verifica(supermercado.ClientesEnCaja(1), 0);
        }

        static void Verifica<T>(T real, T esperado)
        {
            if (Equals(real, esperado))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("OK    ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0} == {1}", real, esperado);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("ERROR ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0} != {1}", real, esperado);
            }
        }
    }
}
