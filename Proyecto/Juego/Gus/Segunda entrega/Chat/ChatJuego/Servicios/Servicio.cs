using ChatJuego.Base_de_datos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Linq;
using ChatJuego.Servicios;
using System.Net.Mail;
using System.Net;

namespace ChatJuego.Host
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Servicio : IChatServicio, IInvitacionCorreoServicio, ITablaDePuntajes, IServidor
    {
        public static Dictionary<IJugadorCallBack, Jugador> jugadores = new Dictionary<IJugadorCallBack, Jugador>();
        private const string correo = "juegocontecta4equipo1@gmail.com";
        private const string SMTPServidor = "smtp.gmail.com";
        private const int puerto = 587;
        private const string contrasenia = "gusandreacarlos1*";
        public bool conectarse(Jugador jugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeAutenticacion estado = autenticacion.iniciarSesion(jugador.usuario, jugador.contrasenia);
            if (estado == EstadoDeAutenticacion.Correcto)
            {
                foreach (var jugadorIniciado in jugadores.Values)
                {
                    if (jugador.usuario == jugadorIniciado.usuario)
                    {
                        MessageBox.Show("Ya hay una sesión de este usuario", "Error", MessageBoxButton.OK);
                        return false;
                    }
                }
                var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
                Console.WriteLine("Jugador Conectado: {0}", jugador.usuario);
                jugadores.Add(conexion, jugador);
                return true;
            } else
            {
            }
            return false;
        }

        public void desconectarse()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IJugadorCallBack>();
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
                conexiones.actualizarJugadoresConectados(nombresDeJugadores);
            }
        }

        

        public EstadoDeEnvio enviarInvitacion(Jugador jugadorInvitado, string codigoPartida, Jugador jugadorInvitador)
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
   

    public void inicializar()
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
                conexiones.actualizarJugadoresConectados(nombresDeJugadores);
            }
        }

        public void mandarMensaje(Mensaje mensaje, Jugador jugadorQueMandaMensaje)
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
                conexiones.recibirMensaje(jugadorQueMandaMensaje, mensaje,nombresDeJugadores);
            }
        }

        public void mandarMensajePrivado(Mensaje mensaje, string nombreJugador, Jugador jugadorQueMandaMensaje)
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
                    conexiones.recibirMensaje(jugadorQueMandaMensaje, mensaje, nombresDeJugadores);
                    break;
                }
            }
        }

        public void recuperarPuntajesDeJugadores()
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
                    jugadoresArreglo[i] = jugador;
                    i++;
                }
                conexion.mostrarPuntajes(jugadoresArreglo);
                
            }
        }

        public EstadoDeRegistro registroJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeRegistro estadoDeRegistro = autenticacion.registro(usuario, contrasenia, correo, imagenDeJugador);
            return estadoDeRegistro;
        }

        public EstadoDeEnvio mandarCodigoDeRegistro(string codigoDeRegistro, string correoDeRegistro)
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
                            Console.WriteLine("Aquí");
                            estado = EstadoDeEnvio.Fallido;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Ups");
                }
            
            return estado;

        }

        public byte[] obtenerBytesDeImagenDeJugador(string usuario)
        {
            using (var contexto = new JugadorContexto())
            {
                var bytesDeImagen = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuario
                                 select jugador.imagenUsuario).ToArray();
                return bytesDeImagen[0];
            }
        }
    }
}
