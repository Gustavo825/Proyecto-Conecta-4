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

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para RegistroDeJugador.xaml
    /// </summary>
    public partial class RegistroDeJugador : Window
    {
        SoundPlayer sonidoBoton = new SoundPlayer();
        SoundPlayer sonidoError = new SoundPlayer();
        private ServidorClient servidor;
        private InvitacionCorreoServicioClient servidorCorreo;
        private InstanceContext contexto;
        private MainWindow inicioDeSesion;
        private int codigoDeRegistro;
        string ruta = "pack://application:,,,/ChatJuego.Cliente;component/Ventanas/Registro de Jugador/Iconos/imagenPredeterminada.png";
        public RegistroDeJugador(ServidorClient servidor, MainWindow inicioDeSesion, System.ServiceModel.InstanceContext contexto)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            InitializeComponent();
            this.servidor = servidor;
            this.inicioDeSesion = inicioDeSesion;
            this.contexto = contexto;
            servidorCorreo = new InvitacionCorreoServicioClient(this.contexto);
            codigoDeRegistro = EnviarInvitacion.generarCodigoDePartida();
        }

        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBCorreoR.Text) && !string.IsNullOrEmpty(TBContraseniaRegistro.Password) && 
                !string.IsNullOrEmpty(TBContraseniaRegistroConfirmacion.Password) && !string.IsNullOrEmpty(TBUsuarioR.Text)) {
                if (TBContraseniaRegistro.Password == TBContraseniaRegistroConfirmacion.Password) {
                    servidorCorreo.mandarCodigoDeRegistro(codigoDeRegistro.ToString(), TBCorreoR.Text);
                    RegistroDeJugador_InputDeCodigo ventanaDeConfirmacion = new RegistroDeJugador_InputDeCodigo(codigoDeRegistro);
                    var valor = ventanaDeConfirmacion.ShowDialog();
                    if (valor == true)
                    {
                        var estadoDeRegistro = servidor.registroJugador(TBUsuarioR.Text, TBContraseniaRegistro.Password, TBCorreoR.Text, convertirImagenABytes());
                        if (estadoDeRegistro == EstadoDeRegistro.Correcto)
                        {
                            sonidoBoton.Play();
                            MessageBox.Show("Jugador registrado exitosamente", "Registro completado", MessageBoxButton.OK);
                            inicioDeSesion.Show();
                            this.Close();
                        }
                        else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorCorreo)
                        {
                            sonidoError.Play();
                            MessageBox.Show("El correo ingresado ya se encuentra en uso", "Correo en uso", MessageBoxButton.OK);
                        }
                        else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorUsuario)
                        {
                            sonidoError.Play();
                            MessageBox.Show("El usuario ingresado ya se encuentra en uso", "Usuario en uso", MessageBoxButton.OK);
                        }
                    } else
                    {
                        sonidoError.Play();
                        MessageBox.Show("El código de confirmación no coincide", "Error", MessageBoxButton.OK);
                        codigoDeRegistro = EnviarInvitacion.generarCodigoDePartida();
                    }
                } else
                {
                    sonidoError.Play();
                    MessageBox.Show("Las contraseñas no coinciden", "Contraseñas no coinciden", MessageBoxButton.OK);
                }
            } else
            {
                sonidoError.Play();
                MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);

            }


        }

       

        private void BotonCancelar(object sender, RoutedEventArgs e)
        {
            sonidoBoton.Play();
            inicioDeSesion.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            inicioDeSesion.Show();
        }

        private byte[] convertirImagenABytes()
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
            sonidoBoton.Play();
            OpenFileDialog ventanaSeleccionDeImagen = new OpenFileDialog();
            ventanaSeleccionDeImagen.Title = "Seleccione una imagen de jugador";
            ventanaSeleccionDeImagen.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (ventanaSeleccionDeImagen.ShowDialog() == true)
            {
                imagenJugador.Source = new BitmapImage(new Uri(ventanaSeleccionDeImagen.FileName));
                ruta = ventanaSeleccionDeImagen.FileName;
            }
        }
    }
}
