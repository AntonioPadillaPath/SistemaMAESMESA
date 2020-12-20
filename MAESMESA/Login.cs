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

namespace MAESMESA
{
    public partial class Login : Form
    {
        ConexionSQLN cn = new ConexionSQLN();

        public Login()
        {
            InitializeComponent();

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);
        

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
            //if(cn.conSQL(txtUsuario.Text, txtPassword.Text) == 1 )
            //{
            //    this.Hide();

            //    var resultado = cn.consultaUsuarioLlenar(txtUsuario.Text);
            //    cn.cerrarCon();

            //    string nombre = resultado.Item1;
            //    string apellido = resultado.Item2;

            //    Menu menu = new Menu(nombre, apellido);
            //    menu.Show();
            //}
            //else
            //{
            //    MessageBox.Show("El usuario no ha sido encontrado", "MAESMESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son obligatorios", "MAESMESA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (cn.conSQL(txtUsuario.Text.Trim(), txtPassword.Text.Trim()) == 1)
                {
                    this.Hide();

                    var resultado = cn.consultaUsuarioLlenar(txtUsuario.Text.Trim());
                    cn.cerrarCon();

                    string nombre = resultado.Item1;
                    string apellido = resultado.Item2;
                    byte[] foto = cn.abrirMatrizPerfil(txtUsuario.Text.Trim());
                    cn.cerrarCon();

                    Menu menu = new Menu(nombre, apellido, foto);
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no ha sido encontrado", "MAESMESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            //if (txtUsuario.Text == "Usuario")
            //{
            //    txtUsuario.Text = "";
            //    txtUsuario.ForeColor = Color.Red;
            //}
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            //if (txtUsuario.Text == "")
            //{
            //    txtUsuario.Text = "Usuario";
            //    txtUsuario.ForeColor = Color.Gray;
            //}
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
