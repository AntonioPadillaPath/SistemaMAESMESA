using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocios;

namespace MAESMESA
{
    public partial class Productos : Form
    {
        ConexionSQLN cn = new ConexionSQLN();

        public Productos()
        {
            InitializeComponent();
            dgvProductos.DataSource = cn.ConsultaDT();
            dgvProductos.Columns[0].Width = 100;
            dgvProductos.Columns[1].Width = 350;
            dgvProductos.Columns[2].Width = 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "" || txtNombre.Text == "" || txtMedidas.Text == "")
                {
                    MessageBox.Show("Asegúrate de llenar todos los campos para agregar el nuevo producto",
                        "Error al agregar nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cn.insertarProducto(txtCodigo.Text, txtNombre.Text, txtMedidas.Text);
                    dgvProductos.DataSource = cn.ConsultaDT();
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtMedidas.Text = "";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Asegúrate que el nuevo código a ingresar no se repita",
                    "Error al agregar nuevo Producto" +error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;

            if(n != -1)
            {
                txtCodigo.Text = (string)dgvProductos.Rows[n].Cells[0].Value;
                txtNombre.Text = (string)dgvProductos.Rows[n].Cells[1].Value;
                txtMedidas.Text = (string)dgvProductos.Rows[n].Cells[2].Value;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
