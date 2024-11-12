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
            if (cajas.Length == 0) return 0;
            int[] combinaciones = new int[cajas.Length];
            return CantidadCombinaciones(cajas, alturaMax, 0, combinaciones) ;
            
        }
        public static int CantidadCombinaciones(int [] cajas, int alturaMaxima, int pos, int [] combinaciones )
        {
            int cantidad = 0;
            if (pos == cajas.Length)
            {
                if (CumpleConLaAltura(combinaciones, cajas, alturaMaxima))
                    return 1;
                pos = 0; 
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    combinaciones[pos] = i;
                    cantidad += CantidadCombinaciones(cajas, alturaMaxima, pos + 1, combinaciones);
                }
            }
            return cantidad;
        }
        public static bool CumpleConLaAltura(int [] comBinaciones,int [] cajas, int altura)
        {
          int [] auxiliar=  LlenarArray(comBinaciones, cajas);
            if (Auxiliar(auxiliar))
            {
                for (int j = 0; j < auxiliar.Length; j++)
                {
                    if (j + 1 < auxiliar.Length && auxiliar[j]!= 0 && auxiliar[j +1]!= 0)
                    {
                        if (Math.Abs(auxiliar[j] - auxiliar[j + 1]) > altura)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static int [] LlenarArray(int [] combinaciones, int [] cajas)
        { 
            int pos = 0;
            int[] auxiliar = new int[cajas.Length];
            for (int i = 0; i < combinaciones.Length; i++)
            {
                if (combinaciones[i] == 1)
                {
                    auxiliar[pos] = cajas[i];
                    pos++;
                }
            }
            return auxiliar;
        }
        public static bool Auxiliar(int [] alturas)
        {
            int count=0;
            for(int i=0; i< alturas.Length; i++ )
            {
                if(alturas[i]> 0)
                {
                    count++;
                }
                
            }
            if (count >= 2) return true;
            return false;
        }
    }
}
