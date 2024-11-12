using System;
using System.Collections.Generic;
using System.Text;
using LibEjercicioMitad;

namespace EjercicioMitad
{
    public class Solucion
    {
        public static Arbol<T> Mitad<T>(Arbol<T> a)
        {
            return Mitad(a, a);
        }

        public static Arbol<T> Mitad<T>(Arbol<T> t, Arbol<T> l)
        {
            Arbol<T> mitad = null;

            for (int i = 0; i < l.Hijos.Count && mitad == null; i++)
            {
                Arbol<T> s = l.Hijos[i];
                l.Hijos.Remove(s);
                
                if (iguales(t,s))
                    mitad = s;

                l.Hijos.Insert(i,s);
            }

            if (mitad != null)
                return mitad;

            foreach(Arbol<T> hijo in l.Hijos)
            {
                mitad = Mitad<T>(t, hijo);
                if (mitad != null)
                    return mitad;
            }

            return null;
        }


        private static bool iguales<T>(Arbol<T> t, Arbol<T> s)
        {
            if (!t.Valor.Equals(s.Valor))
                return false;

            if (t.Hijos.Count != s.Hijos.Count)
                return false;

            for (int i = 0; i < t.Hijos.Count; i++)
                if (!iguales(t.Hijos[i], s.Hijos[i]))
                    return false;

            return true;
        }

    }
}
