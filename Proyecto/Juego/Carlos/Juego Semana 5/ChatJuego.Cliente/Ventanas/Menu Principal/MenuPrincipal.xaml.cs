using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Configuracion;
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
        private static MediaPlayer musicaDeMenu = new MediaPlayer();
        private static SoundPlayer sonidoDeBoton = new SoundPlayer();
        ServidorClient servidor;
        ChatServicioClient servidorDelChat;
        TablaDePuntajesClient servidorDeTablaDePuntajes;
        InstanceContext contexto;
        JugadorCallBack callBackDeJugador;
        Jugador jugador;
        private static int estadoMusica = 1;
        private static int estadoSFX = 1;
        public static Configuracion.Idioma idiomaMenu = Configuracion.Idioma.Espaniol;

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
            if (EstadoMusica == 1)
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
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
            timer.Tick += delegate
            {
                timer.Stop();
                if (idiomaMenu == Configuracion.Idioma.Espaniol)
                {
                    MessageBox.Show("¿Sigues ahí?", "Tiempo de inactividad", MessageBoxButton.OK);
                }
                else if (idiomaMenu == Configuracion.Idioma.Ingles)
                {
                    MessageBox.Show("Are you still there?", "Inactivity timelapse", MessageBoxButton.OK);
                }
                else if (idiomaMenu == Configuracion.Idioma.Frances)
                {
                    MessageBox.Show("Tu es toujours là?", "Temps écoulé d'inactivité", MessageBoxButton.OK);
                }
                else if (idiomaMenu == Configuracion.Idioma.Portugues)
                {
                    MessageBox.Show("Estás ainda aí?", "Tempo de inactividade", MessageBoxButton.OK);
                }
                timer.Start();
            };
            timer.Start();
            InputManager.Current.PostProcessInput += delegate (object s, ProcessInputEventArgs r)
            {
                if (r.StagingItem.Input is MouseButtonEventArgs || r.StagingItem.Input is KeyEventArgs)
                    timer.Interval = TimeSpan.FromMinutes(1);
            };

        }

        private void BotonTablaDePuntajes_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            TablaDePuntajes tablaPuntajes = new TablaDePuntajes(servidorDeTablaDePuntajes);
            callBackDeJugador.SetTablaDePuntajes(tablaPuntajes);
            tablaPuntajes.Show();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            musicaDeMenu.Stop();
            MainWindow mainWindow = new MainWindow();
            servidor.Desconectarse();
            mainWindow.Show();
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
                if (idiomaMenu == Configuracion.Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idiomaMenu == Configuracion.Idioma.Ingles)
                {
                    MessageBox.Show("The connection with the server was lost", "Conenction lost", MessageBoxButton.OK);
                }
                else if (idiomaMenu == Configuracion.Idioma.Frances)
                {
                    MessageBox.Show("Le server ne peut connecter", "Échec de connexion", MessageBoxButton.OK);
                }
                else if (idiomaMenu == Configuracion.Idioma.Portugues)
                {
                    MessageBox.Show("Erro ao se conectar ao servidor", "Falha da conexão", MessageBoxButton.OK);
                }
                musicaDeMenu.Stop();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(jugador, this, contexto);
            enviarInvitacion.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void BotonConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            reproducirBoton();
            Configuracion configuracion = new Configuracion(this);
            configuracion.Show();
        }

        public void ActualizarIdiomaDeVentana()
        {
            if (idiomaMenu == Configuracion.Idioma.Frances)
            {
                Ventana_Menu.Title = "Menu Principal";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta 4FR.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/crear_partidaFR.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaFR.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/salirFR.png", UriKind.Relative));
            }
            else if (idiomaMenu == Configuracion.Idioma.Espaniol)
            {
                Ventana_Menu.Title = "Menú Principal";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta 4.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/crear_partida.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partida.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/salir.png", UriKind.Relative));
            }
            else if (idiomaMenu == Configuracion.Idioma.Portugues)
            {
                Ventana_Menu.Title = "Menu Principal";
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/conecta 4PO.png", UriKind.Relative));
                BotonCrear_Partida.Source = new BitmapImage(new Uri("Iconos/botonCrearPartidaPO.png", UriKind.Relative));
                BotonUnirse_Partida.Source = new BitmapImage(new Uri("Iconos/botonUnirseAPartidaPO.png", UriKind.Relative));
                Boton_Salir.Source = new BitmapImage(new Uri("Iconos/botonSalirPO.png", UriKind.Relative));
            }
            if (idiomaMenu == Configuracion.Idioma.Ingles)
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
    }
}
