using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvolviendoMatrices;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {

            var matrizAEnvolver = new [,]

                                      {
                                           {5 ,1 ,1 ,5 ,2 ,2},
                                           {5 ,1 ,1 ,5 ,2 ,2},
                                           {2 ,1 ,1 ,2 ,1 ,5},
                                           {5 ,2 ,2 ,5 ,8 ,1},
                                           {5 ,2 ,2 ,5 ,8 ,1}
                                      };

            Prueba.Envolver(matrizAEnvolver);


        }
    }
}
