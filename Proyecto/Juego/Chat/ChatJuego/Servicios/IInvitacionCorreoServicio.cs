using ChatJuego.Base_de_datos;
using ChatJuego.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static ChatJuego.Host.Servicio;

namespace ChatJuego.Servicios
{
    /// <summary>
    /// Contrato de la funcionalidad del Correo
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IInvitacionCorreoServicio
    {
        /// <summary>
        /// Permite enviar la invitación de la partida creada al jugador recibido.
        /// </summary>
        /// <param name="jugadorInvitado">Jugador que recibirá la invitación.</param>
        /// <param name="codigoPartida">Código de la partida para unirse.</param>
        /// <param name="jugadorInvitador">Jugador que manda la invitación.</param>
        [OperationContract(IsOneWay = false)]
        EstadoDeEnvio EnviarInvitacion(Jugador jugadorInvitado, string codigoPartida, Jugador jugadorInvitador);

        /// <summary>
        /// Manda un código de registro al correo ingresado por el jugador.
        /// </summary>
        /// <param name="codigoDeRegistro">Código de registro.</param>
        /// <param name="correo">Correo al que se envía el código.</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        EstadoDeEnvio MandarCodigoDeRegistro(string codigoDeRegistro, string correo);
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EstadoDeEnvio
    {
        Correcto = 0,
        UsuarioNoEncontrado,
        Fallido
    }
}
