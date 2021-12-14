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
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente.Ventanas.Juego
{
    /// <summary>
    /// Lógica de interacción para VentanaDeJuego.xaml
    /// </summary>
    public partial class VentanaDeJuego : Window
    {
        InstanceContext contexto;
        private static MediaPlayer musicaDePartida = new MediaPlayer();
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
        public bool turnoDeJuego { get; set; }
        public static MediaPlayer MusicaDePartida { get => musicaDePartida; set => musicaDePartida = value; }

        const string RUTAFICHAAZUL = "Iconos/fichaAzul.png";
        const string RUTAFICHAROJA = "Iconos/fichaRoja.png";
        public const int TIROPROPIO = 1;
        public const int TIROOPONENTE = 2;
        public const int EMPATE = 3;
        private bool partidaFinalizada;

        int[,] tablero = new int[6, 7]
        {
            {0 , 0 , 0 , 0 , 0 , 0 , 0},
            {0 , 0 , 0 , 0 , 0 , 0 , 0},
            {0 , 0 , 0 , 0 , 0 , 0 , 0},
            {0 , 0 , 0 , 0 , 0 , 0 , 0},
            {0 , 0 , 0 , 0 , 0 , 0 , 0},
            {0 , 0 , 0 , 0 , 0 , 0 , 0},
        };

        public VentanaDeJuego(InstanceContext contexto, MenuPrincipal menuPrincipal, Jugador jugador, ChatServicioClient servidorDelChat, string codigoDePartida, JugadorCallBack jugadorCallBack, ServidorClient servidor)
        {
            string ruta = Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaDePartida.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDePartida2.wav"));
            musicaDePartida.MediaEnded += new EventHandler(Media_Ended);
            if (MenuPrincipal.EstadoMusica == 1)
            {
                musicaDePartida.Play();
            }
            InitializeComponent();
            MenuPrincipal.MusicaDeMenu.Stop();
            ImagenJugadorDerecho.Source = ConvertirArrayAImagen(servidor.ObtenerBytesDeImagenDeJugador(jugador.usuario));
            imagenesCargadas = false;
            partidaFinalizada = false;
            this.contexto = contexto;
            this.menuPrincipal = menuPrincipal;
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.codigoDePartida = codigoDePartida;
            this.jugadorCallBack = jugadorCallBack;
            this.servidor = servidor;
            IniciarTiempoDeEspera();

        }

        public int VerificarTablero()
        {
            //Horizontal
            for (int fila = 5; fila >= 0; fila--)
            {
                for (int columna = 0; columna <= 3; columna++ )
                {
                    if (tablero[fila,columna] == 1 && tablero[fila, columna + 1] == 1 && tablero[fila, columna + 2] == 1 && tablero[fila, columna + 3] == 1)
                    {
                        return TIROPROPIO;
                    }
                    if (tablero[fila, columna] == 2 && tablero[fila, columna + 1] == 2 && tablero[fila, columna + 2] == 2 && tablero[fila, columna + 3] == 2)
                    {
                        return TIROOPONENTE;
                    }
                }
            }
            //Vertical
            for (int columna = 0; columna < 7; columna++)
            {
                for (int fila = 5; fila >= 3; fila--)
                {
                    if (tablero[fila, columna] == 1 && tablero[fila - 1, columna] == 1 && tablero[fila - 2, columna] == 1 && tablero[fila - 3, columna] == 1)
                    {
                        return TIROPROPIO;
                    }
                    if (tablero[fila, columna] == 2 && tablero[fila - 1, columna] == 2 && tablero[fila - 2, columna] == 2 && tablero[fila - 3, columna] == 2)
                    {
                        return TIROOPONENTE;
                    }
                }
            }
            //diagonal izquierda-derecha
            int numeroDeComprobaciones = 1;
            int columnaDeTablero = 0;
            for (int fila = 2; fila >= 0; fila--)
            {
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[fila, columnaDeTablero] == 1 && tablero[fila + 1, columnaDeTablero + 1] == 1 && tablero[fila + 2, columnaDeTablero + 2] == 1 && tablero[fila + 3, columnaDeTablero + 3] == 1)
                    {
                        return TIROPROPIO;
                    }
                    if (tablero[fila, columnaDeTablero] == 2 && tablero[fila + 1, columnaDeTablero + 1] == 2 && tablero[fila + 2, columnaDeTablero + 2] == 2 && tablero[fila + 3, columnaDeTablero + 3] == 2)
                    {
                        return TIROOPONENTE;
                    }
                    columnaDeTablero++;
                }
                numeroDeComprobaciones++;
                columnaDeTablero = 0;
            }

            int filaDeTablero = 0;
            numeroDeComprobaciones = 3;
            for (int columna = 1; columna < 4; columna++)
            {
                int columnaOriginal = columna;
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[filaDeTablero, columna] == 1 && tablero[filaDeTablero + 1, columna + 1] == 1 && tablero[filaDeTablero + 2, columna + 2] == 1 && tablero[filaDeTablero + 3, columna + 3] == 1)
                    {
                        return TIROPROPIO;
                    }
                    if (tablero[filaDeTablero, columna] == 2 && tablero[filaDeTablero + 1, columna + 1] == 2 && tablero[filaDeTablero + 2, columna + 2] == 2 && tablero[filaDeTablero + 3, columna + 3] == 2)
                    {
                        return TIROOPONENTE;
                    }
                    filaDeTablero++;
                    columna++;
                }
                columna = columnaOriginal;
                filaDeTablero = 0;
                numeroDeComprobaciones--;
            }
            //Diagonal derecha-izquierda
            numeroDeComprobaciones = 1;
            columnaDeTablero = 6;
            for (int fila = 2; fila >= 0; fila--)
            {
                int filaOriginal = fila;
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[fila, columnaDeTablero] == 1 && tablero[fila + 1, columnaDeTablero - 1] == 1 && tablero[fila + 2, columnaDeTablero - 2] == 1 && tablero[fila + 3, columnaDeTablero - 3] == 1)
                    {
                        return TIROPROPIO;
                    }
                    if (tablero[fila, columnaDeTablero] == 2 && tablero[fila + 1, columnaDeTablero - 1] == 2 && tablero[fila + 2, columnaDeTablero - 2] == 2 && tablero[fila + 3, columnaDeTablero - 3] == 2)
                    {
                        return TIROOPONENTE;
                    }
                    columnaDeTablero--;
                    fila++;
                }
                fila = filaOriginal;
                numeroDeComprobaciones++;
                columnaDeTablero = 6;
            }

            filaDeTablero = 0;
            numeroDeComprobaciones = 3;
            for (int columna = 5; columna > 2; columna--)
            {
                int columnaOriginal = columna;
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[filaDeTablero, columna] == 1 && tablero[filaDeTablero + 1, columna - 1] == 1 && tablero[filaDeTablero + 2, columna - 2] == 1 && tablero[filaDeTablero + 3, columna - 3] == 1)
                    {
                        return TIROPROPIO;
                    }
                    if (tablero[filaDeTablero, columna] == 2 && tablero[filaDeTablero + 1, columna - 1] == 2 && tablero[filaDeTablero + 2, columna - 2] == 2 && tablero[filaDeTablero + 3, columna - 3] == 2)
                    {
                        return TIROOPONENTE;
                    }
                    filaDeTablero++;
                    columna--;
                }
                columna = columnaOriginal;
                numeroDeComprobaciones--;
                filaDeTablero = 0;
            }

            return 0;
        }

        public VentanaDeJuego()
        {
            InitializeComponent();
        }

        private void IniciarTiempoDeEspera()
        {

            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30) };
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
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("Te austentaste demasiado tiempo, serás llevado al menú principal", "Ausente", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Vous avez été absent trop longtemps, vous serez ramené au menu principal", "Absent", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Você esteve ausente por muito tempo, você será levado ao menu principal", "Ausente", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                        }
                        MenuPrincipal.ReproducirMusica();
                        menuPrincipal.Show();
                        CerrarConfirmacionDePresencia();
                        timer.Stop();
                        musicaDePartida.Stop();
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
                    timer.Interval = TimeSpan.FromSeconds(30);
            };
        }

        public void CargarImagenesDeJugadores()
        {
            try
            {
                ImagenJugadorIzquiero.Source = ConvertirArrayAImagen(servidor.ObtenerBytesDeImagenDeJugador(oponente));
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("La connexion au serveur a été perdue", "Erreur de connexion", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("A conexão com o servidor foi perdida", "Error de conexão", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CerrarConfirmacionDePresencia();
                this.Close();
            }
        }

        public void IntroducirFicha(int columna, int quienTira)
        {

                KeyValuePair<int, int> posicionDeFicha;
                for (int fila = 5; fila >= 0; fila--)
                {
                    if (quienTira == TIROPROPIO)
                    {
                        if (tablero[fila, columna - 1] == 0)
                        {
                            posicionDeFicha = new KeyValuePair<int, int>(fila + 1, columna);
                            switch (posicionDeFicha.Value)
                            {
                                case 1:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f16.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f15.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f14.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f13.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f12.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f11.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f26.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f25.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f24.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f23.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f22.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f21.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f36.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f35.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f34.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f33.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f32.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f31.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f46.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f45.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f44.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f43.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f42.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f41.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f56.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f55.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f54.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f53.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f52.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f51.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f66.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f65.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f64.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f63.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f62.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f61.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f76.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 5:
                                            f75.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 4:
                                            f74.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 3:
                                            f73.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 2:
                                            f72.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                        case 1:
                                            f71.Source = new BitmapImage(new Uri(RUTAFICHAAZUL, UriKind.Relative));
                                            break;
                                    }
                                    break;
                            }
                            tablero[fila, columna - 1] = TIROPROPIO;
                            break;
                        }
                    }
                    else
                    {
                        if (tablero[fila, columna - 1] == 0)
                        {
                            posicionDeFicha = new KeyValuePair<int, int>(fila + 1, columna);
                            switch (posicionDeFicha.Value)
                            {
                                case 1:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f16.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f15.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f14.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f13.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f12.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f11.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f26.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f25.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f24.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f23.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f22.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f21.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f36.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f35.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f34.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f33.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f32.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f31.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f46.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f45.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f44.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f43.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f42.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f41.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f56.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f55.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f54.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f53.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f52.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f51.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f66.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f65.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f64.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f63.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f62.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f61.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (posicionDeFicha.Key)
                                    {
                                        case 6:
                                            f76.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 5:
                                            f75.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 4:
                                            f74.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 3:
                                            f73.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 2:
                                            f72.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                        case 1:
                                            f71.Source = new BitmapImage(new Uri(RUTAFICHAROJA, UriKind.Relative));
                                            break;
                                    }
                                    break;
                            }
                            tablero[fila, columna - 1] = TIROOPONENTE;
                            break;
                        }
                    }
                }
            int ganadorDePartida = VerificarTablero();
            if (ganadorDePartida == TIROPROPIO)
            {
                servidor.InsertarFichaEnOponente(columna, codigoDePartida, oponente);
                FinalizarPartida(EstadoPartida.FinDePartidaGanada);
                partidaFinalizada = true;
            } else if (ganadorDePartida == TIROOPONENTE)
            {
                partidaFinalizada = true;
                return;
            }
            int empate = VerificarTableroLleno();
            if (empate == EMPATE) {
                servidor.InsertarFichaEnOponente(columna, codigoDePartida, oponente);
                FinalizarPartida(EstadoPartida.FinDePartidaPorEmpate);
                partidaFinalizada = true;
            }

        }

        private int VerificarTableroLleno()
        {
            for (int fila = 0; fila < 6; fila++)
            {
                for (int columna = 0; columna < 7; columna++)
                {
                    if (tablero[fila, columna] == 0)
                        return 0;
                }
            }
            return EMPATE;
        }

        private void ClicEnTablero(object sender, RoutedEventArgs e)
        {
            try
            {
                if (oponenteConectado == true && turnoDeJuego == true)
                {
                    Button boton = (Button)sender;
                    int columna = int.Parse(boton.Name[1].ToString());
                    bool lleno = VerificarColumnaLlena(columna);
                    if (!lleno)
                    {
                        IntroducirFicha(columna, TIROPROPIO);
                        turnoDeJuego = false;
                        servidor.InsertarFichaEnOponente(columna, codigoDePartida, oponente);
                    } else {
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("Columna llena, seleccione otra columna", "Columna llena", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Colonne pleine, sélectionnez une autre colonne", "Colonne pleine", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Coluna cheia, selecione outra coluna", "Coluna cheia", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("La connexion au serveur a été perdue", "Erreur de connexion", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("A conexão com o servidor foi perdida", "Error de conexão", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CerrarConfirmacionDePresencia();
                this.Close();
            }
        }

        private bool VerificarColumnaLlena(int columna)
        {
            if (tablero[0,columna - 1] != 0)
            {
                return true;
            }
            return false;
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
                    if (idioma == Idioma.Espaniol)
                    {
                        MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Frances)
                    {
                        MessageBox.Show("La connexion au serveur a été perdue", "Erreur de connexion", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Portugues)
                    {
                        MessageBox.Show("A conexão com o servidor foi perdida", "Error de conexão", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Ingles)
                    {
                        MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                    }
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    CerrarConfirmacionDePresencia();
                    this.Close();
                }
            }
            else
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("El oponente aún no se conecta a la partida", "Error", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Adversaire non encore connecté au jeu", "Erreur", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Oponente ainda não conectado ao jogo", "Error", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            }
        }

        private void FinalizarPartida(EstadoPartida estadoDePartida)
        {
            timer.Stop();
            try
            {
                if (oponenteConectado == false)
                {
                    servidor.EliminarPartida(codigoDePartida, jugador.usuario, estadoDePartida);
                }
                else if (estadoDePartida == EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite || estadoDePartida == EstadoPartida.FinDePartidaSalir)
                {
                    servidor.EliminarPartidaConGanador(codigoDePartida, jugador.usuario, estadoDePartida, 10, oponente);
                } else if (estadoDePartida == EstadoPartida.FinDePartidaGanada)
                {
                    servidor.EliminarPartidaConGanador(codigoDePartida, jugador.usuario, estadoDePartida, 50, jugador.usuario);
                    Desconectarse(estadoDePartida);
                } else if (estadoDePartida == EstadoPartida.FinDePartidaPorEmpate)
                {
                    servidor.EliminarPartida(codigoDePartida, jugador.usuario, estadoDePartida);
                    Desconectarse(estadoDePartida);
                }
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("La connexion au serveur a été perdue", "Erreur de connexion", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("A conexão com o servidor foi perdida", "Error de conexão", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CerrarConfirmacionDePresencia();
                MenuPrincipal.ReproducirMusica();
                this.Close();
            }
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        public void Desconectarse(EstadoPartida estadoPartida)
        {
            timer.Stop();
            CerrarConfirmacionDePresencia();
            if (estadoPartida == EstadoPartida.FinDePartidaSalir)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("El oponente salió de la partida, ¡Tú ganas!", "Oponente salió", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("L'adversaire est hors partie, vous gagnez!", "L'adversaire est parti", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("O adversário está fora do jogo, você ganha!", "O oponente partiu", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            }
            else if (estadoPartida == EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("El oponente se ausentó más del tiempo límite, ¡Tú ganas!", "Oponente ausente", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("L'adversaire était absent au-delà du temps imparti, vous gagnez!", "Absent Opposant", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("O adversário estava ausente além do tempo limite, você ganha!", "Oponente ausentado", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            } else if (estadoPartida == EstadoPartida.FinDePartidaGanada)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("¡Tú ganas!", "Partida finalizada", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Vous avez gagné!", "Partie terminé", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Você ganhou!", "Jogo concluído", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            } else if (estadoPartida == EstadoPartida.FinDePartidaPerdida)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("¡Has perdido!", "Partida finalizada", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Vous avez perdu!", "Partie terminé", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Você perdeu!", "Jogo concluído", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            } else if (estadoPartida == EstadoPartida.FinDePartidaPorEmpate)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("¡Empate!", "Partida finalizada", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Cravate!", "Partie terminé", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Empate!", "Jogo concluído", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            }
            MenuPrincipal.ReproducirMusica();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            if (oponenteConectado == false)
            {
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("El oponente nunca se unió a la partida", "Error", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("L'adversaire n'a jamais rejoint le partie", "Erreur", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("O oponente nunca se juntou ao jogo", "Error", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Undefined", "Undefined", MessageBoxButton.OK);
                }
            }
            if (partidaFinalizada != true)
            {
                FinalizarPartida(EstadoPartida.FinDePartidaSalir);
            }
            musicaDePartida.Stop();
            MenuPrincipal.ReproducirMusica();
            menuPrincipal.Show();
            CerrarConfirmacionDePresencia();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            MusicaDePartida.Position = TimeSpan.Zero;
            MusicaDePartida.Play();
        }
    }
}
