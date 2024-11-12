using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Weboo.Examen.Supermercado
{
    public class Supermercado : ISupermercado
    {
        int cajas;
        Queue<Cliente>[] clientesPorCajas;
        Queue<Products>[] productosPorClientes;
        bool sePidioProximo;
        Cliente clienteGab;
        
        public Supermercado(int cajas)
        {
            this.cajas = cajas;
            clientesPorCajas = new Queue<Cliente>[this.cajas];
            productosPorClientes = new Queue<Products>[this.cajas];
            for (int i = 0; i < this.cajas; i++)
            {
                clientesPorCajas[i] = new Queue<Cliente>();
                productosPorClientes[i] = new Queue<Products>();
            }
            
        }

        public void ClienteAPagar(Cliente cliente)
        {
            int menorCantClientes = int.MaxValue;
            int mejorCaja = 0;

            for (int i = 0; i < cajas; i++)
            {
                if (ClientesEnCaja(i) < menorCantClientes)
                {
                    menorCantClientes = ClientesEnCaja(i);
                    mejorCaja = i;
                }
            }
            clientesPorCajas[mejorCaja].Enqueue(cliente);
            productosPorClientes[mejorCaja].Enqueue(new Products(cliente.Productos));            
        }

        public bool Proximo()
        {
            for (int i = 0; i < cajas; i++)
            {
                if (clientesPorCajas[i].Count != 0)
                {
                    clienteGab = DecidirProximo();
                    sePidioProximo = true;
                    return true;
                }
            }
            sePidioProximo = false;
            return false;
        }

        public Cliente EnLaPuerta 
        { 
            get 
            {
                if (sePidioProximo) 
                {
                    return clienteGab;
                }
                throw new InvalidOperationException(); 
            } 
        }

        public int ClientesEnCaja(int caja)
        {
            return clientesPorCajas[caja].Count; 
        }

        public Cliente DecidirProximo()
        {
            int menorCantProductos = int.MaxValue;
            int mejorCaja = 0;

            for (int i = 0; i < cajas; i++)
            {
                if (clientesPorCajas[i].Count != 0 && productosPorClientes[i].Peek().productos < menorCantProductos)
                {
                    menorCantProductos = productosPorClientes[i].Peek().productos;
                    mejorCaja = i;
                }
            }

            for (int i = 0; i < cajas; i++)
            {
                if (clientesPorCajas[i].Count != 0)
                {
                    productosPorClientes[i].Peek().productos = productosPorClientes[i].Peek().productos - menorCantProductos;
                }
            }
            
            productosPorClientes[mejorCaja].Dequeue();
            return clientesPorCajas[mejorCaja].Dequeue();
        }
    }

    class Products
    {
        public int productos { get; set; }

        public Products(int productos)
        {
            this.productos = productos;
        }
    }
}