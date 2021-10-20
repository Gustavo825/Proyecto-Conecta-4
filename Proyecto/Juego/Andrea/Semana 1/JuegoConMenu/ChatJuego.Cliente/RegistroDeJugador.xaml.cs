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
    /// Lógica de interacción para RegistroDeJugador.xaml
    /// </summary>
    public partial class RegistroDeJugador : Window
    {
        private ChatServicioClient servidor;
        private MainWindow inicioDeSesion;
        public RegistroDeJugador(ChatServicioClient servidor, MainWindow inicioDeSesion)
        {
            InitializeComponent();
            this.servidor = servidor;
            this.inicioDeSesion = inicioDeSesion;
        }

        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBCorreoR.Text) && !string.IsNullOrEmpty(TBContraseniaRegistro.Password) && 
                !string.IsNullOrEmpty(TBContraseniaRegistroConfirmacion.Password) && !string.IsNullOrEmpty(TBUsuarioR.Text)) {
                if (TBContraseniaRegistro.Password == TBContraseniaRegistroConfirmacion.Password) {
                    var estadoDeRegistro = servidor.registroJugador(TBUsuarioR.Text, TBContraseniaRegistro.Password,TBCorreoR.Text);
                    if (estadoDeRegistro == EstadoDeRegistro.Correcto)
                    {
                        MessageBox.Show("Jugador registrado exitosamente", "Registro completado", MessageBoxButton.OK);
                        inicioDeSesion.Show();
                        this.Close();
                    } else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorCorreo)
                    {
                        MessageBox.Show("El correo ingresado ya se encuentra en uso", "Correo en uso", MessageBoxButton.OK);
                    } else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorUsuario)
                    {
                        MessageBox.Show("El usuario ingresado ya se encuentra en uso", "Usuario en uso", MessageBoxButton.OK);
                    }
                } else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Contraseñas no coinciden", MessageBoxButton.OK);
                }
            } else
            {
                MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);

            }

        }

        private void BotonCancelar(object sender, RoutedEventArgs e)
        {
            inicioDeSesion.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            inicioDeSesion.Show();
        }
    }
}
