using System;
using System.Collections.Generic;
using System.Text;
using Matrices;

namespace EnvolviendoMatrices
{
    public class Prueba
    {
        /// <summary>
        /// Metodo encargado de determi9nar la menor cantidad de dobleces
        /// </summary>
        /// <param name="matriz">Matriz a envolver</param>
        /// <returns>Arrehglo con la menor cantidad de dobleces</returns>
        public static Doblez[] Envolver(int[,] matriz)
        {
            var result = new List<Doblez>();
            Envolver(matriz, new List<Doblez>(), result);
            return result.ToArray();
        }

        /// <summary>
        /// Metodo encargado de determinar la menor cantidad de dobleces
        /// </summary>
        /// <param name="matriz">Matriz a doblar</param>
        /// <param name="doblecesActuales">Numero de dobleces por nivel</param>
        /// <param name="mejorDoblez">Mejor cantidad de dobleces</param>
        /// <returns>Arreglo con la menor cantidad de dobleces</returns>
        public static void Envolver(int[,] matriz, List<Doblez> doblecesActuales, List<Doblez> mejorDoblez)
        {
            #region Envolver por las filas...

            for (int i = 1; i < matriz.GetLength(0); i++)
            {
                var subMatriz = Matriz.SubMatriz(matriz, 0, 0, i, matriz.GetLength(1));
                {
                    for (int j = i + 1; j < matriz.GetLength(0); j++)
                    {
                        var subMatriz2 = Matriz.SubMatriz(matriz, j, j, matriz.GetLength(0)-j , matriz.GetLength(1));
                    }
                }
            }



            #endregion Envolver por las filas...
        }



        #region Envolver por las columnas...
        #endregion Envolver por las columnas...
    }
}
