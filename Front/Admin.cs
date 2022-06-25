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
            dataGridView1.Rows.Clear();
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
            if(miRed.ModificarUsuarioAdmin(textBox1.Text, textBox2.Text, textBox3.Text, textBox3.Text))
            {
                MessageBox.Show("Modificado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo modificar el usuario");
        }

        private void ButtonEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (miRed.EliminarUsuarioAdmin( textBox3.Text))
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
            miRed.CerrarSesion();
            Form login = new Login();
            this.Dispose();
            login.ShowDialog();
        }
    }
}
