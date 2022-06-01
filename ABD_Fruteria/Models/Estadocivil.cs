using System;
using System.Collections.Generic;

namespace ABD_Fruteria.Models
{
    public partial class Estadocivil
    {
        public Estadocivil()
        {
            Vendedores = new HashSet<Vendedores>();
        }

        public int IdEstadoCivil { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Vendedores> Vendedores { get; set; }
    }
}
