using System.Drawing;

namespace Exam;

public static class QuadTreeFactory
{
    public static IQuadtree Create(int size)
    {
         return new QuadTree(size);
    }
}

  public class node 
  {
   public Point start {get; set;}
   public Point end {get; set;}
   public QuadNodeColor color {get; set;}

    public node (Point start, Point end, QuadNodeColor color)
    {
        this.start = start;
        this.end = end;
        this.color = color;
    }
  }

  public class verification 
  {

    public static int pixelcount;

   public static bool topleft(Point casilla, Point middle)
   {
     if(middle.x >= casilla.x && middle.y >= casilla.y) return true;
     return false;
   }

    public static bool topright(Point casilla, Point middle)
   {
     if(middle.x >= casilla.x && middle.y < casilla.y) return true;
     return false;
   }

    public static bool buttonleft(Point casilla, Point middle)
   {
     if(middle.x < casilla.x && middle.y >= casilla.y) return true;
     return false;
   }

    public static bool buttonright(Point casilla, Point middle)
   {
     if(middle.x < casilla.x && middle.y < casilla.y) return true;
     return false;
   }
  
   public static void rellenar(QuadTree nodoactual, int x)
   {

         Point middle = new Point((nodoactual.nodo.end.x - nodoactual.nodo.start.x)/2, (nodoactual.nodo.end.y - nodoactual.nodo.start.y)/2);

        if(x == 0)
        nodoactual.childrens[0] = new QuadTree(nodoactual.nodo.start, middle);
        if(x==1)
        nodoactual.childrens[1] = new QuadTree(new Point(nodoactual.nodo.start.x,middle.y+1),new Point(middle.x, nodoactual.nodo.end.y));
        if(x==2)
        nodoactual.childrens[2] = new QuadTree(new Point(middle.x+1, nodoactual.nodo.start.y), new Point(nodoactual.nodo.end.x, middle.y));
        if(x==3)
       nodoactual.childrens[3] = new QuadTree(new Point(middle.x+1, middle.y+1),nodoactual.nodo.end);

        nodoactual.childrens[x].nodo.color = QuadNodeColor.White;
   }



  }

  public class Point 
  {
   public int x{get; set;}
   public int y{get; set;}

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }


    public bool igual(Point aux)
    {
        return aux.x==x && aux.y == y;
    }


  }

public class QuadTree: IQuadtree
{
    public node nodo{get; set;}

    public QuadTree(int size)
    {
        nodo = new node(new Point(0,0), new Point(size-1,size-1), QuadNodeColor.Gray);
        verification.pixelcount = 0;
    }

    public QuadTree( Point start , Point end )
    {
        nodo = new node(start, end, QuadNodeColor.Gray);
    }

    public void DrawPixel(int x, int y, bool isBlack)
    {

       pintar(x,y,isBlack);
       actualizararbol(this);

    }


    public void pintar(int x, int y, bool isBlack )
    {

          //  Console.WriteLine(nodo.start.x + " " + nodo.start.y + ">>>" + nodo.end.x + " " + nodo.end.y);

        if(nodo.start.igual(nodo.end))
        {

            if(isBlack && nodo.color!=QuadNodeColor.Black) {nodo.color = QuadNodeColor.Black; verification.pixelcount++;}
            else if(!isBlack)
            {
                if(nodo.color == QuadNodeColor.Black) verification.pixelcount--;
                 nodo.color = QuadNodeColor.White; 
            }           
            return;
        }
        Point middle = new Point(((nodo.end.x + nodo.start.x)/2), ((nodo.end.y + nodo.start.y)/2));
        Point casilla = new Point(x,y);
        if(verification.topleft(casilla,middle))
        {
                if(TopLeft == null)
                {
                    childrens[0] = new QuadTree(nodo.start, middle);
                }
                childrens[0].nodo.color = QuadNodeColor.Gray;
                childrens[0].pintar(x,y,isBlack);
                return;
        }
         if(verification.topright(casilla,middle))
        {
                if(TopRight == null)
                {
                    childrens[1] = new QuadTree(new Point(nodo.start.x,middle.y+1),new Point(middle.x, nodo.end.y));
                }
                childrens[1].nodo.color = QuadNodeColor.Gray;
                childrens[1].pintar(x,y,isBlack);
                return;
        }
         if(verification.buttonleft(casilla,middle))
        {

                if(BottomLeft == null)
                {
                    childrens[2] = new QuadTree(new Point(middle.x+1, nodo.start.y), new Point(nodo.end.x, middle.y));
                }
                childrens[2].nodo.color = QuadNodeColor.Gray;
                childrens[2].pintar(x,y,isBlack);
                return;
        }
         if(verification.buttonright(casilla,middle))
        {
                if(BottomRight == null)
                {
                    childrens[3] = new QuadTree(new Point(middle.x+1, middle.y+1),nodo.end);
                }
                childrens[3].nodo.color = QuadNodeColor.Gray;
                childrens[3].pintar(x,y,isBlack);
                return;
        }
    }


    void actualizararbol(QuadTree nodoactual)
    {
    //    / Console.WriteLine(nodoactual.Color);

        if(nodoactual.nodo.color != QuadNodeColor.Gray) return;

        for(int x = 0; x<4; x++)
        {
            if(nodoactual.childrens[x]==null)
            {
                verification.rellenar(nodoactual,x);
            }
        }


        if(nodoactual.childrens.All(x => x.nodo.color == QuadNodeColor.White)) { nodoactual.nodo.color = QuadNodeColor.White; return;}
        if(nodoactual.childrens.All(x => x.nodo.color == QuadNodeColor.Black)) { nodoactual.nodo.color = QuadNodeColor.Black; return;}
        

        for(int x = 0; x<4; x++)
        {
            if(nodoactual.childrens[x]!=null)
            {
                actualizararbol(nodoactual.childrens[x]);
            }
        }

    }

    public int CountPixels()
    {
        return verification.pixelcount;
    }
    public QuadTree[] childrens = new QuadTree[4];
    public QuadNodeColor Color { get {return nodo.color;} }
    public IQuadtree TopLeft { get{return childrens[0];} }
    public IQuadtree TopRight { get{return childrens[1];} }
    public IQuadtree BottomLeft { get{return childrens[2];} }
    public IQuadtree BottomRight { get{ return childrens[3];}  


}
}