using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;

namespace ChatJuego.Cliente
{
    public class JugadorCallBack : IChatServicioCallback, IInvitacionCorreoServicioCallback, IServidorCallback, ITablaDePuntajesCallback
    {
        private Chat chat;
        private VentanaDeJuego ventanaDeJuego;
        private TablaDePuntajes tabla;

        /// <summary>
        /// Método que actualiza los jugadores conectados.
        /// </summary>
        /// <param name="nombresDeJugadores">Arreglo que contiene los nombres de los jugadores conectados</param>
        public virtual void ActualizarJugadoresConectados(string[] nombresDeJugadores)
        {
            if (chat != null)
            {
                if (chat.UsuariosConectados != null)
                    chat.UsuariosConectados.Items.Clear();
                Jugador jugador = chat.GetJugador();
                foreach (string nombre in nombresDeJugadores)
                {
                    if (jugador.usuario != nombre)
                        chat.UsuariosConectados.Items.Add(new { UsuarioConectado = nombre });
                }
            }
        }

        /// <summary>
        /// Método que muestra los puntajes de los jugadores.
        /// </summary>
        /// <param name="jugadores">Arreglo que contiene los Jugadores con sus puntuaciones.</param>
        public virtual void MostrarPuntajes(Jugador[] jugadores)
        {
            if (tabla != null)
            {
                int i = 1;
                foreach (Jugador jugador in jugadores)
                {
                    tabla.PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = i.ToString(), NombreJugador = jugador.usuario, Puntaje = jugador.puntaje });
                    i++;
                }
            }
        }

        /// <summary>
        /// Método que recibe el mensaje para mostrarlo en la ventana del Chat.
        /// </summary>
        /// <param name="jugador">Jugador que envía el mensaje.</param>
        /// <param name="mensaje">Contiene el mensaje y su información.</param>
        /// <param name="nombresDeJugadores">Arreglo que contiene los jugadores conectados.</param>
        public virtual void RecibirMensaje(Jugador jugador, Mensaje mensaje, string[] nombresDeJugadores)
        {
            if (chat != null)
            {
                chat.PlantillaMensaje.Items.Add(new { Posicion = "Left", FondoElemento = "White", FondoCabecera = "#7696EC", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
                chat.UsuariosConectados.Items.Clear();
                ActualizarJugadoresConectados(nombresDeJugadores);
            }
        }

        /// <summary>
        /// Asigna la tabla de puntajes al CallBack.
        /// </summary>
        /// <param name="tabla">Instancia de la tabla de puntajes.</param>
        public void SetTablaDePuntajes(TablaDePuntajes tabla)
        {
            this.tabla = tabla;
        }

        /// <summary>
        /// Asigna el chat al CallBack.
        /// </summary>
        /// <param name="chat">Instancia del chat.</param>
        public void SetChat(Chat chat)
        {
            this.chat = chat;
        }

        /// <summary>
        /// Asigna la ventana del juego al CallBack.
        /// </summary>
        /// <param name="ventanaDeJuego">Instancia de la ventana de juego.</param>
        public void SetVentanaDeJuego(VentanaDeJuego ventanaDeJuego)
        {
            this.ventanaDeJuego = ventanaDeJuego;
        }

        /// <summary>
        /// Método que inica la partida solo si ya se asignó una ventana de juego.
        /// </summary>
        /// <param name="nombreOponente">Nombre del oponente.</param>
        public void IniciarPartida(string nombreOponente)
        {
            if (ventanaDeJuego != null)
            {
                ventanaDeJuego.oponente = nombreOponente;
                ventanaDeJuego.oponenteConectado = true;
            }
        }

        /// <summary>
        /// Método que desconecta de la partida y la finaliza.
        /// Manda el estado de la partida para saber cómo finalizó.
        /// </summary>
        /// <param name="estadoPartida">Estado de la partida, ya sea ganada, empate, etc.</param>
        public void DesconectarDePartida(EstadoPartida estadoPartida)
        {
            if (ventanaDeJuego != null)
                ventanaDeJuego.Desconectarse(estadoPartida);
        }

        /// <summary>
        /// Método que inserta la ficha del oponente en el tablero, solo si existe ya una instancia de la ventana de juego.
        /// </summary>
        /// <param name="columna">Entero que contiene la columna donde tiró el oponente.</param>
        public void InsertarFichaEnTablero(int columna)
        {
            if (ventanaDeJuego != null)
            {
                ventanaDeJuego.IntroducirFicha(columna, VentanaDeJuego.TIROOPONENTE);
                ventanaDeJuego.turnoDeJuego = true;
            }
        }
    }
}