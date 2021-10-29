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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer musicaMenu = new MediaPlayer();
        MediaPlayer musicaRegistro = new MediaPlayer();
        SoundPlayer sonidoBoton = new SoundPlayer(@"C:\Users\perez\Desktop\Croy\Avances Chat\ChatJuego.Cliente\Ventanas\Menu Principal\Sonido\boton.wav");
        SoundPlayer sonidoError = new SoundPlayer(@"C:\Users\perez\Desktop\Croy\Avances Chat\ChatJuego.Cliente\Ventanas\Menu Principal\Sonido\error.wav");
        Proxy.ChatServicioClient servidor;
        JugadorCallBack jugadorCallback;
        InstanceContext contexto;
        public MainWindow()
        {
            jugadorCallback = new JugadorCallBack();
            contexto = new InstanceContext(jugadorCallback);
            servidor = new Proxy.ChatServicioClient(contexto);
            InitializeComponent();
            musicaMenu.Open(new Uri(@"C:\Users\perez\Desktop\Croy\Avances Chat\ChatJuego.Cliente\Ventanas\Menu Principal\Sonido\Restaurant City Music - Default.wav"));
            musicaMenu.Play();
        }

        private void BotonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBUsuario.Text) && !string.IsNullOrEmpty(TBContrasenia.Password))
            {
                sonidoBoton.Play();
                Jugador jugador = new Jugador()
                {
                    usuario = TBUsuario.Text,
                    contrasenia = TBContrasenia.Password 
                };
                var estado = servidor.conectarse(jugador);
                if (estado)
                {
                    MenuPrincipal menuPrincipal = new MenuPrincipal(servidor, jugadorCallback, jugador, contexto);
                    menuPrincipal.Show();
                    musicaMenu.Stop();
                    Close();
                } else
                {
                    sonidoError.Play();
                    MessageBox.Show("Credenciales incorrectas", "Error en el inicio de sesión", MessageBoxButton.OK);
                }
            } else
            {
                sonidoError.Play();
                MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);
            }
        }

        private void BotonRegistrarseI_Click(object sender, RoutedEventArgs e)
        {
            sonidoBoton.Play();
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