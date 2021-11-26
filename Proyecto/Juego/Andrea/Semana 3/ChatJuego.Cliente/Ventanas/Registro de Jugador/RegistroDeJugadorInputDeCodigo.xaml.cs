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
using static ChatJuego.Cliente.MenuPrincipal;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para EnviarInvitacion_InputDeCodigo.xaml
    /// </summary>
    public partial class RegistroDeJugador_InputDeCodigo : Window
    {
        private int codigoDeRegistro;

        public RegistroDeJugador_InputDeCodigo(int codigoDeRegistro)
        {
            InitializeComponent();
            this.codigoDeRegistro = codigoDeRegistro;
            Actualizar_Idioma();

        }

        private void BotonOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnswer.Text.Equals(codigoDeRegistro.ToString()))
                this.DialogResult = true;
            else

                this.DialogResult = false;

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }



        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Ingles)
            {

                Titulo.Title = "Register Confirmation";
                lblQuestion.Content = "Enter the confirmation code that was sent to your email";
                btnDialogoCancel.Content = "Cancel";
            }
            else
            {
                Titulo.Title = "Confirmación de Registro";
                lblQuestion.Content = "Ingrese el código de confirmación que se le envió al correo";
                btnDialogoCancel.Content = "Cancelar";
            }
        }
    }
}
