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
using System.IO;
using System.Diagnostics;

using System.Runtime.InteropServices;

namespace MAESMESA
{
    public partial class Diseños : Form
    {
        private DataTable dt;
        ConexionSQLN cn = new ConexionSQLN();


        public Diseños()
        {
            InitializeComponent();

            dgvDiseños.DataSource = cn.ConsultaDiseños();
            dgvDiseños.Columns[0].Width = 40;
            dgvDiseños.Columns[1].Width = 200;
            dgvDiseños.Columns[2].Width = 100;
            dgvDiseños.Columns[3].Width = 200;
            dgvDiseños.Columns[4].Width = 170;

            dgvDiseños.DefaultCellStyle.Font = new Font("Century Gothic", 10);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog1.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtRuta.Text.Trim().Equals("") || txtCliente.Text.Trim().Equals("")
                || txtCodigo.Text.Trim().Equals("") || txtProducto.Text.Trim().Equals("") ||
                txtCliente.Text.Trim().Equals("Cliente")
                || txtCodigo.Text.Trim().Equals("Código del Producto") || txtProducto.Text.Trim().Equals("Descripción del Diseño"))
            {
                MessageBox.Show("Todos los campos son obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] file = null;
            Stream myStream = openFileDialog1.OpenFile();
            using (MemoryStream ms = new MemoryStream())
            {
                myStream.CopyTo(ms);
                file = ms.ToArray();
            }

            string nombreReal = openFileDialog1.SafeFileName;

            cn.insertarDiseños(txtCliente.Text.Trim(), txtCodigo.Text.Trim(), txtProducto.Text.Trim(), nombreReal, file);
            cn.cerrarCon();
            dgvDiseños.DataSource = cn.ConsultaDiseños();
            cn.cerrarCon();

            txtCliente.Text = "Cliente";
            txtCodigo.Text = "Código del Producto";
            txtProducto.Text = "Descripción del Producto";
            txtRuta.Text = "";

            txtCliente.ForeColor = Color.FromArgb(255, 128, 128);
            txtCodigo.ForeColor = Color.FromArgb(255, 128, 128);
            txtProducto.ForeColor = Color.FromArgb(255, 128, 128);


            MessageBox.Show("DISEÑO de "+txtCodigo.Text.Trim()+" guardado correctamente", "DISEÑO GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Process.Start(txtRuta.Text.Trim());

        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDiseños_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int n = e.RowIndex;

            //if (n != -1)
            //{
            //    int id = (int)dgvDiseños.Rows[n].Cells[0].Value;

            //}
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvDiseños.Rows[dgvDiseños.CurrentRow.Index].Cells[0].Value.ToString());

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "/temp/";
            string fullFilePath = folder + cn.abrirDiseño(id);
            cn.cerrarCon();


            //txtCliente.Text = cn.abrirMatriz(id).ToString();
            //cn.cerrarCon();

            
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            //if (File.Exists(fullFilePath))
            //   Directory.Delete(fullFilePath);

            //byte[] mapaBytes = cn.abrirMatriz(id); //Encoding.ASCII.GetBytes(cn.abrirMatriz(id));
            //cn.cerrarCon();



            
            File.WriteAllBytes(fullFilePath, cn.abrirMatriz(id));
            cn.cerrarCon();

            Process.Start(fullFilePath);
            cn.cerrarCon();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void Diseños_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtCliente_Enter(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() == "Cliente")
            {
                txtCliente.Text = "";
                txtCliente.ForeColor = Color.FromArgb(7, 27, 79);
            }
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() == "")
            {
                txtCliente.Text = "Cliente";
                txtCliente.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "Código del Producto")
            {
                txtCodigo.Text = "";
                txtCodigo.ForeColor = Color.FromArgb(7, 27, 79);
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                txtCodigo.Text = "Código del Producto";
                txtCodigo.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void txtProducto_Enter(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() == "Descripción del Diseño")
            {
                txtProducto.Text = "";
                txtProducto.ForeColor = Color.FromArgb(7, 27, 79);
            }
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() == "")
            {
                txtProducto.Text = "Descripción del Diseño";
                txtProducto.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }
    }
}
