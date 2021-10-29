using ChatJuego.Base_de_datos;
using ChatJuego.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatJuego.Host
{
    class Host
    {
        static void Main(string[] args)
        {
            JugadorContexto jc = new JugadorContexto();
            ServiceHost host = new ServiceHost(typeof(Servicio));
            
            host.Open();
            Console.WriteLine("Servidor corriendo");
            Console.ReadLine();
            host.Close();
        }
    }
}