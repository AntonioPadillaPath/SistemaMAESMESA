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
    public partial class Clientes : Form
    {
        ConexionSQLN cn = new ConexionSQLN();

        public Clientes()
        {
            InitializeComponent();

            dgvClientes.DataSource = cn.ConsultaDTClientes();
            dgvClientes.Columns[0].Width = 300;
            dgvClientes.Columns[1].Width = 700;
            dgvClientes.Columns[2].Width = 150;
            dgvClientes.Columns[3].Width = 150;
            dgvClientes.Columns[4].Width = 150;
            dgvClientes.Columns[5].Width = 400;
            dgvClientes.Columns[6].Width = 300;
            dgvClientes.Columns[7].Width = 200;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*try
            {*/
            if (txtNombreCl.Text == "" || txtDireccionCl.Text == ""
                || txtTelCl.Text == "" || txtCiudadCl.Text == "" || txtEstadoCl.Text == ""
                || txtEmailCl.Text == "" || txtRFCCl.Text == "")
            {
                MessageBox.Show("Asegúrate de llenar todos los campos para poder guardar un nuevo cliente",
                    "Error al guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                cn.insertarCliente(txtNombreCl.Text, txtDireccionCl.Text, txtCiudadCl.Text,
                    txtEstadoCl.Text, txtTelCl.Text, txtEmailCl.Text, txtPostalCl.Text, txtRFCCl.Text);
                

                MessageBox.Show("Se ha guardado con éxito",
                        "¡LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvClientes.DataSource = cn.ConsultaDTClientes();

                txtNombreCl.Text = "";
                txtDireccionCl.Text = "";
                txtCiudadCl.Text = "";
                txtEstadoCl.Text = "";
                txtTelCl.Text = "";
                txtEmailCl.Text = "";
                txtPostalCl.Text = "";
                txtRFCCl.Text = "";


                //Falta para limpiar los campos de texto
            }
            /*}
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un ERROR. Cierra la ventana e intenta de nuevo",
                    "Error" + error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
