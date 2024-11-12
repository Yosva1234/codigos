using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LiezoVirtual
{
    class Lienzo
    {
        public List<Point> dibujo;

        public Lienzo() 
        {
           dibujo = new List<Point>();
           
        }

        bool SonVecinos(Point a,Point b) 
        {
            return (Math.Abs(a.X - b.X) <= 1) && (Math.Abs(a.Y - b.Y) <= 1);
        }
  
        public void AdicionaPuntos(params Point[] puntos)
        {
            foreach (Point t in puntos)            
                if(!dibujo.Contains(t))
                dibujo.Add(t);            
        }

        List<Point> AUX() 
        {
           
                Point[] q = new Point[dibujo.Count];
                Array.Copy(dibujo.ToArray(), q, q.Length);
                return new List<Point>(q);           
            
        }

        public IEnumerable<Point> Dibujo(Point p)
        {           
            List<Point> temp = AUX();
            List<Point> result = new List<Point>();
            if (temp.Contains(p))
            {
                result.Add(p);
                temp.Remove(p);
                for (int i=0;i<temp.Count;i++)
                {
                    for (int j = 0; j < result.Count;j++ )
                        if (i<temp.Count && SonVecinos(result[j], temp[i]))
                        {
                           
                            result.Add(temp[i]);
                            temp.Remove(temp[i]);
                        }
                }
                foreach (Point a in result)
                    yield return a;
            }
            
        }

        public IEnumerable<IEnumerable<Point>> Dibujos()
        {
            
            List<Point> temp = AUX();

            for (int i = 0; i < temp.Count; i++)
            {
               
                IEnumerable<Point> dibujoTemp = Dibujo(temp[i]);
                i = -1;
                foreach (Point p in dibujoTemp)
                {
                    if ((p.X == 10 && p.Y == 12)|| (p.X==8 && p.Y==10))
                    {
                        int y;
                    }
                    temp.Remove(p);
                }               
                 yield return dibujoTemp;
            }
        }
    }
}
