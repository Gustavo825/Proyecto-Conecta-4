using ChatJuego.Cliente.Proxy;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private Jugador jugador;
        private ChatServicioClient servidorDelChat;
        private bool MensajePrivado { get; set; }
        private bool Error { get; set; }
        private Label jugadorPrivadoSeleccionado;
        public MenuPrincipal menuPrincipal;
        public bool ChatDePartida { get; set; }
        public string NombreJugadorInvitado { get; set; }

        public TextBox ContenedorDelMensaje
        {
            get { return ContenidoDelMensaje; }
            set { ContenidoDelMensaje = value; }
        }

        public Chat(Jugador jugador, ChatServicioClient servidorDelChat, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            MensajePrivado = false;
            Error = false;
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.menuPrincipal = menuPrincipal;
            ChatDePartida = false;
            ActualizarIdioma();

        }

        public Chat(Jugador jugador, ChatServicioClient servidorDelChat, string oponente)
        {
            InitializeComponent();
            MensajePrivado = false;
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.NombreJugadorInvitado = oponente;
            ChatDePartida = false;
            ActualizarIdioma();
        }

        /// <summary>
        /// Método para obtener el Jugador recibido en el Chat
        /// </summary>
        /// <returns>Regresa el jugador</returns>
        public Jugador GetJugador()
        {
            return jugador;
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón Enviar de la GUI y envía el mensaje escrito en la caja de texto
        /// </summary>
        private void BotonEnviar_Click(object sender, RoutedEventArgs e)
        {
            ScrollerContenido.ScrollToBottom();
            if (!string.IsNullOrWhiteSpace(ContenidoDelMensaje.Text))
            {
                string mensajeFinal;
                if (ContenedorDelMensaje.Text.Length > 36)
                {
                    int tamanioMensaje = ContenedorDelMensaje.Text.Length;
                    mensajeFinal = ContenedorDelMensaje.Text.Substring(0, 30);
                    mensajeFinal += System.Environment.NewLine;
                    mensajeFinal += ContenedorDelMensaje.Text.Substring(31, tamanioMensaje - 32);

                }
                else
                {
                    mensajeFinal = ContenedorDelMensaje.Text;
                }
                try
                {
                    if (MensajePrivado && !ChatDePartida)
                    {
                        MandarMensajePrivado(mensajeFinal);
                    }
                    else if (!ChatDePartida)
                    {

                        Mensaje mensaje = new Mensaje() { ContenidoMensaje = mensajeFinal, TiempoDeEnvio = DateTime.Now };
                        servidorDelChat.MandarMensaje(mensaje, jugador);
                        PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
                        ContenidoDelMensaje.Clear();
                    }
                    else if (ChatDePartida)
                    {
                        string mensaje = "Mensaje de partida: " + mensajeFinal;
                        servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, NombreJugadorInvitado, jugador);
                        PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                        ContenidoDelMensaje.Clear();
                    }
                }
                catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                {
                    NotificarErrorDeConexion();
                    menuPrincipal.DesconexionDelServidor = true;
                    menuPrincipal.Close();
                    Error = true;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de conexión al servidor
        /// </summary>
        private static void NotificarErrorDeConexion()
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
        /// Manda un mensaje privado al usuario seleccionado
        /// </summary>
        /// <param name="mensajeFinal">Contiene el mensaje final</param>
        private void MandarMensajePrivado(string mensajeFinal)
        {
            try
            {
                if (idioma == Idioma.Ingles)
                {
                    string mensaje = "Private message: " + mensajeFinal;
                    servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                    PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                    MensajePrivado = false;
                    jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                    ContenidoDelMensaje.Clear();
                }
                else if (idioma == Idioma.Espaniol)
                {
                    string mensaje = "Mensaje privado: " + mensajeFinal;
                    servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                    PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                    MensajePrivado = false;
                    jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                    ContenidoDelMensaje.Clear();
                }
                else if (idioma == Idioma.Portugues)
                {
                    string mensaje = "Mensagem privada: " + mensajeFinal;
                    servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                    PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                    MensajePrivado = false;
                    jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                    ContenidoDelMensaje.Clear();
                }
                else if (idioma == Idioma.Frances)
                {
                    string mensaje = "Message privé: " + mensajeFinal;
                    servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                    PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                    MensajePrivado = false;
                    jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                    ContenidoDelMensaje.Clear();
                }
            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                NotificarErrorDeConexion();
                menuPrincipal.DesconexionDelServidor = true;
                menuPrincipal.Close();
                Error = true;
                this.Close();
            }
        }

        /// <summary>
        /// Activa el envío de mensajes privados al usuario seleccionado
        /// </summary>

        private void ClickEnLabelDeJugador_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label texto = sender as Label;
            jugadorPrivadoSeleccionado = texto;
            texto.Foreground = new SolidColorBrush(Colors.Red);
            MensajePrivado = true;
        }

        /// <summary>
        /// Detecta cuando se presiona la tecla "Enter" para enviar el mensaje
        /// </summary>

        private void ContenidoDelMensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BotonEnviar_Click(new object(), new RoutedEventArgs());
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/Enviar.png", UriKind.Relative));
                Titulo.Content = "conectado";
                Jugadores_Conectados.Content = "jugadores conectados";
            }
            else if (idioma == Idioma.Frances)
            {
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/EnviarFR.png", UriKind.Relative));
                Titulo.Content = "connecte";
                Jugadores_Conectados.Content = "joueurs connectes";
            }
            else if (idioma == Idioma.Portugues)
            {
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/EnviarPO.png", UriKind.Relative));
                Titulo.Content = "conectado";
                Jugadores_Conectados.Content = "jogadores conectados";
            }
            else if (idioma == Idioma.Ingles)
            {
                Jugadores_Conectados.Content = "Players Online";
                Titulo.Content = "Online";
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/botonEnviarIN.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se cierra el chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ChatDePartida && !Error)
                menuPrincipal.Show();
        }
    }
}