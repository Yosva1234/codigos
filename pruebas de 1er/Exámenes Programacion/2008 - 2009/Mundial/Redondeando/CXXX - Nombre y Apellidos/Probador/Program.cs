using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Quadtries;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new Quadtree(
                new Quadtree(QuadtreeColor.White),
                new Quadtree(QuadtreeColor.White),
                new Quadtree(
                    new Quadtree(QuadtreeColor.White),
                    new Quadtree(QuadtreeColor.White),
                    new Quadtree(QuadtreeColor.White),
                    new Quadtree(QuadtreeColor.White)),
                new Quadtree(QuadtreeColor.White));


            var t = Redondeando.RedondeoQuadtree.RecorridoPorNiveles(temp);
        }
    }
}
