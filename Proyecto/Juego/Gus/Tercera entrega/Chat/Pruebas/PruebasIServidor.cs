using ChatJuego.Cliente;
using ChatJuego.Cliente.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

namespace Pruebas
{
    [TestClass]
    public class PruebasIServidor
    {
        private static JugadorCallBack callBackDelJugador;
        private static InstanceContext contexto;
        private static ServidorClient servidor;

        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
            servidor = new ServidorClient(contexto);
        }

        [TestMethod]
        public void TestConectarseCorrecto()
        {
           Assert.AreEqual(EstadoDeInicioDeSesion.Correcto,servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" }));
            servidor.Desconectarse();

        }

        [TestMethod]
        public void TestConectarseIncorrecto()
        {
            Assert.AreEqual(EstadoDeInicioDeSesion.Fallido, servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "6124" }));
        }

        [TestMethod]
        public void TestConectarseJugadorYaConectado()
        {
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            Assert.AreEqual(EstadoDeInicioDeSesion.FallidoPorUsuarioYaConectado, servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" }));
            servidor.Desconectarse();
        }

        [TestMethod]
        public void TestRegistrarJugadorCorrecto()
        {
            EstadoDeRegistro resultado = servidor.RegistroDeJugador("UsuarioDePrueba", "12345", "correo@gmail.com", new byte[2]);
            if (resultado == EstadoDeRegistro.Correcto)
                servidor.EliminarJugador(new Jugador() { usuario = "UsuarioDePrueba", contrasenia = "12345" });
            Assert.AreEqual(EstadoDeRegistro.Correcto, resultado);
        }

        [TestMethod]
        public void TestRegistrarJugadorIncorrectoPorCorreo()
        {
            Assert.AreEqual(EstadoDeRegistro.FallidoPorCorreo, servidor.RegistroDeJugador("UsuarioDePrueba", "12345", "gusttavo_floress@hotmail.com", new byte[2]));

        }

        [TestMethod]
        public void TestRegistrarJugadorIncorrectoPorUsuario()
        {
            Assert.AreEqual(EstadoDeRegistro.FallidoPorUsuario, servidor.RegistroDeJugador("Gustavo825", "12345", "correo@hotmail.com", new byte[2]));

        }

        [TestMethod]
        public void TestEliminarJugadorCorrecto()
        {
            EstadoDeRegistro resultado = servidor.RegistroDeJugador("UsuarioDePrueba", "12345", "correo@gmail.com", new byte[2]);
            if (resultado == EstadoDeRegistro.Correcto) {
                EstadoDeEliminacion estado = servidor.EliminarJugador(new Jugador() { usuario = "UsuarioDePrueba", contrasenia = "12345" });
                Assert.AreEqual(EstadoDeEliminacion.Correcto, estado);
            }
            else
                Assert.Fail();
        }

        [TestMethod]
        public void TestEliminarJugadorIncorrecto()
        {
            Assert.AreEqual(EstadoDeEliminacion.Fallido, servidor.EliminarJugador(new Jugador() { usuario = "UsuarioInexistente", contrasenia = "12345" }));
        }

        [TestMethod]
        public void TestObtenerBytesDeImagenDeJugador()
        {
           Assert.IsNotNull(servidor.ObtenerBytesDeImagenDeJugador("WastyFace").Length);            
        }
        
        [TestMethod]
        public void TestObtenerBytesDeImagenDeJugadorNulo()
        {
            Assert.AreEqual(null,servidor.ObtenerBytesDeImagenDeJugador("JugadorNoExistente"));
        }
    }
}
