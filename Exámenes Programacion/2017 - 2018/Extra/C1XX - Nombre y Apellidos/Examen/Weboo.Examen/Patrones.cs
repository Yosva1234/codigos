using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Examen
{
    public class Patrones
    {
        public static int CantidadValidos(int k, int filas, int columnas)
        {
            int[] combinaciones = new int[(k + 1) * 2];
            return CantidadValidos(k, filas, columnas, 0, combinaciones); 
        }
        public static int CantidadValidos(int k, int filas, int columnas, int pos, int[] combinaciones)
        {
            int cantidad = 0;
            if (k == 0) return 0;
           if(pos== combinaciones.Length)
            {
                if (EsValida(combinaciones,filas,columnas))
                {
                    bool[,] mascara = new bool[filas, columnas];
                    if (Aristas(combinaciones, mascara, k))
                    {
                        return 1;
                    }
                }
                return 0;
            }
           for(int i=0; i< Math.Max(filas, columnas); i++)
            {
                combinaciones[pos] = i;
                cantidad += CantidadValidos(k, filas, columnas, pos + 1, combinaciones);
            }
            return cantidad;
        }
        public static bool EsValida(int[] combinaciones, int filas, int columnas)
        {
            if (combinaciones[0] == combinaciones[combinaciones.Length / 2 - 1] && combinaciones[combinaciones.Length / 2] == combinaciones[combinaciones.Length - 1]) return false;
            if (filas < columnas)
            {
                for (int i = 0, j = combinaciones.Length / 2; i < combinaciones.Length / 2 && j < combinaciones.Length; i++, j++)
                {
                    if (i + 1 < combinaciones.Length / 2 && j + 1 < combinaciones.Length)
                    {
                        if (combinaciones[i] >= filas) return false;
                        if (combinaciones[i + 1] >= filas) return false;
                        if (combinaciones[i] == combinaciones[i + 1] && combinaciones[j] == combinaciones[j + 1]) return false;
                    }

                }
            }
            else if(columnas< filas)
            {
                for (int i = 0, j = combinaciones.Length / 2; i < combinaciones.Length / 2 && j < combinaciones.Length; i++, j++)
                {
                    if (i + 1 < combinaciones.Length / 2 && j + 1 < combinaciones.Length)
                    {
                        if (combinaciones[j] >= columnas) return false;
                        if (combinaciones[j + 1] >= columnas) return false;
                        if (combinaciones[i] == combinaciones[i + 1] && combinaciones[j] == combinaciones[j + 1]) return false;
                    }

                }
            }
            else
            {
                for (int i = 0, j = combinaciones.Length / 2; i < combinaciones.Length / 2 && j < combinaciones.Length; i++, j++)
                {
                    if (i + 1 < combinaciones.Length / 2 && j + 1 < combinaciones.Length)
                    {
                        if (combinaciones[i] == combinaciones[i + 1] && combinaciones[j] == combinaciones[j + 1]) return false;
                    }

                }
            }
            return true;
        }
        public static bool Aristas(int [] combinaciones,bool [,] Mascara, int k )
        {
            int cantidad=0;
            for(int i=0, j=combinaciones.Length/2;i< combinaciones.Length/2 && j< combinaciones.Length; i++, j++)
            {
                
                if(i+ 1< combinaciones.Length/2 && j+1< combinaciones.Length)
                {
                        Mascara[combinaciones[i], combinaciones[j]] = true;   
                    if (Math.Abs(combinaciones[i]- combinaciones[i+1])== Math.Abs(combinaciones[j]- combinaciones[j + 1]))
                    {
                        if(combinaciones[i]< combinaciones[i+1])
                        {
                            if(combinaciones[j]< combinaciones[j + 1])
                            {
                             for(int s= combinaciones[i], h= combinaciones[j]; s< combinaciones[i+1] && h< combinaciones[j+1]; s++, h++)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }
                            else
                            {
                             for(int s= combinaciones[i], h= combinaciones[j]; s< combinaciones[i+1] && h> combinaciones[j + 1]; s++, h--)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }

                        }
                        else
                        {
                            if(combinaciones[j]< combinaciones[j+1])
                            {
                                for (int s = combinaciones[i], h = combinaciones[j]; s > combinaciones[i + 1] && h < combinaciones[j + 1]; s--, h++)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }
                            else
                            {
                                for (int s = combinaciones[i], h = combinaciones[j]; s > combinaciones[i + 1] && h > combinaciones[j + 1]; s--, h--)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }
                        }
                        if (!Mascara[combinaciones[i + 1], combinaciones[j + 1]])
                            cantidad += 1;
                    }
                  else if(combinaciones[i]== combinaciones[i + 1])
                    {
                        if (combinaciones[j] < combinaciones[j + 1])
                        {
                            for (int s = combinaciones[j]; s < combinaciones[j + 1]; s++)
                            {
                                if (!Mascara[combinaciones[i], s]) return false;
                            }
                        }
                        else
                        {
                            for (int s = combinaciones[j]; s > combinaciones[j + 1]; s--)
                            {
                                if (!Mascara[combinaciones[i], s]) return false;
                            }

                        }
                        if(!Mascara[combinaciones[i+1],combinaciones[j+1]])
                        cantidad += 1;

                    }
                  else if( combinaciones[j]== combinaciones[j + 1])
                    {
                        if (combinaciones[i] < combinaciones[i + 1])
                        {
                            for (int s = combinaciones[i]; s < combinaciones[i + 1]; s++)
                            {
                                if (!Mascara[s,combinaciones[j]]) return false;
                            }
                        }
                        else
                        {
                            for (int s = combinaciones[i]; s > combinaciones[i + 1]; s--)
                            {
                                if (!Mascara[s, combinaciones[j]]) return false;
                            }

                        }
                        if(!Mascara[combinaciones[i+1], combinaciones[j+1]])
                        cantidad += 1;
                    }
                  else  if (Math.Abs(combinaciones[i] - combinaciones[i + 1]) != Math.Abs(combinaciones[j] - combinaciones[j + 1]))
                    {
                        if (!Mascara[combinaciones[i + 1], combinaciones[j + 1]])
                        {
                            cantidad += 1;
                        }
                    }
                }
            }
            if (Mascara[combinaciones[combinaciones.Length / 2 - 1], combinaciones[combinaciones.Length-1]])
                return false;
            if (cantidad == k)
            {
                return true;
            }
            return false;
        }
    }
}