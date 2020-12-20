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
    public partial class Pedidos : Form
    {
        private DataTable dt;
        ConexionSQLN cn = new ConexionSQLN();

        public Pedidos()
        {
            InitializeComponent();

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
        }

        public Pedidos(string nombre, string direccion, 
            string ciudad, string estado, string tel, string email, 
            string postal, string rfc, string atiende, string numero)
        {
            InitializeComponent();

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

            var resultado1 = cn.consultaCotizacionLlenar1("2");
            cn.cerrarCon();
            var resultado2 = cn.consultaCotizacionLlenar2("2");
            cn.cerrarCon();

            dgvPedido.DataSource = cn.consultaCotizacionTabla("C2020-27");
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
            string parte1 = "P" + year1.ToString();
            cn.cerrarCon();

            string parte2 = cn.consultaPedidosIndex().ToString();
            cn.cerrarCon();

            txtNumeroP.Text = parte1 + "-" + parte2;



        }

        //Metodo constructor para ponerle el cliente automáticamente

        public Pedidos(string nombre, string direccion, string ciudad, string estado, string postal,
            string telefono, string rfc, string email)
        {
            InitializeComponent();

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
                cn.updateIndexCot(index);
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
            Pedidos_Clientes seleccionar = new Pedidos_Clientes();

            seleccionar.Show();
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
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            cn.cerrarCon();

            btnNuevoPedido.Enabled = false;

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

            txtNombreP.Text = "";
            txtDireccionP.Text = "";
            txtCiudadP.Text = "";
            txtEstadoP.Text = "";
            txtTelP.Text = "";
            txtEmailP.Text = "";
            txtPostalP.Text = "";
            txtRFCP.Text = "";
            txtAtiendeP.Text = "";
            txtComentariosP.Text = "";
            txtFPagoP.Text = "";
            txtOCompraP.Text = "";
            txtEntregaP.Text = "";
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

                txtBuscarProductoP.Text = "";
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
                || txtEntregaP.Text == "")
            {
                MessageBox.Show("Asegúrate de llenar todos los campos para realizar un PEDIDO",
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

                cn.insertarPedidos(txtNombreP.Text, txtDireccionP.Text, txtCiudadP.Text,
                    txtEstadoP.Text, txtTelP.Text, txtEmailP.Text, txtPostalP.Text, txtRFCP.Text, txtAtiendeP.Text,
                    dateFechaP.Value.ToString(), txtSubTotalP.Text, txtIVAP.Text, txtTotalP.Text,
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
