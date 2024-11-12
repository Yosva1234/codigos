using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstChance
{
    public class Buscador<T>
    {
        public static bool SubArbolesIguales(Arbol<T> arbol, out Arbol<T> gemelo1, out Arbol<T> gemelo2) 
        {
            gemelo1 = null;
            gemelo2 = null;
            int count = 0;
            int auxCount = 0;
            bool habia = false;
            List<Arbol<T>> preordeNodo;

            preordeNodo = arbol.PreordenNodo;

            for (int i = 0; i < preordeNodo.Count - 1; i++)
                for (int j = i + 1; j < preordeNodo.Count; j++)
                    if (preordeNodo[i].Valor.Equals(preordeNodo[j].Valor) && TienenIgualPreOrden(preordeNodo[i], preordeNodo[j], out count) && count > auxCount)
                    {
                            auxCount = count;
                            habia = true;
                            gemelo1 = preordeNodo[i];
                            gemelo2 = preordeNodo[j];
                     }

            return habia;
        }

        private static bool TienenIgualPreOrden(Arbol<T> arbol, Arbol<T> arbol_2, out int count) 
        {
            count = 0;
            List<Arbol<T>> preArbol = arbol.PreordenNodo;
            List<Arbol<T>> preArbol2 = arbol_2.PreordenNodo;

            if (preArbol.Count != preArbol2.Count)
                return false;

            for (int i = 0; i < preArbol.Count; i++)
                if (!preArbol[i].Valor.Equals(preArbol2[i].Valor) || preArbol[i].CantDeHijos != preArbol2[i].CantDeHijos)
                    return false;

            count = preArbol2.Count;
            return true;
        }
    }
}
