using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{

	public class Post
	{
		public int ID { get; set; }
		public Usuario Usuario { get; set; } 
		public int UsuarioID { get; set; }
		public int ComentarioID   { get; set; }
		public string Contenido { get; set; }
		public List<Comentario> Comentarios { get; set; }
		public List<Reaccion> Reacciones { get; set; }
		//public List<Tag> Tags { get; set; }
		public List<TagPost> TagPost { get; set; }
		public DateTime Fecha { get; set; }
		
		public  ICollection<Tag> Tags { get; set; }	= new List<Tag>();

		//Constructor vacio para EF
		public Post()
		{ }
		
		public Post(int ID,int UsuarioID,int ComentarioID, string Contenido,DateTime Fecha){
			this.ID = ID;
			this.UsuarioID = UsuarioID;
			this.ComentarioID = ComentarioID;
			this.Contenido = Contenido;
			this.Fecha = Fecha;
		
		}
	}
}
