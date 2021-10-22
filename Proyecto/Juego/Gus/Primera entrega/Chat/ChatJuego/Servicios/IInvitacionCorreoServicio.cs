using ChatJuego.Base_de_datos;
using ChatJuego.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static ChatJuego.Host.ChatServicio;

namespace ChatJuego.Servicios
{
    [ServiceContract(CallbackContract = typeof(IChatJugadorCallBack))]

    public interface IInvitacionCorreoServicio
    {
        [OperationContract(IsOneWay = false)]
        EstadoDeEnvio enviarInvitacion(Jugador jugadorInvitado, string codigoPartida, Jugador jugadorInvitador);
    }
}
