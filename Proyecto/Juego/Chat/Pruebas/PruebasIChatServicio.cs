using ChatJuego.Cliente;
using ChatJuego.Cliente.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

namespace Pruebas
{
    [TestClass]
    public class PruebasIChatServicio
    {
        private static JugadorCallBack callBackDelJugador;
        private static InstanceContext contexto;
        private static ChatServicioClient servidorDelChat;
        private static ServidorClient servidor;

        
        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
        }

        [TestMethod]
        public void TestInicializarChat()
        {
            servidor = new ServidorClient(contexto);
            servidorDelChat = new ChatServicioClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorDelChat.InicializarChat();
            servidor.Desconectarse();
        }

        [TestMethod]
        public void TestMandarMensaje()
        {
            servidor = new ServidorClient(contexto);
            servidorDelChat = new ChatServicioClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorDelChat.MandarMensaje(new Mensaje() { ContenidoMensaje = "Hola", TiempoDeEnvio = System.DateTime.Now, UsuarioEmisor = "JugadorFalso", UsuarioReceptor = "JugadorFalso" }, new Jugador() { usuario = "JugadorFalso" });
            servidor.Desconectarse();
        }

        [TestMethod]
        public void TestMandarMensajePrivado()
        {
            servidor = new ServidorClient(contexto);
            servidorDelChat = new ChatServicioClient(contexto);
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = "Hola", TiempoDeEnvio = System.DateTime.Now, UsuarioEmisor = "JugadorFalso", UsuarioReceptor = "JugadorFalso" }, "Gustavo825" ,new Jugador() { usuario = "JugadorFalso" });
            servidor.Desconectarse();
        }
    }
}
