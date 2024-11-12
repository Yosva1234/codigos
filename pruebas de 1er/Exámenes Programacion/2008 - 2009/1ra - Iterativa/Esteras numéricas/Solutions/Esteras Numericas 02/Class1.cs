using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ExamenEsteras
{
    public class Rieles
    {
        public static int CantidadDePasos(int[,] esteras, int[] riel, int posicion)
        {
            int pasos = 0;
            if (!FueraLugar(esteras, riel, pasos+posicion))
            {
                do
                {
                    RotaEstera(esteras);
                    pasos++;
                } while (!FueraLugar(esteras, riel, pasos + posicion));
            } 

            return pasos-1;
        }

        //
        //***Metosdos auxiaiares***
        //
        public static void RotaEstera(int[,] estera)
        {
            List<int> miPila = new List<int>();
             for(int i=0;i<estera.GetLength(0);i++)
                 for (int j = 0; j < estera.GetLength(1); j++)
                 {
                     miPila.Add(estera[i, j]);
                 }
             int t = miPila[miPila.Count / 2];
             miPila.RemoveAt(miPila.Count / 2);
             miPila.Insert(0, t);
             t = miPila[miPila.Count / 2];
             miPila.RemoveAt(miPila.Count / 2);
             miPila.Insert(miPila.Count, t);
             int x = 0; int y = 0;
             foreach (int i in miPila)
             {
                 estera[y, x] = i;
                 //if (y == 0)
                 //{
                 //    x++;
                 //}
                 //else
                 //{
                 //    x--;
                 //}
                 x++;
                 if (x == estera.GetLength(1))
                 {
                     y++;
                     x = 0;
                 }
             }
        }

        private static bool FueraLugar(int[,] estera, int[] riel, int poss)
        {
            if (poss + estera.GetLength(1) >= riel.Length)
                return true;
            for (int i = 0; i < estera.GetLength(1); i++)
            {
                if (estera[1, i] != riel[poss + i])
                    return true;
            }
            return false;
        }
    }
}
