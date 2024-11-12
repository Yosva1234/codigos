using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Lienzo lienzo = new Lienzo();
            //dibujo 1
            lienzo.AdicionaPuntos(new Point(5, 7), new Point(5, 8), new Point(5, 9),
            new Point(4, 9), new Point(4, 10));
            //dibujo 2
            lienzo.AdicionaPuntos(new Point(7, 8), new Point(7, 9));
            lienzo.AdicionaPuntos(new Point(8, 9), new Point(8, 10));
            //dibujo 3
            lienzo.AdicionaPuntos(new Point(10, 12), new Point(10, 13), new Point(10, 14),
            new Point(9, 13), new Point(11, 13));

            int i = 1;
            foreach (IEnumerable<Point> dibujo in lienzo.Dibujos())
            {
                Console.WriteLine("Figura {0}:", i++);
                foreach (Point p in dibujo)
                {
                    Console.WriteLine("({0};{1})", p.X, p.Y);
                }
            }
        }
    }
}
