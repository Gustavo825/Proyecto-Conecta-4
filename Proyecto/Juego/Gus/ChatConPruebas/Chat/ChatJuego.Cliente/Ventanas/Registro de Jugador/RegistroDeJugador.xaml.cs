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
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

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
            Actualizar_Idioma();
            this.servidor = servidor;
            this.inicioDeSesion = inicioDeSesion;
            this.contexto = contexto;
            servidorDeCorreo = new InvitacionCorreoServicioClient(this.contexto);
            codigoDeRegistro = EnviarInvitacion.GenerarCodigoDePartida();
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
                                if (idioma == Idioma.Espaniol)
                                {
                                    MessageBox.Show("Jugador registrado exitosamente", "Registro completado", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Frances)
                                {
                                    MessageBox.Show("Joueur enregistré avec succès", "Enregistrement complet", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Portugues)
                                {
                                    MessageBox.Show("Jogador registado com êxito", "Registro completo", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Ingles)
                                {
                                    MessageBox.Show("Player registered succesfully", "Register completed", MessageBoxButton.OK);
                                }
                                inicioDeSesion.Show();
                                this.Close();
                            }
                            else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorCorreo)
                            {
                                sonidoDeError.Play();
                                if (idioma == Idioma.Espaniol)
                                {
                                    MessageBox.Show("El correo ingresado ya se encuentra en uso", "Correo en uso", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Frances)
                                {
                                    MessageBox.Show("Le courriel est en utilisation", "Courriel en utilisation", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Portugues)
                                {
                                    MessageBox.Show("O correio introduzido já está sendo usado", "Correio em uso", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Ingles)
                                {
                                    MessageBox.Show("The email is already in use", "Email in use", MessageBoxButton.OK);
                                }
                            }
                            else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorUsuario)
                            {
                                sonidoDeError.Play();
                                if (idioma == Idioma.Espaniol)
                                {
                                    MessageBox.Show("El usuario ingresado ya se encuentra en uso", "Usuario en uso", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Frances)
                                {
                                    MessageBox.Show("Le nom de l'utilisateur est en utilisation", "Nom de l'utilisateur en utilisation", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Portugues)
                                {
                                    MessageBox.Show("O usuário introduzido já está sendo usado", "Usuáio em uso", MessageBoxButton.OK);
                                }
                                else if (idioma == Idioma.Ingles)
                                {
                                    MessageBox.Show("The user is already in use", "User in use", MessageBoxButton.OK);
                                }
                            }
                        }
                        else
                        {
                            sonidoDeError.Play();
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("El código de confirmación no coincide", "Error", MessageBoxButton.OK);
                            }
                            else if (idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Le code d'confirmation ne correspond", "Erreur", MessageBoxButton.OK);
                            }
                            else if (idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("O código introduzido não é correto", "Error", MessageBoxButton.OK);
                            }
                            else if (idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("The confirmation code does not match", "Error", MessageBoxButton.OK);
                            }
                            codigoDeRegistro = EnviarInvitacion.GenerarCodigoDePartida();
                        }
                    }
                    catch (EndpointNotFoundException endpointNotFoundException)
                    {
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("No se ha podido conectar con el servidor", "Error de conexión", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Le server ne peut connecter", "Échec de connexion", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Erro ao se conectar ao servidor", "Falha da conexão", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("The game was unable to connect with the server", "Connection error", MessageBoxButton.OK);
                        }
                        servidor = new ServidorClient(contexto);
                        servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                    }
                } else
                {
                    sonidoDeError.Play();
                    if (idioma == Idioma.Espaniol)
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Contraseñas no coinciden", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Frances)
                    {
                        MessageBox.Show("Les mots de passe ne correspond", "Mots de passe ne correspond", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Portugues)
                    {
                        MessageBox.Show("As senhas não são iguais", "Senhas não são iguais", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Ingles)
                    {
                        MessageBox.Show("The passwords code do not match", "Passwords don't match", MessageBoxButton.OK);
                    }
                }
            } else
            {
                sonidoDeError.Play();
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Il comprend formulaires en blanc", "Information tronquée", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Há campos vazios", "Campos incompletos", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
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
            if (idioma == Idioma.Espaniol)
            {
                OpenFileDialog ventanaSeleccionDeImagen = new OpenFileDialog
                {
                    Title = "Seleccione una imagen de jugador",
                    Filter = "Todos los formatos permitidos|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
                };
                if (ventanaSeleccionDeImagen.ShowDialog() == true)
                {
                    imagenJugador.Source = new BitmapImage(new Uri(ventanaSeleccionDeImagen.FileName));
                    ruta = ventanaSeleccionDeImagen.FileName;
                }
            }
            else if (idioma == Idioma.Frances)
            {
                OpenFileDialog ventanaSeleccionDeImagen = new OpenFileDialog
                {
                    Title = "Sélectionnez une image d'joueur",
                    Filter = "Tous les formats autorisés|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
                };
                if (ventanaSeleccionDeImagen.ShowDialog() == true)
                {
                    imagenJugador.Source = new BitmapImage(new Uri(ventanaSeleccionDeImagen.FileName));
                    ruta = ventanaSeleccionDeImagen.FileName;
                }
            }
            else if (idioma == Idioma.Portugues)
            {
                OpenFileDialog ventanaSeleccionDeImagen = new OpenFileDialog
                {
                    Title = "Selecione uma imagem para seu jogador",
                    Filter = "Todos os formatos permitidos|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
                };
                if (ventanaSeleccionDeImagen.ShowDialog() == true)
                {
                    imagenJugador.Source = new BitmapImage(new Uri(ventanaSeleccionDeImagen.FileName));
                    ruta = ventanaSeleccionDeImagen.FileName;
                }
            }
            else if (idioma == Idioma.Ingles)
            {
                OpenFileDialog ventanaSeleccionDeImagen = new OpenFileDialog
                {
                    Title = "Select an image for your account",
                    Filter = "All admitted formats|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
                };
                if (ventanaSeleccionDeImagen.ShowDialog() == true)
                {
                    imagenJugador.Source = new BitmapImage(new Uri(ventanaSeleccionDeImagen.FileName));
                    ruta = ventanaSeleccionDeImagen.FileName;
                }
            }
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_Registro_De_Jugador.Title = "Registro de Jugador";
                Titulo_Registro.Source = new BitmapImage(new Uri("Iconos/registro.png", UriKind.Relative));
                Boton_Imagen.Content = "Imagen";
                Texto_Usuario.Source = new BitmapImage(new Uri("Iconos/usuario.png", UriKind.Relative));
                Texto_Correo.Source = new BitmapImage(new Uri("Iconos/correo.png", UriKind.Relative));
                Texto_Contrasenia.Source = new BitmapImage(new Uri("Iconos/contrasenia.png", UriKind.Relative));
                Texto_Confirmar_Contrasenia.Source = new BitmapImage(new Uri("Iconos/confirmarContrasenia.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarse.png", UriKind.Relative));
                Boton_Cancelar.Source = new BitmapImage(new Uri("Iconos/botonCancelar.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_Registro_De_Jugador.Title = "Enregistrement du Joueur";
                Titulo_Registro.Source = new BitmapImage(new Uri("Iconos/tituloRegistroFR.png", UriKind.Relative));
                Boton_Imagen.Content = "Image";
                Texto_Usuario.Source = new BitmapImage(new Uri("Iconos/textoUsuarioFR.png", UriKind.Relative));
                Texto_Correo.Source = new BitmapImage(new Uri("Iconos/textoCorreoFR.png", UriKind.Relative));
                Texto_Contrasenia.Source = new BitmapImage(new Uri("Iconos/contraseniaFR.png", UriKind.Relative));
                Texto_Confirmar_Contrasenia.Source = new BitmapImage(new Uri("Iconos/confirmarContraseniaFR.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseFR.png", UriKind.Relative));
                Boton_Cancelar.Source = new BitmapImage(new Uri("Iconos/botonCancelarFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Registro_De_Jugador.Title = "Registo de Jogador";
                Titulo_Registro.Source = new BitmapImage(new Uri("Iconos/tituloRegistrarsePO.png", UriKind.Relative));
                Boton_Imagen.Content = "Foto";
                Texto_Usuario.Source = new BitmapImage(new Uri("Iconos/textoNombreDeUsuarioPO.png", UriKind.Relative));
                Texto_Correo.Source = new BitmapImage(new Uri("Iconos/textoCorreoPO.png", UriKind.Relative));
                Texto_Contrasenia.Source = new BitmapImage(new Uri("Iconos/textoContraseniaPO.png", UriKind.Relative));
                Texto_Confirmar_Contrasenia.Source = new BitmapImage(new Uri("Iconos/textoConfirmarContraseniaPO.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarsePO.png", UriKind.Relative));
                Boton_Cancelar.Source = new BitmapImage(new Uri("Iconos/botonCancelarPO.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Registro_De_Jugador.Title = "Player Register";
                Titulo_Registro.Source = new BitmapImage(new Uri("Iconos/registroIN.png", UriKind.Relative));
                Boton_Imagen.Content = "Image";
                Texto_Usuario.Source = new BitmapImage(new Uri("Iconos/usuarioIN.png", UriKind.Relative));
                Texto_Correo.Source = new BitmapImage(new Uri("Iconos/correoIN.png", UriKind.Relative));
                Texto_Contrasenia.Source = new BitmapImage(new Uri("Iconos/contraseniaIN.png", UriKind.Relative));
                Texto_Confirmar_Contrasenia.Source = new BitmapImage(new Uri("Iconos/confirmarContraseniaIN.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseIN.png", UriKind.Relative));
                Boton_Cancelar.Source = new BitmapImage(new Uri("Iconos/botonCancelarIN.png", UriKind.Relative));
            }
        }

    }
}
