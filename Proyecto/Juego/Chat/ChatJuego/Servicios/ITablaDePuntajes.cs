using ChatJuego.Host;
using System.ServiceModel;

namespace ChatJuego.Servicios
{
    /// <summary>
    /// Contrato de la funcionalidad de la Tabla de Puntajes
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface ITablaDePuntajes
    {
        /// <summary>
        /// Recupera los puntajes de los jugadores para mostrarlos en el jugador que abre la ventana de tabla de puntajes.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void RecuperarPuntajesDeJugadores();
    }
}
