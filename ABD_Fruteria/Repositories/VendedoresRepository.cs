using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABD_Fruteria.Models;
using Microsoft.EntityFrameworkCore;

namespace ABD_Fruteria.Repositories
{
    public class VendedoresRepository
    {
        fruteria1Context context = new fruteria1Context();

        public IEnumerable<Vendedores> GetNombre()
        {
            return context.Vendedores.OrderBy(x => x.NombreVendedor);
        }

        public IEnumerable<Productos> GetProducto()
        {
            return context.Productos.OrderBy(x => x.NomProducto);
        }

        public IEnumerable<Comisiones> GetComisiones()
        {
            context = new fruteria1Context();
            return context.Comisiones.OrderBy(x => x.Fecha).Include(x => x.IdvendedorNavigation);
        }
        public IEnumerable<Comisiones> GetByDateTime(DateTime fecha)
        {
            return context.Comisiones.OrderBy(x => x.IdComision).Where(x => x.Fecha == fecha);
        }
    }
}
