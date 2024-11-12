using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolucionCaminosEnergia
{
    public class Examen
    {
        private static bool Isposible(int [,] matriz, int row , int column){
            return row >= 0 && row < matriz.GetLength(0) && column >= 0 && column < matriz.GetLength(1);
        }
        public static bool HayCamino(int[,] matriz, int f1, int c1, int f2, int c2, int consumoMaximo)
        {
            if (f1 == f2 && c1 == c2)
                return true;
            if (Isposible(matriz,f1-1,c1)){
                if (matriz[f1-1,c1] < matriz[f1,c1]){
                    if (consumoMaximo -1 >=0){
                        if(HayCamino(matriz,f1-1,c1,f2,c2,consumoMaximo-1))
                           return true;
                    }
                }
                int temp = (consumoMaximo -(1 + (matriz[f1-1,c1] - Math.Abs(matriz[f1,c1]))));
                    if (temp >= 0){
                        if(HayCamino(matriz,f1-1,c1,f2,c2,temp))
                           return true;
                    }
            } // Primer caso
            if (Isposible(matriz,f1+1,c1)){
                if (matriz[f1+1,c1] < matriz[f1,c1]){
                    if (consumoMaximo +1 >=0){
                        if(HayCamino(matriz,f1+1,c1,f2,c2,consumoMaximo-1))
                           return true;
                    }
                }
                int temp = (consumoMaximo -(1 + (matriz[f1-1,c1] - Math.Abs(matriz[f1,c1]))));
                    if (temp >= 0){
                        if(HayCamino(matriz,f1-1,c1,f2,c2,temp))
                           return true;
                    }
            } // Segundo caso
            if (Isposible(matriz,f1,c1-1)){
                if (matriz[f1,c1-1] < matriz[f1,c1]){
                    if (consumoMaximo -1 >=0){
                        if(HayCamino(matriz,f1,c1-1,f2,c2,consumoMaximo-1))
                           return true;
                    }
                }
                int temp = (consumoMaximo -(1 + (matriz[f1,c1-1] - Math.Abs(matriz[f1,c1]))));
                    if (temp >= 0){
                        if(HayCamino(matriz,f1,c1-1,f2,c2,temp))
                           return true;
                    }
                
            } // Tercer caso
            if (Isposible(matriz,f1,c1+1)){
                if (matriz[f1,c1+1] < matriz[f1,c1]){
                    if (consumoMaximo -1 >=0){
                        if(HayCamino(matriz,f1,c1+1,f2,c2,consumoMaximo-1))
                           return true;
                    }
                }
                int temp = (consumoMaximo -(1 + (matriz[f1,c1+1] - Math.Abs(matriz[f1,c1]))));
                    if (temp >= 0){
                        if(HayCamino(matriz,f1,c1+1,f2,c2,temp))
                           return true;
                    }
            }
            return false;
        
    }
}
}
