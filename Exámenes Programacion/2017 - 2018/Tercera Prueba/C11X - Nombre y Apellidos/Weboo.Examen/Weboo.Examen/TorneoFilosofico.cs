using ConceptosSocraticos;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Weboo.Examen
{
    public class LinkedList<T> : IEnumerable<T>
    {
        Node FirstNode;
        Node Last;
        int Count = 0;

        public void Add(T value, IComparer<T> comparer = null)
        {
            Count++;
            if (comparer == null)
            {
                if (Last == null)
                {
                    var temp = new Node(value);
                    FirstNode = temp;
                    Last = temp;
                    return;
                }
                Last.NextNode = new Node(value);
                Last = Last.NextNode;
                return;
            }
            if (FirstNode == null)
            {
                var temp = new Node(value);
                FirstNode = temp;
                Last = temp;
                return;
            }
            Node previous = null;
            for (Node node = FirstNode; node != null; node = node.NextNode)
            {
                if (comparer.Compare(node.Value, value) > 0)
                {
                    Node temp = new Node(value);
                    temp.NextNode = node;
                    if (previous == null)
                        FirstNode = temp;
                    else
                        previous.NextNode = temp;
                    return;
                }
                if (node.NextNode == null)
                {
                    node.NextNode = new Node(value);
                    Last = node.NextNode;
                    return;
                }
                previous = node;
            }
        }

        public void Remove(T value)
        {
            if (FirstNode == null)
                return;
            if (FirstNode.Value.Equals(value))
            {
                FirstNode = FirstNode.NextNode;
                if (Count == 1)
                {
                    Last = null;
                }
                Count--;
                if (Count == 1)
                {
                    Last = FirstNode;
                }
                return;
            }
            for (Node node = FirstNode; node.NextNode != null; node = node.NextNode)
            {
                if (node.NextNode.Value.Equals(value))
                {
                    node.NextNode = node.NextNode.NextNode;
                    if (node.NextNode == null)
                    {
                        Last = node;
                    }
                    Count--;
                    if (Count == 1)
                        Last = FirstNode;
                    return;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public class Node
        {
            T value;

            public Node(T Value)
            {
                this.value = Value;
            }

            public T Value => value;
            public Node NextNode { get; set; }
        }

        private class ListEnumerator : IEnumerator<T>
        {
            LinkedList<T> List;
            Node CurrentNode;

            public ListEnumerator(LinkedList<T> list)
            {
                List = list;
            }
            public T Current => CurrentNode.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (List.FirstNode == null)
                    return false;
                if (CurrentNode == null)
                {
                    CurrentNode = List.FirstNode;
                    return true;
                }
                CurrentNode = CurrentNode.NextNode;
                return CurrentNode != null;
            }

            public void Reset()
            {
            }
        }
    }

    public class Escuela : IEnumerable<Filosofo>
    {
        LinkedList<Filosofo> Filosofos = new LinkedList<Filosofo>();

        public Escuela(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; private set; }

        public void Add(Filosofo fil)
        {
            Filosofos.Add(fil, new CompareFilosofos());
        }

        public class CompareFilosofos : IComparer<Filosofo>
        {
            public int Compare(Filosofo x, Filosofo y)
            {
                return y.Conocimiento - x.Conocimiento;
            }
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this == (Escuela)obj;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(Escuela a, Escuela b)
        {
            return a.Name == b.Name;
        }

        public static bool operator !=(Escuela a, Escuela b)
        {
            return a.Name != b.Name;
        }

        public IEnumerator<Filosofo> GetEnumerator()
        {
            return Filosofos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }






    public class TorneoFilosofico : ITorneoFilosofico
    {

        LinkedList<Escuela> Escuelas = new LinkedList<Escuela>();

        public Escuela GetSchoolByString(string str)
        {
            foreach (var item in Escuelas)
            {
                if (item.Name == str)
                    return item;
            }
            return null;
        }

        public void MoveSchool(Escuela from, Escuela to)
        {
            foreach (var item in from)
            {
                to.Add(item);
            }
            Escuelas.Remove(from);
        }

        public string Compite(string escuela1, string escuela2)
        {
            Escuela esc1 = GetSchoolByString(escuela1);
            Escuela esc2 = GetSchoolByString(escuela2);
            IEnumerator<Filosofo> e1 = esc1.GetEnumerator();
            IEnumerator<Filosofo> e2 = esc2.GetEnumerator();


            do
            {
                if (!e1.MoveNext())
                {
                    if (!e2.MoveNext())
                        return "EMPATE";
                    else
                    {
                        MoveSchool(esc1, esc2);
                        return esc2.Name;
                    }
                }
                else
                {
                    if (!e2.MoveNext())
                    {
                        MoveSchool(esc2, esc1);
                        return esc1.Name;
                    }
                    else
                    {
                        if (e1.Current.Conocimiento < e2.Current.Conocimiento)
                        {
                            MoveSchool(esc1, esc2);
                            return esc2.Name;
                        }
                        else if (e1.Current.Conocimiento > e2.Current.Conocimiento)
                        {
                            MoveSchool(esc2, esc1);
                            return esc1.Name;
                        }
                    }
                }
            }while (e1.Current.Conocimiento == e2.Current.Conocimiento);

            return "EMPATE";
        }

        public IEnumerable<string> DameEscuelas()
        {
            foreach (var item in Escuelas)
            {
                yield return item.Name;
            }
        }

        public IEnumerable<Filosofo> FilosofosMasDestacados()
        {
            foreach (var item in Escuelas)
            {
                var tempEnum = item.GetEnumerator();
                if (tempEnum.MoveNext())
                    yield return tempEnum.Current;
            }
        }

        public IEnumerable<Filosofo> Miembros(string escuela)
        {
            return GetSchoolByString(escuela);
        }

        public string PerteneceAEscuela(Filosofo filosofo)
        {
            foreach (var esc in Escuelas)
            {
                foreach (var fil in esc)
                {
                    if (fil.Equals(filosofo))
                        return esc.Name;
                }
            }
            return null;
        }

        public void RegistraEscuela(string escuela, IEnumerable<Filosofo> filosofos)
        {
            var temp = new Escuela(escuela);
            Escuelas.Add(temp);
            foreach (var item in filosofos)
            {
                temp.Add(item);
            }
        }
    }
}
