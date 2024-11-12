using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problema3;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            Prueba1();
            Prueba2();
            Prueba3();
            //MyTest();

            Console.Read();
        }

        private static void MyTest()
        {
            ColaConCategorias< List<int> > q = new ColaConCategorias< List<int> >();

            q.AgregaCategoria("ramon", 1);
            q.AgregaCategoria("m", 10);
            q.AgregaCategoria("glenda", 2);

            q.Enqueue("ramon", new List<int>(){1,2,3});
            q.Enqueue("ramon", new List<int>(){4,5,6});
            q.Enqueue("glenda", new List<int>(){7,8,9});

            foreach (string c in q.Categorias)
                Console.Write(c + " ");

            Console.WriteLine();

            foreach (int i in q.Peek())
                Console.Write(i);

            Console.WriteLine();

            foreach (int i in q.Dequeue())
                Console.Write(i);

            Console.WriteLine();

            foreach (int i in q.Peek())
                Console.Write(i);

            Console.WriteLine();

            foreach (int i in q.Dequeue())
                Console.Write(i);

            Console.WriteLine();

            foreach (int i in q.Dequeue())
                Console.Write(i);

            Console.WriteLine();
        }

        static void ImprimeCola<T>(ColaConCategorias<T> q)
        {
            Console.WriteLine("[{0}]", string.Join(",", q.Select(e => e.ToString()).ToArray()));
        }

        static void Prueba3()
        {
            ColaConCategorias<string> q = new ColaConCategorias<string>();

            q.AgregaCategoria("A", 1);
            q.Enqueue("A", "A1");
            Console.WriteLine(q.Dequeue());

            q.AgregaCategoria("B", 2);
            q.Enqueue("B", "B1");
            q.Enqueue("B", "B2");
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());

            q.Enqueue("A", "A2");
            q.Enqueue("B", "B3");
            q.Enqueue("B", "B4");

            Console.WriteLine("Peek :" + q.Peek());

            q.AgregaCategoria("C", 1);
            q.Enqueue("C", "C1");
            ImprimeCola(q);
        }

        static void Prueba2()
        {
            ColaConCategorias<int> q = new ColaConCategorias<int>();

            q.AgregaCategoria("rojo", 10);
            q.AgregaCategoria("verde", 2);
            q.AgregaCategoria("azul", 1);

            q.Enqueue("rojo", 1);
            q.Enqueue("rojo", 2);
            q.Enqueue("rojo", 3);
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
            q.Enqueue("verde", 4);
            q.Enqueue("verde", 5);
            q.Enqueue("verde", 6);
            q.Enqueue("azul", 7);
            q.Enqueue("rojo", 8);
            ImprimeCola(q);

        }

        static void Prueba1()
        {
            ColaConCategorias<string> q = new ColaConCategorias<string>();

            string catPlanJaba = "Plan Jaba";
            string catNormal = "Normal";
            string catEmbarazadas = "Embarazadas";

            q.AgregaCategoria(catPlanJaba, 2);
            q.AgregaCategoria(catNormal, 1);
            q.AgregaCategoria(catEmbarazadas, 4);

            q.Enqueue(catPlanJaba, "Juan");
            q.Enqueue(catPlanJaba, "Pedro");
            q.Enqueue(catNormal, "Jose");
            q.Enqueue(catEmbarazadas, "Ana");
            q.Enqueue(catNormal, "Maria");
            q.Enqueue(catNormal, "Carlos");
            q.Enqueue(catEmbarazadas, "Arnold");
            q.Enqueue(catPlanJaba, "Jesus");

            ImprimeCola(q);

            q.Dequeue();
            q.Dequeue();
            q.Dequeue();

            q.Enqueue(catEmbarazadas, "Lola");
            q.Enqueue(catPlanJaba, "Raul");

            ImprimeCola(q);
        }
    }
}

