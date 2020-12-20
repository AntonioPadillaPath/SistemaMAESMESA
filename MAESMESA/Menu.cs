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
using System.IO;

namespace MAESMESA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        }

        public Menu(string nombre, string apellido, byte[]foto)
        {
            InitializeComponent();
            btnUsuarios.Enabled = false;

            string nombre1 = nombre;
            string apellido1 = apellido; //Para enviar los datos a todas las ventanas

            MemoryStream ms = new MemoryStream(foto);
            pboxPerfil.Image = Image.FromStream(ms);

            label3.Text = nombre + " " + apellido;

            if(nombre.Equals("Antonio") && apellido.Equals("Padilla"))
            {
                btnUsuarios.Enabled = true;
            }

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Productos productos = new Productos();
            //this.Hide();
            //productos.ShowDialog();
            //this.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clientes clientes = new Clientes();
            //this.Hide();
            //clientes.ShowDialog();
            //this.Show();
        }

        private void diseñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Diseños diseños = new Diseños();
            //this.Hide();
            //diseños.ShowDialog();
            //this.Show();
        }

        private void cotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cotizaciones cotizaciones = new Cotizaciones();
            //this.Hide();
            //cotizaciones.ShowDialog();
            //this.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pedidos pedidos = new Pedidos();
            //this.Hide();
            //pedidos.ShowDialog();
            //this.Show();
        }

        private void diseñosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Diseños diseños = new Diseños();
            //this.Hide();
            //diseños.ShowDialog();
            //this.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Consultas consultas = new Consultas();
            //this.Hide();
            //consultas.ShowDialog();
            //this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Diseños diseños = new Diseños();
            this.Hide();
            diseños.ShowDialog();
            this.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            this.Hide();
            productos.ShowDialog();
            this.Show();
        }

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            this.Hide();
            clientes.ShowDialog();
            this.Show();
        }

        private void btnCotizaciones_Click(object sender, EventArgs e)
        {
            Cotizaciones cotizaciones = new Cotizaciones();
            this.Close();
            cotizaciones.Show();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            this.Close();
            pedidos.Show();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            this.Hide();
            consultas.ShowDialog();
            this.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
        }

        private void btnProductos_MouseEnter(object sender, EventArgs e)
        {
            btnProductos.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnProductos_MouseLeave(object sender, EventArgs e)
        {
            btnProductos.ForeColor = Color.White;
        }

        private void btnClientes_MouseEnter(object sender, EventArgs e)
        {
            btnClientes.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnClientes_MouseLeave(object sender, EventArgs e)
        {
            btnClientes.ForeColor = Color.White;
        }

        private void btnCotizaciones_MouseEnter(object sender, EventArgs e)
        {
            btnCotizaciones.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnCotizaciones_MouseLeave(object sender, EventArgs e)
        {
            btnCotizaciones.ForeColor = Color.White;
        }

        private void btnPedidos_MouseEnter(object sender, EventArgs e)
        {
            btnPedidos.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnPedidos_MouseLeave(object sender, EventArgs e)
        {
            btnPedidos.ForeColor = Color.White;
        }

        private void btnDiseños_MouseEnter(object sender, EventArgs e)
        {
            btnDiseños.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnDiseños_MouseLeave(object sender, EventArgs e)
        {
            btnDiseños.ForeColor = Color.White;
        }

        private void btnEstadisticas_MouseEnter(object sender, EventArgs e)
        {
            btnEstadisticas.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnEstadisticas_MouseLeave(object sender, EventArgs e)
        {
            btnEstadisticas.ForeColor = Color.White;
        }

        private void btnUsuarios_MouseEnter(object sender, EventArgs e)
        {
            btnUsuarios.ForeColor = Color.FromArgb(7, 27, 79);
        }

        private void btnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuarios.ForeColor = Color.White;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            this.Hide();
            usuarios.ShowDialog();
            this.Show();
        }
    }
}
