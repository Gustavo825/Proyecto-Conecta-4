using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Configuracion;
using ChatJuego.Cliente.Ventanas.Tutorial;
using ChatJuego.Cliente.Ventanas.Unirse_a_Partida;
using System;
using System.IO;
using System.Media;
using System.ServiceModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    public partial class MenuPrincipal : Window
    {
        private ServidorClient servidor;
        private ChatServicioClient servidorDelChat;
        private TablaDePuntajesClient servidorDeTablaDePuntajes;
        private InstanceContext contexto;
        private JugadorCallBack callBackDeJugador;
        private Configuracion configuracion;
        private Chat chat;
        private Tutorial tutorial;
        private Jugador jugador;
        private TablaDePuntajes tablaDePuntajes;
        public bool DesconexionDelServidor { get; set; }
        public const int MUSICA_ENCENDIDA = 1;
        public const int EFECTOS_ENCENDIDO = 1;
        public const int EFECTOS_APAGADO = 0;

        public static MediaPlayer MusicaDeMenu { get; set; } = new MediaPlayer();
        public static SoundPlayer SonidoDeBoton { get; set; } = new SoundPlayer();
        public static int EstadoMusica { get; set; } = MUSICA_ENCENDIDA;
        public static int EstadoSFX { get; set; } = EFECTOS_ENCENDIDO;
        public static SoundPlayer SonidoDeError { get; set; } = new SoundPlayer();

        public MenuPrincipal(ServidorClient servidor, JugadorCallBack callBackDeJugador, Jugador jugador, InstanceContext contexto)
        {
            DesconexionDelServidor = false;
            servidorDelChat = null;
            string ruta = Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            MusicaDeMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDePartida.wav"));
            MusicaDeMenu.MediaEnded += new EventHandler(Media_Ended);
            if (EstadoMusica == MUSICA_ENCENDIDA)
            {
                MusicaDeMenu.Play();
            }
            SonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            SonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            this.callBackDeJugador = callBackDeJugador;
            this.servidor = servidor;
            this.jugador = jugador;
            this.contexto = contexto;
            servidorDelChat = new ChatServicioClient(contexto);
            servidorDeTablaDePuntajes = new TablaDePuntajesClient(contexto);
            InitializeComponent();
            ActualizarIdioma();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Tabla de Puntajes.
        /// Abre la ventana de Tabla de Puntajes.
        /// </summary>
        private void BotonTablaDePuntajes_Click(object sender, RoutedEventArgs e)
        {
            ReproducirBoton();
            tablaDePuntajes = new TablaDePuntajes(servidorDeTablaDePuntajes);
            callBackDeJugador.SetTablaDePuntajes(tablaDePuntajes);
            tablaDePuntajes.Show();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Salir.
        /// Se cierra la ventana.
        /// </summary>
        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Chat.
        /// Se abre la ventana de Chat.
        /// </summary>
        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            ReproducirBoton();
            chat = new Chat(jugador, servidorDelChat, this);
            try
            {
                servidorDelChat = new ChatServicioClient(contexto);
                servidorDelChat.InicializarChat();
                callBackDeJugador.SetChat(chat);
                chat.Show();
                this.Hide();
            } catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                NotificarDesconexionDelServidor();
                MusicaDeMenu.Stop();
                DesconexionDelServidor = true;
                this.Close();
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de desconexión del servidor
        /// </summary>
        private static void NotificarDesconexionDelServidor()
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
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Configuración.
        /// Se abre la ventana de Configuración.
        /// </summary>
        private void BotonConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            ReproducirBoton();
            configuracion = new Configuracion(this,servidor,jugador);
            configuracion.Show();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Crear Partida.
        /// Abre la ventana de Enviar Invitación.
        /// </summary>
        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            ReproducirBoton();
            servidorDelChat = new ChatServicioClient(contexto);
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(jugador, this, contexto, servidorDelChat,callBackDeJugador, servidor);
            enviarInvitacion.Show();
            this.Hide();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Unirse a Partida.
        /// Se abre la ventana de Unirse a Partida.
        /// </summary>
        private void BotonUnirse_Click(object sender, RoutedEventArgs e)
        {
            ReproducirBoton();
            servidorDelChat = new ChatServicioClient(contexto);
            UnirseAPartida unirseAPartida = new UnirseAPartida(jugador, this, servidorDelChat, callBackDeJugador, servidor);
            unirseAPartida.Show();
            this.Hide();
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        public void ActualizarIdioma()
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
        /// <summary>
        /// Método que reproduce el sonido cuando se da click en un botón.
        /// </summary>
        public static void ReproducirMusica()
        {
            if (EstadoMusica == MUSICA_ENCENDIDA)
            {
                MusicaDeMenu.Play();
            }
        }

        /// <summary>
        /// Método que reproduce el sonido cuando se da click en un botón.
        /// </summary>
        public static void ReproducirBoton()
        {
            if (EstadoSFX == EFECTOS_ENCENDIDO)
            {
                SonidoDeBoton.Play();
            }
        }

        /// <summary>
        /// Método que reproduce el sonido cuando se produce un error.
        /// </summary>
        public static void ReproducirError()
        {
            if (EstadoSFX == EFECTOS_ENCENDIDO)
            {
                SonidoDeError.Play();
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se activa la música.
        /// Detecta cuando termina la canción para reiniciarla y así hacer un loop.
        /// </summary>
        private void Media_Ended(object sender, EventArgs e)
        {
            MusicaDeMenu.Position = TimeSpan.Zero;
            MusicaDeMenu.Play();
        }

        /// <summary>
        /// Método que se ejecuta cuando se cierra el menú principal.
        /// Se desconecta del servidor y nos regresas a la ventana de Iniciar Sesión.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReproducirBoton();
            MainWindow mainWindow = new MainWindow();
            MusicaDeMenu.Stop();
            if (tutorial != null)
            {
                tutorial.Close();
            }
            if (configuracion != null)
            {
                configuracion.Close();
            }
            if (tablaDePuntajes != null)
            {
                tablaDePuntajes.Close();
            }
            try
            {
                if (!DesconexionDelServidor)
                {
                    servidor.Desconectarse();
                }
                mainWindow.Show();
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                NotificarDesconexionDelServidor();
                MusicaDeMenu.Stop(); 
                mainWindow.Show();
            }

        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón del tutorial
        /// </summary>
        private void BotonTutorial_Click(object sender, RoutedEventArgs e)
        {
            ReproducirBoton();
            tutorial = new Tutorial();
            tutorial.Show();
        }
    }
}
