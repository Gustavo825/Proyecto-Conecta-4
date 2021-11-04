using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChatJuego.Base_de_datos;
using ChatJuego.Host;

namespace ChatJuego.Servicios
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IServidor
    {

        [OperationContract(IsOneWay = false)]
        bool Conectarse(Jugador jugador);


        [OperationContract(IsOneWay = false)]
        EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador);

        [OperationContract(IsOneWay = false)]
        byte[] ObtenerBytesDeImagenDeJugador(string usuario);

        [OperationContract(IsOneWay = true)]
        void Desconectarse();
    }
}
