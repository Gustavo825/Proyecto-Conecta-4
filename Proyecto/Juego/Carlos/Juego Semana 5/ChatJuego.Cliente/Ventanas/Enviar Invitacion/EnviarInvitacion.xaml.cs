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
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

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
        public static Idioma idiomaEnvioInvitacion = Idioma.Espaniol;

        public EnviarInvitacion(Jugador jugador, MenuPrincipal menuPrincipal, InstanceContext contexto)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            InitializeComponent();
            Actualizar_Idioma();
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
            this.contexto = contexto;
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
                        if (idiomaEnvioInvitacion == Idioma.Espaniol)
                        {
                            MessageBox.Show("El usuario ingresado no existe", "Usuario no encontrado", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("The user does not exist", "User not found", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Cet utilisateur n'existe pas", "Utilisateur n'est pas trouvée", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("O usuário não existe", "Usuário não encontrado", MessageBoxButton.OK);
                        }
                    }
                    else if (estado == EstadoDeEnvio.Fallido)
                    {
                        if (idiomaEnvioInvitacion == Idioma.Espaniol)
                        {
                            MessageBox.Show("Ocurrió un error y no se pudo mandar la invitación", "Error", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("Something happened and we coudln´t send the invitation", "Error", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Something happened and we coudln´t send the invitation", "Erreur", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Acountecou um error e a convite não pudo ser enviada", "Error", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        if (idiomaEnvioInvitacion == Idioma.Espaniol)
                        {
                            MessageBox.Show("Invitación enviada", "Correcto", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("Invitation sent", "Correct", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Invitation adressée", "Correct", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Convite enviada", "Correct", MessageBoxButton.OK);
                        }
                    }
                }
                catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                {
                    if (idiomaEnvioInvitacion == Idioma.Espaniol)
                    {
                        MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                    }
                    else if (idiomaEnvioInvitacion == Idioma.Ingles)
                    {
                        MessageBox.Show("The connection with the server was lost", "Connection lost", MessageBoxButton.OK);
                    }
                    else if (idiomaEnvioInvitacion == Idioma.Frances)
                    {
                        MessageBox.Show("La connexion au serveur été perdue", "Connexion perdue", MessageBoxButton.OK);
                    }
                    else if (idiomaEnvioInvitacion == Idioma.Portugues)
                    {
                        MessageBox.Show("A conexão foi perdida", "Conexão perdida", MessageBoxButton.OK);
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
                if (idiomaEnvioInvitacion == Idioma.Espaniol)
                {
                    MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
                }
                else if (idiomaEnvioInvitacion == Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
                }
                else if (idiomaEnvioInvitacion == Idioma.Frances)
                {
                    MessageBox.Show("Entrez les information requises", "Information tronquée", MessageBoxButton.OK);
                }
                else if (idiomaEnvioInvitacion == Idioma.Portugues)
                {
                    MessageBox.Show("Ingresse os datos requeridos", "Campos incompletos", MessageBoxButton.OK);
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
            if (idiomaEnvioInvitacion == Idioma.Espaniol)
            {
                Ventana_Envio_Invitacion.Title = "Enviar Invitación";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacion.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuario.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacion.png", UriKind.Relative));
            }
            else if (idiomaEnvioInvitacion == Idioma.Frances)
            {
                Ventana_Envio_Invitacion.Title = "Envoyer Invitation";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionFR.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioFR.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionFR.png", UriKind.Relative));
            }
            else if (idiomaEnvioInvitacion == Idioma.Portugues)
            {
                Ventana_Envio_Invitacion.Title = "Enviar Convite";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionPO.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioPO.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionPO.png", UriKind.Relative));
            }
            else if (idiomaEnvioInvitacion == Idioma.Ingles)
            {
                Ventana_Envio_Invitacion.Title = "Send Invitation";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionIN.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioIN.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionIN.png", UriKind.Relative));
            }
        }
    }
}
