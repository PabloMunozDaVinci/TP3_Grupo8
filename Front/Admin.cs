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

        /*private void button2_Click(object sender, EventArgs e)
        {
            if (miRed.eliminarUsuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo eliminar el usuario");
        }*/
    }
}
