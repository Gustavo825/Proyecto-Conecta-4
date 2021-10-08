using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;

namespace ChatJuego.Cliente
{
    public class JugadorCallBack : Proxy.IChatServicioCallback
    {
        private Chat chat;

        public void actualizarJugadoresConectados(string[] nombresDeJugadores)
        {
            chat.UsuariosConectados.Items.Clear();
            foreach (string nombre in nombresDeJugadores)
                chat.UsuariosConectados.Items.Add(new { UsuarioConectado = nombre });
        }

       

        public void recibirMensaje(Jugador jugador, Mensaje mensaje, string[] nombresDeJugadores)
        {
            chat.PantallaDeMensajes.Items.Add(new { FondoElemento = "White", FondoCabecera = "Salmon", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
            chat.UsuariosConectados.Items.Clear();
            actualizarJugadoresConectados(nombresDeJugadores);
        }



     

        public void setChat(Chat chat)
        {
            this.chat = chat;
        }
    }
}