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
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente.Ventanas.Tutorial
{
    /// <summary>
    /// Lógica de interacción para Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window
    {
        public Tutorial()
        {
            InitializeComponent();
            ActualizarIdioma();
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        public void ActualizarIdioma()
        {
            if (idioma == Idioma.Frances)
            {
                Title = "Jeu";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salirFR.png", UriKind.Relative));
                ImagenTutorial.Source = new BitmapImage(new Uri("Iconos/tutoFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Espaniol)
            {
                Title = "Juego";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salir.png", UriKind.Relative));
                ImagenTutorial.Source = new BitmapImage(new Uri("Iconos/tutoES.png", UriKind.Relative));

            }
            else if (idioma == Idioma.Portugues)
            {
                Title = "Jogo";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salirPO.png", UriKind.Relative));
                ImagenTutorial.Source = new BitmapImage(new Uri("Iconos/tutoPO.png", UriKind.Relative));

            }
            if (idioma == Idioma.Ingles)
            {
                Title = "Game";
                BotonSalirImagen.Source = new BitmapImage(new Uri("Iconos/salirEN.png", UriKind.Relative));
                ImagenTutorial.Source = new BitmapImage(new Uri("Iconos/tutoEN.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el boton de Salir
        /// </summary>
        private void BotoSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            this.Close();
        }
    }
}
