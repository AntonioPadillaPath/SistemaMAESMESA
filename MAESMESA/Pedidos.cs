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
    public partial class Pedidos : Form
    {
        private DataTable dt;
        ConexionSQLN cn = new ConexionSQLN();

        string nombre1 = "";
        string apellido1 = "";
        byte[] foto1;

        public Pedidos(string nombre, string apellido, byte[] foto)
        {
            InitializeComponent();

            nombre1 = nombre;
            apellido1 = apellido;
            foto1 = foto;

            txtNombreP.Enabled = false;
            txtNumeroP.Enabled = false;
            txtDireccionP.Enabled = false;
            txtCiudadP.Enabled = false;
            txtEstadoP.Enabled = false;
            txtTelP.Enabled = false;
            txtEmailP.Enabled = false;
            txtPostalP.Enabled = false;
            txtRFCP.Enabled = false;
            txtAtiendeP.Enabled = false;
            txtComentariosP.Enabled = false;
            txtFPagoP.Enabled = false;
            txtOCompraP.Enabled = false;
            txtEntregaP.Enabled = false;

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
            btnPedido.Enabled = false;
            btnGuardarPedido.Enabled = false;
            btnSeleccionarCliente.Enabled = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        public Pedidos(string nombre, string direccion, 
            string ciudad, string estado, string tel, string email, 
            string postal, string rfc, string atiende, string numero, string nom, string ape, byte[] foto)
        {
            InitializeComponent();

            nombre1 = nom;
            apellido1 = ape;
            foto1 = foto;

            txtNombreP.Enabled = true;
            txtNumeroP.Enabled = true;
            txtDireccionP.Enabled = true;
            txtCiudadP.Enabled = true;
            txtEstadoP.Enabled = true;
            txtTelP.Enabled = true;
            txtEmailP.Enabled = true;
            txtPostalP.Enabled = true;
            txtRFCP.Enabled = true;
            txtAtiendeP.Enabled = true;
            txtComentariosP.Enabled = true;
            txtFPagoP.Enabled = true;
            txtOCompraP.Enabled = true;
            txtEntregaP.Enabled = true;

            txtNombreP.ForeColor = Color.Black;
            txtDireccionP.ForeColor = Color.Black;
            txtCiudadP.ForeColor = Color.Black;
            txtEstadoP.ForeColor = Color.Black;
            txtTelP.ForeColor = Color.Black;
            txtEmailP.ForeColor = Color.Black;
            txtPostalP.ForeColor = Color.Black;
            txtRFCP.ForeColor = Color.Black;
            txtAtiendeP.ForeColor = Color.Black;

            txtNombreP.Text = nombre;
            txtDireccionP.Text = direccion;
            txtCiudadP.Text = ciudad;
            txtEstadoP.Text = estado;
            txtTelP.Text = tel;
            txtEmailP.Text = email;
            txtPostalP.Text = postal;
            txtRFCP.Text = rfc;
            txtAtiendeP.Text = atiende;

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


            cn.cerrarCon();

            //var resultado1 = cn.consultaCotizacionLlenar1("2");
            //cn.cerrarCon();
            //var resultado2 = cn.consultaCotizacionLlenar2("2");
            //cn.cerrarCon();

            dgvPedido.DataSource = cn.consultaCotizacionTabla(numero);
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
                cn.updateIndexPed(index);
                cn.cerrarCon();
            }

            //txtNumeroC.Text = "C" + year + "-" + cn.consultaCotizaciones();
            string parte1 = "P" + year1.ToString();
            cn.cerrarCon();

            string parte2 = cn.consultaPedidosIndex().ToString();
            cn.cerrarCon();

            txtNumeroP.Text = parte1 + "-" + parte2;

            btnBuscarProductoC.Enabled = true;
            btnPedido.Enabled = true;
            btnSeleccionarCliente.Enabled = true;
            btnGuardarPedido.Enabled = false;

        }

        //Metodo constructor para ponerle el cliente automáticamente

        public Pedidos(string nombre, string direccion, string ciudad, string estado, string postal,
            string telefono, string rfc, string email, string nom, string ape, byte[] foto)
        {
            InitializeComponent();

            nombre1 = nom;
            apellido1 = ape;
            foto1 = foto;

            txtNombreP.Enabled = true;
            txtNumeroP.Enabled = true;
            txtDireccionP.Enabled = true;
            txtCiudadP.Enabled = true;
            txtEstadoP.Enabled = true;
            txtTelP.Enabled = true;
            txtEmailP.Enabled = true;
            txtPostalP.Enabled = true;
            txtRFCP.Enabled = true;
            txtAtiendeP.Enabled = true;
            txtComentariosP.Enabled = true;
            txtFPagoP.Enabled = true;
            txtOCompraP.Enabled = true;
            txtEntregaP.Enabled = true;

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

            txtNombreP.Text = nombre;
            txtDireccionP.Text = direccion;
            txtCiudadP.Text = ciudad;
            txtEstadoP.Text = estado;
            txtTelP.Text = telefono;
            txtEmailP.Text = email;
            txtRFCP.Text = rfc;
            txtPostalP.Text = postal;




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
                cn.updateIndexPed(index);
                cn.cerrarCon();
            }

            //txtNumeroC.Text = "C" + year + "-" + cn.consultaCotizaciones();
            string parte1 = "P" + year1.ToString();
            cn.cerrarCon();

            string parte2 = cn.consultaPedidosIndex().ToString();
            cn.cerrarCon();

            txtNumeroP.Text = parte1 + "-" + parte2;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEstadoP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTSBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Pedidos_Clientes seleccionar = new Pedidos_Clientes(nombre1, apellido1, foto1);

            seleccionar.Show();
            this.Close();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            int totalFilas = dgvPedido.RowCount;
            double subTotal = 0;

            for (int indice = 0; indice < totalFilas; indice++)
            {
                double precio = Convert.ToDouble((string)dgvPedido.Rows[indice].Cells[2].Value);
                int unidad = Convert.ToInt32((string)dgvPedido.Rows[indice].Cells[3].Value);

                double importe = precio * unidad;

                dgvPedido.Rows[indice].Cells[4].Value = Convert.ToString(importe);

                subTotal += importe;

            }

            txtSubTotalP.Text = Convert.ToString(subTotal);

            double iva = 0.16;
            txtIVAP.Text = Convert.ToString(subTotal * iva);

            double subIVA = subTotal * iva;
            double total = subTotal + subIVA;

            txtTotalP.Text = Convert.ToString(total);

            btnGuardarPedido.Enabled = true;
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            cn.cerrarCon();

            btnSeleccionarCliente.Enabled = true;
            btnBuscarProductoC.Enabled = true;
            btnPedido.Enabled = true;

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
                cn.updateIndexPed(index);
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
            string parte1 = "P" + year1.ToString();
            cn.cerrarCon();

            string parte2 = cn.consultaPedidosIndex().ToString();
            cn.cerrarCon();

            txtNumeroP.Text = parte1 + "-" + parte2;

            txtNombreP.Enabled = true;
            txtNumeroP.Enabled = true;
            txtDireccionP.Enabled = true;
            txtCiudadP.Enabled = true;
            txtEstadoP.Enabled = true;
            txtTelP.Enabled = true;
            txtEmailP.Enabled = true;
            txtPostalP.Enabled = true;
            txtRFCP.Enabled = true;
            txtAtiendeP.Enabled = true;
            txtComentariosP.Enabled = true;
            txtFPagoP.Enabled = true;
            txtOCompraP.Enabled = true;
            txtEntregaP.Enabled = true;

            txtNombreP.Text = "Nombre:";
            txtDireccionP.Text = "Dirección:";
            txtCiudadP.Text = "Ciudad:";
            txtEstadoP.Text = "Estado";
            txtTelP.Text = "Teléfono(s):";
            txtEmailP.Text = "e-Mail:";
            txtPostalP.Text = "Código Postal:";
            txtRFCP.Text = "RFC:";
            txtAtiendeP.Text = "Atiende:";
            txtComentariosP.Text = "Comentarios:";
            txtFPagoP.Text = "";
            txtOCompraP.Text = "";
            txtEntregaP.Text = "";

            txtNombreP.ForeColor = Color.SlateBlue;
            txtDireccionP.ForeColor = Color.SlateBlue;
            txtCiudadP.ForeColor = Color.SlateBlue;
            txtEstadoP.ForeColor = Color.SlateBlue;
            txtTelP.ForeColor = Color.SlateBlue;
            txtEmailP.ForeColor = Color.SlateBlue;
            txtPostalP.ForeColor = Color.SlateBlue;
            txtRFCP.ForeColor = Color.SlateBlue;
            txtAtiendeP.ForeColor = Color.SlateBlue;
            txtComentariosP.ForeColor = Color.SlateBlue;
        }

        private void btnBuscarProductoC_Click(object sender, EventArgs e)
        {
            cn.cerrarCon();

            var resultado = cn.consultaProductosLlenar(txtBuscarProductoP.Text);

            //cn.cerrarCon();

            DataRow row = dt.NewRow();

            if (resultado.Item1 == "Null")
            {
                MessageBox.Show("No existe un producto con ese Código en la Base de Datos",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtBuscarProductoP.Text == "")
            {
                MessageBox.Show("Asegúrate de insertar un código de producto",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                row["Código"] = resultado.Item1;
                row["Concepto"] = resultado.Item2;

                dt.Rows.Add(row);

                txtBuscarProductoP.Text = "Buscar Código...";
                txtBuscarProductoP.ForeColor = Color.SlateBlue;
            }
        }

        private void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            /*try
            {*/
            if (txtNombreP.Text == "" || txtNumeroP.Text == "" || txtDireccionP.Text == ""
                || txtTelP.Text == "" || txtCiudadP.Text == "" || txtEstadoP.Text == ""
                || txtEmailP.Text == "" || txtRFCP.Text == "" || txtAtiendeP.Text == ""
                || txtPostalP.Text == "" || txtFPagoP.Text == "" || txtOCompraP.Text == ""
                || txtEntregaP.Text == "" || txtNombreP.Text == "Nombre:" || txtDireccionP.Text == "Dirección:"
                || txtTelP.Text == "Teléfono(s):" || txtCiudadP.Text == "Ciudad:" || txtEstadoP.Text == "Estado:"
                || txtEmailP.Text == "e-Mail:" || txtRFCP.Text == "RFC:" || txtAtiendeP.Text == "Atiende:"
                || txtPostalP.Text == "Código Postal" || txtFPagoP.Text == "Forma de Pago:" || txtOCompraP.Text == "Órden de Compra:"
                || txtEntregaP.Text == "Dirección de Entrega:")
            {
                MessageBox.Show("Todos los campos excepto COMENTARIOS son obligatorios para poder guardar un PEDIDO",
                    "Error al guardar PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSubTotalP.Text == "" || txtIVAP.Text == "" || txtTotalP.Text == "")
            {
                MessageBox.Show("Debe realizar el CÁLCULO DEL PEDIDO antes de guardar",
                    "Error al guardar PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                cn.cerrarCon();

                DateTime fechaActual = dateFechaP.Value;

                string fechaHoy = fechaActual.Day.ToString() + "/" + fechaActual.Month.ToString() + "/" + fechaActual.Year.ToString();

                cn.insertarPedidos(txtNombreP.Text, txtDireccionP.Text, txtCiudadP.Text,
                    txtEstadoP.Text, txtTelP.Text, txtEmailP.Text, txtPostalP.Text, txtRFCP.Text, txtAtiendeP.Text,
                    //dateFechaP.Value.ToString(), 
                    fechaHoy, txtSubTotalP.Text, txtIVAP.Text, txtTotalP.Text,
                    txtOCompraP.Text, txtFPagoP.Text, txtEntregaP.Text, txtComentariosP.ToString());

                MessageBox.Show("El PEDIDO se ha guardado con éxito",
                        "¡LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreP.Enabled = false;
                txtNumeroP.Enabled = false;
                txtDireccionP.Enabled = false;
                txtCiudadP.Enabled = false;
                txtEstadoP.Enabled = false;
                txtTelP.Enabled = false;
                txtEmailP.Enabled = false;
                txtPostalP.Enabled = false;
                txtRFCP.Enabled = false;
                txtAtiendeP.Enabled = false;
                txtComentariosP.Enabled = false;
                txtOCompraP.Enabled = false;
                txtFPagoP.Enabled = false;
                txtEntregaP.Enabled = false;

                btnNuevoPedido.Enabled = true;

                //Itera el número del index
                int index = Convert.ToInt32(cn.consultaPedidosIndex());
                cn.cerrarCon();
                cn.updateIndexPed(index);
                cn.cerrarCon();


                //Aquí comienza la inserción de los productos en otra tabla


                List<Guardar> listGuardar = new List<Guardar>();

                foreach (DataRow row in dt.Rows)
                {
                    Guardar guardar = new Guardar();

                    guardar.Nocot = txtNumeroP.Text;
                    guardar.Cliente = txtNombreP.Text;
                    guardar.Codigo = row["Código"].ToString();
                    guardar.Concepto = row["Concepto"].ToString();
                    guardar.Cantidad = row["Cantidad"].ToString();
                    guardar.Precio = row["P.U."].ToString();
                    guardar.Importe = row["Importe"].ToString();

                    listGuardar.Add(guardar);
                }

                cn.insertarTablaPedidos(listGuardar);

                btnGuardarPedido.Enabled = false;
                btnBuscarProductoC.Enabled = false;
                btnSeleccionarCliente.Enabled = false;
                btnPedido.Enabled = false;
                btnNuevoPedido.Enabled = true;


                //Falta para limpiar los campos de texto
            }
            /*}
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un ERROR. Cierra la ventana e intenta de nuevo",
                    "Error" + error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarProductoC_Click_1(object sender, EventArgs e)
        {
            cn.cerrarCon();

            var resultado = cn.consultaProductosLlenar(txtBuscarProductoP.Text);

            //cn.cerrarCon();

            DataRow row = dt.NewRow();

            if (resultado.Item1 == "Null")
            {
                MessageBox.Show("No existe un producto con ese Código en la Base de Datos",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtBuscarProductoP.Text == "")
            {
                MessageBox.Show("Asegúrate de insertar un código de producto",
                        "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                row["Código"] = resultado.Item1;
                row["Concepto"] = resultado.Item2;

                dt.Rows.Add(row);

                txtBuscarProductoP.Text = "";
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Pedidos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(nombre1, apellido1, foto1);

            menu.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtNombreP_Enter(object sender, EventArgs e)
        {
            if (txtNombreP.Text.Trim() == "Nombre:")
            {
                txtNombreP.Text = "";
                txtNombreP.ForeColor = Color.Black;
            }
        }

        private void txtNombreP_Leave(object sender, EventArgs e)
        {
            if (txtNombreP.Text.Trim() == "")
            {
                txtNombreP.Text = "Nombre:";
                txtNombreP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtDireccionP_Enter(object sender, EventArgs e)
        {
            if (txtDireccionP.Text.Trim() == "Dirección:")
            {
                txtDireccionP.Text = "";
                txtDireccionP.ForeColor = Color.Black;
            }
        }

        private void txtDireccionP_Leave(object sender, EventArgs e)
        {
            if (txtDireccionP.Text.Trim() == "")
            {
                txtDireccionP.Text = "Dirección:";
                txtDireccionP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtPostalP_Enter(object sender, EventArgs e)
        {
            if (txtPostalP.Text.Trim() == "Código Postal:")
            {
                txtPostalP.Text = "";
                txtPostalP.ForeColor = Color.Black;
            }
        }

        private void txtPostalP_Leave(object sender, EventArgs e)
        {
            if (txtPostalP.Text.Trim() == "")
            {
                txtPostalP.Text = "Código Postal:";
                txtPostalP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtCiudadP_Enter(object sender, EventArgs e)
        {
            if (txtCiudadP.Text.Trim() == "Ciudad:")
            {
                txtCiudadP.Text = "";
                txtCiudadP.ForeColor = Color.Black;
            }
        }

        private void txtCiudadP_Leave(object sender, EventArgs e)
        {
            if (txtCiudadP.Text.Trim() == "")
            {
                txtCiudadP.Text = "Ciudad:";
                txtCiudadP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtEstadoP_Enter(object sender, EventArgs e)
        {
            if (txtEstadoP.Text.Trim() == "Estado:")
            {
                txtEstadoP.Text = "";
                txtEstadoP.ForeColor = Color.Black;
            }
        }

        private void txtEstadoP_Leave(object sender, EventArgs e)
        {
            if (txtEstadoP.Text.Trim() == "")
            {
                txtEstadoP.Text = "Estado:";
                txtEstadoP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtTelP_Enter(object sender, EventArgs e)
        {
            if (txtTelP.Text.Trim() == "Teléfono(s):")
            {
                txtTelP.Text = "";
                txtTelP.ForeColor = Color.Black;
            }
        }

        private void txtTelP_Leave(object sender, EventArgs e)
        {
            if (txtTelP.Text.Trim() == "")
            {
                txtTelP.Text = "Teléfono(s):";
                txtTelP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtEmailP_Enter(object sender, EventArgs e)
        {
            if (txtEmailP.Text.Trim() == "e-Mail:")
            {
                txtEmailP.Text = "";
                txtEmailP.ForeColor = Color.Black;
            }
        }

        private void txtEmailP_Leave(object sender, EventArgs e)
        {
            if (txtEmailP.Text.Trim() == "")
            {
                txtEmailP.Text = "e-Mail:";
                txtEmailP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtRFCP_Enter(object sender, EventArgs e)
        {
            if (txtRFCP.Text.Trim() == "RFC:")
            {
                txtRFCP.Text = "";
                txtRFCP.ForeColor = Color.Black;
            }
        }

        private void txtRFCP_Leave(object sender, EventArgs e)
        {
            if (txtRFCP.Text.Trim() == "")
            {
                txtRFCP.Text = "RFC:";
                txtRFCP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtAtiendeP_Enter(object sender, EventArgs e)
        {
            if (txtAtiendeP.Text.Trim() == "Atiende:")
            {
                txtAtiendeP.Text = "";
                txtAtiendeP.ForeColor = Color.Black;
            }
        }

        private void txtAtiendeP_Leave(object sender, EventArgs e)
        {
            if (txtAtiendeP.Text.Trim() == "")
            {
                txtAtiendeP.Text = "Atiende:";
                txtAtiendeP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtOCompraP_Enter(object sender, EventArgs e)
        {
            if (txtOCompraP.Text.Trim() == "Órden de Compra:")
            {
                txtOCompraP.Text = "";
                txtOCompraP.ForeColor = Color.Black;
            }
        }

        private void txtOCompraP_Leave(object sender, EventArgs e)
        {
            if (txtOCompraP.Text.Trim() == "")
            {
                txtOCompraP.Text = "Órden de Compra:";
                txtOCompraP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtFPagoP_Enter(object sender, EventArgs e)
        {
            if (txtFPagoP.Text.Trim() == "Forma de Pago:")
            {
                txtFPagoP.Text = "";
                txtFPagoP.ForeColor = Color.Black;
            }
        }

        private void txtFPagoP_Leave(object sender, EventArgs e)
        {
            if (txtFPagoP.Text.Trim() == "")
            {
                txtFPagoP.Text = "Forma de Pago:";
                txtFPagoP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtEntregaP_Enter(object sender, EventArgs e)
        {
            if (txtEntregaP.Text.Trim() == "Dirección de Entrega:")
            {
                txtEntregaP.Text = "";
                txtEntregaP.ForeColor = Color.Black;
            }
        }

        private void txtEntregaP_Leave(object sender, EventArgs e)
        {
            if (txtEntregaP.Text.Trim() == "")
            {
                txtEntregaP.Text = "Dirección de Entrega:";
                txtEntregaP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtComentariosP_Enter(object sender, EventArgs e)
        {
            if (txtComentariosP.Text.Trim() == "Comentarios:")
            {
                txtComentariosP.Text = "";
                txtComentariosP.ForeColor = Color.Red;
            }
        }

        private void txtComentariosP_Leave(object sender, EventArgs e)
        {
            if (txtComentariosP.Text.Trim() == "")
            {
                txtComentariosP.Text = "Comentarios:";
                txtComentariosP.ForeColor = Color.SlateBlue;
            }
        }

        private void txtBuscarProductoP_Enter(object sender, EventArgs e)
        {
            if (txtBuscarProductoP.Text.Trim() == "Buscar Código...")
            {
                txtBuscarProductoP.Text = "";
                txtBuscarProductoP.ForeColor = Color.Black;
            }
        }

        private void txtBuscarProductoP_Leave(object sender, EventArgs e)
        {
            if (txtBuscarProductoP.Text.Trim() == "")
            {
                txtBuscarProductoP.Text = "Buscar Código...";
                txtBuscarProductoP.ForeColor = Color.SlateBlue;
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
