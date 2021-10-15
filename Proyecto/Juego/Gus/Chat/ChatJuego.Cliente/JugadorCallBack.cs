using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;

namespace ChatJuego.Cliente
{
    public class JugadorCallBack : Proxy.IChatServicioCallback
    {
        private Chat chat;
        private TablaDePuntajes tabla;

        public void actualizarJugadoresConectados(string[] nombresDeJugadores)
        {
            chat.UsuariosConectados.Items.Clear();
            foreach (string nombre in nombresDeJugadores)
                chat.UsuariosConectados.Items.Add(new { UsuarioConectado = nombre });
        }

        public void mostrarPuntajes(Jugador[] jugadores)
        {
            int i = 1;
            foreach (Jugador jugador in jugadores) {
                tabla.PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = i.ToString(), NombreJugador = jugador.usuario, Puntaje = jugador.puntaje });
                i++;
            }
        }

        public void recibirMensaje(Jugador jugador, Mensaje mensaje, string[] nombresDeJugadores)
        {
            chat.PantallaDeMensajes.Items.Add(new { FondoElemento = "White", FondoCabecera = "Salmon", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
            chat.UsuariosConectados.Items.Clear();
            actualizarJugadoresConectados(nombresDeJugadores);
        }


        public void setTablaDePuntajes(TablaDePuntajes tabla)
        {
            this.tabla = tabla;
        }


     

        public void setChat(Chat chat)
        {
            this.chat = chat;
        }
    }
}