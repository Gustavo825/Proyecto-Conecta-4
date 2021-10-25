using ChatJuego.Base_de_datos;
using System.ServiceModel;

namespace ChatJuego.Host
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IChatServicio
    {

        [OperationContract(IsOneWay = true)]
        void inicializar();

        
        [OperationContract(IsOneWay = true)]
        void mandarMensaje(Mensaje mensaje, Jugador jugadorQueMandaMensaje);

        [OperationContract(IsOneWay = true)]
        void mandarMensajePrivado(Mensaje mensaje, string nombreJugador, Jugador jugadorQueMandaMensaje);


        
    }
}
