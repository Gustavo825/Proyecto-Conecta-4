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

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        Proxy.ChatServicioClient servidor;
        Proxy.InvitacionCorreoServicioClient servidorCorreo;
        InstanceContext contexto;
        JugadorCallBack jC;
        Jugador jugador;


        public MenuPrincipal(ChatServicioClient servidor, JugadorCallBack jC, Jugador jugador, InstanceContext contexto)
        {
            this.jC = jC;
            this.servidor = servidor;
            this.jugador = jugador;
            this.contexto = contexto;
            servidorCorreo = new InvitacionCorreoServicioClient(this.contexto);
            InitializeComponent();
        }

        private void BotonTablaPuntajes_Click(object sender, RoutedEventArgs e)
        {
            TablaDePuntajes tablaPuntajes = new TablaDePuntajes(servidor);
            jC.setTablaDePuntajes(tablaPuntajes);
            tablaPuntajes.Show();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            IniciarSesion mainWindow = new IniciarSesion();
            servidor.desconectarse();
            mainWindow.Show();
            this.Close();

        }

        private void BotonChat_Click(object sender, RoutedEventArgs e)
        {
            servidor.inicializar();
            Chat chat = new Chat(jugador, servidor);
            jC.setChat(chat);
            chat.Show();
        }

        private void BotonCrearParida_Click(object sender, RoutedEventArgs e)
        {
            EnviarInvitacion enviarInvitacion = new EnviarInvitacion(servidorCorreo,jugador, this);
            enviarInvitacion.Show();
            this.Hide();
        }
    }
}
