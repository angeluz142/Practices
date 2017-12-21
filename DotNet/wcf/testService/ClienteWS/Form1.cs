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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_MouseClick(object sender, MouseEventArgs e)
        {
            FrmListar frm = new FrmListar();
            frm.Show();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmInsertar frm = new FrmInsertar();
            frm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditar frm = new FrmEditar();
            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Frmeliminar frm = new Frmeliminar();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscar frm = new FrmBuscar();
            frm.Show();
        }
    }
}
