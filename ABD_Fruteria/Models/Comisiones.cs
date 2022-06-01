using System;
using System.Collections.Generic;

namespace ABD_Fruteria.Models
{
    public partial class Comisiones
    {
        public int IdComision { get; set; }
        public int Idvendedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Comision { get; set; }

        public virtual Vendedores IdvendedorNavigation { get; set; }
    }
}
