using System;
using System.Collections.Generic;

namespace Problema3
{
    public class ColaConCategorias<T> : IEnumerable<T>
    {
        private int _count;

        private int _dequeCurr;
        private int _dequeLeft;

        private readonly List<string> _categories;
        private readonly List<int> _categValue;

        private readonly Dictionary<string, Queue<T>> _data;

        /// <summary>
        /// Inicializa una nueva instancia de PartitionedQueue. Esta cola comienza sin categorías ni elementos.
        /// </summary>
        public ColaConCategorias()
        {
            _count = 0;

            _dequeCurr = _dequeLeft = -1;

            _categories = new List<string>();
            _categValue = new List<int>();

            _data = new Dictionary<string, Queue<T>>();
        }

        /// <summary>
        /// Agrega una nueva categoría en la cola particionada. 
        /// La categoría se describe en forma de texto. La categoría agregada será atendida de última (hasta tanto se agregue otra).
        /// </summary>
        /// <param name="categoria">Un texto para definir la categoría.</param>
        /// <param name="cantidad">La cantidad de elementos que son desencolados de forma consecutiva de esta categoría. Este valor debe ser mayor o igual que 1.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Esta excepción se lanza cuando el valor de cantidad no es mayor o igual a 1.</exception>
        /// <exception cref="System.ArgumentNullException">Esta excepción se lanza cuando el valor de la categoría es null.</exception>
        /// <exception cref="System.ArgumentException">Esta excepción se lanza cuando el valor de la categoría ya está agregado en la cola.</exception>
        public void AgregaCategoria(string categoria, int cantidad)
        {
            if (categoria == null)
                throw new ArgumentNullException("categoria");

            if (_categories.Contains(categoria))
                throw new ArgumentException("This category already exists");

            if (cantidad < 1)
                throw new ArgumentOutOfRangeException("cantidad");

            _categories.Add(categoria);
            _categValue.Add(cantidad);

            _data.Add(categoria, new Queue<T>());
        }

        /// <summary>
        /// Devuelve un objeto IEnumerable con las categorías en las que está particionada la cola actual.
        /// </summary>
        public IEnumerable<string> Categorias
        {
            get
            {
                foreach (string c in _categories)
                    yield return c;
            }
        }

        /// <summary>
        /// Encola un determinado valor en una de las categorías de la cola.
        /// </summary>
        /// <param name="category">Un texto para identificar el nombre de la categoría.</param>
        /// <param name="value">El valor a ser insertado.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Esta excepción se lanza cuando la categoría a la que se refiere no existe en la cola actual.</exception>
        /// <exception cref="System.ArgumentNullException">Esta excepción se lanza cuando el nombre de la categoría es null.</exception>
        public void Enqueue(string category, T value)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            if (!_categories.Contains(category))
                throw new ArgumentOutOfRangeException("category");

            _data[category].Enqueue(value);

            _count++;
        }

        /// <summary>
        /// Devuelve el primer elemento de la cola y lo quita de la cola.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Esta excepción se lanza si la cola actual está vacía.</exception>
        /// <returns>El valor del objeto que estaba en el inicio de la cola.</returns>
        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException();

            if (_dequeLeft <= 0)
            {
                _dequeCurr = (_dequeCurr + 1) % _categories.Count;
                _dequeLeft = _categValue[_dequeCurr];
            }

            while (_data[_categories[_dequeCurr]].Count == 0)
            {
                _dequeCurr = (_dequeCurr + 1)%_categories.Count;
                _dequeLeft = _categValue[_dequeCurr];
            }

            _count--;
            _dequeLeft--;
            return _data[_categories[_dequeCurr]].Dequeue();
        }

        /// <summary>
        /// Devuelve el primer elemento de la cola pero sin desencolarlo.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Esta excepción se lanza si la cola actual está vacía.</exception>
        /// <returns>El valor del objeto que está en el inicio de la cola.</returns>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException();

            int dequeCurr = _dequeCurr;

            if (_dequeLeft <= 0)
                dequeCurr = (dequeCurr + 1) % _categories.Count;

            while (_data[_categories[dequeCurr]].Count == 0)
                dequeCurr = (dequeCurr + 1) % _categories.Count;

            return _data[_categories[dequeCurr]].Peek();
        }

        /// <summary>
        /// Devuelve la cantidad de elementos de la cola.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Devuelve un objeto IEnumerator que permite recorrer los elementos de la cola 
        /// en el orden en que estos serían desencolados si no se produjese ningun Enqueue.
        /// Se garantiza que durante la iteración sobre este iterador no se realizarán operaciones de modificación sobre la cola.
        /// </summary>
        /// <returns>Un objeto IEnumerator que permite recorrer los elementos de la cola.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            int count = _count;
            int dequeCurr = _dequeCurr;
            int dequeLeft = _dequeLeft;
            var data = new Dictionary<string, Queue<T>>();

            foreach (var c in _data)
                data.Add((string) c.Key.Clone(), new Queue<T>(c.Value));

            while (count > 0)
            {
                if (dequeLeft <= 0)
                {
                    dequeCurr = (dequeCurr + 1) % _categories.Count;
                    dequeLeft = _categValue[dequeCurr];
                }

                while (data[_categories[dequeCurr]].Count == 0)
                {
                    dequeCurr = (dequeCurr + 1)%_categories.Count;
                    dequeLeft = _categValue[dequeCurr];
                }

                count--;
                dequeLeft--;
                yield return data[_categories[dequeCurr]].Dequeue();
            }

            yield break;
        }

        /// <summary>
        /// Este metodo ya está implementado.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
