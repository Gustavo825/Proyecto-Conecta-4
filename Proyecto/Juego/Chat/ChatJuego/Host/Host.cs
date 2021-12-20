using ChatJuego.Base_de_datos;
using System;
using System.ServiceModel;

namespace ChatJuego.Host
{
    public static class Host
    {
        /// <summary>
        /// Permite la ejecución del servidor, inicializando el Servicio.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Servicio));
            host.Open();
            Console.WriteLine("Servidor corriendo");
            Console.ReadLine();
            host.Close();
        }
    }
}