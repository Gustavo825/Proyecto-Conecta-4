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
        JugadorCallBack jC;


        public MenuPrincipal(ChatServicioClient servidor, JugadorCallBack jC)
        {
            this.jC = jC;
            this.servidor = servidor;
            InitializeComponent();
        }

        private void BotonTablaPuntajes_Click(object sender, RoutedEventArgs e)
        {
            TablaDePuntajes tablaPuntajes = new TablaDePuntajes();
            jC.setTablaDePuntajes(tablaPuntajes);
            tablaPuntajes.Inicializar(servidor);
            tablaPuntajes.Show();
        }

        private void BotonSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            servidor.desconectarse();
            mainWindow.Show();
            this.Close();

        }
    }
}
