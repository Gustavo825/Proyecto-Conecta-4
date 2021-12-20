using ChatJuego.Base_de_datos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using ChatJuego.Servicios;
using System.Net.Mail;
using System.Net;
using ChatJuego.Dominio;

namespace ChatJuego.Host
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Servicio : IChatServicio, IInvitacionCorreoServicio, ITablaDePuntajes, IServidor
    {
        public static Dictionary<IJugadorCallBack, Jugador> jugadores = new Dictionary<IJugadorCallBack, Jugador>();
        public static List<Partida> partidas = new List<Partida>();
        private const string CORREO = "juegocontecta4equipo1@gmail.com";
        private const string SMTP_SERVIDOR = "smtp.gmail.com";
        private const int PUERTO = 587;
        private const string CONTRASENIA = "gusandreacarlos1*";

        /// <summary>
        /// Permite conectar un jugador al servidor. Guarda su conexión.
        /// </summary>
        /// <param name="jugador">Objeto de tipo jugador que contiene la información de inicio de sesión.</param>
        /// <returns>Regresa el estado de inicio de sesión, es decir, si fue correcto, fallido, etc.</returns>
        public EstadoDeInicioDeSesion Conectarse(Jugador jugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeAutenticacion estado = autenticacion.IniciarSesion(jugador.usuario, jugador.contrasenia);
            if (estado == EstadoDeAutenticacion.Correcto)
            {
                foreach (var jugadorIniciado in jugadores.Values)
                {
                    if (jugador.usuario == jugadorIniciado.usuario)
                    {

                        return EstadoDeInicioDeSesion.FallidoPorUsuarioYaConectado;
                    }
                }
                var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
                Console.WriteLine("Jugador Conectado: {0}", jugador.usuario);
                jugadores.Add(conexion, jugador);
                return EstadoDeInicioDeSesion.Correcto;
            }
            else
                return EstadoDeInicioDeSesion.Fallido;
        }

        /// <summary>
        /// Desconecta al jugador del servidor. Elimina su conexión del servidor.
        /// </summary>
        public void Desconectarse()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
            Console.WriteLine("Jugador desconectado: {0}", jugadores[conexion].usuario);
            jugadores.Remove(conexion);
            string[] nombresDeJugadores = new string[jugadores.Count];
            var i = 0;
            foreach (Jugador nombre in jugadores.Values)
            {
                nombresDeJugadores[i] = nombre.usuario;
                i++;
            }
            foreach (var conexiones in jugadores.Keys)
            {
                if (conexiones == conexion)
                    continue;
                conexiones.ActualizarJugadoresConectados(nombresDeJugadores);
            }
        }


        /// <summary>
        /// Permite enviar la invitación de la partida creada al jugador recibido.
        /// </summary>
        /// <param name="jugadorInvitado">Jugador que recibirá la invitación.</param>
        /// <param name="codigoPartida">Código de la partida para unirse.</param>
        /// <param name="jugadorInvitador">Jugador que manda la invitación.</param>
        /// <returns></returns>
        public EstadoDeEnvio EnviarInvitacion(Jugador jugadorInvitado, string codigoPartida, Jugador jugadorInvitador)
        {
            EstadoDeEnvio estado = EstadoDeEnvio.Fallido;
            using (var contexto = new JugadorContexto())
            {
                if ((from jugador in contexto.jugadores
                     where jugador.usuario == jugadorInvitado.usuario
                     select jugador).Count() == 0)
                {
                    estado = EstadoDeEnvio.UsuarioNoEncontrado;
                    return estado;
                }
                jugadorInvitado.correo = (from jugador in contexto.jugadores
                                          where jugador.usuario == jugadorInvitado.usuario
                                          select jugador.correo).Single();
                try
                {
                    SmtpClient smtpCliente = new SmtpClient(SMTP_SERVIDOR, PUERTO);
                    smtpCliente.EnableSsl = true;
                    smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpCliente.UseDefaultCredentials = false;
                    smtpCliente.Credentials = new NetworkCredential(CORREO, CONTRASENIA);
                    string jugadorQueInvita = "";
                    jugadorQueInvita = jugadorInvitador.usuario;
                    using (MailMessage mensaje = new MailMessage())
                    {
                        mensaje.From = new MailAddress(CORREO);
                        mensaje.Subject = "Invitación de " + jugadorQueInvita;
                        mensaje.Body = "El código para unirse a la partida es: " + codigoPartida;
                        mensaje.IsBodyHtml = false;
                        mensaje.To.Add(jugadorInvitado.correo);
                        smtpCliente.Send(mensaje);
                        estado = EstadoDeEnvio.Correcto;
                        partidas.Add(new Partida(codigoPartida, jugadorInvitador));
                    }

                }
                catch (Exception exception) when (exception is SmtpException || exception is InvalidOperationException
              || exception is FormatException || exception is ArgumentNullException)
                {
                    estado = EstadoDeEnvio.Fallido;
                    Console.WriteLine(exception.StackTrace);
                }
            }
            return estado;

        }

        /// <summary>
        /// Cuando se conecta un jugador nuevo o desconecta, este método actualiza 
        /// los jugadores conectados de los jugadores en el chat.
        /// </summary>
        public void InicializarChat()
        {
            OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
            string[] nombresDeJugadores = new string[jugadores.Count];
            var i = 0;
            foreach (Jugador nombre in jugadores.Values)
            {
                nombresDeJugadores[i] = nombre.usuario;
                i++;
            }
            foreach (var conexiones in jugadores.Keys)
            {
                conexiones.ActualizarJugadoresConectados(nombresDeJugadores);
            }
        }

        /// <summary>
        /// Este método permite el intercambio de mensajes entre jugadores. Manda un mensaje a los jugadores conectados.
        /// </summary>
        /// <param name="mensaje">Contiene la información del mensaje.</param>
        /// <param name="jugadorQueMandaMensaje">Contiene la información del jugador que manda el mensaje.</param>
        public void MandarMensaje(Mensaje mensaje, Jugador jugadorQueMandaMensaje)
        {
            Console.WriteLine("{0}:{1}", jugadorQueMandaMensaje.usuario, mensaje.ContenidoMensaje);
            string[] nombresDeJugadores = new string[jugadores.Count];
            var i = 0;
            foreach (Jugador nombre in jugadores.Values)
            {
                nombresDeJugadores[i] = nombre.usuario;
                i++;
            }
            foreach (var conexiones in jugadores.Keys)
            {
                if (jugadores[conexiones].usuario == jugadorQueMandaMensaje.usuario)
                    continue;
                conexiones.RecibirMensaje(jugadorQueMandaMensaje, mensaje, nombresDeJugadores);
            }
        }

        /// <summary>
        /// Este método permite el intercambio de mensajes entre dos jugadores específicos. Se utiliza para el chat durante la partida o para mensajes directos privados.
        /// </summary>
        /// <param name="mensaje">Contiene la información del mensaje.</param>
        /// <param name="nombreJugador">Nombre del jugador que recibirá el mensaje privado.</param>
        /// <param name="jugadorQueMandaMensaje">Contiene la información del jugador que manda el mensaje.</param>
        public void MandarMensajePrivado(Mensaje mensaje, string nombreJugador, Jugador jugadorQueMandaMensaje)
        {
            Console.WriteLine("{0}:{1}", jugadorQueMandaMensaje.usuario, mensaje.ContenidoMensaje);
            string[] nombresDeJugadores = new string[jugadores.Count];
            var i = 0;
            foreach (Jugador nombre in jugadores.Values)
            {
                nombresDeJugadores[i] = nombre.usuario;
                i++;
            }
            foreach (var conexiones in jugadores.Keys)
            {
                if (jugadores[conexiones].usuario == jugadorQueMandaMensaje.usuario)
                    continue;
                if (jugadores[conexiones].usuario == nombreJugador)
                {
                    conexiones.RecibirMensaje(jugadorQueMandaMensaje, mensaje, nombresDeJugadores);
                    break;
                }
            }
        }

        /// <summary>
        /// Recupera los puntajes de los jugadores para mostrarlos en el jugador que abre la ventana de tabla de puntajes.
        /// </summary>
        public void RecuperarPuntajesDeJugadores()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 select jugador).ToList().OrderByDescending(x => x.puntaje);
                var jugadoresArreglo = new Jugador[jugadores.Count()];
                int i = 0;
                foreach (Jugador jugador in jugadores)
                {
                    jugador.imagenUsuario = null;
                    jugadoresArreglo[i] = jugador;
                    i++;
                }
                conexion.MostrarPuntajes(jugadoresArreglo);

            }
        }

        /// <summary>
        /// Permite el registro de un jugador en la base de datos.
        /// </summary>
        /// <param name="usuario">Usuario que tendrá el jugador.</param>
        /// <param name="contrasenia">Contraseña del jugador.</param>
        /// <param name="correo">Correo del jugador.</param>
        /// <param name="imagenDeJugador">Arreglo de bytes de la imágen del jugador.</param>
        /// <returns>Regresa el estado del registro del jugador</returns>
        public EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeRegistro estadoDeRegistro = autenticacion.Registrar(usuario, contrasenia, correo, imagenDeJugador);
            return estadoDeRegistro;
        }

        /// <summary>
        /// Manda un código de registro al correo ingresado por el jugador.
        /// </summary>
        /// <param name="codigoDeRegistro">Código de registro.</param>
        /// <param name="correo">Correo al que se envía el código.</param>
        /// <returns></returns>
        public EstadoDeEnvio MandarCodigoDeRegistro(string codigoDeRegistro, string correo)
        {
            EstadoDeEnvio estado = EstadoDeEnvio.Fallido;
            try
            {
                SmtpClient smtpCliente = new SmtpClient(SMTP_SERVIDOR, PUERTO);
                smtpCliente.EnableSsl = true;
                smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpCliente.UseDefaultCredentials = false;
                smtpCliente.Credentials = new NetworkCredential(CORREO, CONTRASENIA);
                using (MailMessage mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(CORREO);
                    mensaje.Subject = "Confirmación de registro de jugador";
                    mensaje.Body = "Ingrese el siguiente código para validar su registro: " + codigoDeRegistro;
                    mensaje.IsBodyHtml = false;
                    mensaje.To.Add(correo);
                    smtpCliente.Send(mensaje);
                    estado = EstadoDeEnvio.Correcto;
                }
            }
            catch (Exception exception) when (exception is SmtpException || exception is InvalidOperationException
            || exception is FormatException || exception is ArgumentNullException)
            {
                estado = EstadoDeEnvio.Fallido;
                Console.WriteLine(exception.StackTrace);
            }
            return estado;

        }

        /// <summary>
        /// Obtiene los bytes de la imágen de un jugador.
        /// </summary>
        /// <param name="usuario">Usuario del jugador del que se quiere recuperar los bytes de la imagen.</param>
        /// <returns>Regresa un arreglo con los bytes de la imágen.</returns>
        public byte[] ObtenerBytesDeImagenDeJugador(string usuario)
        {
            using (var contexto = new JugadorContexto())
            {
                byte[][] bytesDeImagen;
                bytesDeImagen = (from jugador in contexto.jugadores
                                     where jugador.usuario == usuario
                                     select jugador.imagenUsuario).ToArray();
                if (bytesDeImagen.Length == 0)
                    bytesDeImagen = new byte[1][];
                return bytesDeImagen[0];
            }
        }

        /// <summary>
        /// Llama al método de la clase Autenticación para eliminar un jugador de la base de datos.
        /// </summary>
        /// <param name="jugador">Contiene la información del jugador a eliminar.</param>
        /// <returns>Regresa el estado de eliminación, es decir, correcto, fallido, etc.</returns>
        public EstadoDeEliminacion EliminarJugador(Jugador jugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            return autenticacion.EliminarJugador(jugador.usuario, jugador.contrasenia);
        }

        /// <summary>
        /// Permite a un jugador unirse a una partida, registrándolo en la partida que tenga el código de partida recibido.
        /// </summary>
        /// <param name="jugador">Contiene la información del jugador que e va a unir a la partida.</param>
        /// <param name="codigoDePartida">Contiene el código de la partida a la que se quiere unir.</param>
        /// <returns>Regresa el estado de unirse a la partida, es decir, correcto, fallido, etc.</returns>
        public EstadoUnirseAPartida UnirseAPartida(Jugador jugador, string codigoDePartida)
        {
            bool encontroPartida = false;
            foreach (Partida partida in partidas)
            {
                if (partida.codigoDePartida == codigoDePartida)
                {
                    encontroPartida = true;
                    if (partida.jugadores[1] != null)
                    {
                        return EstadoUnirseAPartida.FallidoPorMaximoDeJugadores;
                    }
                    else
                    {
                        partida.jugadores[1] = jugador;
                        break;
                    }
                }
            }
            if (!encontroPartida)
                return EstadoUnirseAPartida.FallidoPorPartidaNoEncontrada;
            return EstadoUnirseAPartida.Correcto;
        }

        /// <summary>
        /// Método que inicializa la partida de los jugadores asignados a una partida.
        /// </summary>
        /// <param name="codigoDePartida">Código de la partida en la que se ecuentran los dos jugadores.</param>
        public void InicializarPartida(string codigoDePartida)
        {
            foreach (Partida partida in partidas)
            {
                if (partida.codigoDePartida == codigoDePartida)
                {
                    foreach (var conexiones in jugadores.Keys)
                    {
                        if (jugadores[conexiones].usuario == partida.jugadores[1].usuario)
                        {
                            conexiones.IniciarPartida(partida.jugadores[0].usuario);
                        }
                        if (jugadores[conexiones].usuario == partida.jugadores[0].usuario)
                        {
                            conexiones.IniciarPartida(partida.jugadores[1].usuario);
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Elimina una partida del servidor.
        /// </summary>
        /// <param name="codigoDePartida">Código de la partida que se va a eliminar.</param>
        /// <param name="usuarioQueFinaliza">Usuario que finaliza la partida.</param>
        /// <param name="estadoPartida">Estado de fin de partida.</param>
        public void EliminarPartida(string codigoDePartida, string usuarioQueFinaliza, EstadoPartida estadoPartida)
        {
            foreach (Partida partida in partidas)
            {
                if (partida.codigoDePartida == codigoDePartida)
                {
                    if (partida.jugadores[1] != null && usuarioQueFinaliza == partida.jugadores[0].usuario)
                    {
                        foreach (var conexiones in jugadores.Keys)
                        {
                            if (jugadores[conexiones].usuario == partida.jugadores[1].usuario)
                            {
                                conexiones.DesconectarDePartida(estadoPartida);
                            }
                        }
                    }
                    else if (partida.jugadores[1] != null && usuarioQueFinaliza == partida.jugadores[1].usuario)
                    {
                        foreach (var conexiones in jugadores.Keys)
                        {
                            if (jugadores[conexiones].usuario == partida.jugadores[0].usuario)
                            {
                                conexiones.DesconectarDePartida(estadoPartida);
                            }
                        }
                    }
                    partidas.Remove(partida);
                    break;
                }
            }
        }

        /// <summary>
        /// Elimina una partida del servidor, pero este método, a diferencia del anterior, se llama cuando alguien gana.
        /// </summary>
        /// <param name="codigoDePartida">Código de la partida que se va a eliminar.</param>
        /// <param name="usuarioQueFinaliza">Usuario que finaliza la partida.</param>
        /// <param name="estadoPartida">Estado de fin de partida, es decir, ganada.</param>
        /// <param name="puntaje">Puntaje que se le agregará al ganador.</param>
        /// <param name="ganador">Usuario del jugador que ganó.</param>
        public void EliminarPartidaConGanador(string codigoDePartida, string usuarioQueFinaliza, EstadoPartida estadoPartida, float puntaje, string ganador)
        {
            foreach (Partida partida in partidas)
            {
                if (partida.codigoDePartida == codigoDePartida)
                {
                    var estadoAgregarPuntaje = AgregarPuntajeAJugador(ganador, puntaje);
                    if (estadoAgregarPuntaje == EstadoAgregarPuntuacion.Correcto)
                        Console.WriteLine("Puntaje agregado");
                    else
                        Console.WriteLine("Puntaje no agregado");
                    if (partida.jugadores[1] != null && usuarioQueFinaliza == partida.jugadores[0].usuario)
                    {
                        foreach (var conexiones in jugadores.Keys)
                        {
                            if (jugadores[conexiones].usuario == partida.jugadores[1].usuario)
                            {
                                if (jugadores[conexiones].usuario != ganador && estadoPartida == EstadoPartida.FinDePartidaGanada)
                                    conexiones.DesconectarDePartida(EstadoPartida.FinDePartidaPerdida);
                                else
                                    conexiones.DesconectarDePartida(estadoPartida);
                            }
                        }
                    }
                    else if (partida.jugadores[1] != null && usuarioQueFinaliza == partida.jugadores[1].usuario)
                    {
                        foreach (var conexiones in jugadores.Keys)
                        {
                            if (jugadores[conexiones].usuario == partida.jugadores[0].usuario)
                            {
                                if (jugadores[conexiones].usuario != ganador && estadoPartida == EstadoPartida.FinDePartidaGanada)
                                    conexiones.DesconectarDePartida(EstadoPartida.FinDePartidaPerdida);
                                else
                                    conexiones.DesconectarDePartida(estadoPartida);
                            }
                        }
                    }
                    partidas.Remove(partida);
                    break;
                }
            }
        }

        /// <summary>
        /// Agrega puntaje al usuario recibido.
        /// </summary>
        /// <param name="usuario">Usuario al que se le agregarán los puntos</param>
        /// <param name="puntaje">Puntaje que se agregará al usuario.</param>
        /// <returns></returns>
        public EstadoAgregarPuntuacion AgregarPuntajeAJugador(string usuario, float puntaje)
        {
            foreach (var conexiones in jugadores.Keys)
            {
                if (jugadores[conexiones].usuario == usuario)
                {
                    using (var contexto = new JugadorContexto())
                    {
                        float puntajeDelJugador = (from jugador in contexto.jugadores
                                                   where jugador.usuario == usuario
                                                   select jugador.puntaje).First().Value;

                        puntajeDelJugador += puntaje;
                        var jugadorBD = contexto.jugadores.Where(j => j.usuario == usuario).FirstOrDefault();
                        Jugador copia = new Jugador() { usuario = jugadorBD.usuario, contrasenia = jugadorBD.contrasenia, correo = jugadorBD.correo, imagenUsuario = jugadorBD.imagenUsuario, JugadorId = jugadorBD.JugadorId, puntaje = puntajeDelJugador };
                        if (jugadorBD != null)
                        {
                            contexto.Entry(jugadorBD).CurrentValues.SetValues(copia);
                        }
                        try
                        {
                            contexto.SaveChanges();
                        }
                        catch (Exception exception) when (exception is SmtpException || exception is InvalidOperationException
                         || exception is FormatException || exception is ArgumentNullException)
                        {
                            Console.WriteLine(exception.StackTrace);
                            return EstadoAgregarPuntuacion.Fallido;

                        }
                    }
                    return EstadoAgregarPuntuacion.Correcto;
                }
            }
            return EstadoAgregarPuntuacion.Fallido;
        }

        /// <summary>
        /// Permite insertar una ficha en el tablero del oponente.
        /// </summary>
        /// <param name="columna">Columna a la que se insertará la ficha.</param>
        /// <param name="codigoDePartida">Código de la partidae en curso.</param>
        /// <param name="oponente">Usuario del oponente para insertar la ficha en su tablero.</param>
        public void InsertarFichaEnOponente(int columna, string codigoDePartida, string oponente)
        {
            foreach (Partida partida in partidas)
            {
                if (partida.codigoDePartida == codigoDePartida)
                {
                    if (partida.jugadores[0].usuario == oponente)
                    {
                        foreach (var conexiones in jugadores.Keys)
                        {
                            if (jugadores[conexiones].usuario == oponente)
                            {
                                conexiones.InsertarFichaEnTablero(columna);
                            }
                        }
                    }
                    else
                    {
                        foreach (var conexiones in jugadores.Keys)
                        {
                            if (jugadores[conexiones].usuario == partida.jugadores[1].usuario)
                            {
                                conexiones.InsertarFichaEnTablero(columna);
                            }
                        }
                    }
                }
            }
        }
    }
}
