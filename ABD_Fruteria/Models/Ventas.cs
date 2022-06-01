using System;
using System.Collections.Generic;

namespace ABD_Fruteria.Models
{
    public partial class Ventas
    {
        public int Idventa { get; set; }
        public int CodVendedor { get; set; }
        public int CodProducto { get; set; }
        public DateTime Fecha { get; set; }
        public double Kilos { get; set; }

        public virtual Productos CodProductoNavigation { get; set; }
        public virtual Vendedores CodVendedorNavigation { get; set; }
    }
}
