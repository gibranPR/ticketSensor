using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticket
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo nuevo = new Nuevo(1);
            nuevo.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Ver ver = new Ver(1);
            ver.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Nuevo modificar = new Nuevo(2);
            modificar.Show();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Ver finalizar = new Ver(3);
            finalizar.Show();
        }
    }
}
