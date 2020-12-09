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
    public partial class Login : Form
    {
        ConexionSQLN cn = new ConexionSQLN();

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cn.conSQL(txtUsuario.Text, txtPassword.Text) == 1 )
            {
                this.Hide();

                Menu menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("El usuario no ha sido encontrado", "MAESMESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
