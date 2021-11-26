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
    /// Lógica de interacción para EnviarInvitacion_InputDeCodigo.xaml
    /// </summary>
    public partial class RegistroDeJugador_InputDeCodigo : Window
    {
        private int codigoDeRegistro;
        public static Idioma idiomaCodigoRegistro = Idioma.Espaniol;

        public RegistroDeJugador_InputDeCodigo(int codigoDeRegistro)
        {
            InitializeComponent();
            Actualizar_Idioma();
            this.codigoDeRegistro = codigoDeRegistro;
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
            if (idiomaCodigoRegistro == Idioma.Espaniol)
            {
                TituloConfirmacion.Title = "Confirmación de registro";
                lblQuestion.Content = "Ingrese el código de confirmación que se le envió al correo";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Cancelar";
            }
            else if (idiomaCodigoRegistro == Idioma.Frances)
            {
                TituloConfirmacion.Title = "Confirmation de l'enregistrement";
                lblQuestion.Content = "Entrer le code d'confirmation qui vous a été envoyé par se courriel";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Annuler";
            }
            else if (idiomaCodigoRegistro == Idioma.Portugues)
            {
                TituloConfirmacion.Title = "Confirmação de registro";
                lblQuestion.Content = "Digite o código de confirmação que foi enviado ao seu correio";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Cancelar";
            }
            else if (idiomaCodigoRegistro == Idioma.Ingles)
            {

                TituloConfirmacion.Title = "Register Confirmation";
                lblQuestion.Content = "Enter the confirmation code that was sent to your email";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Cancel";
            }
        }
    }
}
