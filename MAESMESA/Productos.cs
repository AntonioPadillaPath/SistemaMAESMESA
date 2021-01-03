using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

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
                if (txtCodigo.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtMedidas.Text.Trim() == "" ||
                    txtCodigo.ForeColor == Color.MediumPurple || txtNombre.ForeColor == Color.MediumPurple 
                    || txtMedidas.ForeColor == Color.MediumPurple)
                {
                    MessageBox.Show("Asegúrate de llenar todos los campos para agregar el nuevo producto",
                        "Error al agregar nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("¡El producto se ha agregado con Éxito!",
                        "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cn.insertarProducto(txtCodigo.Text, txtNombre.Text, txtMedidas.Text);
                    cn.cerrarCon();
                    dgvProductos.DataSource = cn.ConsultaDT();
                    cn.cerrarCon();
                    txtCodigo.Text = "Código:";
                    txtNombre.Text = "Nombre:";
                    txtMedidas.Text = "Medidas:";

                    txtCodigo.ForeColor = Color.MediumPurple;
                    txtNombre.ForeColor = Color.MediumPurple;
                    txtMedidas.ForeColor = Color.MediumPurple;
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

        private void Productos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "Nombre:")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.White;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                txtNombre.Text = "Nombre:";
                txtNombre.ForeColor = Color.MediumPurple;
            }
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "Código:")
            {
                txtCodigo.Text = "";
                txtCodigo.ForeColor = Color.White;
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                txtCodigo.Text = "Código:";
                txtCodigo.ForeColor = Color.MediumPurple;
            }
        }

        private void txtMedidas_Enter(object sender, EventArgs e)
        {
            if (txtMedidas.Text.Trim() == "Medidas:")
            {
                txtMedidas.Text = "";
                txtMedidas.ForeColor = Color.White;
            }
        }

        private void txtMedidas_Leave(object sender, EventArgs e)
        {
            if (txtMedidas.Text.Trim() == "")
            {
                txtMedidas.Text = "Medidas:";
                txtMedidas.ForeColor = Color.MediumPurple;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar éste PRODUCTO?", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string nombre = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[1].Value.ToString();

                cn.eliminarProducto(nombre);

                dgvProductos.DataSource = cn.ConsultaDT();
                cn.cerrarCon();

                MessageBox.Show("Eliminado",
                        "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
