using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Security;

namespace ClienteWS
{
    public partial class FrmBuscar : Form
    {


        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {

            try
            {
                WSservicio.ClienteIServiceClient cliente = new WSservicio.ClienteIServiceClient();
                cliente.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                //cliente.ClientCredentials.UserName.UserName = "angeluz142";
                //cliente.ClientCredentials.UserName.Password = "abc.123";

                string ide = txtBuscarId.Text;

                object lista = cliente.BuscarCliente(ide);

                int vari = ((ClienteWS.WSservicio.Cliente[])(lista)).Length;

                for (int i = 0; i < vari; i++)
                {

                    string texto0 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].id;
                    string texto1 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].contacto;
                    string texto2 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].company;
                    string texto3 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].pais;


                    string texto4 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].ciudad;
                    string texto5 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].direccion;
                    string texto6 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].tlf;

                    dataGridView1.Rows.Add(texto0, texto0, texto2, texto3, texto4, texto5, texto6);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
