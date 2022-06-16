using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
    public class Comentario
    {
        public int ID { get; set; }
        public int postID { get; set; }
        public int usuarioID { get; set; }
        //public Post Post { get; set; } Este creeriamos que no es necesario ya que tenemos el postID
        public string Contenido { get; set; }
        //public Usuario Usuario { get; set; }Este creeriamos que no es necesario ya que tenemos el usuarioID
        public DateTime fecha { get; set; }


        public Comentario() { }

        public Comentario(int ID, int postID, int usuarioID, string Contenido, DateTime fecha)
        {
            this.ID = ID;
            this.postID = postID;
            this.Contenido = Contenido;
            this.usuarioID = usuarioID;
            this.fecha = fecha;
        }
    }
}
