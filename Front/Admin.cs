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
    public partial class Admin : Form
    {
        private RedSocial miRed;
        public Admin(RedSocial miRed)
        {
            InitializeComponent();
            this.miRed = miRed;
            refreshVista();
        }

        private void refreshVista()
        {
            foreach (Usuario usuario in miRed.obtenerUsuarios())
            {
                dataGridView1.Rows.Add(usuario.toArray());
            }
                
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (usuarios.modificarUsuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Modificado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo modificar el usuario"); */
        }

        private void ButtonEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (miRed.EliminarUsuarioAdmin(textBox1.Text, textBox2.Text, textBox3.Text))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo eliminar el usuario");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Usuario selected = miRed.obtenerUsuario(dataGridView1[0, e.RowIndex].Value.ToString());
            textBox1.Text = selected.Nombre;
            textBox2.Text = selected.Apellido;
            textBox3.Text = selected.Mail;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form index = new Index(miRed);
            this.Hide();
            index.ShowDialog();
            this.Show();
        }
    }
}
