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
        public void TestUnirseAPartidaCorrecto()
        {
            InvitacionCorreoServicioClient servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
            servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "WastyFace" }, "1111", new Jugador() { usuario = "Prueba" });
            Assert.AreEqual(EstadoUnirseAPartida.Correcto, servidor.UnirseAPartida(new Jugador() { usuario = "Prueba" }, "1111"));
            servidor.EliminarPartida("1111", "Prueba", EstadoPartida.FinDePartidaGanada);
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
           Assert.IsNotNull(servidor.ObtenerBytesDeImagenDeJugador("Gustavo825").Length);            
        }
        
        [TestMethod]
        public void TestObtenerBytesDeImagenDeJugadorNulo()
        {
            Assert.AreEqual(null,servidor.ObtenerBytesDeImagenDeJugador("JugadorNoExistente"));
        }

        [TestMethod]
        public void TestDesconectarse()
        {
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            servidor.Desconectarse();
            Assert.IsTrue(true);
        }



        [TestMethod]
        public void TestUnirseAPartidaNoEncontrada()
        {
            InvitacionCorreoServicioClient servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
            servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "Gustavo825" }, "0000", new Jugador() { usuario = "Prueba" });
            Assert.AreEqual(EstadoUnirseAPartida.FallidoPorPartidaNoEncontrada, servidor.UnirseAPartida(new Jugador() { usuario = "Prueba" }, "1111"));
            servidor.EliminarPartida("0000", "Prueba", EstadoPartida.FinDePartidaGanada);

        }

        [TestMethod]
        public void TestUnirseAPartidaNoPosiblePorNumeroDeJugadores()
        {
            InvitacionCorreoServicioClient servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
            servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "Gustavo825" }, "0000", new Jugador() { usuario = "Prueba" });
            servidor.UnirseAPartida(new Jugador() { usuario = "Prueba" }, "0000");
            Assert.AreEqual(EstadoUnirseAPartida.FallidoPorMaximoDeJugadores, servidor.UnirseAPartida(new Jugador() { usuario = "Prueba2" }, "0000"));
            servidor.EliminarPartida("0000", "Prueba", EstadoPartida.FinDePartidaGanada);

        }

        [TestMethod]
        public void TestInicializarPartida()
        {
            servidor.InicializarPartida("0000");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestEliminarPartida()
        {
            InvitacionCorreoServicioClient servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
            servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "Gustavo825" }, "0000", new Jugador() { usuario = "Prueba" });
            servidor.EliminarPartida("0000", "Gustavo825", EstadoPartida.FinDePartidaPorEmpate);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestEliminarPartidaConGanador()
        {
            InvitacionCorreoServicioClient servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
            servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "Gustavo825" }, "0000", new Jugador() { usuario = "Prueba" });
            servidor.EliminarPartidaConGanador("0000", "Gustavo825", EstadoPartida.FinDePartidaGanada,1,"Gustavo825");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestAgregarPuntajeCorrecto()
        {
            servidor.Conectarse(new Jugador() { usuario = "Gustavo825", contrasenia = "61245" });
            Assert.AreEqual(EstadoAgregarPuntuacion.Correcto,servidor.AgregarPuntajeAJugador("Gustavo825", 1));
            servidor.Desconectarse();
        }

        [TestMethod]
        public void TestAgregarPuntajeFallido()
        {
            Assert.AreEqual(EstadoAgregarPuntuacion.Fallido, servidor.AgregarPuntajeAJugador("Gustavo825", 1));

        }

        [TestMethod]
        public void TestInsertarFichaEnOponente()
        {
            InvitacionCorreoServicioClient servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
            servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "Gustavo825" }, "0000", new Jugador() { usuario = "Prueba" });
            servidor.UnirseAPartida(new Jugador() { usuario = "Prueba" }, "0000");
            servidor.InsertarFichaEnOponente(1, "0000", "Prueba");
        }

    }
}
