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
using Entidades;

namespace MAESMESA
{
    public partial class Cotizaciones : Form
    {

        private DataTable dt;
        ConexionSQLN cn = new ConexionSQLN();

        string nombre1 = "";
        string apellido1 = "";
        byte[] foto1;

        public Cotizaciones(string nombre, string apellido, byte[]foto)
        {
            InitializeComponent();

            nombre1 = nombre;
            apellido1 = apellido;
            foto1 = foto;

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

            btnBuscarProductoC.Enabled = false;
            btnCotizacion.Enabled = false;
            btnGuardar.Enabled = false;
            btnSeleccionarCliente.Enabled = false;
            btnEnviar.Enabled = false;

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        //Metodo constructor para ponerle el cliente automáticamente

        public Cotizaciones(string nombre, string direccion, string ciudad, string estado, string postal,
            string telefono, string rfc, string email, string nom, string ape, byte[]foto)
        {
            InitializeComponent();

            nombre1 = nom;
            apellido1 = ape;
            foto1 = foto;

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

            txtNombreC.ForeColor = Color.Black;
            txtDireccionC.ForeColor = Color.Black;
            txtCiudadC.ForeColor = Color.Black;
            txtEstadoC.ForeColor = Color.Black;
            txtTelC.ForeColor = Color.Black;
            txtEmailC.ForeColor = Color.Black;
            txtPostalC.ForeColor = Color.Black;
            txtRFCC.ForeColor = Color.Black;

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


            DateTime fecha = DateTime.Today;

            string year = fecha.Year.ToString();
            int year1 = fecha.Year;
            int newYear = Convert.ToInt32(cn.consultaYear());
            cn.cerrarCon();

            if (year1 != newYear)
            {
                cn.updateYear(newYear + 1);
                cn.cerrarCon();
                int index = 0;
                cn.updateIndexCot(index);
                cn.cerrarCon();
            }

            //txtNumeroC.Text = "C" + year + "-" + cn.consultaCotizaciones();
            string parte1 = "C" + year1.ToString();
            cn.cerrarCon();

            string parte2 = cn.consultaCotizacionesIndex().ToString();
            cn.cerrarCon();

            txtNumeroC.Text = parte1 + "-" + parte2;

            btnBuscarProductoC.Enabled = true;
            btnCotizacion.Enabled = true;
            btnSeleccionarCliente.Enabled = true;

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
                double precio = Convert.ToDouble((string)dgvPedido.Rows[indice].Cells[2].Value);
                int unidad = Convert.ToInt32((string)dgvPedido.Rows[indice].Cells[3].Value);

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

            btnGuardar.Enabled = true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                if (txtNombreC.Text == "" || txtNumeroC.Text == "" || txtDireccionC.Text == ""
                    || txtTelC.Text == "" || txtCiudadC.Text == "" || txtEstadoC.Text == ""
                    || txtEmailC.Text == "" || txtRFCC.Text == "" || txtAtiendeC.Text == ""
                    || txtPostalC.Text == "" || txtAtiendeC.Text == "Atiende:" ||
                    txtNombreC.Text == "Nombre:" || txtDireccionC.Text == "Dirección:"
                    || txtTelC.Text == "Teléfono(s):" || txtCiudadC.Text == "Ciudad:" || txtEstadoC.Text == "Estado:"
                    || txtEmailC.Text == "e-Mail:" || txtRFCC.Text == "RFC:" || txtPostalC.Text == "Código Postal:"
                    )
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

                DateTime fechaActual = dateFechaC.Value;
                DateTime fechaRecordar = dateRecordarC.Value;

                string fechaHoy = fechaActual.Day.ToString() + "/" +fechaActual.Month.ToString() + "/" +fechaActual.Year.ToString();
                string fechaRecuerdo = fechaRecordar.Day.ToString() + "/" + fechaRecordar.Month.ToString() + "/" + fechaRecordar.Year.ToString();

                cn.insertarCotizaciones(txtNumeroC.Text, txtNombreC.Text, txtDireccionC.Text, txtCiudadC.Text,
                        txtEstadoC.Text, txtPostalC.Text, txtTelC.Text, txtEmailC.Text, txtRFCC.Text, txtAtiendeC.Text,
                        //dateFechaC.Value.ToString(), dateRecordarC.Value.ToString(),
                        fechaHoy, fechaRecuerdo,
                        txtSubTotalC.Text, txtIVAC.Text, txtTotalC.Text);

                cn.cerrarCon();

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

                //Itera el número del index
                int index = Convert.ToInt32(cn.consultaCotizacionesIndex());
                cn.cerrarCon();
                cn.updateIndexCot(index);
                cn.cerrarCon();


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
                    cn.cerrarCon();
                }

                cn.insertarTablaCotizacion(listGuardar);
                cn.cerrarCon();

                btnEnviar.Enabled = true;
                btnGuardar.Enabled = false;
                btnBuscarProductoC.Enabled = false;
                btnSeleccionarCliente.Enabled = false;
                btnCotizacion.Enabled = false;
                btnNuevaCotizacion.Enabled = true;


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

            btnBuscarProductoC.Enabled = true;
            btnCotizacion.Enabled = true;
            btnSeleccionarCliente.Enabled = true;

            DateTime fecha = DateTime.Today;

            string year = fecha.Year.ToString();
            int year1 = fecha.Year;
            int newYear = Convert.ToInt32(cn.consultaYear());
            cn.cerrarCon();

            if (year1 != newYear)
            {
                cn.updateYear(newYear + 1);
                cn.cerrarCon();
                int index = 0;
                cn.updateIndexCot(index);
                cn.cerrarCon();
            }


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



            //txtNumeroC.Text = "C" + year + "-" + cn.consultaCotizaciones();
            string parte1 = "C" + year1.ToString();
            cn.cerrarCon();

            string parte2 = cn.consultaCotizacionesIndex().ToString();
            cn.cerrarCon();

            txtNumeroC.Text = parte1 + "-" + parte2;

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

            txtNombreC.Text = "Nombre:";
            txtDireccionC.Text = "Dirección:";
            txtCiudadC.Text = "Ciudad:";
            txtEstadoC.Text = "Estado:";
            txtTelC.Text = "Teléfono(s):";
            txtEmailC.Text = "e-Mail:";
            txtPostalC.Text = "Código Postal:";
            txtRFCC.Text = "RFC:";
            txtAtiendeC.Text = "Atiende:";
            txtSubTotalC.Text = "";
            txtIVAC.Text = "";
            txtTotalC.Text = "";

            txtNombreC.ForeColor = Color.SlateBlue;
            txtDireccionC.ForeColor = Color.SlateBlue;
            txtCiudadC.ForeColor = Color.SlateBlue;
            txtEstadoC.ForeColor = Color.SlateBlue;
            txtTelC.ForeColor = Color.SlateBlue;
            txtEmailC.ForeColor = Color.SlateBlue;
            txtPostalC.ForeColor = Color.SlateBlue;
            txtRFCC.ForeColor = Color.SlateBlue;
            txtAtiendeC.ForeColor = Color.SlateBlue;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtNombreC.Text == "" || txtDireccionC.Text == "" || txtCiudadC.Text == "" ||
            txtEstadoC.Text == "" || txtTelC.Text == "" || txtEmailC.Text == "" ||
            txtPostalC.Text == "" || txtRFCC.Text == "" || txtAtiendeC.Text == "" ||
            txtAtiendeC.Text == "Atiende:" || txtNombreC.Text == "Nombre:" || txtDireccionC.Text == "Dirección:"
            || txtTelC.Text == "Teléfono(s):" || txtCiudadC.Text == "Ciudad:" || txtEstadoC.Text == "Estado:"
            || txtEmailC.Text == "e-Mail:" || txtRFCC.Text == "RFC:" || txtPostalC.Text == "Código Postal:"
            )
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
                string numero = txtNumeroC.Text;

                Pedidos pedidos = new Pedidos(nombre, direccion, ciudad, estado, tel, email, postal, 
                    rfc, atiende, numero, nombre1, apellido1, foto1);
                pedidos.Show();

                this.Close();
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

                txtBuscarProductoC.Text = "Buscar Código...";
                txtBuscarProductoC.ForeColor = Color.SlateBlue;
            }

            cn.cerrarCon();

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Cotizaciones_Clientes seleccionar = new Cotizaciones_Clientes(nombre1, apellido1, foto1);

            this.Close();
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


                dgvPedido.DataSource = cn.consultaCotizacionTabla(tSTBuscarCot.Text.Trim());
                cn.cerrarCon();


                tSTBuscarCot.Text = "";

                btnBuscarProductoC.Enabled = true;
                btnSeleccionarCliente.Enabled = false;
                btnCotizacion.Enabled = true;
                btnGuardar.Enabled = false;
                btnEnviar.Enabled = true;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(nombre1, apellido1, foto1);
            menu.Show();

            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Cotizaciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtNombreC_Enter(object sender, EventArgs e)
        {
            if(txtNombreC.Text.Trim() == "Nombre:")
            {
                txtNombreC.Text = "";
                txtNombreC.ForeColor = Color.Black;
            }
        }

        private void txtNombreC_Leave(object sender, EventArgs e)
        {
            if(txtNombreC.Text.Trim() == "")
            {
                txtNombreC.Text = "Nombre:";
                txtNombreC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtDireccionC_Enter(object sender, EventArgs e)
        {
            if (txtDireccionC.Text.Trim() == "Dirección:")
            {
                txtDireccionC.Text = "";
                txtDireccionC.ForeColor = Color.Black;
            }
        }

        private void txtDireccionC_Leave(object sender, EventArgs e)
        {
            if (txtDireccionC.Text.Trim() == "")
            {
                txtDireccionC.Text = "Dirección:";
                txtDireccionC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtPostalC_Enter(object sender, EventArgs e)
        {
            if (txtPostalC.Text.Trim() == "Código Postal:")
            {
                txtPostalC.Text = "";
                txtPostalC.ForeColor = Color.Black;
            }
        }

        private void txtPostalC_Leave(object sender, EventArgs e)
        {
            if (txtPostalC.Text.Trim() == "")
            {
                txtPostalC.Text = "Código Postal:";
                txtPostalC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtCiudadC_Enter(object sender, EventArgs e)
        {
            if (txtCiudadC.Text.Trim() == "Ciudad:")
            {
                txtCiudadC.Text = "";
                txtCiudadC.ForeColor = Color.Black;
            }
        }

        private void txtCiudadC_Leave(object sender, EventArgs e)
        {
            if (txtCiudadC.Text.Trim() == "")
            {
                txtCiudadC.Text = "Ciudad:";
                txtCiudadC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtEstadoC_Enter(object sender, EventArgs e)
        {
            if (txtEstadoC.Text.Trim() == "Estado:")
            {
                txtEstadoC.Text = "";
                txtEstadoC.ForeColor = Color.Black;
            }
        }

        private void txtEstadoC_Leave(object sender, EventArgs e)
        {
            if (txtEstadoC.Text.Trim() == "")
            {
                txtEstadoC.Text = "Estado:";
                txtEstadoC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtTelC_Enter(object sender, EventArgs e)
        {
            if (txtTelC.Text.Trim() == "Teléfono(s):")
            {
                txtTelC.Text = "";
                txtTelC.ForeColor = Color.Black;
            }
        }

        private void txtTelC_Leave(object sender, EventArgs e)
        {
            if (txtTelC.Text.Trim() == "")
            {
                txtTelC.Text = "Teléfono(s):";
                txtTelC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtEmailC_Enter(object sender, EventArgs e)
        {
            if (txtEmailC.Text.Trim() == "e-Mail:")
            {
                txtEmailC.Text = "";
                txtEmailC.ForeColor = Color.Black;
            }
        }

        private void txtEmailC_Leave(object sender, EventArgs e)
        {
            if (txtEmailC.Text.Trim() == "")
            {
                txtEmailC.Text = "e-Mail:";
                txtEmailC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtRFCC_Enter(object sender, EventArgs e)
        {
            if (txtRFCC.Text.Trim() == "RFC:")
            {
                txtRFCC.Text = "";
                txtRFCC.ForeColor = Color.Black;
            }
        }

        private void txtRFCC_Leave(object sender, EventArgs e)
        {
            if (txtRFCC.Text.Trim() == "")
            {
                txtRFCC.Text = "RFC:";
                txtRFCC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtAtiendeC_Enter(object sender, EventArgs e)
        {
            if (txtAtiendeC.Text.Trim() == "Atiende:")
            {
                txtAtiendeC.Text = "";
                txtAtiendeC.ForeColor = Color.Black;
            }
        }

        private void txtAtiendeC_Leave(object sender, EventArgs e)
        {
            if (txtAtiendeC.Text.Trim() == "")
            {
                txtAtiendeC.Text = "Atiende:";
                txtAtiendeC.ForeColor = Color.SlateBlue;
            }
        }

        private void txtBuscarProductoC_Enter(object sender, EventArgs e)
        {
            if (txtBuscarProductoC.Text.Trim() == "Buscar Código...")
            {
                txtBuscarProductoC.Text = "";
                txtBuscarProductoC.ForeColor = Color.Black;
            }
        }

        private void txtBuscarProductoC_Leave(object sender, EventArgs e)
        {
            if (txtBuscarProductoC.Text.Trim() == "")
            {
                txtBuscarProductoC.Text = "Buscar Código...";
                txtBuscarProductoC.ForeColor = Color.SlateBlue;
            }
        }
    }
}
