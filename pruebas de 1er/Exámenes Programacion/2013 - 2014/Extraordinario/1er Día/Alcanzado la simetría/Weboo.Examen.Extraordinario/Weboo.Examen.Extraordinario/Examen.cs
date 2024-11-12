using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Arboles;

namespace Weboo.Examen.Extraordinario
{
    public class Examen
    {
        public static int CantidadDeInserciones(IArbol arbol)
        {
            return CantidadDeInserciones(arbol.HijoIzq, arbol.HijoDer);
        }
        public static int CantidadDeInserciones(IArbol izquierdo,IArbol derecho)
        {
            if (izquierdo == null && derecho == null) return 0;
            int result = 0;
            if (izquierdo != null && derecho != null)
            {
                result += CantidadDeInserciones(izquierdo.HijoIzq, derecho.HijoDer);
                result += CantidadDeInserciones(izquierdo.HijoDer, derecho.HijoIzq);
            }
            else
            {
                if (izquierdo == null)
                {
                    result++;
                    result += CantidadDeInserciones(null, derecho.HijoDer);
                    result += CantidadDeInserciones(null, derecho.HijoIzq);
                }
                else
                {
                    result++;
                    result += CantidadDeInserciones(izquierdo.HijoIzq, null);
                    result += CantidadDeInserciones(izquierdo.HijoDer, null);
                }
            }
            return result;
        }
    }
}
