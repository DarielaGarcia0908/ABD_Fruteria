using ABD_Fruteria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABD_Fruteria.Repositories
{
    public class VentaRepository
    {
        fruteria1Context context = new fruteria1Context();

        public IEnumerable<Ventas> GetAll()
        {
            return context.Ventas.OrderBy(x => x.Idventa).Where(x => x.Fecha == DateTime.Now.Date).Include
            (x => x.CodProductoNavigation).Include(x => x.CodVendedorNavigation).OrderBy(x => x.Idventa);
            //return context.Ventas.OrderBy(x => x.Fecha);            
        }

        public Ventas GetByDateTime(Ventas v)
        {
            return context.Ventas.First(x => x.Fecha == v.Fecha.Date);
        }

        public void Insert(Ventas v)
        {
            context.Add(v);
            context.SaveChanges();
        }

        public void Update(Ventas v)
        {
            Ventas venta = context.Ventas.FirstOrDefault(x => x.Idventa == v.Idventa);
            if (venta != null)
            {
                venta.Idventa = v.Idventa;
                venta.CodVendedor = v.CodVendedor;
                venta.CodProducto = v.CodProducto;
                venta.Fecha = v.Fecha;
                venta.Kilos = v.Kilos;
                context.SaveChanges();

            }


        }

        public void Delete(Ventas v)
        {
            context.Remove(v);
            context.SaveChanges();
        }

        public bool Validate(Ventas v)
        {
            if (v.CodVendedor == 0)
            {
                throw new ArgumentException("Agregue un codigo de Vendedor");
            }
            if (v.CodProducto == 0)
            {
                throw new ArgumentException("Agregue un codigo de producto");
            }
            if (v.Kilos == 0)
            {
                throw new ArgumentException("Agregue una cantidad de Kilos a Vender");
            }

            if (v.Fecha > DateTime.Now.Date)
            {
            
                throw new ArgumentException("La fecha no es posible");
            }
            return true;
        }
    }
}

