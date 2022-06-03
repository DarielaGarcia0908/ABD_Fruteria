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

        public IEnumerable<Vendedores> GetAll()
        {
            return context.Vendedores.OrderBy(x => x.IdVendedor).Include
            (x => x.EstalCivilNavigation).Include(x => x.PoblacionNavigation).OrderBy(x => x.IdVendedor);

        }

        public void Insert(Vendedores v)
        {
            context.Add(v);
            context.SaveChanges();
        }

        public void Update(Vendedores v)
        {
            Vendedores vendedor = context.Vendedores.FirstOrDefault(x => x.IdVendedor == v.IdVendedor);
            if (vendedor != null)
            {
                vendedor.IdVendedor = v.IdVendedor;
                vendedor.NombreVendedor = v.NombreVendedor;
                vendedor.FechaAlta = v.FechaAlta;
                vendedor.Nif = v.Nif;
                vendedor.FechaNac = v.FechaNac;
                vendedor.Direccion = v.Direccion;
                vendedor.Poblacion = v.Poblacion;
                vendedor.CodPostal = v.CodPostal;
                vendedor.Telefon = v.Telefon;
                vendedor.EstalCivil = v.EstalCivil;

                context.SaveChanges();

            }


        }

        public bool Validate(Vendedores v)
        {
            if (string.IsNullOrWhiteSpace(v.NombreVendedor))
            {
                throw new ArgumentException("Agregue un nombre de vendedor");
            }
            if (v.FechaAlta > DateTime.Now.Date)
            {
                throw new ArgumentException("LA fecha no puede ser mayor que hoy");
            }
            if (string.IsNullOrWhiteSpace(v.Nif))
            {
                throw new ArgumentException("Agregue un NIF");
            }

            if (v.FechaNac > DateTime.Now.Date)
            {

                throw new ArgumentException("La fecha no es posible");
            }
            if (string.IsNullOrWhiteSpace(v.Direccion))
            {
                throw new ArgumentException("Agregue una dirección");
            }
            if (v.Poblacion == 0)
            {
                throw new ArgumentException("Agregue una población");
            }
            if (v.EstalCivil == 0)
            {
                throw new ArgumentException("Agregue un estado civil");
            }


            return true;
        }
    }
}
