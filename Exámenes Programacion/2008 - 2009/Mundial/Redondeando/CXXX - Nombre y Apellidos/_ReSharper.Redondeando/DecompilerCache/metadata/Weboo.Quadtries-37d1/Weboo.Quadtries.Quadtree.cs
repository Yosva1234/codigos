// Type: Weboo.Quadtries.Quadtree
// Assembly: Weboo.Quadtries, Version=1.0.0.0, Culture=neutral
// Assembly location: D:\Arnold\Importante\Estudio\programacion\Pruebas\2008 - 2009\Mundial\Redondeando\CXXX - Nombre y Apellidos\Weboo.Quadtries.dll

namespace Weboo.Quadtries
{
    public class Quadtree
    {
        public Quadtree(QuadtreeColor color);
        public Quadtree(Quadtree h0, Quadtree h1, Quadtree h2, Quadtree h3);
        public QuadtreeColor Color { get; }
        public int CantidadDeHijos { get; }
        public Quadtree Hijo0 { get; }
        public Quadtree Hijo1 { get; }
        public Quadtree Hijo2 { get; }
        public Quadtree Hijo3 { get; }
        public Quadtree Hijo(int index);
    }
}
