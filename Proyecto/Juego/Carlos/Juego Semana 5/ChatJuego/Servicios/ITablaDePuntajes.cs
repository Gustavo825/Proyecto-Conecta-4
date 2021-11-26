using ChatJuego.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatJuego.Servicios
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]

    public interface ITablaDePuntajes
    {
        [OperationContract(IsOneWay = true)]
        void RecuperarPuntajesDeJugadores();
    }
}
