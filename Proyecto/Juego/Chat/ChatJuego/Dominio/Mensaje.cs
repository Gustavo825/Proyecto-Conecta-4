using System;

namespace ChatJuego.Host
{
    /// <summary>
    /// Guarda toda la información de un mensaje
    /// </summary>
    public class Mensaje
    {
        public DateTime TiempoDeEnvio { get; set; }
        public string UsuarioEmisor { get; set; }
        public string UsuarioReceptor { get; set; }
        public string ContenidoMensaje { get; set; }
    }
}