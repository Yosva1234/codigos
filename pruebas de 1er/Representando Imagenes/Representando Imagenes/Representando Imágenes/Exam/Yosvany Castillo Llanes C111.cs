using System.Net.Mail;
namespace Exam
{

public static class QuadTreeFactory
{
    public static IQuadtree Create(int size)
    {
        return new QuadTree(size);
    }
}

public class Point 
{
   public int X;
    public int Y;

    public Point(int x, int y)
    {
         X=x; 
         Y=y;
    }

   public bool arribaizquierda(Point aux)
   {
       if(X< aux.X && Y < aux.Y) return true;
       else return false;
   }

    public bool aribaderecha(Point aux)
   {
       if(X< aux.X && Y >= aux.Y) return true;
       else return false;
   }

    public bool abajoderecha(Point aux)
   {
       if(X>= aux.X && Y >= aux.Y) return true;
       else return false;
   }

     public bool abajoizquierda(Point aux)
   {
       if(X>= aux.X && Y < aux.Y) return true;
       else return false;
   }

   public bool igual(Point aux)
   {
    if(aux.X == X && aux.Y == Y) return true;
    return false;
   }




}

 public class node 
 {
     public Point start{get; set;}
     public Point end {get; set;}
     public QuadNodeColor color {get; set;}

    public node (int x1, int y1 , int x2, int y2 , QuadNodeColor color )
    {
        start = new Point(x1,y1);
        end = new Point(x2,y2);
        this.color = color;
    }
 }


public class QuadTree : IQuadtree
{
    public node nodo;
    List <QuadTree> hijos {get; set;}

   public   QuadTree(int size)
   {
    nodo = new node(0,0,size,size,QuadNodeColor.White);
    hijos  = new List<QuadTree>(4);
    for(int x = 0; x<4; x++) hijos[x] = new QuadTree(0);
   }

    public void DrawPixel(int x, int y, bool isBlack)
    {

       if(nodo.end.igual(nodo.start) && nodo.start.igual(new Point(x,y)))
       {
         return ;
       }
       
      nodo.color = QuadNodeColor.Gray;

      Point  casilla  = new Point(x,y);
      Point middle = new Point((nodo.start.X+nodo.end.X)/2, (nodo.start.Y+nodo.end.Y)/2);

      if(middle.arribaizquierda(casilla))
      {
        if(hijos[0].nodo.end == new Point(0,0)) 
        {
            hijos[0] = new QuadTree(middle.X);
            hijos[0].nodo.start = nodo.start;
            if(isBlack) hijos[0].nodo.color = QuadNodeColor.Black;
            else hijos[0].nodo.color = QuadNodeColor.White;
            hijos[0].DrawPixel(x,y,isBlack);
        }
        else  hijos[0].DrawPixel(x,y,isBlack);
      }

      if(middle.aribaderecha(casilla))
      {
        if(hijos[1].nodo.end != new Point(0,0)) 
        {
            hijos[1] = new QuadTree(middle.X);
            hijos[1].nodo.start = new Point(nodo.start.X,middle.Y);
            hijos[1].nodo.end = new Point(middle.X, nodo.end.Y);

            if(isBlack) hijos[1].nodo.color = QuadNodeColor.Black;
            else hijos[1].nodo.color = QuadNodeColor.White;
            hijos[1].DrawPixel(x,y,isBlack);
        }
        else   hijos[1].DrawPixel(x,y,isBlack);
      }


      if(middle.abajoizquierda(casilla))
      {
        if(hijos[3].nodo.end != new Point(0,0)) 
        {
            hijos[3] = new QuadTree(middle.X);
            hijos[3].nodo.start = new Point(middle.X,nodo.start.Y);
            hijos[3].nodo.end = new Point(nodo.end.X,middle.Y);

            if(isBlack) hijos[3].nodo.color = QuadNodeColor.Black;
            else hijos[3].nodo.color = QuadNodeColor.White;
            hijos[3].DrawPixel(x,y,isBlack);
        }
        else   hijos[3].DrawPixel(x,y,isBlack);
      }


   if(middle.abajoderecha(casilla))
      {
        if(hijos[2].nodo.end == new Point(0,0)) 
        {
            hijos[2] = new QuadTree(middle.X);
            hijos[2].nodo.start = middle;
            hijos[2].nodo.end = nodo.end;

            if(isBlack) hijos[2].nodo.color = QuadNodeColor.Black;
            else hijos[2].nodo.color = QuadNodeColor.White;
            hijos[2].DrawPixel(x,y,isBlack);
        }
        else   hijos[2].DrawPixel(x,y,isBlack);
      }
    }

      public int CountPixels()
      {
        return 0;
      }



   public IQuadtree TopLeft { get
   {
    return hijos[0];
   }
   }

   public QuadNodeColor Color { 
    get{ return nodo.color;}
    }

   public IQuadtree TopRight { get
   {
    return hijos[1];
   }
    }

     public IQuadtree BottomLeft { get{
        return  hijos[3];
     } }
     
    public IQuadtree BottomRight { get
    {
        return hijos[2];
    } }



}}

