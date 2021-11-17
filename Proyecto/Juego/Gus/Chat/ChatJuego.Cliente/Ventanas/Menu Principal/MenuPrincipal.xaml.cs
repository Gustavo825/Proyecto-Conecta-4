using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Unirse_a_Partida;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace ChatJuego.Cliente
{
    public partial class MenuPrincipal : Window
    {
        MediaPlayer musicaDeMenu = new MediaPlayer();
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        ServidorClient servidor;
        ChatServicioClient servidorDelChat = null;
        TablaDePuntajesClient servidorDeTablaDePuntajes;
        InstanceContext contexto;
        JugadorCallBack callBackDeJugador;
        Jugador jugador;
        bool desconexionDelServidor = false;


        public MenuPrincipal(ServidorClient servidor, JugadorCallBack callBackDeJugador, Jugador jugador, InstanceContext contexto)
        {
            string ruta = Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaDeMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDePartida.wav"));
            musicaDeMenu.Play();
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            this.callBackDeJugador = callBackDeJugador;
            this.servidor = servidor;
            this.jugador = jugador;
            this.contexto = contexto;
            servidorDelChat = new ChatServicioClient(contexto);
            servidorDeTablaDePuntajes = new TablaDePuntajesClient(contexto);
            InitializeComponent();
            //ImagenJugador.Source = ConvertirArrayAImagen(jugador.imagenUsuario);
        }
        
        private void BotonTablaDePuntajes_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            TablaDePuntajes tablaPuntajes = new TablaDePuntajes(servidorDeTablaDePuntajes);
            callBackDeJugador.SetTablaDePuntajes(tablaPuntajes);
            tablaPuntajes.Show();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            Chat chat = new Chat(jugador, servidorDelChat);
            try
            {
                servidorDelChat = new ChatServicioClient(contexto);
                servidorDelChat.InicializarChat();
                callBackDeJugador.SetChat(chat);
                chat.Show();
            } catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                desconexionDelServidor = true;
                this.Close();
            }
        }

        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            musicaDeMenu.Stop();
            servidorDelChat = new ChatServicioClient(contexto);
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(jugador, this, contexto, servidorDelChat,callBackDeJugador, servidor);
            enviarInvitacion.Show();
            this.Hide();
        }

        private void BotonUnirse_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            musicaDeMenu.Stop();
            servidorDelChat = new ChatServicioClient(contexto);
            UnirseAPartida unirseAPartida = new UnirseAPartida(jugador, this, contexto, servidorDelChat, callBackDeJugador, servidor);
            unirseAPartida.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sonidoDeBoton.Play();
            musicaDeMenu.Stop();
            MainWindow mainWindow = new MainWindow();
            try
            {
                if (desconexionDelServidor == false)
                {
                    servidor.Desconectarse();
                }
                mainWindow.Show();
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                mainWindow.Show();
            }

        }
    }
}
