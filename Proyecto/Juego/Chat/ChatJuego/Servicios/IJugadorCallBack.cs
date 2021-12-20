using ChatJuego.Base_de_datos;
using ChatJuego.Servicios;
using System.Collections.Generic;
using System.ServiceModel;

namespace ChatJuego.Host
{
    /// <summary>
    /// Contrato de la funcionalidad del CallBack del Jugador
    /// </summary>
    [ServiceContract]
    public interface IJugadorCallBack
    {
        /// <summary>
        /// Método que recibe el mensaje para mostrarlo en la ventana del Chat.
        /// </summary>
        /// <param name="jugador">Jugador que envía el mensaje.</param>
        /// <param name="mensaje">Contiene el mensaje y su información.</param>
        /// <param name="nombresDeJugadores">Arreglo que contiene los jugadores conectados.</param>
        [OperationContract(IsOneWay = true)]
        void RecibirMensaje(Jugador jugador, Mensaje mensaje,string[] nombresDeJugadores);

        /// <summary>
        /// Método que actualiza los jugadores conectados.
        /// </summary>
        /// <param name="nombresDeJugadores">Arreglo que contiene los nombres de los jugadores conectados</param>
        [OperationContract(IsOneWay = true)]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);

        /// <summary>
        /// Método que muestra los puntajes de los jugadores.
        /// </summary>
        /// <param name="jugadores">Arreglo que contiene los Jugadores con sus puntuaciones.</param>
        [OperationContract(IsOneWay = true)]
        void MostrarPuntajes(Jugador[] jugadores);

        /// <summary>
        /// Método que inica la partida solo si ya se asignó una ventana de juego.
        /// </summary>
        /// <param name="nombreOponente">Nombre del oponente.</param>
        [OperationContract(IsOneWay = true)]
        void IniciarPartida(string nombreOponente);

        /// <summary>
        /// Método que desconecta de la partida y la finaliza.
        /// Manda el estado de la partida para saber cómo finalizó.
        /// </summary>
        /// <param name="estadoPartida">Estado de la partida, ya sea ganada, empate, etc.</param>
        [OperationContract(IsOneWay = true)]
        void DesconectarDePartida(EstadoPartida estadoPartida);


        /// <summary>
        /// Método que inserta la ficha del oponente en el tablero, solo si existe ya una instancia de la ventana de juego.
        /// </summary>
        /// <param name="columna">Entero que contiene la columna donde tiró el oponente.</param>
        [OperationContract(IsOneWay = true)]
        void InsertarFichaEnTablero(int columna);
    }
}
