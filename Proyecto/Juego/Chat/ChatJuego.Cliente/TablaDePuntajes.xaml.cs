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

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para TablaDePuntajes.xaml
    /// </summary>
    public partial class TablaDePuntajes : Window
    {
        private ChatServicioClient servidor;

        public ItemsControl PantallaDePuntuaciones
        {
            get { return PlantillaTablaDePuntuaciones; }
            set { PlantillaTablaDePuntuaciones = value; }
        }
        public TablaDePuntajes(ChatServicioClient servidor)
        {
            InitializeComponent();
            this.servidor = servidor;
            PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = "", NombreJugador = "Jugador", Puntaje = "Puntaje" });
            servidor.recuperarPuntajesDeJugadores();
        }
    }
}
