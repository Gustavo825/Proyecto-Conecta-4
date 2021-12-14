using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ChatJuego.Cliente.Ventanas.Juego
{
    /// <summary>
    /// Lógica de interacción para ConfirmacionDePresencia.xaml
    /// </summary>
    public partial class ConfirmacionDePresencia : Window
    {
        DispatcherTimer timer;
        public ConfirmacionDePresencia()
        {
            InitializeComponent();
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
            timer.Tick += delegate
            {
                timer.Stop();
                this.DialogResult = false;
                this.Close();
            };
            timer.Start();
           
        }

        private void BotonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            timer.Stop();
            this.Close();
        }

    }
}
