using System;
using System.Collections.Generic;

namespace ABD_Fruteria.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public int IdGrupo { get; set; }
        public decimal Precio { get; set; }

        public virtual Grupos IdGrupoNavigation { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
