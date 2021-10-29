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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        ServidorClient servidor;
        ChatServicioClient servidorChat;
        InvitacionCorreoServicioClient servidorCorreo;
        TablaDePuntajesClient servidorTablaDePuntajes;
        InstanceContext contexto;
        JugadorCallBack jC;
        Jugador jugador;

        readonly DispatcherTimer activityTimer;


        public MenuPrincipal(ServidorClient servidor, JugadorCallBack jC, Jugador jugador, InstanceContext contexto, ChatServicioClient servidorChat)
        {
            this.jC = jC;
            this.servidor = servidor;
            this.jugador = jugador;
            this.contexto = contexto;
            servidorCorreo = new InvitacionCorreoServicioClient(contexto);
            this.servidorChat = servidorChat;
            servidorTablaDePuntajes = new TablaDePuntajesClient(contexto);
            InitializeComponent();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
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
                    timer.Interval = TimeSpan.FromSeconds(10);
            };
        }

        private void BotonTablaPuntajes_Click(object sender, RoutedEventArgs e)
        {
            TablaDePuntajes tablaPuntajes = new TablaDePuntajes(servidorTablaDePuntajes);
            jC.setTablaDePuntajes(tablaPuntajes);
            tablaPuntajes.Show();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            servidor.desconectarse();
            mainWindow.Show();
            this.Close();

        }

        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            Chat chat = new Chat(jugador, servidorChat);
            servidorChat.inicializar();
            jC.setChat(chat);
            chat.Show();
        }

        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(servidorCorreo,jugador, this);
            enviarInvitacion.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
