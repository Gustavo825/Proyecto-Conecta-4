using ChatJuego.Cliente.Proxy;
using System;
using System.Media;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer musicaDelMenu = new MediaPlayer();
        private SoundPlayer sonidoDeBoton = new SoundPlayer();
        private SoundPlayer sonidoDeError = new SoundPlayer();
        private ServidorClient servidor;
        private JugadorCallBack callBackDelJugador;
        private InstanceContext contexto;

        public MainWindow()
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
            servidor = new ServidorClient(contexto);
            InitializeComponent();
            ActualizarIdiomaDeVentana();
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaDelMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDeMenu.wav"));
            if (MenuPrincipal.EstadoMusica == 1)
            {
                musicaDelMenu.Play();
            }
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";

        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Iniciar Sesión.
        /// Valida que la información de inicio de sesión sea correcta y nos manda al menú principal
        /// </summary>

        private void BotonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBUsuario.Text) && !string.IsNullOrEmpty(TBContrasenia.Password))
            {
                Jugador jugador = new Jugador()
                {
                    usuario = TBUsuario.Text,
                    contrasenia = TBContrasenia.Password 
                };
                try
                {
                    EstadoDeInicioDeSesion estado = servidor.Conectarse(jugador);
                    if (estado == EstadoDeInicioDeSesion.Correcto)
                    {
                        MenuPrincipal menuPrincipal = new MenuPrincipal(servidor, callBackDelJugador, jugador, contexto);
                        menuPrincipal.Show();
                        musicaDelMenu.Stop();
                        Close();
                    }
                    else if (estado == EstadoDeInicioDeSesion.Fallido)
                    {
                        if (MenuPrincipal.EstadoSFX == 1)
                        {
                            sonidoDeError.Play();
                        }
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("Credenciales incorrectas", "Error en el inicio de sesión", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Identifiants incorrects", "Erreur d'authentification", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Credenciais incorrectas", "Error na autenticação", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("User or the password incorrect", "Failed to login", MessageBoxButton.OK);
                        }
                    } else if (estado == EstadoDeInicioDeSesion.FallidoPorUsuarioYaConectado)
                    {
                        if (MenuPrincipal.EstadoSFX == 1)
                        {
                            sonidoDeError.Play();
                        }
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("Ya hay una sesión de este usuario", "Error", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("Ce utilisateur est déjà connecté", "Erreur", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("Esse usuário já está ligado", "Error", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("There's already a session with this user", "Error", MessageBoxButton.OK);
                        }
                    }
                } catch (EndpointNotFoundException)
                {
                    if (MenuPrincipal.EstadoSFX == 1)
                    {
                        sonidoDeError.Play();
                    }
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
                } catch (TimeoutException)
                {
                    if (MenuPrincipal.EstadoSFX == 1)
                    {
                        sonidoDeError.Play();
                    }
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
                }
            } else
            {
                if (MenuPrincipal.EstadoSFX == 1)
                {
                    sonidoDeError.Play();
                }
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

        /// <summary>
        /// Método que se ejecuta cuando se dad click en el botón de Registrarse. Nos manda a la ventana de Registro de Jugador
        /// </summary>

        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPrincipal.EstadoSFX == 1)
            {
                sonidoDeBoton.Play();
            }
            RegistroDeJugador registro = new RegistroDeJugador(servidor,this,contexto);
            registro.Show();
            this.Hide();
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        public void ActualizarIdiomaDeVentana()
        {
            if (idioma == Idioma.Frances)
            {
                Ventana_Iniciar_Sesion.Title = "Ouvrir Session";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/inicio de sesionFR.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioFR.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/contraseniaFR.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionFR.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Espaniol)
            {
                Ventana_Iniciar_Sesion.Title = "Inicio de Sesión";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/inicio de sesion.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuario.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/contrasenia.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesion.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarse.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Iniciar_Sesion.Title = "Autentique-se";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/tituloInicioDeSesionPO.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/textoNombreDeUsuarioPO.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/textoContraseniaPO.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionPO.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarsePO.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Iniciar_Sesion.Title = "Login";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/tituloInicioDeSesionIN.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioIN.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/textoContraseniaIN.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionIN.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseIN.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Método que se ejeucta cuando se aprita la tecla Enter al estar posicionado sobre el campo de contraseña
        /// </summary>

        private void TBContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BotonIniciarSesion_Click(new object(),new RoutedEventArgs());
            }
        }

        
    }
}