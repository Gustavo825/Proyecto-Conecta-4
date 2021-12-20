using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente.Ventanas.Juego
{
    /// <summary>
    /// Lógica de interacción para VentanaDeJuego.xaml
    /// </summary>
    public partial class VentanaDeJuego : Window
    {
        private static MediaPlayer MusicaDePartida = new MediaPlayer();
        private static SoundPlayer SonidoDeFicha = new SoundPlayer();
        public string Oponente { get; set; }
        MenuPrincipal menuPrincipal;
        ServidorClient servidor;
        Jugador jugador;
        ChatServicioClient servidorDelChat;
        JugadorCallBack jugadorCallBack;
        ConfirmacionDePresencia confirmacionDePresencia;
        string codigoDePartida;
        DispatcherTimer timer;
        public bool OponenteConectado { get; set; }
        private bool imagenesCargadas;
        public bool TurnoDeJuego { get; set; }

        private const string RUTA_FICHA_AZUL = "Iconos/fichaAzul.png";
        private const string RUTA_FICHA_ROJA = "Iconos/fichaRoja.png";
        public const int TIRO_PROPIO = 1;
        public const int TIRO_OPONENTE = 2;
        public const int EMPATE = 3;
        public const int SIN_LINEA_GANADORA = 0;
        public const int VACIO = 0;
        public const int TIEMPO_DE_ESPERA = 30;
        public const int COLUMNA_1 = 1;
        public const int COLUMNA_2 = 2;
        public const int COLUMNA_3 = 3;
        public const int COLUMNA_4 = 4;
        public const int COLUMNA_5 = 5;
        public const int COLUMNA_6 = 6;
        public const int COLUMNA_7 = 7;
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

        public VentanaDeJuego(MenuPrincipal menuPrincipal, Jugador jugador, ChatServicioClient servidorDelChat, string codigoDePartida, JugadorCallBack jugadorCallBack, ServidorClient servidor)
        {
            MenuPrincipal.MusicaDeMenu.Stop();
            string ruta = Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            MusicaDePartida.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDePartida2.wav"));
            MusicaDePartida.MediaEnded += new EventHandler(Media_Ended);
            if (MenuPrincipal.EstadoMusica == MenuPrincipal.MUSICA_ENCENDIDA)
            {
                MusicaDePartida.Play();
            }
            SonidoDeFicha.SoundLocation = ruta + @"Ventanas\Sonidos\SonidoFicha.wav";
            InitializeComponent();
            ActualizarIdioma();
            ImagenJugadorDerecho.Source = ConvertirArrayAImagen(servidor.ObtenerBytesDeImagenDeJugador(jugador.usuario));
            imagenesCargadas = false;
            partidaFinalizada = false;
            this.menuPrincipal = menuPrincipal;
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.codigoDePartida = codigoDePartida;
            this.jugadorCallBack = jugadorCallBack;
            this.servidor = servidor;
            IniciarTiempoDeEspera();
        }

        /// <summary>
        /// Verifica si algún jugador ya ganó. Verifica que existan 4 fichas consecutivas de forma horizontal,
        /// vertical y en las diagonales
        /// </summary>
        /// <returns>Si hay un ganador, regresa TIROPROPIO si el ganador es uno mismo, o TIROOPONENTE si el ganador es el oponente. Si nadie gana, regresa un 0</returns>
        public int VerificarTablero()
        {
            int resultado = VerificarHorizontal();
            if (resultado != SIN_LINEA_GANADORA)
            {
                return resultado;
            }
            resultado = VerificarVertical();
            if (resultado != SIN_LINEA_GANADORA)
            {
                return resultado;
            }
            resultado = VerificarDiagonalesDerechaIzquierda();
            if (resultado != SIN_LINEA_GANADORA)
            {
                return resultado;
            }
            resultado = VerificarDiagonalesIzquierdaDerecha();
            if (resultado != SIN_LINEA_GANADORA)
            {
                return resultado;
            }
            return SIN_LINEA_GANADORA;
        }

        /// <summary>
        /// Verifica que existan 4 fichas consecutivas horizontales en el tablero 
        /// </summary>
        /// <returns>Regresa el resulta de la verificación</returns>
        private int VerificarHorizontal()
        {
            for (int fila = 5; fila >= 0; fila--)
            {
                for (int columna = 0; columna <= 3; columna++)
                {
                    if (tablero[fila, columna] == TIRO_PROPIO && tablero[fila, columna + 1] == TIRO_PROPIO && tablero[fila, columna + 2] == TIRO_PROPIO && tablero[fila, columna + 3] == TIRO_PROPIO)
                    {
                        return TIRO_PROPIO;
                    }
                    if (tablero[fila, columna] == TIRO_OPONENTE && tablero[fila, columna + 1] == TIRO_OPONENTE && tablero[fila, columna + 2] == TIRO_OPONENTE && tablero[fila, columna + 3] == TIRO_OPONENTE)
                    {
                        return TIRO_OPONENTE;
                    }
                }
            }
            return SIN_LINEA_GANADORA;
        }

        /// <summary>
        /// Verifica que existan 4 fichas consecutivas verticales en el tablero 
        /// </summary>
        /// <returns>Regresa el resulta de la verificación</returns>
        private int VerificarVertical()
        {
            for (int columna = 0; columna < 7; columna++)
            {
                for (int fila = 5; fila >= 3; fila--)
                {
                    if (tablero[fila, columna] == TIRO_PROPIO && tablero[fila - 1, columna] == TIRO_PROPIO && tablero[fila - 2, columna] == TIRO_PROPIO && tablero[fila - 3, columna] == TIRO_PROPIO)
                    {
                        return TIRO_PROPIO;
                    }
                    if (tablero[fila, columna] == TIRO_OPONENTE && tablero[fila - 1, columna] == TIRO_OPONENTE && tablero[fila - 2, columna] == TIRO_OPONENTE && tablero[fila - 3, columna] == TIRO_OPONENTE)
                    {
                        return TIRO_OPONENTE;
                    }
                }
            }
            return SIN_LINEA_GANADORA;
        }

        /// <summary>
        /// Verifica que existan 4 fichas consecutivas en las diagonales izquierda-derecha en el tablero 
        /// </summary>
        /// <returns>Regresa el resulta de la verificación</returns>
        private int VerificarDiagonalesIzquierdaDerecha()
        {
            //diagonal izquierda-derecha
            int numeroDeComprobaciones = 1;
            int columnaDeTablero = 0;
            for (int fila = 2; fila >= 0; fila--)
            {
                int filaOriginal = fila;
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[fila, columnaDeTablero] == TIRO_PROPIO && tablero[fila + 1, columnaDeTablero + 1] == TIRO_PROPIO && tablero[fila + 2, columnaDeTablero + 2] == TIRO_PROPIO && tablero[fila + 3, columnaDeTablero + 3] == TIRO_PROPIO)
                    {
                        return TIRO_PROPIO;
                    }
                    if (tablero[fila, columnaDeTablero] == TIRO_OPONENTE && tablero[fila + 1, columnaDeTablero + 1] == TIRO_OPONENTE && tablero[fila + 2, columnaDeTablero + 2] == TIRO_OPONENTE && tablero[fila + 3, columnaDeTablero + 3] == TIRO_OPONENTE)
                    {
                        return TIRO_OPONENTE;
                    }
                    columnaDeTablero++;
                    fila++;
                }
                fila = filaOriginal;
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
                    if (tablero[filaDeTablero, columna] == TIRO_PROPIO && tablero[filaDeTablero + 1, columna + 1] == TIRO_PROPIO && tablero[filaDeTablero + 2, columna + 2] == TIRO_PROPIO && tablero[filaDeTablero + 3, columna + 3] == TIRO_PROPIO)
                    {
                        return TIRO_PROPIO;
                    }
                    if (tablero[filaDeTablero, columna] == TIRO_OPONENTE && tablero[filaDeTablero + 1, columna + 1] == TIRO_OPONENTE && tablero[filaDeTablero + 2, columna + 2] == TIRO_OPONENTE && tablero[filaDeTablero + 3, columna + 3] == TIRO_OPONENTE)
                    {
                        return TIRO_OPONENTE;
                    }
                    filaDeTablero++;
                    columna++;
                }
                columna = columnaOriginal;
                filaDeTablero = 0;
                numeroDeComprobaciones--;
            }
            return SIN_LINEA_GANADORA;
        }

        /// <summary>
        /// Verifica que existan 4 fichas consecutivas en las diagonales izquierda-derecha en el tablero 
        /// </summary>
        /// <returns>Regresa el resulta de la verificación</returns>
        private int VerificarDiagonalesDerechaIzquierda()
        {
            int numeroDeComprobaciones = 1;
            int columnaDeTablero = 6;
            for (int fila = 2; fila >= 0; fila--)
            {
                int filaOriginal = fila;
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[fila, columnaDeTablero] == TIRO_PROPIO && tablero[fila + 1, columnaDeTablero - 1] == TIRO_PROPIO && tablero[fila + 2, columnaDeTablero - 2] == TIRO_PROPIO && tablero[fila + 3, columnaDeTablero - 3] == TIRO_PROPIO)
                    {
                        return TIRO_PROPIO;
                    }
                    if (tablero[fila, columnaDeTablero] == TIRO_OPONENTE && tablero[fila + 1, columnaDeTablero - 1] == TIRO_OPONENTE && tablero[fila + 2, columnaDeTablero - 2] == TIRO_OPONENTE && tablero[fila + 3, columnaDeTablero - 3] == TIRO_OPONENTE)
                    {
                        return TIRO_OPONENTE;
                    }
                    columnaDeTablero--;
                    fila++;
                }
                fila = filaOriginal;
                numeroDeComprobaciones++;
                columnaDeTablero = 6;
            }

            int filaDeTablero = 0;
            numeroDeComprobaciones = 3;
            for (int columna = 5; columna > 2; columna--)
            {
                int columnaOriginal = columna;
                for (int comprobacion = numeroDeComprobaciones; comprobacion > 0; comprobacion--)
                {
                    if (tablero[filaDeTablero, columna] == TIRO_PROPIO && tablero[filaDeTablero + 1, columna - 1] == TIRO_PROPIO && tablero[filaDeTablero + 2, columna - 2] == TIRO_PROPIO && tablero[filaDeTablero + 3, columna - 3] == TIRO_PROPIO)
                    {
                        return TIRO_PROPIO;
                    }
                    if (tablero[filaDeTablero, columna] == TIRO_OPONENTE && tablero[filaDeTablero + 1, columna - 1] == TIRO_OPONENTE && tablero[filaDeTablero + 2, columna - 2] == TIRO_OPONENTE && tablero[filaDeTablero + 3, columna - 3] == TIRO_OPONENTE)
                    {
                        return TIRO_OPONENTE;
                    }
                    filaDeTablero++;
                    columna--;
                }
                columna = columnaOriginal;
                numeroDeComprobaciones--;
                filaDeTablero = 0;
            }
            return SIN_LINEA_GANADORA;
        }

        /// <summary>
        /// Inicia el contador para el monitoreo de presencia del jugador.
        /// </summary>
        private void IniciarTiempoDeEspera()
        {

            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(TIEMPO_DE_ESPERA) };
            timer.Tick += delegate
            {
                if (OponenteConectado)
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
                        NotificarAusenciaDeJugador();
                        menuPrincipal.Show();
                        CerrarConfirmacionPresencia();
                        timer.Stop();
                        MusicaDePartida.Stop();
                        MenuPrincipal.ReproducirMusica();
                        this.Close();
                    }
                }
            };
            timer.Start();
            InputManager.Current.PostProcessInput += delegate (object s, ProcessInputEventArgs r)
            {
                if (!imagenesCargadas && OponenteConectado)
                {
                    CargarImagenesDeJugadores();
                    imagenesCargadas = true;
                }
                if (r.StagingItem.Input is MouseButtonEventArgs || r.StagingItem.Input is KeyEventArgs)
                    timer.Interval = TimeSpan.FromSeconds(TIEMPO_DE_ESPERA);
            };
        }

        /// <summary>
        /// Muestra el mensaje de ausencia de jugador
        /// </summary>
        private static void NotificarAusenciaDeJugador()
        {
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
                MessageBox.Show("You were inactive for too long, you will be taken to the main menu", "Inactive", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Recupera la imagen de jugador del oponente para mostrarla en la Ventana de Juego
        /// </summary>
        public void CargarImagenesDeJugadores()
        {
            try
            {
                ImagenJugadorIzquiero.Source = ConvertirArrayAImagen(servidor.ObtenerBytesDeImagenDeJugador(Oponente));
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                NotificarDesconexionDeServidor();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CerrarConfirmacionPresencia();
                MusicaDePartida.Stop();
                MenuPrincipal.ReproducirMusica();
                this.Close();
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de desconexión del servidor
        /// </summary>
        private static void NotificarDesconexionDeServidor()
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
                MessageBox.Show("The connection with the server was lost", "Connection lost", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Verifica que la posición seleccionada para ingresar la ficha sea posible.
        /// Si es posible, introduce la ficha y también llama a la función de VerificarTablero para checar si hay ya un ganador.
        /// </summary>
        public void IntroducirFicha(int columna, int quienTira)
        {
            KeyValuePair<int, int> posicionDeFicha;
            for (int fila = 5; fila >= 0; fila--)
            {
                if (quienTira == TIRO_PROPIO)
                {
                    if (tablero[fila, columna - 1] == VACIO)
                    {
                        posicionDeFicha = new KeyValuePair<int, int>(fila + 1, columna);
                        InsertarFichaPropia(posicionDeFicha);
                        tablero[fila, columna - 1] = TIRO_PROPIO;
                        break;
                    }
                }
                else
                {
                    if (tablero[fila, columna - 1] == VACIO)
                    {
                        posicionDeFicha = new KeyValuePair<int, int>(fila + 1, columna);
                        InsertarFichaOponente(posicionDeFicha);
                        tablero[fila, columna - 1] = TIRO_OPONENTE;
                        break;
                    }
                }
            }
            int ganadorDePartida = VerificarTablero();
            if (ganadorDePartida == TIRO_PROPIO)
            {
                servidor.InsertarFichaEnOponente(columna, codigoDePartida, Oponente);
                FinalizarPartida(EstadoPartida.FinDePartidaGanada);
                partidaFinalizada = true;
            }
            else if (ganadorDePartida == TIRO_OPONENTE)
            {
                partidaFinalizada = true;
                return;
            }
            int empate = VerificarTableroLleno();
            if (empate == EMPATE)
            {
                servidor.InsertarFichaEnOponente(columna, codigoDePartida, Oponente);
                FinalizarPartida(EstadoPartida.FinDePartidaPorEmpate);
                partidaFinalizada = true;
            }

        }

        /// <summary>
        /// Inserta la ficha en el tablero con ficha del oponente
        /// </summary>
        /// <param name="posicionDeFicha">Posicion de la ficha</param>
        private void InsertarFichaOponente(KeyValuePair<int,int> posicionDeFicha)
        {
            switch (posicionDeFicha.Value)
            {
                case 1:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f16.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f15.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f14.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f13.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f12.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f11.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
                case 2:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f26.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f25.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f24.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f23.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f22.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f21.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
                case 3:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f36.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f35.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f34.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f33.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f32.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f31.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
                case 4:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f46.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f45.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f44.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f43.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f42.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f41.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
                case 5:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f56.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f55.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f54.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f53.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f52.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f51.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
                case 6:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f66.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f65.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f64.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f63.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f62.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f61.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
                case 7:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f76.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 5:
                            f75.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 4:
                            f74.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 3:
                            f73.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 2:
                            f72.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                        case 1:
                            f71.Source = new BitmapImage(new Uri(RUTA_FICHA_ROJA, UriKind.Relative));
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Inserta la ficha en el tablero con ficha propia
        /// </summary>
        /// <param name="posicionDeFicha">Posicion de la ficha</param>
        private void InsertarFichaPropia(KeyValuePair<int, int> posicionDeFicha)
        {
            switch (posicionDeFicha.Value)
            {
                case COLUMNA_1:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f16.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f15.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f14.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f13.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f12.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f11.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
                case COLUMNA_2:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f26.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f25.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f24.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f23.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f22.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f21.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
                case COLUMNA_3:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f36.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f35.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f34.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f33.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f32.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f31.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
                case COLUMNA_4:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f46.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f45.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f44.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f43.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f42.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f41.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
                case COLUMNA_5:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f56.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f55.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f54.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f53.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f52.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f51.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
                case COLUMNA_6:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f66.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f65.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f64.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f63.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f62.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f61.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
                case COLUMNA_7:
                    switch (posicionDeFicha.Key)
                    {
                        case 6:
                            f76.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 5:
                            f75.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 4:
                            f74.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 3:
                            f73.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 2:
                            f72.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                        case 1:
                            f71.Source = new BitmapImage(new Uri(RUTA_FICHA_AZUL, UriKind.Relative));
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Verifica si el tablero se llenó para declarar un empate
        /// </summary>
        /// <returns>Si el tablero está lleno, regresa el valor EMPATE, si no, regresa un 0</returns>
        private int VerificarTableroLleno()
        {
            for (int fila = 0; fila < 6; fila++)
            {
                for (int columna = 0; columna < 7; columna++)
                {
                    if (tablero[fila, columna] == VACIO)
                        return 0;
                }
            }
            return EMPATE;
        }

        /// <summary>
        /// Detecta en qué columna se introduce la ficha para verificar si se puede ingresar o no la ficha.
        /// También se encarga de ingresar la ficha en el juego del oponente.
        /// </summary>
        private void ClicEnTablero(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OponenteConectado && TurnoDeJuego)
                {
                    Button boton = (Button)sender;
                    int columna = int.Parse(boton.Name[1].ToString());
                    bool lleno = VerificarColumnaLlena(columna);
                    if (!lleno)
                    {
                        ReproducirSonidoFicha();
                        IntroducirFicha(columna, TIRO_PROPIO);
                        TurnoDeJuego = false;
                        servidor.InsertarFichaEnOponente(columna, codigoDePartida, Oponente);
                    }
                    else
                    {
                        NotificarColumnaLlena();
                    }
                }
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                NotificarDesconexionDeServidor();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CerrarConfirmacionPresencia();
                MusicaDePartida.Stop();
                MenuPrincipal.ReproducirMusica();
                this.Close();
            }
        }

        /// <summary>
        /// Muestra el mensaje de columna llena
        /// </summary>
        private static void NotificarColumnaLlena()
        {
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
                MessageBox.Show("Full column, selecto another one", "Full column", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Verifica que la columna a la que se le quiere ingresar la ficha no se encuentre llena.
        /// </summary>
        /// <param name="columna">La columna a la que se quiere ingresar la ficha</param>
        /// <returns>Regresa un booleano, true si la columna está llena, y false si sí se pueden meter fichas en esa columna</returns>
        private bool VerificarColumnaLlena(int columna)
        {
            if (tablero[0, columna - 1] != VACIO)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón del Chat.
        /// Abre un chat donde los mensajes son privados entre el jugador de la partida y el oponente.
        /// </summary>
        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            if (OponenteConectado)
            {
                Chat chat = new Chat(jugador, servidorDelChat, Oponente);
                try
                {
                    chat.ChatDePartida = true;
                    jugadorCallBack.SetChat(chat);
                    servidorDelChat.InicializarChat();
                    chat.Show();
                }
                catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                {
                    NotificarDesconexionDeServidor();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    CerrarConfirmacionPresencia();
                    MusicaDePartida.Stop();
                    MenuPrincipal.ReproducirMusica();
                    this.Close();
                }
            }
            else
            {
                NotificarOponenteNoConectado();
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de oponente conectado
        /// </summary>
        private static void NotificarOponenteNoConectado()
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
                MessageBox.Show("The opponent has not joined yet", "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Finaliza la partida, y elimina la partida del servidor.
        /// </summary>
        /// <param name="estadoDePartida">Recibe el estado de la partidam; si se ganó, se perdió, se empató, etc.</param>
        private void FinalizarPartida(EstadoPartida estadoDePartida)
        {
            timer.Stop();
            try
            {
                if (!OponenteConectado)
                {
                    servidor.EliminarPartida(codigoDePartida, jugador.usuario, estadoDePartida);
                }
                else if (estadoDePartida == EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite || estadoDePartida == EstadoPartida.FinDePartidaSalir)
                {
                    servidor.EliminarPartidaConGanador(codigoDePartida, jugador.usuario, estadoDePartida, 10, Oponente);
                }
                else if (estadoDePartida == EstadoPartida.FinDePartidaGanada)
                {
                    servidor.EliminarPartidaConGanador(codigoDePartida, jugador.usuario, estadoDePartida, 50, jugador.usuario);
                    Desconectar(estadoDePartida);
                }
                else if (estadoDePartida == EstadoPartida.FinDePartidaPorEmpate)
                {
                    servidor.EliminarPartida(codigoDePartida, jugador.usuario, estadoDePartida);
                    Desconectar(estadoDePartida);
                }
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                NotificarDesconexionDeServidor();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CerrarConfirmacionPresencia();
                MusicaDePartida.Stop();
                MenuPrincipal.ReproducirMusica();
                this.Close();
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Salir.
        /// </summary>
        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            MusicaDePartida.Stop();
            MenuPrincipal.ReproducirMusica();
            this.Close();
        }

        /// <summary>
        /// Muestra un mensaje dependiendo del valor del parámetro de estado de partida.
        /// Termina el juego completamente y detiene el monitoreo de presencia.
        /// </summary>
        /// <param name="estadoPartida">Contiene el estado de la partida, si se ganó, perdió, empató, etc.</param>
        public void Desconectar(EstadoPartida estadoPartida)
        {
            timer.Stop();
            CerrarConfirmacionPresencia();
            if (estadoPartida == EstadoPartida.FinDePartidaSalir)
            {
                NotificarPartidaGanadaPorOponenteSalio();
            }
            else if (estadoPartida == EstadoPartida.FinDePartidaPorTiempoDeEsperaLimite)
            {
                NotificarPartidaGanadaPorTiempo();
            }
            else if (estadoPartida == EstadoPartida.FinDePartidaGanada)
            {
                NotificarPartidaGanada();
            }
            else if (estadoPartida == EstadoPartida.FinDePartidaPerdida)
            {
                NotificarPartidaPerdida();
            }
            else if (estadoPartida == EstadoPartida.FinDePartidaPorEmpate)
            {
                NotificarEmpate();
            }
            MusicaDePartida.Stop();
            MenuPrincipal.ReproducirMusica();
            this.Close();
        }

        /// <summary>
        /// Muestra el mensaje de empate
        /// </summary>
        private static void NotificarEmpate()
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
                MessageBox.Show("Tie!", "Game finished", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Muestra el mensaje de partida perdida
        /// </summary>
        private static void NotificarPartidaPerdida()
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
                MessageBox.Show("You lose!", "Game finished", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Muestra el mensaje de partida ganada
        /// </summary>
        private static void NotificarPartidaGanada()
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
                MessageBox.Show("You win!", "Game finished", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Muestra el mensaje de partida ganada por tiempo
        /// </summary>
        private static void NotificarPartidaGanadaPorTiempo()
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
                MessageBox.Show("The opponent was inactive for too long, You win!", "Opponent inactive", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Muestar el mensaje de partida ganada por salida del oponente
        /// </summary>
        private static void NotificarPartidaGanadaPorOponenteSalio()
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
                MessageBox.Show("The opponent left the game, You win!", "Opponent left", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Cierra la ventana de confirmación de presencia
        /// </summary>
        private void CerrarConfirmacionPresencia()
        {
            if (confirmacionDePresencia != null && confirmacionDePresencia.IsActive)
                confirmacionDePresencia.Close();
        }

        /// <summary>
        /// Convierte un arreglo de bytes en una imagen para mostrarla en la Ventana de Juego.
        /// </summary>
        /// <param name="arrayDeImagen">Arreglo con los bytes de la imagen.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que se ejecuta cuando se cierra la ventana.
        /// Nos regresa al menú princpal y puede mostrar un mensaje dependiendo si se cumplen ciertos valores (oponente no se conectó)
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            if (!OponenteConectado)
            {
                NotificarOponenteNoConectado();
            }
            if (!partidaFinalizada)
            {
                FinalizarPartida(EstadoPartida.FinDePartidaSalir);
            }
            menuPrincipal.Show();
            CerrarConfirmacionPresencia();
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        public void ActualizarIdioma()
        {
            if (idioma == Idioma.Frances)
            {
                Title = "Jeu";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salirFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Espaniol)
            {
                Title = "Juego";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salir.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Title = "Jogo";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salirPO.png", UriKind.Relative));
            }
            if (idioma == Idioma.Ingles)
            {
                Title = "Game";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salirEN.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se activa la música.
        /// Detecta cuando termina la canción para reiniciarla y así hacer un loop.
        /// </summary>
        private void Media_Ended(object sender, EventArgs e)
        {
            MusicaDePartida.Position = TimeSpan.Zero;
            MusicaDePartida.Play();
        }

        /// <summary>
        /// Reproduce el sonido de la ficha al insertarla
        /// </summary>
        private void ReproducirSonidoFicha()
        {
            if (MenuPrincipal.EstadoSFX == MenuPrincipal.EFECTOS_ENCENDIDO)
            {
                SonidoDeFicha.Play();
            }
        }
    }
}