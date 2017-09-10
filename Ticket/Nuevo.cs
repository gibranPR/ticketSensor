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
            comporta(valor);
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
        private void comporta(int i)
        {
            accion = new ConectaBD();
            if (i == 1)
            {
                string consulta1 = "Select id, nombre from tipoticket;";
                DataTable aux1 = accion.Select(consulta1);
                cmbClase.ValueMember = "id";
                cmbClase.DisplayMember = "nombre";
                string consulta2 = "Select id, nombre from empleado where tipo = 1 or tipo = 3 order by nombre;";
                DataTable aux2 = accion.Select(consulta2);
                cmbAlta.DataSource = aux2;
                cmbAlta.ValueMember = "id";
                cmbAlta.DisplayMember = "nombre";
                AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
                foreach (DataRow nombre in aux2.AsEnumerable()) {
                    stringCol.Add(nombre.ToString());
                }
                cmbAlta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbAlta.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbAlta.AutoCompleteCustomSource = stringCol;

                string consulta3 = "Select id, nombre, telefono from empleado where tipo = 2 order by nombre;";
                DataTable aux3 = accion.Select(consulta3);
                cmbAsignado.DataSource = aux3;
                cmbAsignado.ValueMember = "id";
                cmbAsignado.DisplayMember = "nombre";
            } else
            {
                gb2.Visible = true;
                button1.Visible = false;
                txtFolio.Visible = true;
                label12.Visible = true;
                btnAceptar.Text = "Modificar";
                string consulta = ("select * from ticket");
                DataTable aux1 = accion.Select(consulta);
                txtFolio.Text= aux1.Rows[0].ItemArray[0].ToString();


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            String consulta = "select descripcion from tipoticket where id = "+cmbClase.SelectedValue +";";
            DataTable aux1 = accion.Select(consulta);

            MessageBox.Show(aux1.Rows[0].ItemArray[0].ToString());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {  

            if (cmbClase.SelectedValue.Equals(1))
            {
                string consulta = "select telefono from empleado where id = " + cmbAsignado.SelectedValue + ";";
                DataTable aux = accion.Select(consulta);
                string telefono = aux.Rows[0].ItemArray[0].ToString();
                MessageBox.Show("Favor de llamar a " + cmbAsignado.Text + "\nSu número es: " + telefono + ".");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => Close();
    }
}
