using ChatJuego.Cliente.Proxy;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para RegistroDeJugador.xaml
    /// </summary>
    public partial class RegistroDeJugador : Window
    {
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        SoundPlayer sonidoDeError = new SoundPlayer();
        private ServidorClient servidor;
        private InvitacionCorreoServicioClient servidorDeCorreo;
        private InstanceContext contexto;
        private MainWindow inicioDeSesion;
        private int codigoDeRegistro;
        string ruta = "pack://application:,,,/ChatJuego.Cliente;component/Ventanas/Registro de Jugador/Iconos/imagenPredeterminada.png";
       
        public RegistroDeJugador(ServidorClient servidor, MainWindow inicioDeSesion, InstanceContext contexto)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            InitializeComponent();
            this.servidor = servidor;
            this.inicioDeSesion = inicioDeSesion;
            this.contexto = contexto;
            servidorDeCorreo = new InvitacionCorreoServicioClient(this.contexto);
            codigoDeRegistro = EnviarInvitacion.GenerarCodigoDePartida();
            Actualizar_Idioma();
        }

        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBCorreoR.Text) && !string.IsNullOrEmpty(TBContraseniaRegistro.Password) && 
                !string.IsNullOrEmpty(TBContraseniaRegistroConfirmacion.Password) && !string.IsNullOrEmpty(TBUsuarioR.Text)) {
                if (TBContraseniaRegistro.Password == TBContraseniaRegistroConfirmacion.Password) {
                    try
                    {
                        servidorDeCorreo.MandarCodigoDeRegistro(codigoDeRegistro.ToString(), TBCorreoR.Text);
                        RegistroDeJugador_InputDeCodigo ventanaDeConfirmacion = new RegistroDeJugador_InputDeCodigo(codigoDeRegistro);
                        var valor = ventanaDeConfirmacion.ShowDialog();
                        if (valor == true)
                        {

                            var estadoDeRegistro = servidor.RegistroDeJugador(TBUsuarioR.Text, TBContraseniaRegistro.Password, TBCorreoR.Text, ConvertirImagenABytes());
                            if (estadoDeRegistro == EstadoDeRegistro.Correcto)
                            {
                                sonidoDeBoton.Play();
                                if (idioma == Idioma.Ingles)
                                {
                                    MessageBox.Show("Player registered succesfully", "Register completed", MessageBoxButton.OK);
                                }
                                else
                                {
                                    MessageBox.Show("Jugador registrado exitosamente", "Registro completado", MessageBoxButton.OK);
                                }
                                inicioDeSesion.Show();
                                this.Close();
                            }
                            else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorCorreo)
                            {
                                sonidoDeError.Play();
                                if(idioma == Idioma.Ingles)
                                {
                                    MessageBox.Show("The email is already in use", "Email in use", MessageBoxButton.OK);
                                }
                                else
                                {
                                    MessageBox.Show("El correo ingresado ya se encuentra en uso", "Correo en uso", MessageBoxButton.OK);
                                }
                            }
                            else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorUsuario)
                            {
                                sonidoDeError.Play();
                                if (idioma == Idioma.Ingles)
                                {
                                    MessageBox.Show("The user is already in use", "User in use", MessageBoxButton.OK);
                                }
                                else
                                {
                                    MessageBox.Show("El usuario ya se encuentra en uso", "Usuario en uso", MessageBoxButton.OK);
                                }
                            }
                        }
                        else
                        {
                            sonidoDeError.Play();
                            if (idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("The confirmation code does not match", "Error", MessageBoxButton.OK);
                            }
                            else
                            {
                                MessageBox.Show("El código de confirmación no coincide", "Error", MessageBoxButton.OK);
                            }
                            codigoDeRegistro = EnviarInvitacion.GenerarCodigoDePartida();
                        }
                    }
                    catch (EndpointNotFoundException endpointNotFoundException)
                    {
                        if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("The game was unable to connect with the server", "Connection error", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido conectar con el servidor", "Error de conexión", MessageBoxButton.OK);
                        }
                        servidor = new ServidorClient(contexto);
                        servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                    }
                } else
                {
                    sonidoDeError.Play();
                    if (idioma == Idioma.Ingles)
                    {
                        MessageBox.Show("The passwords code do not match", "Error", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButton.OK);
                    }
                }
            } else
            {
                sonidoDeError.Play();
                if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
                }

            }


        }

       

        private void BotonCancelar(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            inicioDeSesion.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            inicioDeSesion.Show();
        }

        private byte[] ConvertirImagenABytes()
        {
            MemoryStream ms = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            BitmapImage imagenFinal = new BitmapImage();
            imagenFinal.BeginInit();
            imagenFinal.UriSource = new Uri(ruta);
            imagenFinal.DecodePixelHeight = 200;
            imagenFinal.DecodePixelWidth = 200;
            imagenFinal.EndInit();
            encoder.Frames.Add(BitmapFrame.Create(imagenFinal));
            encoder.Save(ms);
            return ms.ToArray();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            OpenFileDialog ventanaSeleccionDeImagen = new OpenFileDialog
            {
                Title = "Seleccione una imagen de jugador",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
            };
            if (ventanaSeleccionDeImagen.ShowDialog() == true)
            {
                imagenJugador.Source = new BitmapImage(new Uri(ventanaSeleccionDeImagen.FileName));
                ruta = ventanaSeleccionDeImagen.FileName;
            }
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Ingles)
            {
                Titulo.Title = "Player Register";
                TituloVentanaRegistro.Source = new BitmapImage(new Uri("Iconos/registroIN.png", UriKind.Relative));
                BotonImagen.Content = "Image";
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioIN.png", UriKind.Relative));
                TextoCorreo.Source = new BitmapImage(new Uri("Iconos/correoIN.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/contraseniaIN.png", UriKind.Relative));
                TextoConfirmarContrasenia.Source = new BitmapImage(new Uri("Iconos/confirmarContraseniaIN.png", UriKind.Relative));
                ImagenBotonRegistrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseIN.png", UriKind.Relative));
                ImagenBotonCancelar.Source = new BitmapImage(new Uri("Iconos/botonCancelarIN.png", UriKind.Relative));

            }
            else
            {
                Titulo.Title = "Registro de Jugador";
                TituloVentanaRegistro.Source = new BitmapImage(new Uri("Iconos/registro.png", UriKind.Relative));
                BotonImagen.Content = "Image";
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioIN.png", UriKind.Relative));
                TextoCorreo.Source = new BitmapImage(new Uri("Iconos/correo.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/contraseniaIN.png", UriKind.Relative));
                TextoConfirmarContrasenia.Source = new BitmapImage(new Uri("Iconos/confirmarContraseniaIN.png", UriKind.Relative));
                ImagenBotonRegistrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseIN.png", UriKind.Relative));
                ImagenBotonCancelar.Source = new BitmapImage(new Uri("Iconos/botonCancelarIN.png", UriKind.Relative));
            }
        }
    }
}
