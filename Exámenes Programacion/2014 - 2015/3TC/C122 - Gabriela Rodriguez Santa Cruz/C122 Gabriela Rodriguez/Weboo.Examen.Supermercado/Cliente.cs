namespace Weboo.Examen.Supermercado
{
    public class Cliente
    {
        public int Productos { get; private set; }

        public Cliente(int productos)
        {
            Productos = productos;
        }
    }
}