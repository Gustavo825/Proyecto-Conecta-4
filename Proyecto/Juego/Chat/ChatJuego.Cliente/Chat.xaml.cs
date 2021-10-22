using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private Jugador jugador;
        private ChatServicioClient servidor;
        private bool mensajePrivado = false;
        private Label jugadorPrivadoSeleccionado;

        
        public ScrollViewer VistaDeContenidoDeScroll
        {
            get { return ScrollerContenido; }
            set { ScrollerContenido = value; }
        }

        public TextBox ContenedorDelMensaje
        {
            get { return ContenidoDelMensaje; }
            set { ContenidoDelMensaje = value; }
        }

        public ItemsControl PantallaDeMensajes
        {
            get { return PlantillaMensaje; }
            set { PlantillaMensaje = value; }
        }
     

        public Label TituloDeMensaje
        {
            get { return Titulo; }
            set { Titulo = value; }
        }

        public Chat(Jugador jugador, ChatServicioClient servidor)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.servidor = servidor;
            Titulo.Content = "Bienvenid@ al chat " + jugador.usuario;

        }

        public Jugador getJugador()
        {
            return jugador;
        }



        private void BotonEnviar_Click(object sender, RoutedEventArgs e)
        {
            ScrollerContenido.ScrollToBottom();
            if (!string.IsNullOrEmpty(ContenidoDelMensaje.Text))
            {
                string mensajeFinal;
                if (ContenedorDelMensaje.Text.Length > 36)
                {
                    int tamanioMensaje = ContenedorDelMensaje.Text.Length;
                    mensajeFinal = ContenedorDelMensaje.Text.Substring(0, 30);
                    mensajeFinal += System.Environment.NewLine;
                    mensajeFinal += ContenedorDelMensaje.Text.Substring(31,tamanioMensaje - 32);
                    
                } else
                {
                    mensajeFinal = ContenedorDelMensaje.Text;
                }
                if (mensajePrivado)
                {
                    string mensaje = "Mensaje privado: " + mensajeFinal;
                    PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                    servidor.mandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString());
                    mensajePrivado = false;
                    jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                    ContenidoDelMensaje.Clear();
                }
                else
                {
                    Mensaje mensaje = new Mensaje() { ContenidoMensaje = mensajeFinal, TiempoDeEnvio = DateTime.Now };
                    PlantillaMensaje.Items.Add(new {Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
                    servidor.mandarMensaje(mensaje);
                    ContenidoDelMensaje.Clear();
                }
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label texto = sender as Label;
            jugadorPrivadoSeleccionado = texto;
            texto.Foreground = new SolidColorBrush(Colors.Red);
            mensajePrivado = true;
        }

      
        private void ContenidoDelMensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BotonEnviar_Click(new object(), new RoutedEventArgs());
        }
    }
}