using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp1_grupo6.Logica;
using Microsoft.EntityFrameworkCore;

namespace tp1_grupo6.Logica
{
    public class TagPost
    {
        public int ID_Tag { get; set; }
        public Tag Tag { get; set; }
        public int? ID_Post { get; set; }
        public Post Post { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public TagPost() { }
    }
}
