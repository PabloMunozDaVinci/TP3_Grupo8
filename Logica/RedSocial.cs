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

        //Falta
        public void ModificarUsuario(int newID, string newNombre, string newApellido, string newMail, string newPassword)
        {
            if (usuarioActual != null && usuarioActual.ID == newID)
            {
                usuarioActual.Nombre = newNombre;
                usuarioActual.Apellido = newApellido;
                usuarioActual.Mail = newMail;
                usuarioActual.Password = newPassword;
            }
        }

        //no se si funciona
        public bool EliminarUsuario(string Mail)
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in context.Usuarios)
                    if (u.Mail == Mail)
                    {
                        context.Usuarios.Remove(u);
                        salida = true;
                    }
                if (salida)
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

        /*
         * se obtiene el ID del usuario
        public int obtenerUsuarioId(string Mail)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.Mail == Mail)
                {
                    return u.ID;
                }
            }
            return 0;
        }*/

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

        // funciona
        public bool CerrarSesion(Usuario u)
        {
            //Pregunto si existe usuario Actual
            if (usuarioActual != null)
            {
                //seteo el usuario actual a null
                usuarioActual = null;
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

        // no se si funciona

        public bool Postear(int userID, String postContenido,DateTime Fecha)
        {
            DateTime now = DateTime.Now;
            try
            {
                Usuario usrAux = context.Usuarios.Where(u => u.ID == userID).FirstOrDefault();
              
                if (usrAux != null )
                {

                    Post postAux = new Post { UsuarioID = userID/*usuarioActual.userID*/, Contenido = postContenido, Fecha = now};
                    
                    context.Posts.Add(postAux);
                    usrAux.MisPosts.Add(postAux);  
                    //context.Usuarios.Update(usrAux);
                    //postAux.Usuario.Add(usrAux); 
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
        public void Comentar(Post p, Comentario c)
        {
            //pregunto si el conteo de post es mayor a 0 para determinar si existen posts
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
                        //Agrego al Post actual el comentario
                        postAux.Comentarios.Add(c);
                        //al usuario actual le agrego a su lista el comentario que realizó
                        usuarioActual.MisComentarios.Add(c);
                        //si realiza mas comentarios deben tener ID  diferente
                        //usuarioActual.MisComentarios.
                    }
                }
            }
        }

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
        return context.Posts.ToList();
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
