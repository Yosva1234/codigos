using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candados.Utiles;
 

namespace Candaos
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new Enlace[]
                           {
                               new Enlace(0, 1),
                               new Enlace(0, 2),
                               new Enlace(1, 2),
                               new Enlace(1, 4),
                               new Enlace(3, 1),
                               new Enlace(2, 5),
                               new Enlace(4,4)
                           };
            Candados.Cerrajero.LlavesParaAbrir(6, temp);
        }
    }
}
