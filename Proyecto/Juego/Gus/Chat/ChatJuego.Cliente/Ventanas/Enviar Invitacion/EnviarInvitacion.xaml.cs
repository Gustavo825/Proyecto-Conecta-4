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
    /// Lógica de interacción para EnviarInvitacion.xaml
    /// </summary>
    public partial class EnviarInvitacion : Window
    {
        InvitacionCorreoServicioClient servidorCorreo;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;

        public EnviarInvitacion(Proxy.InvitacionCorreoServicioClient servidorCorreo, Jugador jugador, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
            this.servidorCorreo = servidorCorreo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBUsuarioInvitacion.Text))
            {
                var estado = servidorCorreo.enviarInvitacion(new Jugador() { usuario = TBUsuarioInvitacion.Text }, generarCodigoDePartida().ToString(), jugador);
                if (estado == EstadoDeEnvio.UsuarioNoEncontrado)
                {
                    MessageBox.Show("El usuario ingresado no existe", "Usuario no encontrado", MessageBoxButton.OK);
                } else if (estado == EstadoDeEnvio.Fallido)
                {
                    MessageBox.Show("Ocurrió un error y no se pudo mandar la invitación", "Error", MessageBoxButton.OK);
                } else
                {

                    MessageBox.Show("Invitación enviada", "Correcto", MessageBoxButton.OK);

                }
            }
        }

        public static int generarCodigoDePartida()
        {
            return new Random().Next(1000, 3000);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.Show();
        }
    }
}
