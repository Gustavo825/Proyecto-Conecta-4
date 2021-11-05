using ChatJuego.Cliente;
using ChatJuego.Cliente.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ServiceModel;
using System.Threading;

namespace Pruebas
{
    [TestClass]
    public class PruebasJugadorCallback
    {
        private static InstanceContext contexto;
        private static ChatServicioClient servidorDelChat;
        private static TablaDePuntajesClient servidorTablaDePuntajes;
        private static ServidorClient servidor;


        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
        }

        [TestMethod]
        public void TestRecibirMensaje()
        {
            Mock<JugadorCallBack> mockCallback = new Mock<JugadorCallBack>() { CallBase = true };
            contexto = new InstanceContext(mockCallback.Object);
            servidor = new ServidorClient(contexto);
            servidorDelChat = new ChatServicioClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorDelChat.MandarMensaje(new Mensaje() { ContenidoMensaje = "Hola", TiempoDeEnvio = System.DateTime.Now, UsuarioEmisor = "JugadorFalso", UsuarioReceptor = "JugadorFalso" },new Jugador() { usuario = "JugadorFalso" });
            Thread.Sleep(2000);
            mockCallback.Verify(mock => mock.RecibirMensaje(It.IsAny<Jugador>(),It.IsAny<Mensaje>(),It.IsAny<string[]>()),Times.AtLeastOnce());
            servidor.Desconectarse();
        }

        [TestMethod]
        public void TestActualizarJugadoresConectados()
        {
            Mock<JugadorCallBack> mockCallback = new Mock<JugadorCallBack>() { CallBase = true };
            contexto = new InstanceContext(mockCallback.Object);
            servidor = new ServidorClient(contexto);
            servidorDelChat = new ChatServicioClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorDelChat.InicializarChat();
            Thread.Sleep(2000);
            mockCallback.Verify(mock => mock.ActualizarJugadoresConectados(It.IsAny<string[]>()), Times.AtLeastOnce());
            servidor.Desconectarse();
        }

        [TestMethod]
        public void TestMostrarPuntajes()
        {
            Mock<JugadorCallBack> mockCallback = new Mock<JugadorCallBack>() { CallBase = true };
            contexto = new InstanceContext(mockCallback.Object);
            servidor = new ServidorClient(contexto);
            servidorTablaDePuntajes = new TablaDePuntajesClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorTablaDePuntajes.RecuperarPuntajesDeJugadores();
            Thread.Sleep(2000);
            mockCallback.Verify(mock => mock.MostrarPuntajes(It.IsAny<Jugador[]>()), Times.AtLeastOnce());
            servidor.Desconectarse();
        }
    }
}
