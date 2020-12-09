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
using Entidades;

namespace MAESMESA
{
    public partial class Cotizaciones : Form
    {

        private DataTable dt;
        ConexionSQLN cn = new ConexionSQLN();


        public Cotizaciones()
        {
            InitializeComponent();

            txtNombreC.Enabled = false;
            txtNumeroC.Enabled = false;
            txtDireccionC.Enabled = false;
            txtCiudadC.Enabled = false;
            txtEstadoC.Enabled = false;
            txtTelC.Enabled = false;
            txtEmailC.Enabled = false;
            txtPostalC.Enabled = false;
            txtRFCC.Enabled = false;
            txtAtiendeC.Enabled = false;

            dt = new DataTable();
            dt.Columns.Add("Código");
            dt.Columns.Add("Concepto");
            dt.Columns.Add("P.U.");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Importe");
            //dt.Columns.Add("Importe").ReadOnly = true;  hay que hacerlo de solo lectura

            dgvPedido.DataSource = dt;

            dgvPedido.Columns["Código"].Width = 80;
            dgvPedido.Columns["Concepto"].Width = 300;
            dgvPedido.Columns["P.U."].Width = 80;
            dgvPedido.Columns["Cantidad"].Width = 100;
            dgvPedido.Columns["Importe"].Width = 100;

            dgvPedido.DefaultCellStyle.Font = new Font("Century Gothic", 10);

        }

        //Metodo constructor para ponerle el cliente automáticamente

        public Cotizaciones(string nombre, string direccion, string ciudad, string estado, string postal,
            string telefono, string rfc, string email)
        {
            InitializeComponent();

            txtNombreC.Enabled = true;
            txtNumeroC.Enabled = true;
            txtDireccionC.Enabled = true;
            txtCiudadC.Enabled = true;
            txtEstadoC.Enabled = true;
            txtTelC.Enabled = true;
            txtEmailC.Enabled = true;
            txtPostalC.Enabled = true;
            txtRFCC.Enabled = true;
            txtAtiendeC.Enabled = true;

            dt = new DataTable();
            dt.Columns.Add("Código");
            dt.Columns.Add("Concepto");
            dt.Columns.Add("P.U.");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Importe");
            //dt.Columns.Add("Importe").ReadOnly = true;  hay que hacerlo de solo lectura

            dgvPedido.DataSource = dt;

            dgvPedido.Columns["Código"].Width = 80;
            dgvPedido.Columns["Concepto"].Width = 300;
            dgvPedido.Columns["P.U."].Width = 80;
            dgvPedido.Columns["Cantidad"].Width = 100;
            dgvPedido.Columns["Importe"].Width = 100;

            dgvPedido.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            txtNombreC.Text = nombre;
            txtDireccionC.Text = direccion;
            txtCiudadC.Text = ciudad;
            txtEstadoC.Text = estado;
            txtTelC.Text = telefono;
            txtEmailC.Text = email;
            txtRFCC.Text = rfc;
            txtPostalC.Text = postal;




            cn.cerrarCon();

            btnNuevaCotizacion.Enabled = false;
            btnEnviar.Enabled = false;

            DateTime fecha = DateTime.Today;

            string year = fecha.Year.ToString();

            txtNumeroC.Text = "C" + year + "-" + cn.consultaCotizaciones();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtAtiendeC_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {


        }

        private void dgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            int totalFilas = dgvPedido.RowCount;
            double subTotal = 0;

            for(int indice = 0; indice < totalFilas; indice ++)
            {
                double precio = Convert.ToDouble((string)dgvPedido.Rows[indice].Cells[3].Value);
                int unidad = Convert.ToInt32((string)dgvPedido.Rows[indice].Cells[2].Value);

                double importe = precio * unidad;

                dgvPedido.Rows[indice].Cells[4].Value = Convert.ToString(importe);

                subTotal += importe;
                                
            }

            txtSubTotalC.Text = Convert.ToString(subTotal);

            double iva = 0.16;
            txtIVAC.Text = Convert.ToString(subTotal * iva);

            double subIVA = subTotal * iva;
            double total = subTotal + subIVA;

            txtTotalC.Text = Convert.ToString(total);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                if (txtNombreC.Text == "" || txtNumeroC.Text == "" || txtDireccionC.Text == ""
                    || txtTelC.Text == "" || txtCiudadC.Text == "" || txtEstadoC.Text == ""
                    || txtEmailC.Text == "" || txtRFCC.Text == "" || txtAtiendeC.Text == ""
                    || txtPostalC.Text == "")
                {
                    MessageBox.Show("Asegúrate de llenar todos los campos para realizar una cotización",
                        "Error al guardar Cotización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSubTotalC.Text == "" || txtIVAC.Text == "" || txtTotalC.Text == "")
                {
                    MessageBox.Show("Debe realizar la cotización de productos antes de guardar",
                        "Error al guardar Cotización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                cn.cerrarCon();

                    cn.insertarCotizaciones(txtNombreC.Text, txtDireccionC.Text, txtCiudadC.Text,
                        txtEstadoC.Text, txtTelC.Text, txtEmailC.Text, txtPostalC.Text, txtRFCC.Text, txtAtiendeC.Text,
                        dateFechaC.Value.ToString(), dateRecordarC.Value.ToString(),
                        txtSubTotalC.Text, txtIVAC.Text, txtTotalC.Text);

                MessageBox.Show("La Cotización se ha guardado con éxito",
                        "¡LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreC.Enabled = false;
                txtNumeroC.Enabled = false;
                txtDireccionC.Enabled = false;
                txtCiudadC.Enabled = false;
                txtEstadoC.Enabled = false;
                txtTelC.Enabled = false;
                txtEmailC.Enabled = false;
                txtPostalC.Enabled = false;
                txtRFCC.Enabled = false;
                txtAtiendeC.Enabled = false;

                btnNuevaCotizacion.Enabled = true;
                btnEnviar.Enabled = true;


                //Aquí comienza la inserción de los productos en otra tabla

                
                List<Guardar> listGuardar = new List<Guardar>();

                foreach (DataRow row in dt.Rows)
                {
                    Guardar guardar = new Guardar();

                    guardar.Nocot = txtNumeroC.Text;
                    guardar.Cliente = txtNombreC.Text;
                    guardar.Codigo = row["Código"].ToString();
                    guardar.Concepto = row["Concepto"].ToString();
                    guardar.Cantidad = row["Cantidad"].ToString();
                    guardar.Precio = row["P.U."].ToString();
                    guardar.Importe = row["Importe"].ToString();

                    listGuardar.Add(guardar);
                }

                cn.insertarTablaCotizacion(listGuardar);


                //Falta para limpiar los campos de texto
            }
            /*}
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un ERROR. Cierra la ventana e intenta de nuevo",
                    "Error" + error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void comboAtiende_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void NoConInicial(object sender, EventArgs e)
        {
            /*txtNumeroC.Text = "C-" +txtAtiendeC.Text.Substring(0) + cn.consultaCotizaciones();*/
        }

        private void btnNuevaCotizacion_Click(object sender, EventArgs e)
        {
            cn.cerrarCon();

            btnNuevaCotizacion.Enabled = false;
            btnEnviar.Enabled = false;

            DateTime fecha = DateTime.Today;

            string year = fecha.Year.ToString();
            //string newYear = cn.consultaYear();

            //int newYear = Convert.ToInt32(cn.consultaYear());

            /*if(year != cn.consultaYear())
            {
                cn.updateYear(fecha.Year + 1);
                cn.updateIndexCot(0);
            }*/


            //Comienza código para reiniciar la DataGriView
            dgvPedido.DataSource = null;

            dt = new DataTable();
            dt.Columns.Add("Código");
            dt.Columns.Add("Concepto");
            dt.Columns.Add("P.U.");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Importe");
            //dt.Columns.Add("Importe").ReadOnly = true;  hay que hacerlo de solo lectura

            dgvPedido.DataSource = dt;

            dgvPedido.Columns["Código"].Width = 80;
            dgvPedido.Columns["Concepto"].Width = 300;
            dgvPedido.Columns["P.U."].Width = 80;
            dgvPedido.Columns["Cantidad"].Width = 100;
            dgvPedido.Columns["Importe"].Width = 100;

            dgvPedido.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            //Termina código para limpiar DataGridView



            txtNumeroC.Text = "C" + year + "-" + cn.consultaCotizaciones();

            txtNombreC.Enabled = true;
            txtNumeroC.Enabled = true;
            txtDireccionC.Enabled = true;
            txtCiudadC.Enabled = true;
            txtEstadoC.Enabled = true;
            txtTelC.Enabled = true;
            txtEmailC.Enabled = true;
            txtPostalC.Enabled = true;
            txtRFCC.Enabled = true;
            txtAtiendeC.Enabled = true;

            txtNombreC.Text = "";
            txtDireccionC.Text = "";
            txtCiudadC.Text = "";
            txtEstadoC.Text = "";
            txtTelC.Text = "";
            txtEmailC.Text = "";
            txtPostalC.Text = "";
            txtRFCC.Text = "";
            txtAtiendeC.Text = "";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtNombreC.Text == "" ||
            txtDireccionC.Text == "" ||
            txtCiudadC.Text == "" ||
            txtEstadoC.Text == "" ||
            txtTelC.Text == "" ||
            txtEmailC.Text == "" ||
            txtPostalC.Text == "" ||
            txtRFCC.Text == "" ||
            txtAtiendeC.Text == "")
            {
                MessageBox.Show("Necesitas llenar todos los campos del cliente",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nombre = txtNombreC.Text;
                string direccion = txtDireccionC.Text;
                string ciudad = txtCiudadC.Text;
                string estado = txtEstadoC.Text;
                string tel = txtTelC.Text;
                string email = txtEmailC.Text;
                string postal = txtPostalC.Text;
                string rfc = txtRFCC.Text;
                string atiende = txtAtiendeC.Text;
                /*string col0 = this.dgvPedido.CurrentRow.Cells[0].Value.ToString();
                string col1 = this.dgvPedido.CurrentRow.Cells[1].Value.ToString();
                string col2 = this.dgvPedido.CurrentRow.Cells[2].Value.ToString();
                string col3 = this.dgvPedido.CurrentRow.Cells[3].Value.ToString();
                string col4 = this.dgvPedido.CurrentRow.Cells[4].Value.ToString();*/
                

                Pedidos pedidos = new Pedidos(nombre, direccion, ciudad, estado, tel, email, postal, 
                    rfc, atiende/*, col0, col1, col2, col3, col4*/);
                pedidos.Show();
            }

            
        }

        private void btnBuscarProductoC_Click(object sender, EventArgs e)
        {

            cn.cerrarCon();

            var resultado = cn.consultaProductosLlenar(txtBuscarProductoC.Text);

            //cn.cerrarCon();

            DataRow row = dt.NewRow();

            if(resultado.Item1 == "Null")
            {
                MessageBox.Show("No existe un producto con ese Código en la Base de Datos",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtBuscarProductoC.Text == "")
            {
                MessageBox.Show("Asegúrate de insertar un código de producto",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                row["Código"] = resultado.Item1;
                row["Concepto"] = resultado.Item2;

                dt.Rows.Add(row);

                txtBuscarProductoC.Text = "";
            }

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Cotizaciones_Clientes seleccionar = new Cotizaciones_Clientes();

            seleccionar.Show();
        
        }

        private void btnTSBuscar_Click(object sender, EventArgs e)
        {

            cn.cerrarCon();

            var resultado1 = cn.consultaCotizacionLlenar1(tSTBuscarCot.Text);
            cn.cerrarCon();
            var resultado2 = cn.consultaCotizacionLlenar2(tSTBuscarCot.Text);
            cn.cerrarCon();

            if (tSTBuscarCot.Text == "")
            {
                MessageBox.Show("Asegúrate de insertar un número de Cotización",
                        "Error al buscar Cotización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado1.Item1 == "Null")
            {
                MessageBox.Show("No existe este Número de Cotización en la Base de Datos",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtNumeroC.Text = resultado1.Item1;
                txtNombreC.Text = resultado1.Item2;
                txtDireccionC.Text = resultado1.Item3;
                txtCiudadC.Text = resultado1.Item4;
                txtEstadoC.Text = resultado1.Item5;
                txtPostalC.Text = resultado1.Item6;
                txtTelC.Text = resultado1.Item7;

                txtEmailC.Text = resultado2.Item1;
                txtRFCC.Text = resultado2.Item2;
                txtAtiendeC.Text = resultado2.Item3;
                dateFechaC.Value = Convert.ToDateTime(resultado2.Item4);
                txtSubTotalC.Text = resultado2.Item5;
                txtIVAC.Text = resultado2.Item6;
                txtTotalC.Text = resultado2.Item7;

                txtBuscarProductoC.Text = "";

                dgvPedido.DataSource = cn.consultaCotizacionTabla("C2020-27");
            }
        }
    }
}
