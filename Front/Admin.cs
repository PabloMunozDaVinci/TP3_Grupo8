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
            this.miRed = miRed;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
