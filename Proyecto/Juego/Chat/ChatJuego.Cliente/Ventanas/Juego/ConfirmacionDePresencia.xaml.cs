using System;
using System.Windows;
using System.Windows.Threading;

namespace ChatJuego.Cliente.Ventanas.Juego
{
    /// <summary>
    /// Lógica de interacción para ConfirmacionDePresencia.xaml
    /// </summary>
    public partial class ConfirmacionDePresencia : Window
    {
        private DispatcherTimer timer;
        public const int TIEMPO_DE_ESPERA = 30;

        public ConfirmacionDePresencia()
        {
            InitializeComponent();
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(TIEMPO_DE_ESPERA) };
            timer.Tick += delegate
            {
                timer.Stop();
                this.DialogResult = false;
                this.Close();
            };
            timer.Start();
           
        }

        /// <summary>
        /// Método que se ejecuta cuando el jugador confirma su presencia en el juego.
        /// </summary>

        private void BotonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            timer.Stop();
            this.Close();
        }

    }
}
