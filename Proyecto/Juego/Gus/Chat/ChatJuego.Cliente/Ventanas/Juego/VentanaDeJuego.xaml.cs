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

        const string RUTAFICHAAZUL = "Iconos/fichaAzul.png";
        const string RUTAFICHAROJA = "Iconos/fichaRoja.png";
        public const int TIROPROPIO = 1;
        public const int TIROOPONENTE = 2;

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
                } else
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
                        tablero[fila, columna - 1] = TIROPROPIO;
                        break;
                    }
                }
            }
           
        }

        private void ClicEnTablero(object sender, RoutedEventArgs e)
        {
            if (oponenteConectado == true)
            {
                Button boton = (Button)sender;
                int columna = int.Parse(boton.Name[1].ToString());
                IntroducirFicha(columna, TIROPROPIO);
                servidor.InsertarFichaEnOponente(columna, codigoDePartida, oponente);
            }
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            if (oponenteConectado == false)
            {
                MessageBox.Show("El oponente nunca se unió a la partida", "Error", MessageBoxButton.OK);
            }
            FinalizarPartida(EstadoPartida.FinDePartidaSalir);
            menuPrincipal.Show();
            CerrarConfirmacionDePresencia();
        }

        
    }
}
