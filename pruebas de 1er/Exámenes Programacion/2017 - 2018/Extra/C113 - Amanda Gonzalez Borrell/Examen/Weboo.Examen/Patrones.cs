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
            int totaldepasarunaposicion = 0;
            bool[,] mascara = new bool[filas, columnas];
            int[] fila = new int[(k +1) *2];
            List<int> columna = new List<int>();
            totaldepasarunaposicion = CantidadValidos(k,filas , columnas,fila, 0); 
            return totaldepasarunaposicion;
        }
        public static int CantidadValidos(int numeroaristas,int filas,int columnas, int[] lista, int contador)
        {
            bool[,] mascara = new bool[filas, columnas];
            int total = 0;
            int to=0;
            if (contador == ((numeroaristas + 1) * 2))
            {
                if (descartar(lista, filas, columnas, numeroaristas))
                {
                    List<int> filitas = new List<int>();
                    List<int> colum = new List<int>();
                    for (int i = 0; i < lista.Length/2; i++)
                    {
                        filitas.Add(lista[i]);
                    }
                    for (int i = lista.Length/2; i < lista.Length; i++)
                    {
                        colum.Add(lista[i]);
                    }
                    if (VerificarDistancia(mascara, numeroaristas, filitas, colum,  to))
                    {

                        return 1;
                    }
                }
            }
            else
            {
                for (int j = 0; j < Math.Max(filas, columnas); j++)
                {
                    lista[contador] = j;
                    total += CantidadValidos(numeroaristas, filas, columnas, lista, contador + 1);
                }
            } 

            return total;
            
        }
        public static bool VerificarDistancia(bool[,] combinaciones, int numeroaristas, List<int> fila, List<int> columna,  int total)
        {
            total = 0;
            int count = 0;
            for (int i = 0, j = 0; i < fila.Count && j < columna.Count; i++, j++)
            {
                if (i + 1 < fila.Count && j + 1 < columna.Count)
                {
                    if (Math.Abs(columna[j] - columna[j + 1]) == Math.Abs(fila[i] - fila[i + 1]) && !combinaciones[fila[i + 1], columna[j + 1]])
                    {
                        combinaciones[fila[i], columna[j]] = true;
                        for (int h=fila[i];  h< fila[i +1]; h ++)
                        {
                           for(int m= columna[j];m< columna[j +1]; m++)
                         {
                                if (m == h && !combinaciones[m, h]) count++;
                         }
                        }
                        if (count > total) return false;
                        total += Math.Abs(fila[i] - fila[i + 1]);
                        if (total > numeroaristas) return false;
                    }
                    else if(columna[j] == columna[j + 1]  && !combinaciones[fila[i + 1], columna[j + 1]])
                    {
                        combinaciones[fila[i], columna[j]] = true;
                        for (int h = fila[i]; h < fila[i + 1]; h++)
                        {
                            if (!combinaciones[h, columna[j]]) count ++;

                        }
                        if (count > total) return false;
                        total += Math.Abs(fila[i] - fila[i + 1]);
                        if (total > numeroaristas) return false;
                        combinaciones[fila[i], columna[j]] = true;

                    }
                    else if ((fila[i] == fila[i + 1]) && !combinaciones[fila[i + 1], columna[j + 1]])
                    {
                        total += Math.Abs(columna[j] - columna[j + 1]);
                        if (total > numeroaristas) return false;
                        combinaciones[fila[i], columna[j]] = true;

                    }
                    //else if (Math.Abs(columna[j] - columna[j + 1]) == 1 || Math.Abs(fila[i] - fila[i + 1]) == 1 && !combinaciones[fila[i + 1], columna[j + 1]])
                    //{
                    //    total += 1;
                    //    if(total > numeroaristas) return false;
                    //    combinaciones[fila[i], columna[j]] = true;
                        
                    //}
                    else if (Math.Abs(columna[j] - columna[j + 1]) != Math.Abs(fila[i] - fila[i + 1]) && !combinaciones[fila[i + 1], columna[j + 1]])
                    {
                        total += 1;
                        combinaciones[fila[i], columna[j]] = true;
                        if (total > numeroaristas) return false;
                    }
                }
            }
            if (numeroaristas != total) return false;
            return true;
        }
        public static bool descartar(int [] fil, int filas, int columnas, int aristas)
        {
            
             if (fil[0] == fil[fil.Length/2-1] && fil[fil.Length/2] == fil[fil.Length-1])
                    return false; 
            for (int i = 0,j= fil.Length/2; i < fil.Length/2 && j<fil.Length; i++, j ++)
            {
                if (fil[i] >= filas || fil[j] >= columnas)
                    return false;
                if (i +1 < fil.Length/2 && j +1 < fil.Length)
                    {
                      if ( fil[i] == fil[i + 1] && fil[j]== fil[j +1] )
                        return false; 
                    }
                
            }
            return true;
        }
        public static bool[,] llenarmascara(List<int> fila, List<int> columnas)
        {
            bool[,] mascara = new bool[fila.Count, columnas.Count];
            for (int i = 0, j = 0; i < fila.Count && j < columnas.Count; i++, j++)
            {
                mascara[fila[i], columnas[j]] = true;
            }
            return mascara;
        }
            
        
    }
}