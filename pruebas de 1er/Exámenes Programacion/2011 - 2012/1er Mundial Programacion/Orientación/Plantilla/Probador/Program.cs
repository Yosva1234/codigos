using System;
using Weboo.Examen;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {

            MatrizEsparcida m1 = new MatrizEsparcida(10000000, 500000);
            m1[100, 230] = 10;
            m1[110, 100000] = -3;
            m1[10000, 500] = 45;
            m1[999999, 345676] = 89;

            MatrizEsparcida m2 = new MatrizEsparcida(10000000, 500000);
            m2[100, 230] = 56;
            m2[80, 90] = -78;
            m2[10000, 500] = -45;
            m2[880, 123456] = 68;

            //Calculando la suma de m1 y m2 e imprimiendo las celdas distintas de cero
            Console.WriteLine("Suma");
            MatrizEsparcida suma = m1.Suma(m2);
            foreach (Celda c in suma)
                Console.WriteLine("suma[{0}, {1}] = {2}", c.Fila, c.Columna, c.Valor);

            suma[100, 10] = 34;
            suma[100, 1000] = 48;


            Console.WriteLine();
            //Imprimiendo los elementos distintos de cero en la fila 100
            Console.WriteLine("Elementos en la fila 100");
            foreach (Celda c in suma.ElementosEnFila(100))
                Console.WriteLine("suma[{0}, {1}] = {2}", c.Fila, c.Columna, c.Valor);

            //Se asigna valor cero a un elemento de la matriz
            suma[880, 123456] = 0;

            Console.WriteLine();
            //Imprimiendo la transpuesta de la matriz suma modificada
            Console.WriteLine("Transpuesta");
            foreach (Celda c in suma.Transpuesta)
                Console.WriteLine("t[{0}, {1}] = {2}", c.Fila, c.Columna, c.Valor);
        }
    }
}
