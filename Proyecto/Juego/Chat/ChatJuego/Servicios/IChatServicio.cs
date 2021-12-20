using ChatJuego.Base_de_datos;
using System.ServiceModel;

namespace ChatJuego.Host
{
    /// <summary>
    /// Contrato de la funcionalidad del Chat
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IChatServicio
    {
        /// <summary>
        /// Cuando se conecta un jugador nuevo o desconecta, este método actualiza los 
        /// jugadores conectados de los jugadores en el chat.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void InicializarChat();

        /// <summary>
        /// Este método permite el intercambio de mensajes entre jugadores. Manda un mensaje a los jugadores conectados.
        /// </summary>
        /// <param name="mensaje">Contiene la información del mensaje.</param>
        /// <param name="jugadorQueMandaMensaje">Contiene la información del jugador que manda el mensaje.</param>
        [OperationContract(IsOneWay = true)]
        void MandarMensaje(Mensaje mensaje, Jugador jugadorQueMandaMensaje);

        /// <summary>
        /// Este método permite el intercambio de mensajes entre dos jugadores específicos. Se utiliza para el chat durante la partida o para mensajes directos privados.
        /// </summary>
        /// <param name="mensaje">Contiene la información del mensaje.</param>
        /// <param name="nombreJugador">Nombre del jugador que recibirá el mensaje privado.</param>
        /// <param name="jugadorQueMandaMensaje">Contiene la información del jugador que manda el mensaje.</param>
        [OperationContract(IsOneWay = true)]
        void MandarMensajePrivado(Mensaje mensaje, string nombreJugador, Jugador jugadorQueMandaMensaje);


        
    }
}
