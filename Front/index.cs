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


        public Index(RedSocial miRed)
        {
            this.miRed = miRed;
            InitializeComponent();
            refreshVista();
        }


        private void refreshVista()
        {
            var postsObtenidos = miRed.obtenerPosts();
            if (postsObtenidos != null)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                if (post1 != null || post2 != null || post3 != null || post4 != null
                || Comentario1 != null || Comentario2 != null || Comentario3 != null || Comentario4 != null)
                {
                    post1.Text = postsObtenidos[^1].Contenido.ToString();
                    post2.Text = postsObtenidos[^2].Contenido.ToString();
                    post3.Text = postsObtenidos[^3].Contenido.ToString();
                    post4.Text = postsObtenidos[^4].Contenido.ToString();
                    Comentario1.Text = postsObtenidos[^1].Comentarios.Last().Contenido.ToString();
                    Comentario2.Text = postsObtenidos[^2].Comentarios.Last().Contenido.ToString();
                    Comentario3.Text = postsObtenidos[^3].Comentarios.Last().Contenido.ToString();
                    Comentario4.Text = postsObtenidos[^4].Comentarios.Last().Contenido.ToString();
                }
            }

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
            Form perfil = new Perfil(this.miRed);
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
                post1.Text = postsObtenidos.Last().Contenido.ToString();              
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

        // Comentar Ultimo Post
        private void button10_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                string contenido;
                contenido = textBox2.Text;
                miRed.Comentar(contenido, postsObtenidos[^1].ID);                
                Comentario1.Text = postsObtenidos[^1].Comentarios.Last().Contenido.ToString();
                refreshVista();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Eliminar Ultimo Post
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                miRed.EliminarPost(postsObtenidos[^1].ID);
                refreshVista();
            }
        }

        // Comentar Segundo Post
        private void button15_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                string contenido;
                contenido = textBox6.Text;
                miRed.Comentar(contenido, postsObtenidos[^2].ID);
                Comentario2.Text = postsObtenidos[^2].Comentarios.Last().Contenido.ToString();
                refreshVista();
            }
        }

        // Comentar Tercer Post
        private void button28_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                string contenido;
                contenido = textBox13.Text;
                miRed.Comentar(contenido, postsObtenidos[^3].ID);
                Comentario3.Text = postsObtenidos[^3].Comentarios.Last().Contenido.ToString();
                refreshVista();
            }
        }

        // Comentar Cuarto Post
        private void button22_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                string contenido;
                contenido = textBox9.Text;
                miRed.Comentar(contenido, postsObtenidos[^3].ID);
                Comentario4.Text = postsObtenidos[^3].Comentarios.Last().Contenido.ToString();
                refreshVista();
            }
        }

        // Eliminar Segundo Post
        private void button14_Click_1(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                miRed.EliminarPost(postsObtenidos[^2].ID);
                refreshVista();
            }
        }

        // Eliminar Segundo Post
        private void button27_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                miRed.EliminarPost(postsObtenidos[^3].ID);
                refreshVista();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                miRed.EliminarPost(postsObtenidos[^4].ID);
                refreshVista();
            }
        }
    }
}
