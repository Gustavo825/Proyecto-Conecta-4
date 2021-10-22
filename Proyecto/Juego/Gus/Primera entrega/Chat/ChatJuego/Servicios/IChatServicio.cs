using ChatJuego.Base_de_datos;
using System.ServiceModel;

namespace ChatJuego.Host
{
    [ServiceContract(CallbackContract = typeof(IChatJugadorCallBack))]
    public interface IChatServicio
    {
        [OperationContract(IsOneWay = false)]
        bool conectarse(Jugador jugador);

        [OperationContract(IsOneWay = true)]
        void inicializar();

        [OperationContract(IsOneWay = false)]
        EstadoDeRegistro registroJugador(string usuario, string contrasenia, string correo);
        
        [OperationContract(IsOneWay = true)]
        void mandarMensaje(Mensaje mensaje);

        [OperationContract(IsOneWay = true)]
        void mandarMensajePrivado(Mensaje mensaje, string nombreJugador);

        [OperationContract(IsOneWay = true)]
        void desconectarse();

        [OperationContract(IsOneWay = true)]
        void recuperarPuntajesDeJugadores();
    }
}
