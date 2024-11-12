using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weboo.Examen.Extra
{
    public class Padre
    {
        public static void ResuelveVacaciones(int[,] ciudades, out int[] viaje1, out int[] viaje2)
        {
            min = int.MaxValue;
             ResuelveVacaciones(ciudades, 0, new int[ciudades.GetLength(0)], new int[ciudades.GetLength(0)],
                 new int[ciudades.GetLength(0)], new int[ciudades.GetLength(0)], out viaje1, out viaje2);
        }

        private static int min;
        private static void ResuelveVacaciones(int[,] ciudades, int c,int[] v1,int[] v2,int[] u1,int[] u2,out int[] viaje1, out int[] viaje2)
        {
            if (c == ciudades.GetLength(0))
            {
                int p = CalculaCosto(ciudades, v1, v2);
                if (p < min)
                {
                    Array.Copy(v1,u1,v1.Length);
                    Array.Copy(v2, u2, v2.Length);
                    min = p;
                }
                viaje1 = u1;
                viaje2 = u2;
                return ;
            }
            for (int i = 0; i < ciudades.GetLength(0); i++)
            {
                if(v1[i] != 0) continue;
                for (int j = 0; j < ciudades.GetLength(0); j++)
                {
                    if(v2[j] != 0 || j==i) continue;
                    v1[i] = v2[j] = c;
                    ResuelveVacaciones(ciudades,c+1,v1,v2,u1,u2,out viaje1,out viaje2);
                    v1[i] = v2[j] = 0;
                }
            }
            viaje1 = u1;
            viaje2 = u2;
        }

        static int CalculaCosto(int[,] ciudades, int[] a, int[] b)
        {
            int result = 0;
            for (int i = 0; i < a.Length - 1; i++)
                result += ciudades[a[i], a[i + 1]] + ciudades[b[i], b[i + 1]];
            return result;
        }

    }
}
