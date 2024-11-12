using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstChance
{
    public class Arbol<T>
    {
        List<Arbol<T>> hijos = new List<Arbol<T>>();
        T valor;

        public Arbol(T valor, params Arbol<T>[] hijos) 
        {
            this.valor = valor;

            for (int i = 0; i < hijos.Length; i++)
                this.hijos.Add(hijos[i]);
        }

        public virtual bool EsHoja 
        {
            get 
            {
                if (hijos.Count == 0 || hijos == null)
                    return true;

                return false;
            }
        }

        public virtual int CantDeHijos 
        {
            get { return hijos.Count; }
        }

        public virtual int Altura 
        {
            get 
            {
                if (EsHoja)
                    return 0;

                int altura = 0;
                int auxAltura = 0;

                for (int i = 0; i < hijos.Count; i++)
                {
                    auxAltura = hijos[i].Altura + 1;

                    if (auxAltura > altura)
                        altura = auxAltura;
                }
                return altura;
            }
        }

        public virtual T Valor 
        {
            get { return valor; }
        }

        public virtual Arbol<T> HijoNº(int pos) 
        {
            if (pos >= 0 && pos < hijos.Count)
                return hijos[pos];

            return null;
        }

        public virtual Arbol<T>[] Hijos 
        {
            get { return hijos.ToArray(); }
        }

        public virtual List<T> PreOrden 
        {
            get 
            { 
                List<T> preorden = new List<T>();

                preorden.Add(valor);

                foreach (Arbol<T> hijo in hijos)
                    foreach (T value in hijo.PreOrden)
                        preorden.Add(value);

                return preorden;
            } 
        }

        public virtual List<T> PostOrden 
        {
            get 
            {
                List<T> postorden = new List<T>();

                foreach (Arbol<T> hijo in hijos)
                    foreach (T value in hijo.PostOrden)
                        postorden.Add(value);

                postorden.Add(valor);

                return postorden;
            }
        }

        public virtual List<Arbol<T>> PreordenNodo 
        {
            get
            {
                List<Arbol<T>> preordenNodo = new List<Arbol<T>>();

                preordenNodo.Add(this);

                foreach (Arbol<T> hijo in hijos)
                    foreach (Arbol<T> value in hijo.PreordenNodo)
                    {
                        preordenNodo.Add(value);
                    }
                return preordenNodo;
            }
        }

        public virtual List<Arbol<T>> PostOrdenNodo 
        {
            get 
            { 
                List<Arbol<T>> postordenNodo = new List<Arbol<T>>();

                foreach (Arbol<T> hijo in hijos)
                    foreach (Arbol<T> value in hijo.PostOrdenNodo)
                    {
                        postordenNodo.Add(value);
                    }

                postordenNodo.Add(this);

                return postordenNodo;
            }
        }

        public virtual List<T> AloAncho 
        {
            get
            {
                List<T> aLoAncho = new List<T>();
                Queue<Arbol<T>> cola = new Queue<Arbol<T>>();
                Arbol<T> aux;
                cola.Enqueue(this);

                while (cola.Count != 0)
                {
                    aux = cola.Dequeue();

                    for (int i = 0; i < aux.hijos.Count; i++)
                        cola.Enqueue(aux.hijos[i]);

                    aLoAncho.Add(aux.valor);
                }
                return aLoAncho;
            }
        }
    }
}
