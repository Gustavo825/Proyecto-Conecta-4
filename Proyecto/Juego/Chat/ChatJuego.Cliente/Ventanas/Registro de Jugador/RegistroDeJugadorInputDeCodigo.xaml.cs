using System;
using System.Windows;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

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
            ActualizarIdioma();
            this.codigoDeRegistro = codigoDeRegistro;
        }

        /// <summary>
        /// Método que verifica que el texto ingresado coincida con el código enviado al correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnswer.Text.Equals(codigoDeRegistro.ToString()))
                this.DialogResult = true;
            else

                this.DialogResult = false;

        }

        /// <summary>
        /// Método que hace que se enfoque en la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }


        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón Cancelar.
        /// </summary>
        private void BotonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                TituloConfirmacion.Title = "Confirmación de registro";
                lblQuestion.Content = "Ingrese el código de confirmación que se le envió al correo";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Cancelar";
            }
            else if (idioma == Idioma.Frances)
            {
                TituloConfirmacion.Title = "Confirmation de l'enregistrement";
                lblQuestion.Content = "Entrer le code d'confirmation qui vous a été envoyé par se courriel";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Annuler";
            }
            else if (idioma == Idioma.Portugues)
            {
                TituloConfirmacion.Title = "Confirmação de registro";
                lblQuestion.Content = "Digite o código de confirmação que foi enviado ao seu correio";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Cancelar";
            }
            else if (idioma == Idioma.Ingles)
            {

                TituloConfirmacion.Title = "Register Confirmation";
                lblQuestion.Content = "Enter the confirmation code that was sent to your email";
                btnDialogOk.Content = "OK";
                Boton_Cancelar.Content = "Cancel";
            }
        }
    }
}
