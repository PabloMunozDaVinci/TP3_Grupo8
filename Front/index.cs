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
    public partial class Index : Form
    {
        private RedSocial miRed;
        private Usuario usuario;
        private int postID;
        public Index(RedSocial miRed)
        {
            this.miRed = miRed;

            InitializeComponent();
            refreshVista();
        }


        private void refreshVista()
        {
            var postsObtenidos = miRed.obtenerPosts();
            textBox1.Text = "";
            textBox2.Text="";
            textBox9.Text = "";
            textBox13.Text = "";
            textBox6.Text = "";
            textBox5.Text = postsObtenidos.Last().Contenido.ToString();
            textBox8.Text = postsObtenidos[^2].Contenido.ToString();
            textBox15.Text = postsObtenidos[^3].Contenido.ToString();
            textBox12.Text = postsObtenidos[^4].Contenido.ToString();
        }

        private void index_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form perfil = new Perfil(this.miRed, this.usuario);
            this.Hide();
            perfil.ShowDialog();
            this.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {





                string contenido;

                contenido = textBox1.Text;

                miRed.Postear(miRed.usuarioActual.ID, contenido);


                var postsObtenidos = miRed.obtenerPosts();

                textBox5.Text = postsObtenidos.Last().Contenido.ToString();







             


          
                 postID = miRed.usuarioActual.MisPosts.Last().ID;





       






                //textBox5.Text = miRed.usuarioActual.MisPosts[^2].Contenido.ToString();


                // textBox5.Text = miRed.usuarioActual.MisPosts.Last().Contenido.ToString();

                refreshVista();


            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {

                string contenido;

                contenido = textBox2.Text;

                miRed.Comentar(contenido, postID);




                var comentariosObtenidos = miRed.obtenerComentarios();
                textBox4.Text = comentariosObtenidos[^1].Contenido.ToString();


                //textBox5.Text = miRed.usuarioActual.MisPosts[^2].Contenido.ToString();


                //  textBox5.Text = miRed.usuarioActual.MisPosts.Last().Contenido.ToString();

                refreshVista();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
         
        }
    }
}
