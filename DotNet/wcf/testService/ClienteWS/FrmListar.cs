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
    public partial class FrmListar : Form
    {
        public FrmListar()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int columna = dataGridView.CurrentCell.ColumnIndex;

            if (columna == 0)
            {

                FrmEditar frm = new FrmEditar();
                frm.Show();

                frm.txtIdEditar.Text = dataGridView.CurrentCell.Value.ToString();

            }
            else { }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmListar_Load(object sender, EventArgs e)
        {

            try
            {
                WSservicio.ClienteIServiceClient cliente = new WSservicio.ClienteIServiceClient();
                cliente.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                cliente.ClientCredentials.UserName.UserName = "angeluz";
                cliente.ClientCredentials.UserName.Password = "123456";

                object lista = cliente.listarCliente();

                int vari = ((ClienteWS.WSservicio.Cliente[])(lista)).Length;

                for (int i = 0; i < vari; i++)
                {

                    txtPrueba.Text = i.ToString();


                    string texto0 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].id;
                    string texto1 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].contacto;
                    string texto2 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].company;
                    string texto3 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].pais;
                    string texto4 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].ciudad;
                    string texto5 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].direccion;
                    string texto6 = ((ClienteWS.WSservicio.Cliente[])(lista))[i].tlf;

                    dataGridView.Rows.Add(texto0, texto0, texto2, texto3, texto4, texto5, texto6);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                // throw new Exception();
            }


        }
    }
}
