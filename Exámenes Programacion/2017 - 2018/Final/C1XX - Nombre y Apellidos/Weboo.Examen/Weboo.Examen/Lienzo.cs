using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen.Interfaces;

namespace Weboo.Examen
{
    public class Lienzo : ILienzo
    {
        public QuadTree arbol;
        public static int tamano;
        public Lienzo(int N)
        {
            tamano = N;
            QuadTree[] hijos = new QuadTree[4];
            arbol = new QuadTree(QuadTree.Color.Blanco, hijos, null);
            arbol = FormarArbol(arbol, Resolucion/4);

        }
        public QuadTree FormarArbol(QuadTree arbol, int resolucion)
        {
            if (resolucion == 1)
            {for (int i = 0; i < arbol.Children.Length; i++)
                {
                    arbol.Children[i] = new QuadTree(QuadTree.Color.Blanco, null, arbol);
                }
                return arbol;
            }
            for(int i=0; i< arbol.Children.Length; i++)
            {
               
                arbol.Children[i] = new QuadTree(QuadTree.Color.Blanco, new QuadTree[4], arbol);
                QuadTree arbolito = FormarArbol(arbol.Children[i], resolucion / 4);
            }
            return arbol;
        }
        public int Resolucion
        {
            get { { return ((int)Math.Pow(2, tamano) * (int)Math.Pow(2, tamano)); } }
        }
        public int CantidadDeNodosBlancos
        {
            get
            {
                return CantidadBlancos(arbol);
            }
        }
        public int CantidadDeNodosNegros
        {
            get
            {
                return CantidadNegros(arbol);
            }
        }
        public int CantidadDeNodosGrises
        {
            get
            {
                return CantidadGrises(arbol);

            }
        }
        public void Dibuja(int fila, int columna, int ancho, int alto)
        {
            
            //QuadTree nodo = FindNode(arbol, columna, fila, (int)Math.Sqrt(Resolucion));
            //    nodo.color = QuadTree.Color.Negro;
            QuadTree cursor = null;
           for(int i= fila ; i< fila+ alto; i++)
            {
                for (int j = columna; j < columna + ancho; j++)
                {
                        cursor = FindNode(arbol, j, i, (int)Math.Sqrt(Resolucion));
                        cursor.color = QuadTree.Color.Negro;
                    arbol = Modificar(cursor);
                }
            }
            
        }
        public bool EstaPintado(int fila, int columna)
        {
            QuadTree nodo = FindNode(arbol, columna, fila, (int)Math.Sqrt(Resolucion));
            return (nodo.color == QuadTree.Color.Negro);
          
        }
        public static int CantidadNegros( QuadTree arbol)
        {
            int cantidad = 0;
          if(arbol.color == QuadTree.Color.Negro )
            {
                return 1;
            }
            if (arbol.color == QuadTree.Color.Blanco) return 0;
            else
            {
                for (int i = 0; i < arbol.Children.Length; i++)
                {
                    cantidad += CantidadNegros(arbol.Children[i]);
                }
            }
            return cantidad;
        }
        public static int CantidadBlancos(QuadTree arbol)
        {
            int cantidad = 0;
            if (arbol.color == QuadTree.Color.Negro)
            {
                return 0;
            }
            if (arbol.color == QuadTree.Color.Blanco) return 1;
            else
            {
                for (int i = 0; i < arbol.Children.Length; i++)
                {
                    cantidad += CantidadBlancos(arbol.Children[i]);
                }
            }
            return cantidad;
        }
        public static int CantidadGrises(QuadTree arbol)
        {
            int cantidad = 1;
            if(arbol.color == QuadTree.Color.Blanco || arbol.color== QuadTree.Color.Negro)
            {
                return 0;
            }
            for(int i=0; i< arbol.Children.Length; i++)
            {
                cantidad += CantidadGrises(arbol.Children[i]);
            }
            return cantidad;
        }
        public static QuadTree FindNode(QuadTree arbol, int columna, int fila, int resol)
        {
            if (fila < resol / 2)
            {
                if (columna < resol / 2)
                {
                    if (resol != 1)
                        arbol = FindNode(arbol.Children[0], columna, fila, resol / 2);
                    else return arbol;
                }
                else
                {
                    if (resol != 1)
                        arbol = FindNode(arbol.Children[1], columna  - resol / 2, fila, resol / 2);
                    else return arbol;
                }
            }
            else
            {
                if (columna < resol / 2)
                {
                    if (resol != 1)
                        arbol = FindNode(arbol.Children[2], columna, fila  - resol / 2, resol / 2);
                    else return arbol;
                }
                else
                {
                    if (resol!=1)
                    arbol = FindNode(arbol.Children[3], columna  - resol/2, fila - resol / 2, resol / 2);
                    else
                    {
                        return arbol;
                    }
                }

            }
            return arbol;
        }
        public static QuadTree Modificar(QuadTree arbol)
        {
            
            QuadTree cursor = arbol;
            while(cursor.Padre!= null)
            {
                int countnegros = 0;
                int countblancos = 0;
                int countgris = 0;
                cursor = cursor.Padre;
                for(int i=0; i< cursor.Children.Length; i++)
                {
                    if (cursor.Children[i].color == QuadTree.Color.Negro) countnegros += 1;
                    if (cursor.Children[i].color == QuadTree.Color.Blanco) countblancos += 1;
                    if (cursor.Children[i].color == QuadTree.Color.Gris) countgris += 1; 
                }
                if (countgris != 0) cursor.color = QuadTree.Color.Gris;
                if (countnegros == 4)
                {
                    cursor.color = QuadTree.Color.Negro;
                }
               else if (countblancos < 4 && countnegros < 4 && countnegros != 0) cursor.color = QuadTree.Color.Gris;
            }
            return cursor;
        }
        public class QuadTree
        {
            public Color color { get; set; }
            public QuadTree[] Children;
            public QuadTree Padre;
            public QuadTree(Color a, QuadTree[] hijos, QuadTree padre)
            {
                Children = hijos;
                color = a;
                Padre = padre;
            }
            public IEnumerator<QuadTree> GetEnumerator()
            {
                while (Children[0] != null)
                    yield return Children[0];
                while (Children[1] != null)
                    yield return Children[1];
                while (Children[2] != null)
                    yield return Children[2];
                while (Children[3] != null)
                    yield return Children[3];
            }
            public bool EsHoja
            {
                get
                {
                    if (Children[0] == null && Children[1] == null && Children[2] == null && Children[3] == null) return true;
                    return false;
                }

            }

            public enum Color
            {
                Blanco,
                Negro,
                Gris

            }

        }

    }
}