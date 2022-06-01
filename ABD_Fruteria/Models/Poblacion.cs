using System;
using System.Collections.Generic;

namespace ABD_Fruteria.Models
{
    public partial class Poblacion
    {
        public Poblacion()
        {
            Vendedores = new HashSet<Vendedores>();
        }

        public int IdPoblacion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vendedores> Vendedores { get; set; }
    }
}
