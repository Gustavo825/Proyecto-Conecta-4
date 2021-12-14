using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Configuracion;
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
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    public partial class MenuPrincipal : Window
    {
        private static MediaPlayer musicaDeMenu = new MediaPlayer();
        private static SoundPlayer sonidoDeBoton = new SoundPlayer();
        ServidorClient servidor;
        ChatServicioClient servidorDelChat = null;
        TablaDePuntajesClient servidorDeTablaDePuntajes;
        InstanceContext contexto;
        JugadorCallBack callBackDeJugador;
        Jugador jugador;
        bool desconexionDelServidor = false;
        const int MUSICAENCENDIDA = 1;
        const int EFECTOSENCENDIDO = 1;
        private static int estadoMusica = MUSICAENCENDIDA;
        private static int estadoSFX = EFECTOSENCENDIDO;

        public static MediaPlayer MusicaDeMenu { get => musicaDeMenu; set => musicaDeMenu = value; }
        public static SoundPlayer SonidoDeBoton { get => sonidoDeBoton; set => sonidoDeBoton = value; }
        public static int EstadoMusica { get => estadoMusica; set => estadoMusica = value; }
        public static int EstadoSFX { get => estadoSFX; set => estadoSFX = value; }


        public MenuPrincipal(ServidorClient servidor, JugadorCallBack callBackDeJugador, Jugador jugador, InstanceContext contexto)
        {
            string ruta = Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaDeMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDePartida.wav"));
            MusicaDeMenu.MediaEnded += new EventHandler(Media_Ended);
            if (EstadoMusica == MUSICAENCENDIDA)
            {
                musicaDeMenu.Play();
            }
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            this.callBackDeJugador = callBackDeJugador;
            this.servidor = servidor;
            this.jugador = jugador;
            this.contexto = contexto;
            servidorDelChat = new ChatServicioClient(contexto);
            servidorDeTablaDePuntajes = new TablaDePuntajesClient(contexto);
            InitializeComponent();
            ActualizarIdiomaDeVentana();
            //ImagenJugador.Source = ConvertirArrayAImagen(jugador.imagenUsuario);
        }

        private void BotonTablaDePuntajes_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            musicaDeMenu.Stop();
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
            reproducirBoton();
            Chat chat = new Chat(jugador, servidorDelChat);
            try
            {
                servidorDelChat = new ChatServicioClient(contexto);
                servidorDelChat.InicializarChat();
                callBackDeJugador.SetChat(chat);
                chat.Show();
            } catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("The connection with the server was lost", "Conenction lost", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Le server ne peut connecter", "Échec de connexion", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Erro ao se conectar ao servidor", "Falha da conexão", MessageBoxButton.OK);
                }
                musicaDeMenu.Stop(); desconexionDelServidor = true;
                this.Close();
            }
        }

        private void BotonConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            Configuracion configuracion = new Configuracion(this);
            configuracion.Show();
        }

        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            servidorDelChat = new ChatServicioClient(contexto);
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(jugador, this, contexto, servidorDelChat,callBackDeJugador, servidor);
            enviarInvitacion.Show();
            this.Hide();
        }

        private void BotonUnirse_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            musicaDeMenu.Stop();
            servidorDelChat = new ChatServicioClient(contexto);
            UnirseAPartida unirseAPartida = new UnirseAPartida(jugador, this, contexto, servidorDelChat, callBackDeJugador, servidor);
            unirseAPartida.Show();
            this.Hide();
        }

        public void ActualizarIdiomaDeVentana()
        {
            if (idioma == Idioma.Frances)
            {
                Ventana_Menu.Title = "Menu Principal";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta 4FR.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/crear_partidaFR.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaFR.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/salirFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Espaniol)
            {
                Ventana_Menu.Title = "Menú Principal";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta 4.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/crear_partida.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partida.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/salir.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Menu.Title = "Menu Principal";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta 4PO.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/botonCrearPartidaPO.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/botonUnirseAPartidaPO.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/botonSalirPO.png", UriKind.Relative));
            }
            if (idioma == Idioma.Ingles)
            {
                Title = "Main Menu";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta4IN.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/crear_partidaIN.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaIN.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/salirIN.png", UriKind.Relative));
            }
        }

        public static void reproducirBoton()
        {
            if (estadoSFX == 0)
            {
                return;
            }
            else
            {
                SonidoDeBoton.Play();
            }
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            MusicaDeMenu.Position = TimeSpan.Zero;
            MusicaDeMenu.Play();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            reproducirBoton();
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
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("The connection with the server was lost", "Conenction lost", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Le server ne peut connecter", "Échec de connexion", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Erro ao se conectar ao servidor", "Falha da conexão", MessageBoxButton.OK);
                }
                musicaDeMenu.Stop(); mainWindow.Show();
            }

        }
    }
}
