using System;
using System.Collections.Generic;
using System.Text;
using Weboo.Quadtries;

namespace Redondeando
{
    public class RedondeoQuadtree
    {
        public static int MinimoRedondeo(Quadtree q)
        {
            return 0;
        }
        public static List<List<Quadtree>> RecorridoPorNiveles(Quadtree arbol)
        {
            var result = new List<List<Quadtree>> { new List<Quadtree>(new[] { arbol }) };
            {
                for (int i = 0; i < result.Count; i++)
                {
                    var temp = result[i];
                    for (int j = 0; j < temp.Count; j++)
                    {
                        var padre = temp[j];
                        var nivel = new List<Quadtree>();
                        {
                            for (int k = 0; k < padre.CantidadDeHijos; k++)
                            {
                                if (k == 0)
                                    nivel.Add(padre.Hijo0);
                                if (k == 1)
                                    nivel.Add(padre.Hijo1);
                                if (k == 2)
                                    nivel.Add(padre.Hijo2);
                                if (k == 3)
                                    nivel.Add(padre.Hijo3);
                            }
                        }
                        if (nivel.Count != 0)
                            result.Add(nivel);
                    }
                }
            }
            return result;
        }


        private static void Redondear(List<List<Quadtree>> recorridoPorNiveles, int index)
        {
            
        }

    }
}
