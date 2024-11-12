using System;
using System.Collections.Generic;
using System.Text;

namespace Weboo.Examen.Final
{
    public class Caminante
    {
        /// <summary>
        /// Dada una secuencias de cajas y la diferencia posible entre alturas,
        /// determinar el número de combinaciones posibles de estas cajas.
        /// </summary>
        /// <param name="cajas">Combinación inicial de cajas</param>
        /// <param name="alturaMax">Diferencia entre las alturas de dos cajas
        /// colocadas de forma consecutivas en el rio</param>
        /// <returns>El número de combinaciones posibles de las cajas</returns>
        public static int CantidadCombinacionesCajas(int[] cajas, int alturaMax)
        {
            int[] combinaciones = new int[cajas.Length];
            int cantidad = 0;
            return CantidadCombinacionesCajas(cajas, alturaMax, 0,combinaciones, cantidad);
        }
        public static int CantidadCombinacionesCajas(int [] cajas, int alturaMax, int pos, int [] combinaciones, int cantidad)
        {
            if (pos == cajas.Length)
            {
                if (Poda(combinaciones))
                {
                    if (Altura(combinaciones, alturaMax, cajas))
                    {
                        return 1;
                    }
                }

            }

            else
            {
                for (int i = 0; i < 2; i++)
                {
                    combinaciones[pos] = i;
                    cantidad += CantidadCombinacionesCajas(cajas, alturaMax, pos + 1, combinaciones, cantidad);
                }
            }

            return cantidad;
        }
        public static bool Poda(int [] combinaciones)
        {
            int cantidadde1 = 0;
            int cantidad0 = 0;
            for (int i = 0; i < combinaciones.Length; i++)
            {
                if (combinaciones[i] == 0) cantidad0 += 1;
                else cantidadde1 += 1;
            }
            if (cantidadde1 == 0 || cantidadde1 == 1) return false;
            return true;
        }
        public static bool Altura(int [] combinaciones, int alturamax, int [] cajas) 
        {
            List<int> cajascon1 = new List<int>();
            for(int i=0; i< cajas.Length; i++)
            {
                if (combinaciones[i] == 1) cajascon1.Add(cajas[i]);
            }
            for(int i=0; i< cajascon1.Count; i++)
            {
                if (i + 1 < cajascon1.Count)
                {
                    if (Math.Abs(cajascon1[i ] - cajascon1[i+1]) > alturamax) return false;
                }
            }
            return true;
        }
    }
}
