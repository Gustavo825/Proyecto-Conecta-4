using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatJuego.Base_de_datos
{
    public class Autenticacion
    {

        public Autenticacion ()
        {
        }

        public EstadoDeRegistro Registro(string usuarioARegistrar, string contraseniaARegistrar, string correoARegistrar, byte[] imagenDeJugador)
        {
            EstadoDeRegistro estado = EstadoDeRegistro.Fallido;
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuarioARegistrar
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeRegistro.FallidoPorUsuario;
                    return estado;
                }
                jugadores = (from jugador in contexto.jugadores
                                 where jugador.correo == correoARegistrar
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeRegistro.FallidoPorCorreo;
                    return estado;
                }
                var jugadorRegistrado = contexto.jugadores.Add(new Jugador() { usuario = usuarioARegistrar, contrasenia = ComputeSHA256Hash(contraseniaARegistrar), correo = correoARegistrar, puntaje = 0 , imagenUsuario = imagenDeJugador });
                contexto.SaveChanges();
                estado = EstadoDeRegistro.Correcto;
                return estado;
            }
        }

        public EstadoDeAutenticacion IniciarSesion(string usuario, string contrasenia)
        {
            EstadoDeAutenticacion estado = EstadoDeAutenticacion.Failed;
            string contraseniaCifrada = ComputeSHA256Hash(contrasenia);
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuario && jugador.contrasenia == contraseniaCifrada
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeAutenticacion.Correcto;
                }
            }
            return estado;
        }

        private string ComputeSHA256Hash(string contrasenia)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public enum EstadoDeAutenticacion
    {
        Correcto = 0,
        Failed
    }

    public enum EstadoDeRegistro 
    { 
        Correcto = 0,
        FallidoPorCorreo,
        FallidoPorUsuario,
        Fallido
    }

}
