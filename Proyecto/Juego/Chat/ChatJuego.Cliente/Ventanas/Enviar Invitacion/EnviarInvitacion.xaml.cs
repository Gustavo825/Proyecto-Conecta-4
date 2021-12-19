using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Media.Imaging;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para EnviarInvitacion.xaml
    /// </summary>
    public partial class EnviarInvitacion : Window
    {
        private InvitacionCorreoServicioClient servidorDeCorreo;
        private ChatServicioClient servidorDelChat;
        private InstanceContext contexto;
        private JugadorCallBack jugadorCallBack;
        private ServidorClient servidor;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;
        private bool perdidaDeConexion = false;
        private bool juegoIniciado = false;


        public EnviarInvitacion(Jugador jugador, MenuPrincipal menuPrincipal, InstanceContext contexto, ChatServicioClient servidorDelChat, JugadorCallBack jugadorCallBack, ServidorClient servidor)
        {
            InitializeComponent();
            ActualizarIdioma();
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
            this.contexto = contexto;
            this.servidorDelChat = servidorDelChat;
            this.jugadorCallBack = jugadorCallBack;
            this.servidor = servidor;
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Enviar Invitación.
        /// Verifica que el usuario sea correcto, que no esté vacío, entre otras cosas para luego mandar la invitación.
        /// </summary>
        private void BotonDeEnviarInvitacion_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TBUsuarioInvitacion.Text))
            {
                if (jugador.usuario != TBUsuarioInvitacion.Text)
                {
                    try
                    {
                        servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                        string codigoDePartida = GenerarCodigoDePartida().ToString();
                        var estado = servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = TBUsuarioInvitacion.Text }, codigoDePartida, jugador);
                        if (estado == EstadoDeEnvio.UsuarioNoEncontrado)
                        {
                            MenuPrincipal.ReproducirError();
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("El usuario ingresado no existe", "Usuario no encontrado", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("The user does not exist", "User not found", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Cet utilisateur n'existe pas", "Utilisateur n'est pas trouvée", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("O usuário não existe", "Usuário não encontrado", MessageBoxButton.OK);
                            }
                        }
                        else if (estado == EstadoDeEnvio.Fallido)
                        {
                            MenuPrincipal.ReproducirError();
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("Ocurrió un error y no se pudo mandar la invitación", "Error", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("Something happened and we coudln´t send the invitation", "Error", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Something happened and we coudln´t send the invitation", "Erreur", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("Acountecou um error e a convite não pudo ser enviada", "Error", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MenuPrincipal.ReproducirBoton();
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("Invitación enviada", "Correcto", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("Invitation sent", "Correct", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Invitation adressée", "Correct", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("Convite enviada", "Correct", MessageBoxButton.OK);
                            }
                            VentanaDeJuego ventanaDeJuego = new VentanaDeJuego(contexto, menuPrincipal, jugador, servidorDelChat, codigoDePartida, jugadorCallBack, servidor);
                            ventanaDeJuego.Show();
                            ventanaDeJuego.turnoDeJuego = true;
                            jugadorCallBack.SetVentanaDeJuego(ventanaDeJuego);
                            juegoIniciado = true;
                            this.Close();
                        }
                    }
                    catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                    {
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("The connection with the server was lost", "Connection lost", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("La connexion au serveur été perdue", "Connexion perdue", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("A conexão foi perdida", "Conexão perdida", MessageBoxButton.OK);
                        }
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        perdidaDeConexion = true;
                        menuPrincipal.desconexionDelServidor = true;
                        menuPrincipal.Close();
                        this.Close();
                    }
                } else
                {
                    MenuPrincipal.ReproducirError(); 
                    if (idioma == Idioma.Espaniol)
                    {
                        MessageBox.Show("No te puedes invitar a ti mismo", "Usuario inválido", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Ingles)
                    {
                        MessageBox.Show("You can not send an invitation to yourself", "Invalid user", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Frances)
                    {
                        MessageBox.Show("Vous ne puvez pasinviter vous - même", "Utilisateur invalite", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Portugues)
                    {
                        MessageBox.Show("Você nao pode convidar você mesmo", "Usuário inválido", MessageBoxButton.OK);
                    }
                }
            } else
            {
                MenuPrincipal.ReproducirError();
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Entrez les information requises", "Information tronquée", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Ingresse os datos requeridos", "Campos incompletos", MessageBoxButton.OK);
                }
            }
        }

        /// <summary>
        /// Genera un código de partida
        /// </summary>
        /// <returns>Regresa un entero generado para la partida</returns>
        public static int GenerarCodigoDePartida()
        {
            return new Random().Next(1000, 3000);
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_Envio_Invitacion.Title = "Enviar Invitación";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacion.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuario.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacion.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_Envio_Invitacion.Title = "Envoyer Invitation";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionFR.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioFR.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Envio_Invitacion.Title = "Enviar Convite";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionPO.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioPO.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionPO.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Envio_Invitacion.Title = "Send Invitation";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionIN.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioIN.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionIN.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Se ejecuta cuando se cierra la ventana. Si no se inicia la partida o si no se perdió la conexión, regresa al menú principal
        /// </summary>

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if (!perdidaDeConexion && !juegoIniciado)
                menuPrincipal.Show();   
        }
    }
}
