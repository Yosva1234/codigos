using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCP2
{
    public class GuaguaConDesperfectos
    {
        public static int MayorCantidadDePersonas(int[,] personasPorCuadra, bool[,] talleres)
        {
            return MayorCantidadDePersonas(personasPorCuadra,talleres,0,0,0,10);
        }
        private static bool Isposible(int [,] matriz, int row , int column){
            return row >= 0 && row < matriz.GetLength(0) && column >= 0 && column < matriz.GetLength(1);
        }
        private static int MayorCantidadDePersonas(int[,] personasPorCuadra, bool[,] talleres, int row , int column, int totalpersonas, int cuadrassintaller )
        {
            if (row == personasPorCuadra.GetLongLength(0) || column == personasPorCuadra.GetLength(1))
                return -1;
            if (row == personasPorCuadra.GetLength(0)-1 && column == personasPorCuadra.GetLength(1) -1)
                return totalpersonas; 
            if (cuadrassintaller ==0 && !talleres[row,column])
                return -1;
            if (talleres[row,column])
                cuadrassintaller = 10;
            if (personasPorCuadra[row,column] != 0)
                totalpersonas+=personasPorCuadra[row,column];
            return Math.Max(MayorCantidadDePersonas(personasPorCuadra,talleres,row-1,column,totalpersonas,cuadrassintaller-1),MayorCantidadDePersonas(personasPorCuadra,talleres,row,column+1,totalpersonas,cuadrassintaller-1));
        }
    }
}
