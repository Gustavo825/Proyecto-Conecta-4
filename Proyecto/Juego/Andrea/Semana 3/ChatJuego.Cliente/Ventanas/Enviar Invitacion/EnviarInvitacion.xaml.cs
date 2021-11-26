using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using static ChatJuego.Cliente.MenuPrincipal;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para EnviarInvitacion.xaml
    /// </summary>
    public partial class EnviarInvitacion : Window
    {
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        SoundPlayer sonidoDeError = new SoundPlayer();
        InvitacionCorreoServicioClient servidorDeCorreo;
        InstanceContext contexto;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;
        bool perdidaDeConexion = false;

        public EnviarInvitacion(Jugador jugador, MenuPrincipal menuPrincipal, InstanceContext contexto)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            InitializeComponent();
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
            this.contexto = contexto;
            Actualizar_Idioma();
        }

        private void BotonDeEnviarInvitacion_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            if (!string.IsNullOrEmpty(TBUsuarioInvitacion.Text))
            {
                try
                {
                    servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                    var estado = servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = TBUsuarioInvitacion.Text }, GenerarCodigoDePartida().ToString(), jugador);
                    if (estado == EstadoDeEnvio.UsuarioNoEncontrado)
                    {
                        if(idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("The user does not exist", "User not found", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("El usuario ingresado no existe", "Usuario no encontrado", MessageBoxButton.OK);
                        }
                    }
                    else if (estado == EstadoDeEnvio.Fallido)
                    {
                        if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("Something happened and we coudln´t send the invitation", "Error", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error y no se pudo mandar la invitación", "Error", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        if(idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("Invitation sent", "Correct", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Invitación enviada", "Correcto", MessageBoxButton.OK);
                        }
                    }
                }
                catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                {
                    if (idioma == Idioma.Ingles)
                    {
                        MessageBox.Show("The connection with the server was lost", "Conenction lost", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                    }
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    perdidaDeConexion = true;
                    menuPrincipal.Close();
                    this.Close();
                }
            } else
            {
                sonidoDeError.Play();
                if(idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
                }
            }
        }

        public static int GenerarCodigoDePartida()
        {
            return new Random().Next(1000, 3000);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if (!perdidaDeConexion)
                menuPrincipal.Show();   
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Ingles)
            {
                Title = "Send Invitation";
                TituloVentanaEnvio.Source = new BitmapImage(new Uri("Iconos/envioInvitacionIN.png", UriKind.Relative));
                TextoIngresarUsuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioIN.png", UriKind.Relative));
                ImagenBotonEnviar.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionIN.png", UriKind.Relative));
            }
            else
            {
                Title = "Enviar Invitación";
                TituloVentanaEnvio.Source = new BitmapImage(new Uri("Iconos/envioInvitacion.png", UriKind.Relative));
                TextoIngresarUsuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuario.png", UriKind.Relative));
                ImagenBotonEnviar.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacion.png", UriKind.Relative));
            }
        }
    }
}
