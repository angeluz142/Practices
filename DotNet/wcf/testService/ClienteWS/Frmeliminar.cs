using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWS
{
    public partial class Frmeliminar : Form
    {
        public Frmeliminar()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                 string id = txtIdEliminar.Text;

            WSservicio.ClienteIServiceClient cliente = new WSservicio.ClienteIServiceClient();
            //cliente.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            cliente.ClientCredentials.UserName.UserName = "angeluz142";
            cliente.ClientCredentials.UserName.Password = "abc.123";

            cliente.eliminarCliente(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            txtIdEliminar.Text="";
        }
    }
}
