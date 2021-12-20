using System.ServiceModel;
using ChatJuego.Base_de_datos;
using ChatJuego.Host;

namespace ChatJuego.Servicios
{
    /// <summary>
    /// Contrato de la funcionalidad del Servidor y del Juego
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IServidor
    {
        /// <summary>
        /// Permite conectar un jugador al servidor. Guarda su conexión.
        /// </summary>
        /// <param name="jugador">Objeto de tipo jugador que contiene la información de inicio de sesión.</param>
        /// <returns>Regresa el estado de inicio de sesión, es decir, si fue correcto, fallido, etc.</returns>
        [OperationContract(IsOneWay = false)]
        EstadoDeInicioDeSesion Conectarse(Jugador jugador);

        /// <summary>
        /// Llama al método de la clase Autenticación para eliminar un jugador de la base de datos.
        /// </summary>
        /// <param name="jugador">Contiene la información del jugador a eliminar.</param>
        /// <returns>Regresa el estado de eliminación, es decir, correcto, fallido, etc.</returns>
        [OperationContract(IsOneWay = false)]
        EstadoDeEliminacion EliminarJugador(Jugador jugador);

        /// <summary>
        /// Permite el registro de un jugador en la base de datos.
        /// </summary>
        /// <param name="usuario">Usuario que tendrá el jugador.</param>
        /// <param name="contrasenia">Contraseña del jugador.</param>
        /// <param name="correo">Correo del jugador.</param>
        /// <param name="imagenDeJugador">Arreglo de bytes de la imágen del jugador.</param>
        /// <returns>Regresa el estado del registro del jugador</returns>
        [OperationContract(IsOneWay = false)]
        EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador);

        /// <summary>
        /// Obtiene los bytes de la imágen de un jugador.
        /// </summary>
        /// <param name="usuario">Usuario del jugador del que se quiere recuperar los bytes de la imagen.</param>
        /// <returns>Regresa un arreglo con los bytes de la imágen.</returns>
        [OperationContract(IsOneWay = false)]
        byte[] ObtenerBytesDeImagenDeJugador(string usuario);

        /// <summary>
        /// Desconecta al jugador del servidor. Elimina su conexión del servidor.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Desconectarse();

        /// <summary>
        /// Permite a un jugador unirse a una partida, registrándolo en la partida que tenga el código de partida recibido.
        /// </summary>
        /// <param name="jugador">Contiene la información del jugador que e va a unir a la partida.</param>
        /// <param name="codigoDePartida">Contiene el código de la partida a la que se quiere unir.</param>
        /// <returns>Regresa el estado de unirse a la partida, es decir, correcto, fallido, etc.</returns>
        [OperationContract(IsOneWay = false)]
        EstadoUnirseAPartida UnirseAPartida(Jugador jugador, string codigoDePartida);

        /// <summary>
        /// Elimina una partida del servidor.
        /// </summary>
        /// <param name="codigoDePartida">Código de la partida que se va a eliminar.</param>
        /// <param name="usuarioQueFinaliza">Usuario que finaliza la partida.</param>
        /// <param name="estadoPartida">Estado de fin de partida.</param>
        [OperationContract(IsOneWay = true)]
        void EliminarPartida(string codigoDePartida, string usuarioQueFinaliza, EstadoPartida estadoPartida);

        /// <summary>
        /// Elimina una partida del servidor, pero este método, a diferencia del anterior, se llama cuando alguien gana.
        /// </summary>
        /// <param name="codigoDePartida">Código de la partida que se va a eliminar.</param>
        /// <param name="usuarioQueFinaliza">Usuario que finaliza la partida.</param>
        /// <param name="estadoPartida">Estado de fin de partida, es decir, ganada.</param>
        /// <param name="puntaje">Puntaje que se le agregará al ganador.</param>
        /// <param name="ganador">Usuario del jugador que ganó.</param>
        [OperationContract(IsOneWay = true)]
        void EliminarPartidaConGanador(string codigoDePartida, string usuarioQueFinaliza, EstadoPartida estadoPartida, float puntaje, string ganador);

        /// <summary>
        /// Método que inicializa la partida de los jugadores asignados a una partida.
        /// </summary>
        /// <param name="codigoDePartida">Código de la partida en la que se ecuentran los dos jugadores.</param>
        [OperationContract(IsOneWay = true)]
        void InicializarPartida(string codigoDePartida);

        /// <summary>
        /// Agrega puntaje al usuario recibido.
        /// </summary>
        /// <param name="usuario">Usuario al que se le agregarán los puntos</param>
        /// <param name="puntaje">Puntaje que se agregará al usuario.</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        EstadoAgregarPuntuacion AgregarPuntajeAJugador(string usuario, float puntaje);

        /// <summary>
        /// Permite insertar una ficha en el tablero del oponente.
        /// </summary>
        /// <param name="columna">Columna a la que se insertará la ficha.</param>
        /// <param name="codigoDePartida">Código de la partidae en curso.</param>
        /// <param name="oponente">Usuario del oponente para insertar la ficha en su tablero.</param>
        [OperationContract(IsOneWay = true)]
        void InsertarFichaEnOponente(int columna, string codigoDePartida, string oponente);
        
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

    public enum EstadoPartida
    {
        FinDePartidaGanada = 0,
        FinDePartidaSalir,
        FinDePartidaPorTiempoDeEsperaLimite,
        FinDePartidaPerdida,
        FinDePartidaPorEmpate
    }

    public enum EstadoAgregarPuntuacion
    {
        Correcto = 0,
        Fallido
    }
}
