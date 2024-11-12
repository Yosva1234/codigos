using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen
{
    public class CaminoSeguro
    {
        public static int LongitudMinimaRutaSegura(bool[,] tablero)
        {
            //bool[,] MueveRey = new bool[tablero.GetLength(0), tablero.GetLength(1)];
            //int mejorcantidaddepasos = int.MaxValue;
            //CalculodeLaLongitudMinima(tablero, MueveRey, tablero.GetLength(0) - 1, 0, 1, ref mejorcantidaddepasos);
            //if (mejorcantidaddepasos == int.MaxValue)
            //    return 0;
            //return mejorcantidaddepasos;

            Queue<two> lista = new Queue<two>();
            lista.Enqueue(new two(tablero.GetLength(0) - 1, 0));
            int[,] MueveRey = new int[tablero.GetLength(0), tablero.GetLength(1)];
            MueveRey[tablero.GetLength(0) - 1, 0] = 1;

            CalculoExtra(tablero, MueveRey, ref lista);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(MueveRey[i, j]);
                Console.WriteLine();
            }
            return MueveRey[0, tablero.GetLength(1) - 1];
        }

        static void CalculodeLaLongitudMinima(bool[,] tablero, bool[,] MueveRey, int i, int j, int pasoactual, ref int mejor)
        {
            //Se demora mucho con todos en linea.
            MueveRey[i, j] = true;
            
            if (i == 0 && j == tablero.GetLength(1) - 1)
                if (pasoactual < mejor)
                    mejor = pasoactual;
            if (pasoactual > mejor)
            {
                MueveRey[i, j] = false;
                return;
            }

            int[] dx = { -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };

            for (int k = 0; k < 8; k++)
            {
                int i1 = i + dx[k % 3];
                int j1 = j + dy[k];

                if (Amenazado(tablero, i1, j1) || MueveRey[i1, j1])
                    continue;
                if (tablero[i1, j1])
                {
                    tablero[i1, j1] = false;
                    CalculodeLaLongitudMinima(tablero, MueveRey, i1, j1, pasoactual + 1, ref mejor);
                    tablero[i1, j1] = true;
                }
                else
                    CalculodeLaLongitudMinima(tablero, MueveRey, i1, j1, pasoactual + 1, ref mejor);
            }
            MueveRey[i, j] = false;
        }

        static bool Amenazado(bool[,] tablero, int i, int j)
        {
            if(i < 0 || j < 0 || i >= tablero.GetLength(0) || j >= tablero.GetLength(1))
                return true;
            if(i != tablero.GetLength(0) - 1 && j != tablero.GetLength(1) - 1 && tablero[i + 1, j + 1])
                return true;
            if(i != 0 && j != 0 && tablero[i - 1, j - 1])
                return true;
            if(i != tablero.GetLength(0) - 1 && j != 0 && tablero[i + 1, j - 1])
                return true;
            if(i != 0 && j != tablero.GetLength(1) - 1 && tablero[i - 1, j + 1])
                return true;
            return false;
        }

        struct two 
        {
            public int x;
            public int y;
            public two(int a = 0, int b = 0)
            {
                x = a;
                y = b;
            }
        }

        static void CalculoExtra(bool[,] tablero, int[,] MueveRey, ref Queue<two> lista)
        {
            char[,] a = { {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                          {'-','-','-','-','-','-','-','-'},
                         };
            while (lista.Count != 0)
            {
                int[] dx = { -1, 0, 1 };
                int[] dy = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
                tablero[lista.Peek().x, lista.Peek().y] = false;
                for (int k = 0; k < 9; k++)
                {
                    int i1 = lista.Peek().x + dx[k % 3];
                    int j1 = lista.Peek().y + dy[k];

                    if (Amenazado(tablero, i1, j1))
                        continue;
                    else if (MueveRey[i1, j1] > MueveRey[lista.Peek().x, lista.Peek().y] + 1 || MueveRey[i1, j1] == 0)
                    {
                        a[i1, j1] = '+';
                        MueveRey[i1, j1] = MueveRey[lista.Peek().x, lista.Peek().y] + 1;
                        lista.Enqueue(new two(i1, j1));
                    }
                    
                }
                
                lista.Dequeue();
            }
            for(int i = 0; i < 8; i++){
                for (int j = 0; j < 8; j++)
                    Console.Write(a[i,j]);
                Console.WriteLine();
                }
        }
    }
}
