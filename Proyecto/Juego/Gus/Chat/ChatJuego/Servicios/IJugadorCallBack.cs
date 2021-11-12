using ChatJuego.Base_de_datos;
using System.Collections.Generic;
using System.ServiceModel;

namespace ChatJuego.Host
{
    [ServiceContract]
    public interface IJugadorCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RecibirMensaje(Jugador jugador, Mensaje mensaje,string[] nombresDeJugadores);

        [OperationContract(IsOneWay = true)]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);

        [OperationContract(IsOneWay = true)]
        void MostrarPuntajes(Jugador[] jugadores);

        [OperationContract(IsOneWay = true)]
        void IniciarPartida(string nombreOponente);
    }
}
