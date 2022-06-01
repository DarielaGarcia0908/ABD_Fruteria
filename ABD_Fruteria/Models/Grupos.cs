using System;
using System.Collections.Generic;

namespace ABD_Fruteria.Models
{
    public partial class Grupos
    {
        public Grupos()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdGrupo { get; set; }
        public string NombreGrupo { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
