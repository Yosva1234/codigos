using System;
using System.Collections.Generic;
using System.Text;
using Examen;

namespace EjercicioGrafo
{
    public class GrafoDirigido<T>  :IGrafoDirigido<T>
    {
        public GrafoDirigido()
        {
            
        }

        #region IGrafoDirigido<T> Members

        public void AgregarArista(T v1, T v2)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AgregarVertice(T vertice)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumerable<Arista<T>> Aristas
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int CantAristas
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int CantVertices
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool ContieneArista(T v1, T v2)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool ContieneVertice(T vertice)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void EliminarArista(T v1, T v2)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void EliminarVertice(T vertice)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GradoDeEntrada(T vertice)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GradoDeSalida(T vertice)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IGrafoDirigido<T> Simetrico()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IGrafoDirigido<T> SubGrafo(IEnumerable<T> vertices)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Vaciar()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumerable<T> Vertices
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
