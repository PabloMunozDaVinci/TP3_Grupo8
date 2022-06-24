using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tp1_grupo6.Logica;
using tp1_grupo6.Front;

namespace tp1_grupo6.Front
{
    public partial class Perfil : Form
    {
        private RedSocial miRed;

        public Perfil(RedSocial miRed)
        {
            this.miRed = miRed;

            InitializeComponent();
            var User = miRed.usuarioActual.Nombre + " " + miRed.usuarioActual.Apellido;
           
            label7.Text = User.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (miRed.ModificarUsuario(textBoxNombre.Text, textBoxApellido.Text, textBoxMail.Text, textBox3.Text))
            {
                MessageBox.Show("Modificado con éxito");
            }
            else
                MessageBox.Show("No se pudo modificar el usuario");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            miRed.EliminarUsuario();
            MessageBox.Show("Su Usuario fue eliminado");
            Form login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Show();
            Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form index = new Index(miRed);
            this.Hide();
            index.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form amigos = new Amigos(miRed);
            this.Hide();
            amigos.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
