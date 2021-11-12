using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
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

namespace ChatJuego.Cliente.Ventanas.Juego
{
    /// <summary>
    /// Lógica de interacción para VentanaDeJuego.xaml
    /// </summary>
    public partial class VentanaDeJuego : Window
    {
        InstanceContext contexto;
        public string oponente { get; set; }
        MenuPrincipal MenuPrincipal;
        ServidorClient servidor;
        Jugador jugador;
        ChatServicioClient servidorDelChat;
        JugadorCallBack jugadorCallBack;
        string codigoDePartida;
        public bool oponenteConectado { get; set; }
        public VentanaDeJuego(InstanceContext contexto, MenuPrincipal menuPrincipal, Jugador jugador, ChatServicioClient servidorDelChat, string codigoDePartida, JugadorCallBack jugadorCallBack, ServidorClient servidor)
        {
            InitializeComponent();
            this.contexto = contexto;
            this.MenuPrincipal = menuPrincipal;
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.codigoDePartida = codigoDePartida;
            this.jugadorCallBack = jugadorCallBack;
            this.servidor = servidor;
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
                    this.Close();
                }
            } else
            {
                MessageBox.Show("El oponente aún no se conecta a la partida", "Error", MessageBoxButton.OK);
            }
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
