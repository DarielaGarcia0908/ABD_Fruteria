using ABD_Fruteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABD_Fruteria.Repositories
{
  public class ProductosRepository
    {
        fruteria1Context context = new fruteria1Context();
        public IEnumerable<Productos> GetAll() //para recuperar la tabla de ni;os
        {
            return context.Productos.OrderBy(x => x.NomProducto);
        }
        public Productos GetById(Productos p)
        {
            return context.Productos.FirstOrDefault(x => x.IdProducto == p.IdProducto);
        }
        public IEnumerable<Grupos> GetGrupo()
        {
            return context.Grupos.OrderBy(x => x.NombreGrupo);
        }

        public void Insert(Productos p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void Update(Productos p)
        {
            Productos producto = context.Productos.FirstOrDefault(x => x.IdProducto == p.IdProducto);
            if (producto != null)
            {
                producto.IdProducto = p.IdProducto;
                producto.NomProducto = p.NomProducto;
                producto.IdGrupo = p.IdGrupo;
                producto.Precio = p.Precio;
             
                context.SaveChanges();

            }


        }

        public bool Validate(Productos p)
        {
            if (string.IsNullOrWhiteSpace(p.NomProducto))
            {
                throw new ArgumentException("Agregue un nombre de producto");
            }
           
            
            if (p.IdGrupo == 0)
            {
                throw new ArgumentException("Agregue un grupo");
            }

            if (p.Precio < 1)
            {
                throw new ArgumentException("Agregue un precio");
            }

         
            return true;
        }

    }
}
