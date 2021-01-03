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
    public partial class Pedidos_Clientes : Form
    {
        ConexionSQLN cn = new ConexionSQLN();

        public Pedidos_Clientes()
        {
            InitializeComponent();

            dgvSeleccionarCliente.DataSource = cn.ConsultaDTClientes();
            cn.cerrarCon();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string nombre = this.dgvSeleccionarCliente.CurrentRow.Cells[0].Value.ToString();
            string direccion = this.dgvSeleccionarCliente.CurrentRow.Cells[1].Value.ToString();
            string ciudad = this.dgvSeleccionarCliente.CurrentRow.Cells[2].Value.ToString();
            string estado = this.dgvSeleccionarCliente.CurrentRow.Cells[3].Value.ToString();
            string telefono = this.dgvSeleccionarCliente.CurrentRow.Cells[5].Value.ToString();
            string email = this.dgvSeleccionarCliente.CurrentRow.Cells[6].Value.ToString();
            string postal = this.dgvSeleccionarCliente.CurrentRow.Cells[4].Value.ToString();
            string rfc = this.dgvSeleccionarCliente.CurrentRow.Cells[7].Value.ToString();

            Pedidos dato = new Pedidos(nombre, direccion, ciudad, estado, telefono, email,
                postal, rfc);

            dato.Show();

            this.Hide();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            pedidos.Show();
            this.Close();
        }

        private void btnCancelar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
