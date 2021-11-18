using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para EnviarInvitacion.xaml
    /// </summary>
    public partial class EnviarInvitacion : Window
    {
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        SoundPlayer sonidoDeError = new SoundPlayer();
        InvitacionCorreoServicioClient servidorDeCorreo;
        ChatServicioClient servidorDelChat;
        InstanceContext contexto;
        JugadorCallBack jugadorCallBack;
        ServidorClient servidor;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;
        bool perdidaDeConexion = false;
        bool juegoIniciado = false;

        public EnviarInvitacion(Jugador jugador, MenuPrincipal menuPrincipal, InstanceContext contexto, ChatServicioClient servidorDelChat, JugadorCallBack callBackDeJugador, ServidorClient servidor)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            InitializeComponent();
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
            this.contexto = contexto;
            this.servidorDelChat = servidorDelChat;
            this.jugadorCallBack = callBackDeJugador;
            this.servidor = servidor;
        }

        private void BotonDeEnviarInvitacion_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            if (!string.IsNullOrEmpty(TBUsuarioInvitacion.Text))
            {
                if (jugador.usuario != TBUsuarioInvitacion.Text)
                {
                    try
                    {
                        servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                        string codigoDePartida = GenerarCodigoDePartida().ToString();
                        var estado = servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = TBUsuarioInvitacion.Text }, codigoDePartida, jugador);
                        if (estado == EstadoDeEnvio.UsuarioNoEncontrado)
                        {
                            MessageBox.Show("El usuario ingresado no existe", "Usuario no encontrado", MessageBoxButton.OK);
                        }
                        else if (estado == EstadoDeEnvio.Fallido)
                        {
                            MessageBox.Show("Ocurrió un error y no se pudo mandar la invitación", "Error", MessageBoxButton.OK);
                        }
                        else
                        {

                            MessageBox.Show("Invitación enviada", "Correcto", MessageBoxButton.OK);
                            VentanaDeJuego ventanaDeJuego = new VentanaDeJuego(contexto, menuPrincipal, jugador, servidorDelChat, codigoDePartida, jugadorCallBack, servidor);
                            ventanaDeJuego.Show();
                            ventanaDeJuego.turnoDeJuego = true;
                            jugadorCallBack.SetVentanaDeJuego(ventanaDeJuego);
                            juegoIniciado = true;
                            this.Close();
                        }
                    }
                    catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                    {
                        MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        perdidaDeConexion = true;
                        menuPrincipal.Close();
                        this.Close();
                    }
                } else
                {
                    MessageBox.Show("No te puedes invitar a ti mismo", "Usuario inválido", MessageBoxButton.OK);
                }
            } else
            {
                sonidoDeError.Play();
                MessageBox.Show("Ingrese la información requerida","Campos vacíos",MessageBoxButton.OK);
            }
        }

        public static int GenerarCodigoDePartida()
        {
            return new Random().Next(1000, 3000);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if (!perdidaDeConexion && !juegoIniciado)
                menuPrincipal.Show();   
        }
    }
}
