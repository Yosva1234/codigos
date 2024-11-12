using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Arboles;

namespace Weboo.Examen.Extraordinario.Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Examen.CantidadDeInserciones(
                new Arbol(
                    new Arbol(
                        new Arbol(
                            new Arbol(),
                            new Arbol()),
                        null),
                    new Arbol(
                        null,
                        new Arbol(
                            new Arbol(
                                null,
                                new Arbol()),
                            null)))));
            Console.WriteLine(Examen.CantidadDeInserciones(
                new Arbol(
                   new Arbol(
                       new Arbol(
                           new Arbol(), null)
                           , null
                       ),
                       null
                    )
                ));
        }
    }
}
