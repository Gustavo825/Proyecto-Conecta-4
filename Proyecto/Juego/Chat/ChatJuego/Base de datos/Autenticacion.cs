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

        public EstadoDeRegistro registro(string usuarioR, string contraseniaR, string correoR)
        {
            EstadoDeRegistro estado = EstadoDeRegistro.Fallido;
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuarioR
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeRegistro.FallidoPorUsuario;
                    return estado;
                }
                jugadores = (from jugador in contexto.jugadores
                                 where jugador.correo == correoR
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeRegistro.FallidoPorCorreo;
                    return estado;
                }
                var jugadorRegistrado = contexto.jugadores.Add(new Jugador() { usuario = usuarioR, contrasenia = ComputeSHA256Hash(contraseniaR), correo = correoR, puntaje = 0 });
                contexto.SaveChanges();
                estado = EstadoDeRegistro.Correcto;
                return estado;
            }
        }

        public EstadoDeAutenticacion iniciarSesion(string usuario, string contrasenia)
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

        private string ComputeSHA256Hash(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
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
