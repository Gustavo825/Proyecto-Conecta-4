using ChatJuego.Base_de_datos;
using System.Collections.Generic;
using System.ServiceModel;

namespace ChatJuego.Host
{
    [ServiceContract]
    public interface IChatJugadorCallBack
    {
        [OperationContract(IsOneWay = true)]
        void recibirMensaje(Jugador jugador, Mensaje mensaje,string[] nombresDeJugadores);

        [OperationContract(IsOneWay = true)]
        void actualizarJugadoresConectados(string[] nombresDeJugadores);

    }
}
