using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace tp1_grupo6.Logica
{
    public class Tag
    {
        public int ID    { get; set; }
        public string Palabra { get; set; }
        public List<Post> Posts { get; set; }
        public List<TagPost> TagPost { get; set; }

        //Constructor vacio para EF
        public Tag(){ }

        public Tag(int ID, string Palabra) {
         
            this.ID = ID;
            this.Palabra = Palabra;
        }
    }
}
