using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Colleciones;

namespace Weboo.Examen.Extraordinario
{
    public class BuscandoPadre
    {
        public static Arbol<T> Reconstruye<T>(T[] valores, int[] indicePadres)
        {
            Arbol<T>[] arboles = new Arbol<T>[valores.Length];
            for (int i = 0; i < valores.Length; i++)
                arboles[i] = new Arbol<T>(valores[i]);
            for (int i = 0; i < valores.Length; i++)
                if (indicePadres[i] != -1)
                    arboles[indicePadres[i]].Children.Add(arboles[i]);
            for (int i = 0; i < valores.Length; i++)
                if (indicePadres[i] == -1) return arboles[i];
            throw new Exception("No hay raiz");
        }
    }
}

