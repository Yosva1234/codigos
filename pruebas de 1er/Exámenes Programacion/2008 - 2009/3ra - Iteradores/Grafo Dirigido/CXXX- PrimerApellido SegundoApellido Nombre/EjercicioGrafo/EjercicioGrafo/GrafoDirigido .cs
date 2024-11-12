using System;
using System.Collections.Generic;
using System.Text;
using Examen;

namespace EjercicioGrafo
{
    class Grafo<T>
    {
        public T vertice; public T arista;
        public Grafo(T vertice,T arista) 
        {
            this.arista = arista; this.vertice = vertice;
        
        }
        public Grafo(T vertice) 
        {
            this.vertice = vertice;
        }


    }
    
    
    public class GrafoDirigido<T>  :IGrafoDirigido<T>
    {
        List<Grafo<T>> listaGrafo;
        public GrafoDirigido()
        {
            listaGrafo = new List<Grafo<T>>();
        }

        #region IGrafoDirigido<T> Members

        public void AgregarArista(T v1, T v2)
        {
            bool pertenece = false; pertenece2 = false;
            for(int i=0;i<listaGrafo.Count;i++)
           {
               if (listaGrafo[i].vertice.Equals(v1)) { pertenece = true; }
               if (listaGrafo[i].vertice.Equals(v2)) { pertenece2 = true; }
                if (listaGrafo[i].Equals(new Grafo<T>(v1, v2))) { throw new ArgumentException(); }
           
           }
            if (pertenece == false && pertenece2 == false) 
            { 
            
            
            }
        
        }
         //ok
        public void AgregarVertice(T vertice)
        {  
            Grafo<T> gr = new Grafo<T>(vertice);
            if (listaGrafo.Contains(gr)) { throw new ArgumentException(); }
            listaGrafo.Add(gr);
        
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
         //ok
        public void EliminarArista(T v1, T v2)
        {
            bool hubo = false;
            for (int i = 0; i < listaGrafo.Count; i++) 
            {
                if (listaGrafo[i].Equals(new Grafo<T>(v1, v2))) { hubo = true; listaGrafo.RemoveAt(i); }
            
            }
            if (hubo == false) { throw new ArgumentException(); }
        
        }
          //ok
        public void EliminarVertice(T vertice)
        {
            bool hubo = false;
            for (int i = 0; i < listaGrafo.Count; i++) 
            {
                if (listaGrafo[i].vertice.Equals(vertice) || listaGrafo[i].arista.Equals(vertice)) { hubo = true; listaGrafo.RemoveAt(i); }
            
            }
            if (hubo == false) { throw new ArgumentException(); }
        
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
