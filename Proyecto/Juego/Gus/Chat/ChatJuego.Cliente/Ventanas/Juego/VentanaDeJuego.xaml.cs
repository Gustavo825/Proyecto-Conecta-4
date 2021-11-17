using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace ChatJuego.Cliente.Ventanas.Juego
{
    /// <summary>
    /// Lógica de interacción para VentanaDeJuego.xaml
    /// </summary>
    public partial class VentanaDeJuego : Window
    {
        InstanceContext contexto;
        public string oponente { get; set; }
        MenuPrincipal menuPrincipal;
        ServidorClient servidor;
        Jugador jugador;
        ChatServicioClient servidorDelChat;
        JugadorCallBack jugadorCallBack;
        ConfirmacionDePresencia confirmacionDePresencia;
        string codigoDePartida;
        DispatcherTimer timer;
        public bool oponenteConectado { get; set; }
        private bool imagenesCargadas;

        public VentanaDeJuego(InstanceContext contexto, MenuPrincipal menuPrincipal, Jugador jugador, ChatServicioClient servidorDelChat, string codigoDePartida, JugadorCallBack jugadorCallBack, ServidorClient servidor)
        {
            InitializeComponent();
            ImagenJugadorDerecho.Source = ConvertirArrayAImagen(servidor.ObtenerBytesDeImagenDeJugador(jugador.usuario));
            imagenesCargadas = false;
            this.contexto = contexto;
            this.menuPrincipal = menuPrincipal;
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.codigoDePartida = codigoDePartida;
            this.jugadorCallBack = jugadorCallBack;
            this.servidor = servidor;
            IniciarTiempoDeEspera();

        }

        public VentanaDeJuego()
        {
            InitializeComponent();
        }

        private void IniciarTiempoDeEspera()
        {

            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(15) };
            timer.Tick += delegate
            {
                if (oponenteConectado)
                {
                    confirmacionDePresencia = new ConfirmacionDePresencia();
                    timer.Stop();
                    var presencia = confirmacionDePresencia.ShowDialog();
                    if (presencia == true)
                    {
                        confirmacionDePresencia.Close();
                        timer.Start();
                    }
                    else
                    {
                        confirmacionDePresencia.Close();
                        FinalizarPartida(EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite);
                        MessageBox.Show("Te austentaste demasiado tiempo, serás llevado al menú principal", "Ausente", MessageBoxButton.OK);
                        menuPrincipal.Show();
                        CerrarConfirmacionDePresencia();
                        timer.Stop();
                        this.Close();
                    }
                }
            };
            timer.Start();
            InputManager.Current.PostProcessInput += delegate (object s, ProcessInputEventArgs r)
            {
                if (!imagenesCargadas && oponenteConectado)
                {
                    CargarImagenesDeJugadores();
                    imagenesCargadas = true;
                }
                if (r.StagingItem.Input is MouseButtonEventArgs || r.StagingItem.Input is KeyEventArgs)
                    timer.Interval = TimeSpan.FromSeconds(15);
            };
        }

        public void CargarImagenesDeJugadores()
        {
            ImagenJugadorIzquiero.Source = ConvertirArrayAImagen(servidor.ObtenerBytesDeImagenDeJugador(oponente));

        }

        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            if (oponenteConectado)
            {
                Chat chat = new Chat(jugador, servidorDelChat, oponente);
                try
                {
                    chat.chatDePartida = true;
                    jugadorCallBack.SetChat(chat);
                    servidorDelChat.InicializarChat();
                    chat.Show();
                }
                catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    CerrarConfirmacionDePresencia();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("El oponente aún no se conecta a la partida", "Error", MessageBoxButton.OK);
            }
        }

        private void FinalizarPartida(EstadoPartida estadoDePartida)
        {
            timer.Stop();
            if (oponenteConectado == false)
            {
                servidor.EliminarPartida(codigoDePartida, jugador.usuario, estadoDePartida);
            }
            else if (estadoDePartida == EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite || estadoDePartida == EstadoPartida.FinDePartidaSalir)
            {
                servidor.EliminarPartidaConGanador(codigoDePartida, jugador.usuario, estadoDePartida, 10, oponente);
            }
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if (oponenteConectado == false)
            {
                MessageBox.Show("El oponente nunca se unió a la partida", "Error", MessageBoxButton.OK);
            }
            FinalizarPartida(EstadoPartida.FinDePartidaSalir);
            menuPrincipal.Show();
            CerrarConfirmacionDePresencia();
            this.Close();
        }

        public void Desconectarse(EstadoPartida estadoPartida)
        {
            timer.Stop();
            CerrarConfirmacionDePresencia();
            if (estadoPartida == EstadoPartida.FinDePartidaSalir)
            {
                MessageBox.Show("El oponente salió de la partida, ¡Tú ganas!", "Oponente salió", MessageBoxButton.OK);
            }
            else if (estadoPartida == EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite)
            {
                MessageBox.Show("El oponente se ausentó más del tiempo límite, ¡Tú ganas!", "Oponente ausente", MessageBoxButton.OK);

            }
            menuPrincipal.Show();
            this.Close();


        }

        private void CerrarConfirmacionDePresencia()
        {
            if (confirmacionDePresencia != null && confirmacionDePresencia.IsActive)
                confirmacionDePresencia.Close();
        }

        public static BitmapImage ConvertirArrayAImagen(byte[] arrayDeImagen)
        {
            BitmapImage imagen = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(arrayDeImagen))
            {
                imagen.BeginInit();
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.StreamSource = memStream;
                imagen.EndInit();
                imagen.Freeze();
            }
            return imagen;
        }


    }
}
