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
        }

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
                || txtCodigo.Text.Trim().Equals("") || txtProducto.Text.Trim().Equals(""))
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
            dgvDiseños.DataSource = cn.ConsultaDiseños();

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


            txtCliente.Text = cn.abrirMatriz(id).ToString();
            cn.cerrarCon();

            
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            //if (File.Exists(fullFilePath))
            //   Directory.Delete(fullFilePath);

            //byte[] mapaBytes = cn.abrirMatriz(id); //Encoding.ASCII.GetBytes(cn.abrirMatriz(id));
            //cn.cerrarCon();



            
            File.WriteAllBytes(fullFilePath, cn.abrirMatriz(id));
            cn.cerrarCon();

            Process.Start(fullFilePath);

        }
    }
}
