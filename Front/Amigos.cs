using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tp1_grupo6.Logica;

namespace tp1_grupo6.Front
{
    public partial class Amigos : Form
    {
        private RedSocial miRed;
        public Amigos(RedSocial miRed)
        {
            this.miRed = miRed;
            InitializeComponent();
            var User = miRed.usuarioActual.Nombre + " " + miRed.usuarioActual.Apellido;
            label3.Text= User.ToUpper();
            this.miRed = miRed;
            refreshVista();


        }

        private void refreshVista()
        {
            dataGridView1.Rows.Clear();
            foreach (UsuarioAmigo amigos in miRed.usuarioActual.MisAmigos)
            {
                dataGridView1.Rows.Add(amigos.Amigo.toArray());               
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form home = new Index(this.miRed);
            this.Dispose();
            home.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (miRed.AgregarAmigo(textBox1.Text))
{
                MessageBox.Show("Se agrego con exito el amigo");
            }
            else
            {
                MessageBox.Show("No se pudo agregar al amigo");
            }
            refreshVista();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form perfil = new Perfil(this.miRed);
            this.Dispose();
            perfil.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            miRed.CerrarSesion();
            Form login = new Login();
            this.Dispose();
            login.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
