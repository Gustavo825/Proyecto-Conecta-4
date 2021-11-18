using ChatJuego.Base_de_datos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
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
        private const string correo = "juegocontecta4equipo1@gmail.com";
        private const string SMTPServidor = "smtp.gmail.com";
        private const int puerto = 587;
        private const string contrasenia = "gusandreacarlos1*";
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
                //int i = 0;
                //foreach (Jugador nombre in jugadores.Values)
                //{
                  //  nombresDeJugadores[i] = nombre.usuario;
                   // i++;
                //}
                //foreach (var conexiones in jugadores.Keys)
                //{
                //conexion.ActualizarJugadoresConectados(null);
                ////}
                return EstadoDeInicioDeSesion.Correcto;
            } else
                return EstadoDeInicioDeSesion.Fallido;
        }

        public void Desconectarse()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
            Console.WriteLine("Jugador desconectado: {0}",jugadores[conexion].usuario);
            jugadores.Remove(conexion);
            string[] nombresDeJugadores = new string[jugadores.Count()];
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

        

        public EstadoDeEnvio EnviarInvitacion(Jugador jugadorInvitado, string codigoPartida, Jugador jugadorInvitador)
        {
            EstadoDeEnvio estado = EstadoDeEnvio.Fallido;
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == jugadorInvitado.usuario
                                 select jugador).Count();
                if (jugadores == 0)
                {
                    estado = EstadoDeEnvio.UsuarioNoEncontrado;
                    return estado;
                }
                jugadorInvitado.correo = (from jugador in contexto.jugadores
                                           where jugador.usuario == jugadorInvitado.usuario
                                           select jugador.correo).Single();
                try
                {
                    SmtpClient smtpCliente = new SmtpClient(SMTPServidor, puerto);
                    smtpCliente.EnableSsl = true;
                    smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpCliente.UseDefaultCredentials = false;
                    smtpCliente.Credentials = new NetworkCredential(correo, contrasenia);
                    string jugadorQueInvita = "";
                    jugadorQueInvita = jugadorInvitador.usuario;
                    using (MailMessage mensaje = new MailMessage())
                    {
                        mensaje.From = new MailAddress(correo);
                        mensaje.Subject = "Invitación de " + jugadorQueInvita;
                        mensaje.Body = "El código para unirse a la partida es: " + codigoPartida;
                        mensaje.IsBodyHtml = false;
                        mensaje.To.Add(jugadorInvitado.correo);
                        try
                        {
                            smtpCliente.Send(mensaje);
                            estado = EstadoDeEnvio.Correcto;
                            partidas.Add(new Partida(codigoPartida,jugadorInvitador));
                        }
                        catch
                        {
                            Console.WriteLine("Aquí");
                            estado = EstadoDeEnvio.Fallido;
                        }
                    }
                } catch
                {
                    Console.WriteLine("Ups");
                }
            }
            return estado;

        }
   

    public void InicializarChat()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
            string[] nombresDeJugadores = new string[jugadores.Count()];
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

        public void MandarMensaje(Mensaje mensaje, Jugador jugadorQueMandaMensaje)
        {
            Console.WriteLine("{0}:{1}", jugadorQueMandaMensaje.usuario, mensaje.ContenidoMensaje);
            string[] nombresDeJugadores = new string[jugadores.Count()];
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
                conexiones.RecibirMensaje(jugadorQueMandaMensaje, mensaje,nombresDeJugadores);
            }
        }

        public void MandarMensajePrivado(Mensaje mensaje, string nombreJugador, Jugador jugadorQueMandaMensaje)
        {
            Console.WriteLine("{0}:{1}", jugadorQueMandaMensaje.usuario, mensaje.ContenidoMensaje);
            string[] nombresDeJugadores = new string[jugadores.Count()];
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

        public EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeRegistro estadoDeRegistro = autenticacion.Registro(usuario, contrasenia, correo, imagenDeJugador);
            return estadoDeRegistro;
        }

        public EstadoDeEnvio MandarCodigoDeRegistro(string codigoDeRegistro, string correoDeRegistro)
        {
            EstadoDeEnvio estado = EstadoDeEnvio.Fallido;
            
                try
                {
                    SmtpClient smtpCliente = new SmtpClient(SMTPServidor, puerto);
                    smtpCliente.EnableSsl = true;
                    smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpCliente.UseDefaultCredentials = false;
                    smtpCliente.Credentials = new NetworkCredential(correo, contrasenia);
                    using (MailMessage mensaje = new MailMessage())
                    {
                        mensaje.From = new MailAddress(correo);
                        mensaje.Subject = "Confirmación de registro de jugador";
                        mensaje.Body = "Ingrese el siguiente código para validar su registro: " + codigoDeRegistro;
                        mensaje.IsBodyHtml = false;
                        mensaje.To.Add(correoDeRegistro);
                          Console.WriteLine(correoDeRegistro);
                        try
                        {
                            smtpCliente.Send(mensaje);
                            estado = EstadoDeEnvio.Correcto;
                        }
                        catch
                        {
                            Console.WriteLine("No se mandó el correo");
                            estado = EstadoDeEnvio.Fallido;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("No se pudo crear el cliente SMTP ");
                }
            
            return estado;

        }

        public byte[] ObtenerBytesDeImagenDeJugador(string usuario)
        {
            using (var contexto = new JugadorContexto())
            {
                var bytesDeImagen = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuario
                                 select jugador.imagenUsuario).ToArray();
                if (bytesDeImagen.Length > 0)
                    return bytesDeImagen[0];
                else
                    return null;
            }
        }

        public EstadoDeEliminacion EliminarJugador(Jugador jugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            return autenticacion.EliminarJugador(jugador.usuario, jugador.contrasenia);
        }

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
                    } else {
                        partida.jugadores[1] = jugador;
                        break;
                    }
                }
            }
            if (!encontroPartida)
                return EstadoUnirseAPartida.FallidoPorPartidaNoEncontrada;
            return EstadoUnirseAPartida.Correcto;
        }

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
                    } else if (partida.jugadores[1] != null && usuarioQueFinaliza == partida.jugadores[1].usuario  )
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
                        contexto.SaveChanges();
                    }
                    return EstadoAgregarPuntuacion.Correcto;
                }
            }
            return EstadoAgregarPuntuacion.Fallido;
        }

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
                    } else
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
