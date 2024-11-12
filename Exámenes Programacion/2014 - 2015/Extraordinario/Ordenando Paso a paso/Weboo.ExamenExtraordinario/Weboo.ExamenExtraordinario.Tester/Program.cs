using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weboo.ExamenExtraordinario.Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurante r = new Restaurante();
            r.CreaNuevoPlato("Pizza", 2.75);
            r.CreaNuevoAditivo("Pizza", "Jamón", 0.50);
            r.CreaNuevoAditivo("Pizza", "Champiñones", 0.50);
            r.CreaNuevoAditivo("Pizza", "Aceitunas", 0.75);
            r.CreaNuevoAditivo("Pizza", "Atún", 1.00);

            r.CreaNuevoPlato("Spaguetti", 2.50);
            r.CreaNuevoAditivo("Spaguetti", "Salsa bolognesa", 0.25);
            r.CreaNuevoAditivo("Spaguetti", "Salsa besamel", 0.25);
            r.CreaNuevoAditivo("Spaguetti", "Queso", 0.50);
            r.CreaNuevoAditivo("Spaguetti", "Jamón", 0.75);

            r.CreaNuevoPlato("Risotto", 3.00);
            r.CreaNuevoAditivo("Risotto", "Pescado", 1.00);
            r.CreaNuevoAditivo("Risotto", "Mariscos", 2.00);

            Console.WriteLine("*****MENÚ*****");
            foreach (var tipoPlato in r.Menu)
            {
                Console.WriteLine("{0, -17} .....{1}", tipoPlato.Nombre, tipoPlato.PrecioBase);
                foreach (var aditivo in tipoPlato.AditivosDisponibles)
                    Console.WriteLine("  {0, -15} .....{1}+", aditivo.Nombre, aditivo.Precio);
            }

            //*****MENU*****
            //Pizza             .....2.75
            //  Jamón           .....0.5+
            //  Champiñones     .....0.5+
            //  Aceitunas       .....0.75+
            //  Atún            .....1+
            //Spaguetti         .....2.5
            //  Salsa bolognesa .....0.25+
            //  Salsa besamel   .....0.25+
            //  Queso           .....0.5+
            //  Jamón           .....0.75+
            //Risotto           .....3
            //  Pescado         .....1+
            //  Mariscos        .....2+

            r.IniciaOrden();
            r.Selecciona("Risotto");        // En preparación: "Risotto"
            r.Selecciona("Mariscos");       // En preparación: "Risotto con Mariscos"
            r.FinalizaOrden();              // Terminado: "Risotto con Mariscos" (5.00)

            r.IniciaOrden();
            r.Selecciona("Pizza");          // En preparación: "Pizza"
            r.Selecciona("Spaguetti");      // Terminado: "Pizza" (2.75), En preparación: "Spaguetti"
            r.Selecciona("Salsa bolognesa"); // En preparación: "Spaguetti con Salsa bolognesa"
            r.Selecciona("Jamón");          // En preparación: "Spaguetti con Salsa bolognesa y Jamón"
            r.FinalizaOrden();              // Terminado: "Spaguetti con Salsa bolognesa y Jamón" (3.50)

            Console.WriteLine();
            Console.WriteLine("*****ÓRDENES ATENDIDAS*****");
            foreach (var x in r.OrdenesAtendidas)
                Console.WriteLine(x);

            //*****ORDENES ATENDIDAS*****
            //5
            //6.25
        }
    }
}
