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
                        MessageBox.Show("Credenciales incorrectas", "Error en el inicio de sesión", MessageBoxButton.OK);
                    } else if (estado == EstadoDeInicioDeSesion.FallidoPorUsuarioYaConectado)
                    {
                        sonidoDeError.Play();
                        MessageBox.Show("Ya hay una sesión de este usuario", "Error", MessageBoxButton.OK);
                    }
                } catch (EndpointNotFoundException endpointNotFoundException )
                {
                    MessageBox.Show("No se ha podido conectar con el servidor", "Error de conexión", MessageBoxButton.OK);
                    servidor = new ServidorClient(contexto);
                } catch (TimeoutException timeOutException)
                {
                    MessageBox.Show("No se ha podido conectar con el servidor", "Error de conexión", MessageBoxButton.OK);
                    servidor = new ServidorClient(contexto);
                }
            } else
            {
                sonidoDeBoton.Play();
                MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);
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

        
    }
}