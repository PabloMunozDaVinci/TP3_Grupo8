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
                   /*
                    Comentario1.Text = postsObtenidos[^1].Comentarios.Last().Contenido.ToString();
                    Comentario2.Text = postsObtenidos[^2].Comentarios.Last().Contenido.ToString();
                    Comentario3.Text = postsObtenidos[^3].Comentarios.Last().Contenido.ToString();
                    Comentario4.Text = postsObtenidos[^4].Comentarios.Last().Contenido.ToString();
                   */
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
        // Realizar Post " que estas pensando " 
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

        // Eliminar Ultimo Post agregado
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

        // Eliminar tercer Post
        private void button27_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                miRed.EliminarPost(postsObtenidos[^3].ID);
                refreshVista();
            }
        }
        //Eliminar cuarto Post
        private void button21_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var postsObtenidos = miRed.obtenerPosts();
                miRed.EliminarPost(postsObtenidos[^4].ID);
                refreshVista();
            }
        }
        //Eliminar Ultimo comentario agregado
        private void button32_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var comentariosObtenidos = miRed.obtenerComentarios();
                miRed.EliminarComentario(comentariosObtenidos[^1].ID);
                refreshVista();
            }
        }
        //Eliminar segundo comentario
        private void button33_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var comentariosObtenidos = miRed.obtenerComentarios();
                miRed.EliminarComentario(comentariosObtenidos[^2].ID);
                refreshVista();
            }
    }
        //Eliminar tercer comentario
        private void button34_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var comentariosObtenidos = miRed.obtenerComentarios();
                miRed.EliminarComentario(comentariosObtenidos[^3].ID);
                refreshVista();
            }
    }
        //Eliminar cuarto comentario
        private void button35_Click(object sender, EventArgs e)
        {
            if (miRed.usuarioActual != null)
            {
                var comentariosObtenidos = miRed.obtenerComentarios();
                miRed.EliminarComentario(comentariosObtenidos[^4].ID);
                refreshVista();
            }
        }



       
        //Modificar Post 1
        private void button13_Click(object sender, EventArgs e)
        {

            String contenido=null;
            contenido = textBox2.Text;

            var postObtenidos = miRed.obtenerComentarios();
            miRed.ModificarComentario(postObtenidos[^1].ID,contenido);

            post1.Text = postObtenidos[^1].Contenido;
            refreshVista();
        }



        //Modificar Post 2
        private void button18_Click(object sender, EventArgs e)
        {
            String contenido = null;
            contenido = textBox6.Text;

            var postObtenidos = miRed.obtenerPosts();
            miRed.ModificarPost(postObtenidos[^2].ID, contenido);

            post2.Text = postObtenidos[^2].Contenido;


            refreshVista();
        }

        //Modificar Post 3
        private void button31_Click(object sender, EventArgs e)
        {
            String contenido = null;
            contenido = textBox13.Text;

            var postObtenidos = miRed.obtenerPosts();
            miRed.ModificarPost(postObtenidos[^3].ID, contenido);

            post3.Text = postObtenidos[^3].Contenido;


            refreshVista();
        }

        //Modificar Post 4
        private void button25_Click(object sender, EventArgs e)
        {
            String contenido = null;
            contenido = textBox9.Text;

            var postObtenidos = miRed.obtenerPosts();
            miRed.ModificarPost(postObtenidos[^4].ID, contenido);

            post4.Text = postObtenidos[^4].Contenido;


            refreshVista();
        }
        //modificar Comentario 1
        private void button3_Click(object sender, EventArgs e)
        {
            
                
            String contenido = null;
            contenido = textBox2.Text;

            var comentariosObtenidos = miRed.obtenerComentarios();
            miRed.ModificarComentario(comentariosObtenidos[^1].ID, contenido);

            Comentario1.Text = comentariosObtenidos[^1].Contenido;


            refreshVista();
        }

        //modificar comentario 2
        private void button9_Click(object sender, EventArgs e)
        {

            String contenido = null;
            contenido = textBox6.Text;

            var comentariosObtenidos = miRed.obtenerComentarios();
            miRed.ModificarComentario(comentariosObtenidos[^2].ID, contenido);

            Comentario2.Text = comentariosObtenidos[^2].Contenido;


            refreshVista();


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        //modificar comentario 3
        private void button26_Click(object sender, EventArgs e)
        {
            String contenido = null;
            contenido = textBox13.Text;

            var comentariosObtenidos = miRed.obtenerComentarios();
            miRed.ModificarComentario(comentariosObtenidos[^3].ID, contenido);

            Comentario3.Text = comentariosObtenidos[^3].Contenido;


            refreshVista();

        }
        //modificar comentario 4
        private void button19_Click(object sender, EventArgs e)
        {


            String contenido = null;
            contenido = textBox9.Text;

            var comentariosObtenidos = miRed.obtenerComentarios();
            miRed.ModificarComentario(comentariosObtenidos[^4].ID, contenido);

            Comentario4.Text = comentariosObtenidos[^4].Contenido;


            refreshVista();

        }
    }
}