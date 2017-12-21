using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWS
{
    public partial class FrmInsertar : Form
    {
        public FrmInsertar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmInsertar_Load(object sender, EventArgs e)
        {
            
  

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string id = txtIdCustomer.Text;
            string Company = txtCompany.Text;
            string Contact = txtContact.Text;
            string Title = txtTitle.Text;
            string Address = txtAddress.Text;
            string City = txtCity.Text;
            string Region = txtRegion.Text;
            string postal = txtPostal.Text;
            string country = txtCountry.Text;
            string Phone = txtPhone.Text;
            string Fax = txtPhone.Text;


            try
            {
                WSservicio.ClienteIServiceClient cliente = new WSservicio.ClienteIServiceClient();
                cliente.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                cliente.ClientCredentials.UserName.UserName = "angeluz";
                cliente.ClientCredentials.UserName.Password = "123456";

                if (cliente.nuevoCliente(id, Company, Contact, Title, Address, City, Region, postal, country, Phone, Fax) == 1)
                    MessageBox.Show("Se ha registrado el cliente" + Company + " exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdCustomer.Text = "";
            txtCompany.Text = "";
            txtContact.Text = "";
            txtTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtRegion.Text = "";
            txtPostal.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            txtPhone.Text = "";
        }
    }
}
