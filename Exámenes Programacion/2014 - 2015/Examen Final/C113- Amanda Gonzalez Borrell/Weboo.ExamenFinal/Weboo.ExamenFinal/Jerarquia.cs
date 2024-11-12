using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.ExamenFinal.Interfaces;

namespace Weboo.ExamenFinal
{
    public class Jerarquia<T> : IJerarquia<T>
    {
        private readonly string jefeSupremo;
        public Arbol<T> Padre;

        public Jerarquia(string jefeSupremo)
        {
            this.jefeSupremo = jefeSupremo;
            List<Arbol<T>> arbolitos = new List<Arbol<T>>();
            Padre = new Arbol<T>(jefeSupremo, arbolitos);
        }

        public void AsignaJefe(string jefe, string subordinado)
        {
            Arbol<T> a = BuscarArbol(jefe, Padre);
            if (a == null) throw new ArgumentException("el jefe que me mandaste no esta");
            Arbol<T> hijito = BuscarArbol(subordinado, Padre);
            if (hijito != null) throw new ArgumentException(" ya ese se;or tiene jefe");
            hijito = new Arbol<T>(subordinado, null);
            hijito.Padre = a;
            a.Hijos.Add(hijito);
        }

        public bool EsSuperior(string superior, string integrante)
        {
            if (superior == integrante) return false;
            Arbol<T> super = BuscarArbol(superior, Padre);
            Arbol<T> inte = BuscarArbol(integrante, Padre);
            if (EsFamilia(super, inte)) return true;
            return false;
        }

        public void Ordena(string superior, string integrante, T orden)
        {
            Arbol<T> super = BuscarArbol(superior, Padre);
            Arbol<T> inte = BuscarArbol(integrante, Padre);
            if (inte == null || super == null) throw new ArgumentException(" no estan en la lista o el subordinado o el jefe no se cual ");
            if(EsFamilia(super, inte))
            {
                if(inte.Orden == null)
                inte.Orden = new Orden<T>( orden, super);
                else
                {
                    Arbol<T> superiorord = inte.Orden.PadreQuePusoOrden;
                    if (EsFamilia(super, superiorord))
                        inte.Orden = new Orden<T>(orden, super);
                }
            }
        }

        public T Orden(string integrante, out string superior)
        {
            Arbol<T> inte = BuscarArbol(integrante, Padre);
            superior = inte.Orden.PadreQuePusoOrden.Value;
            return inte.Orden.orden;
            
        }

        public bool TieneOrden(string integrante)
        {
           Arbol<T> inte= BuscarArbol(integrante,Padre);
            if (inte.Orden != null) return true;
            return false;
        }

        public bool Existe(string integrante)
        {
            if (BuscarArbol(integrante, Padre) != null) return true;
            return false;
        }

        public IEnumerable<OrdenDada<T>> OrdenesPorCumplir()
        {
            return (IEnumerable<OrdenDada<T>>) DevolverOrdenes(Padre);
        }
        public Arbol<T> BuscarArbol(string nombre, Arbol<T> padre)
        {
           
            if (padre.Value == nombre) return padre;
            else
            {
                for (int i = 0; i < padre.Hijos.Count; i++)
                {
                    Arbol<T> a = null;
                    if (padre.Hijos[i] != null)
                        a = BuscarArbol(nombre, padre.Hijos[i]);
                    if (a != null)
                        return a;
                }
            }
            return null;
        }
        public bool EsFamilia(Arbol<T> padre, Arbol<T> hijo)
        {
            if (hijo.Padre == null) return false;
            if ( hijo.Padre == padre) return true;

            else{
                bool a = false;
                if(padre != null)
                a= EsFamilia(padre.Padre, hijo);
                if (a)
                return a;
                
            }
            return false;
        }
        public IEnumerable<Orden<T>> DevolverOrdenes(Arbol<T> padre)
        {
           if( padre. Hijos == null)
            {
                if (padre.Orden != null) yield return padre.Orden;
            }
            else
            {
                for(int i=0; i < padre.Hijos.Count; i ++)
                {
                    if (padre.Hijos[i] != null)
                    {
                   foreach(var elementos in DevolverOrdenes(padre.Hijos[i]))
                        {
                            yield return elementos;
                        }
                    }
                }
            }

        }
    }
    public class Arbol<T>
    {
        public Orden<T> Orden;
        public string Value;
        public List<Arbol<T>> Hijos;
        public  Arbol<T> Padre;
        public Arbol( string value, List<Arbol<T>> hijos)
        {
            Hijos = hijos;
            Value = value;
            
        }  

    }
    public class Orden<T>: OrdenDada<T>
    {
        public T orden;
        public Arbol<T> PadreQuePusoOrden;
        public Orden(T orden, Arbol<T> PadreAQuePusoOrden): base(PadreAQuePusoOrden.Value, orden)
        {
           this.orden = orden;
          PadreQuePusoOrden = PadreAQuePusoOrden;

        }
    }
}
