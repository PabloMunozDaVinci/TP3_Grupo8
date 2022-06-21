using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyEncryption;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        public IDictionary<string, int> loginHistory;
        private const int cantMaxIntentos = 3;
        private Context context;
        public Usuario usuarioActual { get; set; }
        public RedSocial()
        {
            this.usuarioActual = usuarioActual;
            this.loginHistory = new Dictionary<string, int>();
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                // creo el contexto 
                context = new Context();

                context.Usuarios.Include(u => u.MisPosts)
                   .Include(u => u.MisComentarios)
                   .Include(u => u.MisReacciones)
                   .Include(u => u.MisAmigos)
                   .Include(u => u.AmigosMios)
                   .Load();

                context.Posts.Include(p => p.Usuario)
                    .Include(p => p.Comentarios)
                    .Include(p => p.Reacciones)
                    .Include(p => p.Tags)
                    .Load();

                context.Comentarios.Include(c => c.Usuario)
                    .Include(c => c.Post)
                    .Load();

                context.Tags.Include(t => t.TagPost)
                    .Include(t => t.Posts)
                    .Load();

                context.Reacciones.Include(r => r.Usuario)
                    .Include(r => r.Post)
                    .Load();

                //Guardo los cambios 
                context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }

        private string Hashear(string contraseñaSinHashear)
        {
            try
            {
                string passwordHash = SHA.ComputeSHA256Hash(contraseñaSinHashear);
                return passwordHash;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public string Intentos(string usuarioIngresado)
        {
            string mensaje = null;
            if (loginHistory.TryGetValue(usuarioIngresado, out int value))
            {
                loginHistory[usuarioIngresado] = loginHistory[usuarioIngresado] + 1;
                mensaje = "Datos incorrectos, intento " + loginHistory[usuarioIngresado] + "/3";
                if (loginHistory[usuarioIngresado] == cantMaxIntentos)
                {
                    this.bloquearDesbloquearUsuario(usuarioIngresado, true);
                    mensaje = "Intento 3/3, usuario bloqueado.";
                }
            }
            else
            {
                mensaje = "Datos incorrectos, intento 1/3";
                loginHistory.Add(usuarioIngresado, 1);
            }
            return mensaje;
        }

        public bool EstaBloqueado(string Mail)
        {
            return DevolverUsuario(Mail).Bloqueado;
        }

        // Modificar los datos del usuario logeado
        public bool ModificarUsuario(string newNombre, string newApellido, string newMail, string newPassword)
        {
            try
            {
                if(newNombre != "")
                {
                    newNombre = usuarioActual.Nombre = newNombre;
                }
                else
                {
                    newNombre = usuarioActual.Nombre;
                }
                if (newApellido != "")
                {
                    newApellido = usuarioActual.Apellido = newApellido;
                }
                else
                {
                    newApellido = usuarioActual.Apellido;
                }
                if (newMail != "")
                {
                    newMail = usuarioActual.Mail = newMail;
                }
                else
                {
                    newMail = usuarioActual.Mail;
                }
                if (newPassword != "")
                {
                    newPassword = usuarioActual.Password = newPassword;
                }
                else
                {
                    newPassword = usuarioActual.Password;
                }
                context.Usuarios.Update(usuarioActual);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Elimina al usuario logueado
        public bool EliminarUsuario()
        {
            try
            {
                bool salida = false;                 
                context.Usuarios.Remove(usuarioActual);
                context.SaveChanges();

                return salida;                                    
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Devuelve el Usuario correspondiente al Mail recibido.
        public Usuario DevolverUsuario(string Mail)
        {
            //Usuario usuarioEncontrado = null;
            return context.Usuarios.Where(U => U.Mail == Mail).FirstOrDefault();
        }

        // Se registra un nuevo usuario
        public bool RegistrarUsuario(string Nombre, string Apellido, string Mail, string Password, bool EsAdmin, bool Bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario { Nombre = Nombre, Apellido = Apellido, Mail = Mail, Password = Password, EsAdmin = EsAdmin, Bloqueado = Bloqueado };
                context.Usuarios.Add(nuevo);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        // Se autentica al Usuario.
        public bool IniciarUsuario(string Mail, string Password)
        {
            bool ok = false;
            Usuario usuario = DevolverUsuario(Mail);
            if (usuario.Password == Password)
            {
                usuarioActual = usuario;
                ok = true;
            }
            return ok;
        }

        // Se valida si el usuario existe y devuelve true o false
        public bool ExisteUsuario(string Mail)
        {
            if (DevolverUsuario(Mail) != null)
            {
                return true;
            }
            return false;
        }

        // Bloquea/Desbloquea el Usuario que se corresponde con el DNI recibido.
        public bool bloquearDesbloquearUsuario(string Mail, bool Bloqueado)
        {
            bool todoOk = false;
            foreach (Usuario u in context.Usuarios)
            {
                if (u.Mail == Mail)
                {
                    u.Bloqueado = Bloqueado;
                    todoOk = true;
                }
            }
            return todoOk;
        }

        // Cierra la sesion 
        public bool CerrarSesion()
        {
            //Pregunto si existe usuario Actual
            if (usuarioActual != null)
            {
                //seteo el usuario actual a null
                usuarioActual = null;
                context.Dispose();
            }
            return true;
        }

        // no se si funciona
        public void AgregarAmigo(Usuario amigo)
        {
            if (usuarioActual != null)
            {

                //usuarioActual.Amigos.Add(amigo);

            }

        }

        // no funciona
        public void QuitarAmigo(Usuario exAmigo)
        {
            if (usuarioActual != null)
            {
                //usuarioActual.Amigos.Remove(amigo);
                //exAmigo.Amigos.Remove(usuarioActual);
            }
        }

        // Metodo para agregar un nuevo Post
        public bool Postear(int userID, String postContenido)
        {
            DateTime now = DateTime.Now;
            try
            {
                Usuario usrAux = usuarioActual;

                if (usrAux != null)
                {

                    Post postAux = new Post { UsuarioID = usuarioActual.ID, Contenido = postContenido, Fecha = now };

                    context.Posts.Add(postAux);
                    usrAux.MisPosts.Add(postAux);
                    context.Usuarios.Update(usrAux);

                    context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool Comentar(String comentarioContenido, int postID)
        {
            try
            {
                DateTime now = DateTime.Now;
                Usuario usrAux = usuarioActual;

                if (usrAux != null)
                {

                    Comentario comentarioAux = new Comentario { PostID= postID ,UsuarioID = usuarioActual.ID, Contenido = comentarioContenido, Fecha = now };

                    context.Comentarios.Add(comentarioAux);
                    usrAux.MisComentarios.Add(comentarioAux);


                    context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }






        /* no funciona
        public void ModificarPost(int pID, Usuario pUsuario, string pContenido, List<Comentario> pComentarios, List<Reaccion> pReacciones, List<Tag> pTags, DateTime pFecha)
        {
            foreach (Post post in posts)
            {
                if (post.ID == pID)
                {
                    //post.Usuario = pUsuario;
                    post.Contenido = pContenido;
                    post.Comentarios = pComentarios;
                    post.Reacciones = pReacciones;
                    post.Tags = pTags;
                    //post.Fecha = pFecha;

                }
            }
        }

        // no hecho
        public void EliminarPost(Post p)
        {

        }

        // no funciona
       

        // no funciona
        public void ModificarComentario(Post p, Comentario c)
        {
            if (posts.Count > 0)
            {
                bool encontre = false;
                //registro el ID del post a guardar
                int id = 0;
                id = p.ID;
                foreach (Post postAux in posts)
                {
                    if (postAux.ID == id)
                    {
                        encontre = true;
                        //remuevo el ultimo comentario dentro del pool de comentarios del usuario actual
                        //usuarioActual.MisComentarios.Remove(usuarioActual.MisComentarios.Last());
                        //remuevo el ultimo Post dentro del pool de Posts 
                        //postAux.Comentarios.Remove(postAux.Comentarios.Last());
                        //al usuario actual le agrego a su lista el comentario que realizó
                        postAux.Comentarios.Add(c);
                    }
                }
            }
        }
        public void QuitarComentario(Post p, Comentario c)
        {
            {
                if (posts.Count > 0)
                {

                    bool encontre = false;


                    //registro el ID del post a guardar
                    int id = 0;

                    id = p.ID;



                    foreach (Post postAux in posts)
                    {

                        if (postAux.ID == id)
                        {
                            encontre = true;


                            //remuevo el ultimo Post dentro del pool de Posts 
                            // postAux.Comentarios.Remove(postAux.Comentarios.Last());
                        }

                    }
                }
            }
        }*/

        public List<Post> obtenerPosts()
    {
        return  context.Posts.ToList();
    }

    public List<Comentario> obtenerComentarios()
    {
        return context.Comentarios.ToList();

    }

    public List<Reaccion> obtenerReacciones()
    {
        return context.Reacciones.ToList();

    }

    public List<Tag> obtenerTags()
    {
        return context.Tags.ToList();

    }

    public List<Usuario> obtenerUsuarios()
    {
        return context.Usuarios.ToList();

    }

    public void Reaccionar(Post p, Reaccion r)
        {

        }

        public void ModificarReaccion(Post p, Reaccion r)
        {

        }

        public void QuitarReaccion(Post p, Reaccion r)
        {

        }

        public void MostrarDatos()
        {

        }

        public void MostrarPosts()
        {

        }

        public void MostrarPostsAmigos()
        {

        }

        public void BuscarPosts(string Contenido, DateTime Fecha, Tag t)
        {

        }

    }
}
