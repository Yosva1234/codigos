using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weboo.Utils;

namespace Weboo.ExamenExtraordinario
{
    public class Restaurante : IRestaurante
    {
        public Queue<TipoPlato> Platos;
        List<List<Aditivo>> aditivos;
        public Restaurante()
        {
            Platos = new Queue<TipoPlato>();
            aditivos = new List<List<Aditivo>>();
        }

        public void CreaNuevoAditivo(string tipoPlato, string aditivo, double precio)
        {
           foreach(var elementos in Platos)
            {
                if(elementos.Nombre == tipoPlato)
                {
                    aditivos.Add(new List<Aditivo>());
                    
                }
            }
        }

        public void CreaNuevoPlato(string tipoPlato, double precioBase)
        {
            Platos.Enqueue(new TipoPlato(tipoPlato, precioBase, aditivos));
        }

        public void FinalizaOrden()
        {
            throw new NotImplementedException();
        }

        public void IniciaOrden()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPlato> Menu
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<double> OrdenesAtendidas
        {
            get { throw new NotImplementedException(); }
        }

        public void Selecciona(string opcion)
        {
            throw new NotImplementedException();
        }
    }
}
