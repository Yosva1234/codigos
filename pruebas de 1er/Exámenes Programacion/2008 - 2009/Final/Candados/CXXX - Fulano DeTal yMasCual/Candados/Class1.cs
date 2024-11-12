using System;
using System.Collections.Generic;
using System.Text;
using Candados.Utiles;

namespace Candados
{
    public class Cerrajero
    {
        public static int[] LlavesParaAbrir(int n, Enlace[] enlaces)
        {
            if (enlaces.Length <= 1)
                return null;

            var result = new List<int>();

            List<Enlace> candadosNoAbiertos;
            var numeroMaxCandadosAbiertos = NumeroCandadosSueltos(0, enlaces, out candadosNoAbiertos);
            var llaveActual = 0;
            for (int i = 1; i < n - 1; i++)
            {
                List<Enlace> minCandadosNoAbiertos;
                var temp = NumeroCandadosSueltos(i, enlaces, out minCandadosNoAbiertos);
                if (temp > numeroMaxCandadosAbiertos)
                {
                    numeroMaxCandadosAbiertos = temp;
                    llaveActual = i;
                    candadosNoAbiertos = new List<Enlace>(minCandadosNoAbiertos);
                }
            }
            result.Add(llaveActual);
            var aux = LlavesParaAbrir(n, candadosNoAbiertos.ToArray());
            if (aux != null)
            {
                result.AddRange(aux);
            }
            return result.ToArray();
        }

        private static int NumeroCandadosSueltos(int candado, Enlace[] candados, out List<Enlace> candadosNoAbiertos)
        {
            var result = 0;
            {
                candadosNoAbiertos = new List<Enlace>();
                var candadosAbiertos = new List<int>();
                for (int i = 0; i < candados.Length; i++)
                {
                    if (candados[i].Candado1 == candados[i].Candado2)
                        continue;

                    if (candados[i].Candado1 == candado || candados[i].Candado2 == candado)
                    {
                        result++;
                        candadosAbiertos.Add(i);
                    }
                }

                for (int i = 0; i < candados.Length; i++)
                {
                    if (!candadosAbiertos.Contains(i))
                    {
                        candadosNoAbiertos.Add(candados[i]);
                    }
                }
            }
            return result;
        }
    }
}
