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
    public partial class Cotizaciones_Clientes : Form
    {

        ConexionSQLN cn = new ConexionSQLN();

        public Cotizaciones_Clientes()
        {
            InitializeComponent();

            dgvSeleccionarCliente.DataSource = cn.ConsultaDTClientes();
        }

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

            Cotizaciones dato = new Cotizaciones(nombre, direccion, ciudad, estado, telefono, email,
                postal, rfc);

            dato.Show();
            
            this.Hide();

        }
    }
}
