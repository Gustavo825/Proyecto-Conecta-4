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

        public EstadoDeAutenticacion iniciarSesion(string usuario, string contrasenia)
        {
            EstadoDeAutenticacion estado = EstadoDeAutenticacion.Failed;
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuario && jugador.contrasenia == contrasenia
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
}
