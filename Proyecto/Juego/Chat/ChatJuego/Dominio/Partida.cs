﻿using ChatJuego.Base_de_datos;

namespace ChatJuego.Dominio
{
    public class Partida
    {
        public string codigoDePartida { get; set; }
        public Jugador[] jugadores = new Jugador[2];


        public Partida(string codigoPartida, Jugador jugadorInvitador)
        {
            this.codigoDePartida = codigoPartida;
            this.jugadores[0] = jugadorInvitador;
        }
    }
}
