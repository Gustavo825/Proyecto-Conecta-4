using ChatJuego.Cliente.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatJuego.Cliente.Pruebas.IServidor
{
    [TestClass]
    class TestIServidor
    {
        private static JugadorCallBack callBackDelJugador;
        private static InstanceContext contexto;
        private static ServidorClient servidor;

        [ClassInitialize]
        public static void Inicializar()
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
            servidor = new ServidorClient(contexto);
        }

        [TestMethod]
        public void TestConectarse()
        {
            Console.WriteLine("Hola");
        }
    }
}
