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
    public partial class Cotizaciones_Clientes : Form
    {

        ConexionSQLN cn = new ConexionSQLN();

        string nombre1 = "";
        string apellido1 = "";
        byte[] foto1;

        public Cotizaciones_Clientes(string nombre, string apellido, byte[] foto)
        {
            InitializeComponent();

            nombre1 = nombre;
            apellido1 = apellido;
            foto1 = foto;

            dgvSeleccionarCliente.DataSource = cn.ConsultaDTClientes();
            cn.cerrarCon();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cotizaciones cotizaciones = new Cotizaciones(nombre1, apellido1, foto1);
            this.Close();
            cotizaciones.Show();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string nombre = this.dgvSeleccionarCliente.CurrentRow.Cells[0].Value.ToString();
            string direccion = this.dgvSeleccionarCliente.CurrentRow.Cells[1].Value.ToString();
            string ciudad = this.dgvSeleccionarCliente.CurrentRow.Cells[2].Value.ToString();
            string estado = this.dgvSeleccionarCliente.CurrentRow.Cells[3].Value.ToString();
            string postal = this.dgvSeleccionarCliente.CurrentRow.Cells[4].Value.ToString();
            string telefono = this.dgvSeleccionarCliente.CurrentRow.Cells[5].Value.ToString();
            string email = this.dgvSeleccionarCliente.CurrentRow.Cells[6].Value.ToString();
            string rfc = this.dgvSeleccionarCliente.CurrentRow.Cells[7].Value.ToString();

            Cotizaciones dato = new Cotizaciones(nombre, direccion, ciudad, estado, postal, telefono,
                email, rfc, nombre1, apellido1, foto1);

            dato.Show();
            
            this.Close();

        }

        private void Cotizaciones_Clientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }
}
