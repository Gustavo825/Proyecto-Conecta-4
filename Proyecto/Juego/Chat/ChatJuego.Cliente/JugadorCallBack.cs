using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;

namespace ChatJuego.Cliente
{
    public class JugadorCallBack : Proxy.IChatServicioCallback, Proxy.IInvitacionCorreoServicioCallback
    {
        private Chat chat;
        private TablaDePuntajes tabla;

        public void actualizarJugadoresConectados(string[] nombresDeJugadores)
        {
            if (chat != null)
            {
                chat.UsuariosConectados.Items.Clear();
                Jugador jugador = chat.getJugador();
                foreach (string nombre in nombresDeJugadores)
                {
                    if (jugador.usuario != nombre)
                        chat.UsuariosConectados.Items.Add(new { UsuarioConectado = nombre });
                }
            }
        }

        public void mostrarPuntajes(Jugador[] jugadores)
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

        public void recibirMensaje(Jugador jugador, Mensaje mensaje, string[] nombresDeJugadores)
        {
            if (chat != null)
            {
                chat.PlantillaMensaje.Items.Add(new { Posicion = "Left", FondoElemento = "White", FondoCabecera = "#7696EC", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
                chat.UsuariosConectados.Items.Clear();
                actualizarJugadoresConectados(nombresDeJugadores);
            }
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