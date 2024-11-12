using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolucionUbicandoPiezas;

namespace ProbandoSolucion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejemplo del documento
            bool[][,] piezas = new bool[][,]
            {
                new bool[,]
                {
                    {false, true, true },
                    {true , true, false}
                },
                
                new bool[,]
                {
                    {true, false, false},
                    {true, true, true },
                    {true, false, false}
                },

                new bool[,]
                {
                    {true, true},
                    {true, true}
                }
            };

            Console.WriteLine(Examen.PuedenUbicarse(piezas, 5, 3));//Debe imprimir True
        }
    }
}
