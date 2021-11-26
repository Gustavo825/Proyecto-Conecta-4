using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ChatJuego.Cliente.MenuPrincipal;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer musicaDelMenu = new MediaPlayer();
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        SoundPlayer sonidoDeError = new SoundPlayer();
        ServidorClient servidor;
        JugadorCallBack callBackDelJugador;
        InstanceContext contexto;
        public MainWindow()
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
            servidor = new ServidorClient(contexto);
            InitializeComponent();
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaDelMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDeMenu.wav"));
            musicaDelMenu.Play();
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            Actualizar_Idioma();
        }

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
                        sonidoDeError.Play();
                        if(idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("User or the password incorrect", "Failed to login", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas", "Error en el inicio de sesión", MessageBoxButton.OK);
                        }
                    } else if (estado == EstadoDeInicioDeSesion.FallidoPorUsuarioYaConectado)
                    {
                        sonidoDeError.Play();
                        if(idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("There's already a session with this user", "Error", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Ya hay una sesión de este usuario", "Error", MessageBoxButton.OK);
                        }
                    }
                } catch (EndpointNotFoundException endpointNotFoundException)
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
                }
            } else
            {
                sonidoDeBoton.Play();
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

        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            RegistroDeJugador registro = new RegistroDeJugador(servidor,this,contexto);
            registro.Show();
            this.Hide();
        }

        private void TBContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BotonIniciarSesion_Click(new object(),new RoutedEventArgs());
            }
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Ingles)
            {
                Title = "Login";
                TituloVentanaInicio.Source = new BitmapImage(new Uri("Iconos/tituloInicioDeSesionIN.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioIN.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/textoContraseniaIN.png", UriKind.Relative));
                ImagenBotonIniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionIN.png", UriKind.Relative));
                ImagenBotonRegistrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseIN.png", UriKind.Relative));
            }
            else
            {
                Title = "Inicio de Sesión";
                TituloVentanaInicio.Source = new BitmapImage(new Uri("Iconos/inicio de sesion.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuario.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/textoContrasenia.png", UriKind.Relative));
                ImagenBotonIniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesion.png", UriKind.Relative));
                ImagenBotonRegistrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarse.png", UriKind.Relative));
            }
        }
    }
}