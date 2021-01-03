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
    public partial class Clientes : Form
    {
        ConexionSQLN cn = new ConexionSQLN();

        public Clientes()
        {
            InitializeComponent();

            dgvClientes.DataSource = cn.ConsultaDTClientes();
            dgvClientes.Columns[0].Width = 170;
            dgvClientes.Columns[1].Width = 230;
            dgvClientes.Columns[2].Width = 100;
            dgvClientes.Columns[3].Width = 100;
            dgvClientes.Columns[4].Width = 100;
            dgvClientes.Columns[5].Width = 100;
            dgvClientes.Columns[6].Width = 160;
            dgvClientes.Columns[7].Width = 100;

            dgvClientes.DefaultCellStyle.Font = new Font("Century Gothic", 9);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*try
            {*/
            if (txtNombre.Text == "" || txtDireccion.Text == "" || txtPostal.Text == ""
                || txtTel.Text == "" || txtCiudad.Text == "" || txtEstado.Text == ""
                || txtEmail.Text == "" || txtRFC.Text == "" || txtNombre.ForeColor == Color.LightSeaGreen
                || txtDireccion.ForeColor == Color.LightSeaGreen || txtTel.ForeColor == Color.LightSeaGreen
                || txtCiudad.ForeColor == Color.LightSeaGreen || txtEstado.ForeColor == Color.LightSeaGreen
                || txtEmail.ForeColor == Color.LightSeaGreen || txtPostal.ForeColor == Color.LightSeaGreen
                || txtRFC.ForeColor == Color.LightSeaGreen)
            {
                MessageBox.Show("Asegúrate de llenar todos los campos para poder guardar un nuevo cliente",
                    "Error al guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                cn.insertarCliente(txtNombre.Text, txtDireccion.Text, txtCiudad.Text,
                    txtEstado.Text, txtTel.Text, txtEmail.Text, txtPostal.Text, txtRFC.Text);
                cn.cerrarCon();
                

                MessageBox.Show("Se ha guardado con éxito",
                        "¡LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvClientes.DataSource = cn.ConsultaDTClientes();
                cn.cerrarCon();

                txtNombre.Text = "Nombre:";
                txtDireccion.Text = "Dirección:";
                txtCiudad.Text = "Ciudad:";
                txtEstado.Text = "Estado:";
                txtTel.Text = "Teléfono(s):";
                txtEmail.Text = "e-Mail:";
                txtPostal.Text = "Código Postal:";
                txtRFC.Text = "RFC:";

                txtNombre.ForeColor = Color.LightSeaGreen;
                txtDireccion.ForeColor = Color.LightSeaGreen;
                txtCiudad.ForeColor = Color.LightSeaGreen;
                txtEstado.ForeColor = Color.LightSeaGreen;
                txtTel.ForeColor = Color.LightSeaGreen;
                txtEmail.ForeColor = Color.LightSeaGreen;
                txtPostal.ForeColor = Color.LightSeaGreen;
                txtRFC.ForeColor = Color.LightSeaGreen;


                //Falta para limpiar los campos de texto
            }
            /*}
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un ERROR. Cierra la ventana e intenta de nuevo",
                    "Error" + error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Clientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //private void txtNombreCl_Enter(object sender, EventArgs e)
        //{

        //}

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
                txtNombre.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Trim() == "Dirección:")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.White;
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Trim() == "")
            {
                txtDireccion.Text = "Dirección:";
                txtDireccion.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtPostal_Enter(object sender, EventArgs e)
        {
            if (txtPostal.Text.Trim() == "Código Postal:")
            {
                txtPostal.Text = "";
                txtPostal.ForeColor = Color.White;
            }
        }

        private void txtPostal_Leave(object sender, EventArgs e)
        {
            if (txtPostal.Text.Trim() == "")
            {
                txtPostal.Text = "Código Postal:";
                txtPostal.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtCiudad_Enter(object sender, EventArgs e)
        {
            if (txtCiudad.Text.Trim() == "Ciudad:")
            {
                txtCiudad.Text = "";
                txtCiudad.ForeColor = Color.White;
            }
        }

        private void txtCiudad_Leave(object sender, EventArgs e)
        {
            if (txtCiudad.Text.Trim() == "")
            {
                txtCiudad.Text = "Ciudad:";
                txtCiudad.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtEstado_Enter(object sender, EventArgs e)
        {
            if (txtEstado.Text.Trim() == "Estado:")
            {
                txtEstado.Text = "";
                txtEstado.ForeColor = Color.White;
            }
        }

        private void txtEstado_Leave(object sender, EventArgs e)
        {
            if (txtEstado.Text.Trim() == "")
            {
                txtEstado.Text = "Estado:";
                txtEstado.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
            if (txtTel.Text.Trim() == "Teléfono(s):")
            {
                txtTel.Text = "";
                txtTel.ForeColor = Color.White;
            }
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            if (txtTel.Text.Trim() == "")
            {
                txtTel.Text = "Teléfono(s):";
                txtTel.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "e-Mail:")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                txtEmail.Text = "e-Mail:";
                txtEmail.ForeColor = Color.LightSeaGreen;
            }
        }

        private void txtRFC_Enter(object sender, EventArgs e)
        {
            if (txtRFC.Text.Trim() == "RFC:")
            {
                txtRFC.Text = "";
                txtRFC.ForeColor = Color.White;
            }
        }

        private void txtRFC_Leave(object sender, EventArgs e)
        {
            if (txtRFC.Text.Trim() == "")
            {
                txtRFC.Text = "RFC:";
                txtRFC.ForeColor = Color.LightSeaGreen;
            }
        }
    }
}
