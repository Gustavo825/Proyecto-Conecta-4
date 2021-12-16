using ChatJuego.Host;
using System.ServiceModel;

namespace ChatJuego.Servicios
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]

    public interface ITablaDePuntajes
    {
        [OperationContract(IsOneWay = true)]
        void RecuperarPuntajesDeJugadores();
    }
}
