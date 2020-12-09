using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAESMESA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            this.Hide();
            productos.ShowDialog();
            this.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            this.Hide();
            clientes.ShowDialog();
            this.Show();
        }

        private void diseñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diseños diseños = new Diseños();
            this.Hide();
            diseños.ShowDialog();
            this.Show();
        }

        private void cotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cotizaciones cotizaciones = new Cotizaciones();
            this.Hide();
            cotizaciones.ShowDialog();
            this.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            this.Hide();
            pedidos.ShowDialog();
            this.Show();
        }

        private void diseñosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diseños diseños = new Diseños();
            this.Hide();
            diseños.ShowDialog();
            this.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            this.Hide();
            consultas.ShowDialog();
            this.Show();
        }
    }
}
