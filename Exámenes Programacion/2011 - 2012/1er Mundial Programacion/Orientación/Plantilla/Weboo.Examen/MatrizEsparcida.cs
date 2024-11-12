using System;
using System.Collections.Generic;

namespace Weboo.Examen
{
    public class MatrizEsparcida:IEnumerable<Celda>
    {
        /// <summary>
        /// Crea una instancia de MatrizEsparcida a partir de sus dimensiones.
        /// Inicialmente todos los elementos son cero;
        /// </summary>
        /// <param name="filas">Cantidad de filas de la nueva matriz.</param>
        /// <param name="columnas">Cantidad de columnas de la nueva matriz.</param>
        public MatrizEsparcida(int filas, int columnas)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna la cantidad de filas de la matriz.
        /// </summary>
        public int Filas { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Retorna la cantidad de columnas de la matriz;
        /// </summary>
        public int Columnas { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Asigna o retorna el valor de un elemento de la matriz a partir de su posición.
        /// </summary>
        /// <param name="fila">La fila del elemento.</param>
        /// <param name="columna">La columna del elemento.</param>
        /// <returns>Retorna el valor de la celda o lanza IndexOutOfRangeException si la posición no es correcta.</returns>
        public int this[int fila, int columna] 
        { 
            get 
            {
                throw new NotImplementedException();
            }

            set 
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Retorna la cantidad de celdas distintas de cero contenidas en la matriz.
        /// </summary>
        public int CeldasNoCero { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Retorna la matriz transpuesta.
        /// </summary>
        public MatrizEsparcida Transpuesta 
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Calcula la suma de con otra matriz.
        /// </summary>
        /// <param name="m">Otra matriz esparcida.</param>
        /// <returns>Retorna una matriz que representa la suma..</returns>
        public MatrizEsparcida Suma(MatrizEsparcida m) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna los elementos distintos de cero contenidos en una columna de la matriz ordenados por fila.
        /// </summary>
        /// <param name="columna">Columna de los elementos a retornar.</param>
        /// <returns>Un IEnumerable que contiene los elementos de la columna dada como parámetro ordenados por fila.</returns>
        public IEnumerable<Celda> ElementosEnColumna(int columna)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna los elementos distintos de cero contenidos en una fila de la matriz ordenados por columna.
        /// </summary>
        /// <param name="fila">Fila de los elementos a retornar.</param>
        /// <returns>Un IEnumerable que contiene los elementos de la fila dada como parámetro ordenados por columna.</returns>
        public IEnumerable<Celda> ElementosEnFila(int fila)
        {
            throw new NotImplementedException();
        }

        #region IEnumerable<Celda> Members

        public IEnumerator<Celda> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
