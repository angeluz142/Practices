using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace testService2
{
   


    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ClienteIService
    {

        
        [OperationContract]
        int nuevoCliente(string CustomerID, string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax);

        [OperationContract]
        int editarCliente(string CustomerID, string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax);

        [OperationContract]
        int eliminarCliente(string id);

        [OperationContract]
        List<Cliente> BuscarCliente(string id);

        [OperationContract]
        List<Cliente> listarCliente();
    }

   


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Cliente
    {

        [DataMember]
        public string id { set; get; }

        [DataMember]
        public string contacto { set; get; }

        [DataMember]
        public string company { set; get; }

        [DataMember]
        public string pais { set; get; }

        [DataMember]
        public string ciudad { set; get; }

        [DataMember]
        public string direccion { set; get; }

        [DataMember]
        public string tlf { set; get; }

    }
}
