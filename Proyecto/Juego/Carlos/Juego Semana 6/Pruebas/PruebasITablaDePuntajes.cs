using ChatJuego.Cliente;
using ChatJuego.Cliente.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

namespace Pruebas
{
    [TestClass]
    public class PruebasITablasDePuntaje
    {
        private static JugadorCallBack callBackDelJugador;
        private static InstanceContext contexto;
        private static TablaDePuntajesClient servidorDeTablaDePuntajes;
        private static ServidorClient servidor;


        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
        }

        [TestMethod]
        public void TestRecuperarPuntajesDeJugadores()
        {
            servidor = new ServidorClient(contexto);
            servidorDeTablaDePuntajes = new TablaDePuntajesClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorDeTablaDePuntajes.RecuperarPuntajesDeJugadores();
            servidor.Desconectarse();
        }

    }
}
