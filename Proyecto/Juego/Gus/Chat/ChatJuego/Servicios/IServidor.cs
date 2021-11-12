using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChatJuego.Base_de_datos;
using ChatJuego.Host;

namespace ChatJuego.Servicios
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IServidor
    {

        [OperationContract(IsOneWay = false)]
        EstadoDeInicioDeSesion Conectarse(Jugador jugador);

        [OperationContract(IsOneWay = false)]
        EstadoDeEliminacion EliminarJugador(Jugador jugador);


        [OperationContract(IsOneWay = false)]
        EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador);

        [OperationContract(IsOneWay = false)]
        byte[] ObtenerBytesDeImagenDeJugador(string usuario);

        [OperationContract(IsOneWay = true)]
        void Desconectarse();

        [OperationContract(IsOneWay = false)]
        EstadoUnirseAPartida UnirseAPartida(Jugador jugador, string codigoDePartida);

        [OperationContract(IsOneWay = true)]
        void EliminarPartida(string codigoDePartida);

        [OperationContract(IsOneWay = true)]
        void InicializarPartida(string codigoDePartida);

        
    }

    public enum EstadoDeRegistro
    {
        Correcto = 0,
        FallidoPorCorreo,
        FallidoPorUsuario,
        Fallido
    }

    public enum EstadoDeEliminacion
    {
        Correcto = 0,
        Fallido
    }

    public enum EstadoDeInicioDeSesion
    {
        Correcto = 0,
        FallidoPorUsuarioYaConectado,
        Fallido
    }

    public enum EstadoUnirseAPartida
    {
        Correcto = 0,
        FallidoPorPartidaNoEncontrada,
        FallidoPorMaximoDeJugadores
    }
}
