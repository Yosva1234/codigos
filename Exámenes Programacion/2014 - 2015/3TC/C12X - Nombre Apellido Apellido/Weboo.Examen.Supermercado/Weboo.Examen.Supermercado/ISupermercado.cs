namespace Weboo.Examen.Supermercado
{
    public interface ISupermercado
    {
        /// <summary>
        /// Lleva un nuevo cliente y se ubica en la caja correspondiente.
        /// </summary>
        void ClienteAPagar(Cliente cliente);

        /// <summary>
        /// El custodio ordena pasar al próximo cliente a la puerta de salida.
        /// </summary>
        bool Proximo();

        /// <summary>
        /// El cliente actualmente en la puerta de salida enseña sus compras.
        /// </summary>
        Cliente EnLaPuerta { get; }

        /// <summary>
        /// Devuelve la cantidad de clientes en espera en la caja correspondiente.
        /// Incluyendo el que puede estar en la punta de la caja con todos los 
        /// productos ya pagados.
        /// </summary>	
        int ClientesEnCaja(int caja);
    }
}
