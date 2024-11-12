using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.ExamenFinal.Interfaces;

namespace Weboo.ExamenFinal
{
    public class Jerarquia<T> : IJerarquia<T>
    {
        private readonly string jefeSupremo;
        public LinkedLista<string> arbol;
        public List<OrdenDada<T>> ordenes;

        public Jerarquia(string jefeSupremo)
        {
           
            this.jefeSupremo = jefeSupremo;
            arbol = new LinkedLista<string>();
            ordenes = new List<OrdenDada<T>>();
            arbol.Add(jefeSupremo);
           
        }

        public void AsignaJefe(string jefe, string subordinado)
        {
            if (!arbol.Contains(jefe))
                throw new ArgumentException(" Ese jefe no esta en la lista");
            if ( arbol.IndexOf(subordinado) != -1)
                throw new ArgumentException(" Ya tiene jefe");
            arbol.Add( subordinado);
             
           
        }

        public bool EsSuperior(string superior, string integrante)
        {
            if (arbol.IndexOf(superior) < arbol.IndexOf(integrante))
                return true;
            //if (arbol.First == arbol.FindNode(arbol.IndexOf(superior)))
            //    return true;
            return false;
        }

        public void Ordena(string superior, string integrante, T orden)
        {
            if (!arbol.Contains(integrante))
                throw new ArgumentException(" No esta");
            if (!arbol.Contains(superior))
                throw new ArgumentException("No est a el superior");
            if (arbol.FindNode(arbol.IndexOf(integrante)).Next != null)
                throw new ArgumentException(" No es un subordinado");
            if (arbol.FindNode(arbol.IndexOf(integrante)).orden == null && arbol.IndexOf(integrante) > arbol.IndexOf(superior))
            {
                arbol.FindNode(arbol.IndexOf(integrante)).orden = orden.ToString();
                arbol.FindNode(arbol.IndexOf(integrante)).QuienPusoLaOrden = superior ;
                ordenes.Add(new OrdenDada<T> (integrante,orden));
            }
            else if(arbol.FindNode(arbol.IndexOf(integrante)).orden != null && arbol.IndexOf(integrante) > arbol.IndexOf(superior))
            {
              if( arbol.IndexOf(arbol.FindNode(arbol.IndexOf(integrante)).QuienPusoLaOrden) < arbol.IndexOf(superior))
                {
                    arbol.FindNode(arbol.IndexOf(integrante)).orden = orden.ToString();
                    arbol.FindNode(arbol.IndexOf(integrante)).QuienPusoLaOrden = superior;
                    ordenes.Add(new OrdenDada<T>(integrante, orden));
                }
            }
        }

        public T Orden(string integrante, out string superior)
        {
            throw new NotImplementedException();
        }

        public bool TieneOrden(string integrante)
        {
            if (arbol.FindNode(arbol.IndexOf(integrante)).orden != null)
                return true;
            return false;
        }

        public bool Existe(string integrante)
        {
            if (arbol.Contains(integrante)) return true;
            return false;
        }

        public IEnumerable<OrdenDada<T>> OrdenesPorCumplir()
        {
            int count = -1;
            List<OrdenDada<T>> ordenes = new List<OrdenDada<T>>();
            foreach(var items in arbol)
            {
                count++;
                if(arbol.FindNode(arbol.IndexOf(items)).orden != null)
                {
                    ordenes.Add(ordenes[count]);
                }
            }
            return ordenes;
            
        }
    }
    public class LinkedLista<T> : IList<T>
    {
        public LinkendNode<T> First;
        public LinkendNode<T> Last;
        int count;
        public LinkendNode<T> FindNode(int index)
        {
            LinkendNode<T> current = First;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new Exception();
                else
                {
                    return FindNode(index).Value;
                }
            }

            set
            {
                if (index < 0 || index >= count) throw new Exception();
                else
                {
                    FindNode(index).Value = value;
                }
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public void Add(T item)
        {
            if (count == 0)
                First = Last = new LinkendNode<T>(null, item,default(T),null);
            else
            {
                Last = Last.Next = new LinkendNode<T>(null, item,default(T), null);
            }
            count++;
        }
        public void Clear()
        {
            First = Last = null;
            count = 0;
        }
        public bool Contains(T item)
        {
            if (IndexOf(item) != -1) return true;
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new Exception();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (LinkendNode<T> current = First; current != null; current = current.Next)
                yield return current.Value;
        }
        public int IndexOf(T item)
        {
            LinkendNode<T> current = First;
            int i = 0;
            while (current != null)
            {
                if (Equals(current.Value, item))
                    return i;
                i++;
                current = current.Next;
            }
            return -1;
        }
        public void Insert(int index, T item)
        {
            if (count == 0)
            {
                First = Last = new LinkendNode<T>(null, item, default(T),null);
            }
            else if (index == 0)
            {
                First = new LinkendNode<T>(First, item, default(T), null );
            }
            else if (index == count)
            {
                Last = Last.Next = new LinkendNode<T>(null, item, default(T), null );
            }
            else
            {
                LinkendNode<T> a = FindNode(index - 1);
                a.Next = new LinkendNode<T>(a.Next, item, default(T), null );
            }
            count++;

        }
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            {
                if (index != -1)
                {
                    RemoveAt(index);
                    return true;
                }
                else return false;
            }
        }
        public void RemoveAt(int index)
        {

            if (count == 0)
                throw new Exception();
            else if (count == 1)
            {
                First = Last = null;
            }
            else if (index == 0)
            {
                First = First.Next;
            }
            else
            {
                LinkendNode<T> nodo = FindNode(index - 1);
                nodo.Next = nodo.Next.Next;
                if (index == count)
                    Last = nodo;
            }
            count--;

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class LinkendNode<T>
    {
        public LinkendNode<T> Next;
        public T Value;
        public T orden;
        public string QuienPusoLaOrden;
        public LinkendNode(LinkendNode<T> next, T Value, T orden, string superororden)
        {
           this .Value = Value;
            Next = next;
            this.orden = orden;
            QuienPusoLaOrden = superororden;
        }
    }
    
}
