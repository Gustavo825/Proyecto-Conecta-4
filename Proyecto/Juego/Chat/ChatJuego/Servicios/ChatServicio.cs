using ChatJuego.Base_de_datos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Linq;


namespace ChatJuego.Host
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ChatServicio : IChatServicio
    {
        Dictionary<IChatJugadorCallBack, Jugador> jugadores = new Dictionary<IChatJugadorCallBack, Jugador>();
        public bool conectarse(Jugador jugador)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeAutenticacion estado = autenticacion.iniciarSesion(jugador.usuario, jugador.contrasenia);
            if (estado == EstadoDeAutenticacion.Correcto)
            {
                var conexion = OperationContext.Current.GetCallbackChannel<IChatJugadorCallBack>();
                Console.WriteLine("Jugador Conectado: {0}", jugador.usuario);
                jugadores[conexion] = jugador;
                return true;
            }
            return false;
        }

        public void desconectarse()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IChatJugadorCallBack>();
            jugadores.Remove(conexion);
            string[] nombresDeJugadores = new string[100];
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

        public void inicializar()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IChatJugadorCallBack>();
            string[] nombresDeJugadores = new string[100];
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

        public void mandarMensaje(Mensaje mensaje)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IChatJugadorCallBack>();
            Jugador jugador;
            if (!jugadores.TryGetValue(conexion, out jugador))
                return;
            Console.WriteLine("{0}:{1}", jugador.usuario, mensaje.ContenidoMensaje);
            string[] nombresDeJugadores = new string[100];
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
                conexiones.recibirMensaje(jugador, mensaje,nombresDeJugadores);
            }
        }

        public void mandarMensajePrivado(Mensaje mensaje, string nombreJugador)
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IChatJugadorCallBack>();
            Jugador jugador;
            if (!jugadores.TryGetValue(conexion, out jugador))
                return;
            Console.WriteLine("{0}:{1}", jugador.usuario, mensaje.ContenidoMensaje);
            string[] nombresDeJugadores = new string[100];
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
                if (jugadores[conexiones].usuario == nombreJugador)
                {
                    conexion.recibirMensaje(jugador, mensaje, nombresDeJugadores);
                    conexiones.recibirMensaje(jugador, mensaje, nombresDeJugadores);
                    break;
                }
            }
        }

        public void recuperarPuntajesDeJugadores()
        {
            var conexion = OperationContext.Current.GetCallbackChannel<IChatJugadorCallBack>();
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

        public EstadoDeRegistro registroJugador(string usuario, string contrasenia, string correo)
        {
            Autenticacion autenticacion = new Autenticacion();
            EstadoDeRegistro estadoDeRegistro = autenticacion.registro(usuario, contrasenia, correo);
            return estadoDeRegistro;
        }


    }
}
