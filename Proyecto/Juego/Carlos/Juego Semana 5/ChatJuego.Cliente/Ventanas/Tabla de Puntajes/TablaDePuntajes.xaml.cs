using ChatJuego.Cliente.Proxy;
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

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para TablaDePuntajes.xaml
    /// </summary>
    public partial class TablaDePuntajes : Window
    {
        private TablaDePuntajesClient servidorTablaDePuntajes;
        public static Idioma idiomaTablaDePuntajes = Idioma.Espaniol;

        public ItemsControl PantallaDePuntuaciones
        {
            get { return PlantillaTablaDePuntuaciones; }
            set { PlantillaTablaDePuntuaciones = value; }
        }
        public TablaDePuntajes(TablaDePuntajesClient servidorTablaDePuntajes)
        {
            InitializeComponent();
            this.servidorTablaDePuntajes = servidorTablaDePuntajes;
            Actualizar_Idioma();
            this.servidorTablaDePuntajes.RecuperarPuntajesDeJugadores();
        }

        private void Actualizar_Idioma()
        {
            if (idiomaTablaDePuntajes == Idioma.Espaniol)
            {
                Ventana_Puntajes.Title = "Tabla de Puntajes";
                Titulo.Content = "tabla de mejores puntuaciones";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Jugador", Puntaje = "Puntaje" });
            }
            else if (idiomaTablaDePuntajes == Idioma.Frances)
            {
                Ventana_Puntajes.Title = "Tableau des Scores";
                Titulo.Content = "tableau des meilleurs scores";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Joueur", Puntaje = "Score" });
            }
            else if (idiomaTablaDePuntajes == Idioma.Portugues)
            {
                Ventana_Puntajes.Title = "Tabela de Pontuações";
                Titulo.Content = "tabela das melhores pontuações";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Jogador", Puntaje = "Pontos" });
            }
            else if (idiomaTablaDePuntajes == Idioma.Ingles)
            {
                Ventana_Puntajes.Title = "Leaderboard";
                Titulo.Content = "Leaderboard";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Player", Puntaje = "Score" });
            }
        }
    }
}
