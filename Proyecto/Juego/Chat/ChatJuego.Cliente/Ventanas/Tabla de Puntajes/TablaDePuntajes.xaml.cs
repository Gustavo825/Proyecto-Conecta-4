using ChatJuego.Cliente.Proxy;
using System.Windows;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para TablaDePuntajes.xaml
    /// </summary>
    public partial class TablaDePuntajes : Window
    {
        private TablaDePuntajesClient servidorTablaDePuntajes;

        public TablaDePuntajes(TablaDePuntajesClient servidorTablaDePuntajes)
        {
            InitializeComponent();
            this.servidorTablaDePuntajes = servidorTablaDePuntajes;
            ActualizarIdioma();
            this.servidorTablaDePuntajes.RecuperarPuntajesDeJugadores();
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_Puntajes.Title = "Tabla de Puntajes";
                Titulo.Content = "tabla de mejores puntuaciones";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Jugador", Puntaje = "Puntaje" });
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_Puntajes.Title = "Tableau des Scores";
                Titulo.Content = "tableau des meilleurs scores";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Joueur", Puntaje = "Score" });
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Puntajes.Title = "Tabela de Pontuações";
                Titulo.Content = "tabela das melhores pontuações";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Jogador", Puntaje = "Pontos" });
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Puntajes.Title = "Leaderboard";
                Titulo.Content = "Leaderboard";
                PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Player", Puntaje = "Score" });
            }
        }
    }
}
