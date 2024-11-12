using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Weboo.Examen.Supermercado
{
    public class Supermercado : ISupermercado
    {
        public Supermercado(int cajas)
        {
            throw new NotImplementedException();
        }

        public void ClienteAPagar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Proximo()
        {
            throw new NotImplementedException();
        }

        public Cliente EnLaPuerta { get { throw new NotImplementedException(); } }

        public int ClientesEnCaja(int caja)
        {
            throw new NotImplementedException();
        }
    }
}