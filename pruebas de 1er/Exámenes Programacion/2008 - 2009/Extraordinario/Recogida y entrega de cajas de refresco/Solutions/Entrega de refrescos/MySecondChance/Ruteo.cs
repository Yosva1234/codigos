using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondChance
{
    public class Ruteo
    {
        public static int[] EncontrarRuta(Cliente[] listado, int capacidad) 
        {
            List<int> ruta = new List<int>();
            int carga;

            //listado = EliminaClientesConExeso(listado, capacidad);

            if (listado.Length == 0)
                return ruta.ToArray();

            carga = Planificacion(listado, capacidad);

            Ruta(listado, carga, capacidad, ref ruta);

            return ruta.ToArray();
        }

        private static void Ruta(Cliente[] listado, int carga, int capacidad, ref List<int> ruta)
        {
            List<Cliente[]> var = new List<Cliente[]>();

            for (int i = 1; i <= listado.Length; i++)
            {
                var = VariacionDeClientes(listado, i, capacidad, carga);

                if (var.Count != 0)
                {
                    ruta.Clear();
                    ruta = BuscadorDeRuta(listado, var[0]);
                }

                else
                    return;
            }
        }

        #region Métodos Auxiliares

        private static int Planificacion(Cliente[] listado, int capacidad)
        {
            int demanda = 0;

            for (int i = 0; i < listado.Length; i++)
                demanda += listado[i].CantCajasBotellasLLenas;

            return (demanda > capacidad) ? capacidad : demanda;
        }

        private static Cliente[] EliminaClientesConExeso(Cliente[] listado, int capacidad)
        {
            List<Cliente> clientList = new List<Cliente>();

            for (int i = 0; i < listado.Length; i++)
            {
                if (listado[i].CantCajasBotellasVacias > capacidad)
                    continue;

                clientList.Add(listado[i]);
            }

            return clientList.ToArray();
        }

        private static List<Cliente[]> VariacionDeClientes(Cliente[] listado, int tamaño, int capacidad, int carga) 
        {
            List<Cliente[]> variacion = new List<Cliente[]>();

            VariaciondeClientesRec(listado, tamaño, 0, variacion, carga, capacidad);

            return variacion;
        }

        private static void VariaciondeClientesRec(Cliente[] listado, int tamaño, int pos, List<Cliente[]> variacion, int carga, int capacidad)
        {
            if (tamaño == pos)
            {
                Cliente[] subVariacion = new Cliente[tamaño];
                Array.Copy(listado, subVariacion, tamaño);
                if (EsRutaValida(subVariacion, carga, capacidad))
                {
                    variacion.Add(subVariacion);
                    return;
                }
            }

            else
            {
                for (int i = pos; i < listado.Length; i++)
                {
                    swap(listado, pos, i);
                    VariaciondeClientesRec(listado, tamaño, pos + 1, variacion, carga, capacidad);
                    swap(listado, pos, i);
                }
            }
        }

        private static void swap(Cliente[] listado, int pos, int i)
        {
            Cliente aux = listado[pos];
            listado[pos] = listado[i];
            listado[i] = aux;
        }

        private static bool EsRutaValida(Cliente[] subVariacion, int carga, int capacidad)
        {
            int auxCarga = carga;
            int cajasLLenas = carga;

            for (int i = 0; i < subVariacion.Length; i++)
            {
                if (auxCarga - subVariacion[i].CantCajasBotellasLLenas + subVariacion[i].CantCajasBotellasVacias > capacidad || cajasLLenas < subVariacion[i].CantCajasBotellasLLenas)
                    return false;

                auxCarga = auxCarga - subVariacion[i].CantCajasBotellasLLenas + subVariacion[i].CantCajasBotellasVacias;
                cajasLLenas -= subVariacion[i].CantCajasBotellasLLenas;
            }
            return true;
        }

        private static List<int> BuscadorDeRuta(Cliente[] listado, Cliente[] clientes)
        {
            List<int> ruta = new List<int>();

            for (int i = 0; i < clientes.Length; i++)
                for (int j = 0; j < listado.Length; j++)
                {
                    if (clientes[i].CantCajasBotellasLLenas == listado[j].CantCajasBotellasLLenas && clientes[i].CantCajasBotellasVacias == listado[j].CantCajasBotellasVacias && NoEstaAntes(ruta, j))
                        ruta.Add(j);
                }
            return ruta;
        }

        private static bool NoEstaAntes(List<int> ruta, int j)
        {
            for (int i = 0; i < ruta.Count; i++)
                if (ruta[i] == j)
                    return false;

            return true;
        }

        #endregion
    }
}
