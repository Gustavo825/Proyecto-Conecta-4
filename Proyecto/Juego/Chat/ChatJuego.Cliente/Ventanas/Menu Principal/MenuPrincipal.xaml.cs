using ChatJuego.Cliente.Proxy;
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
using System.Windows.Threading;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        MediaPlayer musicaMenu = new MediaPlayer();
        SoundPlayer sonidoBoton = new SoundPlayer();
        ServidorClient servidor;
        ChatServicioClient servidorChat;
        InvitacionCorreoServicioClient servidorCorreo;
        TablaDePuntajesClient servidorTablaDePuntajes;
        InstanceContext contexto;
        JugadorCallBack jC;
        Jugador jugador;


        public MenuPrincipal(ServidorClient servidor, JugadorCallBack jC, Jugador jugador, InstanceContext contexto, ChatServicioClient servidorChat)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDePartida.wav"));
            musicaMenu.Play();
            sonidoBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            this.jC = jC;
            this.servidor = servidor;
            this.jugador = jugador;
            this.contexto = contexto;
            servidorCorreo = new InvitacionCorreoServicioClient(contexto);
            this.servidorChat = servidorChat;
            servidorTablaDePuntajes = new TablaDePuntajesClient(contexto);
            InitializeComponent();
            ImagenJugador.Source = convertirArrayAImagen(jugador.imagenUsuario);
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
            timer.Tick += delegate
            {
                timer.Stop();
                MessageBox.Show("¿Sigues ahí?", "Tiempo de inactividad");
                timer.Start();
            };
            timer.Start();
            InputManager.Current.PostProcessInput += delegate (object s, ProcessInputEventArgs r)
            {
                if (r.StagingItem.Input is MouseButtonEventArgs || r.StagingItem.Input is KeyEventArgs)
                    timer.Interval = TimeSpan.FromMinutes(1);
            };

        }
        public BitmapImage convertirArrayAImagen(byte[] arrayDeImagen)
        {
            BitmapImage imagen = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(arrayDeImagen))
            {
                imagen.BeginInit();
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.StreamSource = memStream;
                imagen.EndInit();
                imagen.Freeze();
            }
            return imagen;
        }
        private void BotonTablaPuntajes_Click(object sender, RoutedEventArgs e)
        {
            sonidoBoton.Play();
            TablaDePuntajes tablaPuntajes = new TablaDePuntajes(servidorTablaDePuntajes);
            jC.setTablaDePuntajes(tablaPuntajes);
            tablaPuntajes.Show();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            sonidoBoton.Play();
            MainWindow mainWindow = new MainWindow();
            servidor.desconectarse();
            mainWindow.Show();
            this.Close();

        }

        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            sonidoBoton.Play();
            Chat chat = new Chat(jugador, servidorChat);
            servidorChat.inicializar();
            jC.setChat(chat);
            chat.Show();
        }

        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            sonidoBoton.Play();
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(servidorCorreo,jugador, this);
            enviarInvitacion.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
