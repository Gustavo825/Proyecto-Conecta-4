using System;
using System.IO;
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

namespace ChatJuego.Cliente.Ventanas.Configuracion
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        private MenuPrincipal menuPrincipal;
        public static Idioma idioma = Idioma.Espaniol;

        public Configuracion(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            Actualizar_Idioma();
            this.menuPrincipal = menuPrincipal;
        }

        private void EliminarCuenta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Musica_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            if (MenuPrincipal.EstadoMusica == 1)
            {
                MenuPrincipal.MusicaDeMenu.Stop();
                MenuPrincipal.EstadoMusica = 0;
                Actualizar_Idioma();
            }
            else
            {
                MenuPrincipal.MusicaDeMenu.Play();
                MenuPrincipal.EstadoMusica = 1;
                Actualizar_Idioma();
            }
        }

        private void SFX_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPrincipal.EstadoSFX == 1)
            {
                MenuPrincipal.EstadoSFX = 0;
                Actualizar_Idioma();
            }
            else
            {
                MenuPrincipal.EstadoSFX = 1;
                MenuPrincipal.ReproducirBoton();
                Actualizar_Idioma();
            }
        }

        private void Ingles_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Ingles;
            Actualizar_Idioma();
            menuPrincipal.ActualizarIdiomaDeVentana();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Espaniol_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Espaniol;
            Actualizar_Idioma();
            menuPrincipal.ActualizarIdiomaDeVentana();
            
        }

        private void Frances_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Frances;
            Actualizar_Idioma();
            menuPrincipal.ActualizarIdiomaDeVentana();
           
        }

        private void Portugues_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Portugues;
            Actualizar_Idioma();
            menuPrincipal.ActualizarIdiomaDeVentana();
           
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_Configuracion.Title = "Configuración";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrances.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniolON.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoIngles.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortugues.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/configuracion.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdioma.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/musica.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/SFX.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuenta.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica == 0)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonOFFES.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonONES.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX == 0)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonOFFES.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonONES.png", UriKind.Relative));
                }
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_Configuracion.Title = "Configuration";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrancesON.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniol.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoIngles.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortugues.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/tituloConfiguracionFR.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdiomaFR.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/textoMusicaFR.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/textoSFXFR.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuentaFR.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica == 0)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonApagadoFR.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonEncendidoFR.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX == 0)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonApagadoFR.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonEncendidoFR.png", UriKind.Relative));
                }
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Configuracion.Title = "Configuração";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrances.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniol.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoIngles.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortuguesON.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/tituloConfiguracionPO.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdiomaPO.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/textoMusicaPO.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/textoSFXPO.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuentaPO.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica == 0)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonApagadoPO.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonEncendidoPO.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX == 0)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonApagadoPO.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonEncendidoPO.png", UriKind.Relative));
                }
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Configuracion.Title = "Configuration";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrances.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniol.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoInglesON.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortugues.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/configuracionEN.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdiomaEN.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/textoMusica.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/textoSFXEN.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuentaEN.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica == 0)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonOFF.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonON.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX == 0)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonOFF.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonON.png", UriKind.Relative));
                }
            }
        }

        public enum Idioma
        {
            Espaniol = 0,
            Ingles,
            Frances,
            Portugues
        }
    }
}
