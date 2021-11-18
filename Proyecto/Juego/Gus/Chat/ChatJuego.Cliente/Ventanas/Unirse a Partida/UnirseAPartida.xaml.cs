using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;
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

namespace ChatJuego.Cliente.Ventanas.Unirse_a_Partida
{
    /// <summary>
    /// Lógica de interacción para UnirseAPartida.xaml
    /// </summary>
    public partial class UnirseAPartida : Window
    {
        ChatServicioClient servidorDelChat;
        InstanceContext contexto;
        JugadorCallBack jugadorCallBack;
        ServidorClient servidor;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;
        bool unionCorrectaAPartida = false;
        public UnirseAPartida(Jugador jugador, MenuPrincipal menuPrincipal, InstanceContext contexto, ChatServicioClient servidorDelChat, JugadorCallBack callBackDeJugador, ServidorClient servidor)
        {
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.contexto = contexto;
            this.jugadorCallBack = callBackDeJugador;
            this.menuPrincipal = menuPrincipal;
            this.servidor = servidor;
            InitializeComponent();
        }

        private void BotonDeUnirseAPartida_Click(object sender, RoutedEventArgs e)
        {
           if (!string.IsNullOrEmpty(TBUsuarioInvitacion.Text))
            {
                EstadoUnirseAPartida estado = servidor.UnirseAPartida(jugador, TBUsuarioInvitacion.Text);
                if (estado == EstadoUnirseAPartida.Correcto)
                {
                    unionCorrectaAPartida = true;
                    VentanaDeJuego ventanDeJuego = new VentanaDeJuego(contexto, menuPrincipal, jugador, servidorDelChat, TBUsuarioInvitacion.Text, jugadorCallBack, servidor);
                    jugadorCallBack.SetVentanaDeJuego(ventanDeJuego);
                    ventanDeJuego.Show();
                    ventanDeJuego.turnoDeJuego = false;
                    unionCorrectaAPartida = true;
                    servidor.InicializarPartida(TBUsuarioInvitacion.Text);
                    this.Close();
                } else if (estado == EstadoUnirseAPartida.FallidoPorPartidaNoEncontrada)
                {
                    MessageBox.Show("Partida no encontrada", "Error", MessageBoxButton.OK);
                } else if (estado == EstadoUnirseAPartida.FallidoPorMaximoDeJugadores)
                {
                    MessageBox.Show("Máximo de jugadores en la partida", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (unionCorrectaAPartida == false)
                menuPrincipal.Show();
        }
    }
}
