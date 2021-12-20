using ChatJuego.Cliente.Proxy;
using Microsoft.Win32;
using System;
using System.IO;
using System.Media;
using System.ServiceModel;
using System.Windows;
using System.Windows.Media.Imaging;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para RegistroDeJugador.xaml
    /// </summary>
    public partial class RegistroDeJugador : Window
    {
        private SoundPlayer sonidoDeBoton = new SoundPlayer();
        private SoundPlayer sonidoDeError = new SoundPlayer();
        private ServidorClient servidor;
        private InvitacionCorreoServicioClient servidorDeCorreo;
        private InstanceContext contexto;
        private MainWindow inicioDeSesion;
        private int codigoDeRegistro;
        private string ruta;

        public RegistroDeJugador(ServidorClient servidor, MainWindow inicioDeSesion, InstanceContext contexto)
        {
            ruta = "Iconos/imagenPredeterminada.png";
            InitializeComponent();
            imagenJugador.Source = new BitmapImage(new Uri(ruta, UriKind.Relative));
            ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            ruta += @"Ventanas/Registro de Jugador/Iconos/imagenPredeterminada.png";
            ActualizarIdioma();
            this.servidor = servidor;
            this.inicioDeSesion = inicioDeSesion;
            this.contexto = contexto;
            servidorDeCorreo = new InvitacionCorreoServicioClient(this.contexto);
            codigoDeRegistro = EnviarInvitacion.GenerarCodigoDePartida();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Registrarse.
        /// Se crea un código de registro que se envía por correo para ser ingresado por el usuario a registrarse.
        /// Verifica que el código ingresado sea el correcto.
        /// </summary>
        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TBCorreoR.Text) && !string.IsNullOrWhiteSpace(TBContraseniaRegistro.Password) &&
                !string.IsNullOrWhiteSpace(TBContraseniaRegistroConfirmacion.Password) && !string.IsNullOrWhiteSpace(TBUsuarioR.Text))
            {
                if (ValidarCorreo(TBCorreoR.Text))
                {
                    if (TBContraseniaRegistro.Password == TBContraseniaRegistroConfirmacion.Password)
                    {
                        try
                        {
                            EstadoDeEnvio estado = servidorDeCorreo.MandarCodigoDeRegistro(codigoDeRegistro.ToString(), TBCorreoR.Text);
                            if (estado == EstadoDeEnvio.Fallido)
                            {
                                NotificarErrorDeEnvioDeCorreo();
                            }
                            else
                            {
                                RegistroDeJugador_InputDeCodigo ventanaDeConfirmacion = new RegistroDeJugador_InputDeCodigo(codigoDeRegistro);
                                var valor = ventanaDeConfirmacion.ShowDialog();
                                if (valor == true)
                                {
                                    var estadoDeRegistro = servidor.RegistroDeJugador(TBUsuarioR.Text, TBContraseniaRegistro.Password, TBCorreoR.Text, ConvertirImagenABytes());
                                    if (estadoDeRegistro == EstadoDeRegistro.Correcto)
                                    {
                                        NotificarRegistroExitoso();
                                        inicioDeSesion.Show();
                                        this.Close();
                                    }
                                    else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorCorreo)
                                    {
                                        NotificarCorreoYaRegistrado();
                                    }
                                    else if (estadoDeRegistro == EstadoDeRegistro.FallidoPorUsuario)
                                    {
                                        NotificarFallidoPorUsuarioRegistrado();
                                    }
                                }
                                else
                                {
                                    NotificarCodigoErroneo();
                                    codigoDeRegistro = EnviarInvitacion.GenerarCodigoDePartida();
                                }
                            }

                        }
                        catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                        {
                            sonidoDeError.Play();
                            NotificarDesconexionDeServidor();
                            servidor = new ServidorClient(contexto);
                            servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                        }
                    }
                    else
                    {
                        sonidoDeError.Play();
                        NotificarContraseniasNoCoinciden();
                    }
                } else
                {
                    NotificarCorreoInvalido();
                }
                
            }
            else
            {
                sonidoDeError.Play();
                NotificarCamposVacios();
            }
        }

        /// <summary>
        /// Muestra el mensaje de correo invalido
        /// </summary>
        private void NotificarCorreoInvalido()
        {
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("El correo ingresado no es valido", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("Courriel non valide", "Erreur", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("Correio inválido", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("Invalid email", "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Valida el correo ingresado
        /// </summary>
        /// <param name="email">Correo ingresado</param>
        /// <returns>Se regresa true si el corero es valido, false si es invalido</returns>
        private bool ValidarCorreo(string email)
        {
            string emailPorPartes = email.Trim();
            bool valido;
            valido = emailPorPartes.EndsWith(".");
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                valido = addr.Address == emailPorPartes;
                return valido;
            }
            catch (FormatException)
            {
                valido = false;
                return valido;
            }
        }

        /// <summary>
        /// Muestra mensaje de campos vacios detectados
        /// </summary>
        private static void NotificarCamposVacios()
        {
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

        /// <summary>
        /// Muestra mensaje de contrasenias no coinciden
        /// </summary>
        private static void NotificarContraseniasNoCoinciden()
        {
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

        /// <summary>
        /// Muestra mensaje de error de conexión al servidor
        /// </summary>
        private static void NotificarDesconexionDeServidor()
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
        }

        /// <summary>
        /// Muestra mensaje de codigo ingresado erroneo
        /// </summary>
        private void NotificarCodigoErroneo()
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
        }

        /// <summary>
        /// Muestra mensaje de fallido por nombre de usuario ya registrado
        /// </summary>
        private void NotificarFallidoPorUsuarioRegistrado()
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

        /// <summary>
        /// Muestra el mensaje de correo ya registrado
        /// </summary>
        private void NotificarCorreoYaRegistrado()
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

        /// <summary>
        /// Muestra el mensaje de registro exitoso
        /// </summary>
        private void NotificarRegistroExitoso()
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
        }

        /// <summary>
        /// Muestra el mensaje de error de correo ingresado
        /// </summary>
        private void NotificarErrorDeEnvioDeCorreo()
        {
            sonidoDeError.Play();
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("Envío de correo fallido", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("Mailing infructueux", "Erreur", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("Envio sem êxito", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("Delivery failed", "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botó de Cancelar.
        /// Se regresa a la ventana de Iniciar Sesión.
        /// </summary>
        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            inicioDeSesion.Show();
            this.Close();

        }

        /// <summary>
        /// Método que se ejecuta cuando se cierra la ventana.
        /// Se vuelve a mostrar la ventana de Iniciar Sesión.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            inicioDeSesion.Show();
        }

        /// <summary>
        /// Convierte una imagen en un arreglo de bytes para ser almacenado en la base de datos.
        /// </summary>
        /// <returns>Regresa un arerglo con los bytes de la imagen</returns>
        private byte[] ConvertirImagenABytes()
        {
            MemoryStream ms = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            BitmapImage imagenFinal = new BitmapImage();
            imagenFinal.BeginInit();
            imagenFinal.UriSource = new Uri(ruta);
            imagenFinal.DecodePixelHeight = 150;
            imagenFinal.DecodePixelWidth = 150;
            imagenFinal.EndInit();
            encoder.Frames.Add(BitmapFrame.Create(imagenFinal));
            encoder.Save(ms);
            return ms.ToArray();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de selección de Imagen.
        /// Se abre una ventana del explorador de Windows para seleccionar la imagen que quiere el jugador como
        /// imagen de perfil.
        /// </summary>
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

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
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
