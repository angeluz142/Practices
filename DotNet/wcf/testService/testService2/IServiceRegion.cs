using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace testService2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceRegion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceRegion
    {

        [OperationContract]
        int nuevaRegion(int IdRegion, string Rdescripcion);

        [OperationContract]
        int editarRegion(int IdRegion, string Rdescripcion);

        [OperationContract]
        int eliminarRegion(int IdRegion);

        [OperationContract]
        List<ClienteRegion> listarRegion();
    
    }

    [DataContract]
    public class ClienteRegion
    {

        [DataMember]
        public int id { set; get; }

        [DataMember]
        public string descripcion { set; get; }

    }
}
