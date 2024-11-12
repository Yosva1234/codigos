using System;
using System.Collections.Generic;
using System.Text;
using Weboo.Arboles;

namespace CaminoPosteriores
{
    public static class Respuesta
    {



        public static IEnumerable<T> Camino<T>(Arbol<T> a, T x)
        {
            var result = new List<T>();
            {
                Hallarcamino(a, x, result);
            }
            return result;
        }
        public static IEnumerable<T> Posteriores<T>(Arbol<T> a, T x)
        {
            //...
        }

        private static bool Hallarcamino<T>(Arbol<T> arbol, T elemento, List<T> camino)
        {
            if (arbol.Valor.Equals(elemento))
            {
                camino.Add(elemento);
                return true;
            }

            foreach (var subArbol in arbol.Hijos)
            {
                camino.Add(subArbol.Valor);
                {
                    if (Hallarcamino(subArbol, elemento, camino))
                    {
                        return true;
                    }

                }
                camino.Remove(subArbol.Valor);
            }
            return false;
        }

    }

}
