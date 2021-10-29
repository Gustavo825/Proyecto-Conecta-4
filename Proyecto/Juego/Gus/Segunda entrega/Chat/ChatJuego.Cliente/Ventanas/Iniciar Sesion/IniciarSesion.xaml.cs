using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Proxy.ServidorClient servidor;
        JugadorCallBack jugadorCallback;
        InstanceContext contexto;
        public MainWindow()
        {
            jugadorCallback = new JugadorCallBack();
            contexto = new InstanceContext(jugadorCallback);
            servidor = new Proxy.ServidorClient(contexto);
            InitializeComponent();
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
                var estado = servidor.conectarse(jugador);
                if (estado)
                {
                    jugador.imagenUsuario = servidor.obtenerBytesDeImagenDeJugador(jugador.usuario);
                    MenuPrincipal menuPrincipal = new MenuPrincipal(servidor, jugadorCallback, jugador, contexto, new ChatServicioClient(contexto));
                    menuPrincipal.Show();
                    Close();
                } else
                {
                    MessageBox.Show("Credenciales incorrectas", "Error en el inicio de sesión", MessageBoxButton.OK);
                }
            } else
            {
                MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);
            }
        }

        private void BotonRegistrarseI_Click(object sender, RoutedEventArgs e)
        {

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