using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ticket
{
    public partial class Nuevo : Form
    {
        public static Nuevo nuevo;
        ConectaBD accion;
        int valor;
        public Nuevo(int i)
        {
            nuevo = this;
            valor = i;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            accion = new ConectaBD();
            string consulta1 = "Select id, nombre, descripcion from tipoticket;";
            DataSet aux1 = accion.Select(consulta1);
            cmbClase.DataSource = aux1.Tables[0];
            cmbClase.ValueMember = "id";
            cmbClase.DisplayMember = "nombre";
            string consulta2 = "Select id, nombre from empleado where tipo = 1 or tipo = 3 order by nombre;";
            DataSet aux2 = accion.Select(consulta2);
            cmbAlta.DataSource = aux2.Tables[0];
            cmbAlta.ValueMember = "id";
            cmbAlta.DisplayMember = "nombre";
            string consulta3 = "Select id, nombre from empleado where tipo = 2 order by nombre;";
            DataSet aux3 = accion.Select(consulta3);
            cmbAsignado.DataSource = aux3.Tables[0];
            cmbAsignado.ValueMember = "id";
            cmbAsignado.DisplayMember = "nombre";
        }

        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClase.SelectedValue.Equals(1))
            {
                gb1.Visible = false;
            }
            else
            {
                gb1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Algo");
        }
    }
}
