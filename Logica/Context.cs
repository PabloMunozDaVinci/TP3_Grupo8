using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp1_grupo6.Logica;

namespace test.Logica
{
    internal class Context : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(tp1_grupo6.Properties.Resources.connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.ID);
            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.DNI).HasColumnType("int");
                    usr.Property(u => u.DNI).IsRequired(true);
                    usr.Property(u => u.Nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.Mail).HasColumnType("varchar(30)");
                    usr.Property(u => u.Password).HasColumnType("varchar(50)");
                    usr.Property(u => u.EsAdmin).HasColumnType("bit");
                    usr.Property(u => u.Bloqueado).HasColumnType("bit");
                }
                 );

            modelBuilder.Entity<Comentario>()
                .ToTable("Comentarios")
                .HasKey(comentario => comentario.ID);

            //propiedades de los datos
            modelBuilder.Entity<Comentario>(

                coment => { 
                
                    coment.Property(comentario=> comentario.ID).HasColumnType("int");
                    coment.Property(comentario => comentario.Contenido).HasColumnType("varchar(350)");
                    coment.Property(comentario => comentario.fecha).HasColumnType("DateTime");
                }



               /* public int ID { get; set; }
        public int postID { get; set; }
        public int usuarioID { get; set; }
        public Post Post { get; set; }
        public string Contenido { get; set; }
        public Usuario Usuario { get; set; }
        public string fecha { get; set; }
                */
                
                
                
                );





            //Ignoro, no agrego UsuarioManager a la base de datos , ni DB_Management
            modelBuilder.Ignore<RedSocial>();
            modelBuilder.Ignore<DB_Management>();
            
        }



    }
}
