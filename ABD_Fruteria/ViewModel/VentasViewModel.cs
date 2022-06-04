using ABD_Fruteria.Models;
using ABD_Fruteria.Repositories;
using ABD_Fruteria.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ABD_Fruteria.ViewModel
{
    public class VentasViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // ver Agregar
        public ICommand VerAgregarVentaCommand { get; set; }
        public ICommand VerAgregarVendedorCommand { get; set; }
        public ICommand VerAgregarProductoCommand { get; set; }

        //Agregar
        public ICommand VenderCommand { get; set; }
        public ICommand AgregarVendedorCommand { get; set; }
        public ICommand AgregarProductoCommand { get; set; }


        //ver Editar
        public ICommand VerEditarCommand { get; set; }
        public ICommand VerEditarVendedorCommand { get; set; }
        public ICommand VerEditarProductoCommand { get; set; }

        //Editar
        public ICommand EditarCommand { get; set; }
        public ICommand EditarVendedorCommand { get; set; }
        public ICommand EditarProductoCommand { get; set; }

        public ICommand VerComisionCommand { get; set; }
        public ICommand VerVendedoresCommand { get; set; }
        public ICommand VerProductosCommand { get; set; }

        public ICommand RegresarCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand CancelarEliminarCommand { get; set; }
        public ICommand VerComisionFechaCommand { get; set; }

        private EliminarVentaView DeleteDialog;

        private ObservableCollection<Ventas> ventas;

        public ObservableCollection<Ventas> Ventas
        {
            get { return ventas; }
            set { ventas = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ventas")); }
        }

        private ObservableCollection<Comisiones> comision;

        public ObservableCollection<Comisiones> Comision
        {
            get { return comision; }
            set { comision = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Comision")); }
        }

        private ObservableCollection<Grupos> grupo;

        public ObservableCollection<Grupos> Grupos
        {
            get { return grupo; }
            set { grupo = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Grupos")); }
        }

        private ObservableCollection<Productos> productos;

        public ObservableCollection<Productos> Productos
        {
            get { return productos; }
            set { productos = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Productos")); }
        }

        private ObservableCollection<Vendedores> vendedores;

        public ObservableCollection<Vendedores> Vendedores
        {
            get { return vendedores; }
            set { vendedores = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vendedores")); }
        }
        private ObservableCollection<Estadocivil> estadocivil;

        public ObservableCollection<Estadocivil> EstadoCivil
        {
            get { return estadocivil; }
            set { estadocivil = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EstadoCivil")); }
        }

        private ObservableCollection<Poblacion> poblacion;

        public ObservableCollection<Poblacion> Poblacion
        {
            get { return poblacion; }
            set { poblacion = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Poblacion")); }
        }


        private Operacion operacion;

        public Operacion Operacion
        {
            get { return operacion; }
            set
            {
                operacion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Operacion"));
            }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Error"));
            }
        }



        private Ventas venta;

        public Ventas Venta
        {
            get { return venta; }
            set { venta = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Venta")); }

        }

        private Vendedores vendedor;
        public Vendedores Vendedor
        {
            get { return vendedor; }
            set { vendedor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vendedor"));
            }
        }

        private Productos producto;

        public Productos Producto
        {
            get { return producto; }
            set
            {
                producto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Producto"));
            }
        }


        private Comisiones comisiones;

        public Comisiones Comisiones
        {
            get { return comisiones; }
            set { comisiones = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Comisiones")); }
        }

        //VerAgregar
        public void VerAgregarVenta()
        {
            Operacion = Operacion.venta;
            Venta = new Ventas();
        }
        public void VerAgregarVendedor()
        {
            Operacion = Operacion.insertv;
            Vendedor = new Vendedores();
        }
        public void VerAgregarProducto()
        {
            Operacion = Operacion.insertp;
            Producto = new Productos();
        }




        public void VerComisiones()
        {
            Operacion = Operacion.comision;
        }

        public void VerProductos()
        {
            Operacion = Operacion.verp;
        }
        public void VerVendedores()
        {
            Operacion = Operacion.verv;
        }


        public void Regresar()
        {
            Operacion = Operacion.ver;
        }


        //Repositorios
        VentaRepository reposVenta = new VentaRepository();
        VendedoresRepository reposVendedores = new VendedoresRepository();
        ProductosRepository reposProductos = new ProductosRepository();


        //Agregar
        public void Agregar()
        {
            Error = "";
            try
            {
                if (reposVenta.Validate(Venta))
                {
                    reposVenta.Insert(Venta);
                    Ventas = new ObservableCollection<Ventas>(reposVenta.GetAll());
                    Comision = new ObservableCollection<Comisiones>(reposVendedores.GetComisiones());
                }
                Operacion = Operacion.ver;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public void AgregarVendedor()
        {
            Error = "";
            try
            {
                if (reposVendedores.Validate(Vendedor))
                {
                    reposVendedores.Insert(Vendedor);
                    Vendedores = new ObservableCollection<Vendedores>(reposVendedores.GetAll());
                   
                }
                Operacion = Operacion.verv;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public void AgregarProducto()
        {
            Error = "";
            try
            {
                if (reposProductos.Validate(Producto))
                {
                    reposProductos.Insert(Producto);
                    Productos = new ObservableCollection<Productos>(reposProductos.GetAll());

                }
                Operacion = Operacion.verp;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }



        //VerEditar
        public void VerEditar()
        {
            Error = "";

            if (Venta != null)
            {
                Operacion = Operacion.editar;
                var copia = new Ventas()
                {
                    Idventa = Venta.Idventa,
                    CodVendedor = Venta.CodVendedor,
                    CodProducto = Venta.CodProducto,
                    Fecha = Venta.Fecha,
                    Kilos = Venta.Kilos,
                   
                };
                Venta = copia;
            }
            else
            {
                Error = "Seleccione la venta para editar";
            }
        }
        public void VerEditarVendedor()
        {
            Error = "";

            if (Vendedor != null)
            {
                Operacion = Operacion.updatev;
                var copia = new Vendedores()
                {
                    NombreVendedor = Vendedor.NombreVendedor,
                    FechaAlta = Vendedor.FechaAlta,
                    Nif = Vendedor.Nif,
                    FechaNac= Vendedor.FechaNac,
                    Direccion= Vendedor.Direccion,
                    Poblacion= Vendedor.Poblacion,
                    CodPostal= Vendedor.CodPostal,
                    Telefon= Vendedor.Telefon,
                    EstalCivil=Vendedor.EstalCivil,

                };
                Vendedor = copia;
            }
            else
            {
                Error = "Seleccione el vendedor para editar";
            }

        }
        public void VerEditarProducto()
        {
            Error = "";

            if (Producto != null)
            {
                Operacion = Operacion.upadtep;
                var copia = new Productos()
                {
                    NomProducto = Producto.NomProducto,
                    IdGrupo = Producto.IdGrupo,
                    Precio = Producto.Precio,
                };
                Producto = copia;
            }
            else
            {
                Error = "Seleccione el vendedor para editar";
            }
        }

            //Editar

            public void Editar()
        {
            Error = "";

            try
            {
                if (reposVenta.Validate(Venta))
                {
                    reposVenta.Update(Venta);
                    Ventas = new ObservableCollection<Ventas>(reposVenta.GetAll());
                }
                Operacion = Operacion.ver;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }

        public void EditarVendedor()
        {
            Error = "";

            try
            {
                if (reposVendedores.Validate(Vendedor))
                {
                    reposVendedores.Update(Vendedor);
                    Vendedores = new ObservableCollection<Vendedores>(reposVendedores.GetAll());
                }
                Operacion = Operacion.verv;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }
        public void EditarProducto()
        {
            Error = "";

            try
            {
                if (reposProductos.Validate(Producto))
                {
                    reposProductos.Update(Producto);
                    Productos = new ObservableCollection<Productos>(reposProductos.GetAll());
                }
                Operacion = Operacion.verp;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }


        public void VerEliminar()
        {
            if (Venta != null)
            {
                Error = "";
                DeleteDialog = new EliminarVentaView();
                DeleteDialog.DataContext = this;
                DeleteDialog.ShowDialog();
            }
            else
                Error = "Seleccione la venta a Eliminar";
        }

        public void Eliminar()
        {
            Error = "";
            try
            {
                reposVenta.Delete(Venta);
                Comision = new ObservableCollection<Comisiones>(reposVendedores.GetComisiones());
                Ventas = new ObservableCollection<Ventas>(reposVenta.GetAll());
                DeleteDialog.Close();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public void CancelarDelete()
        {
            Error = "";
            DeleteDialog.Close();
        }

        private void VerComisionFecha(DateTime v)
        {
            Comision = new ObservableCollection<Comisiones>(reposVendedores.GetByDateTime(v));
            Error = "";
        }

        public VentasViewModel()
        {
            var datos = reposVenta.GetAll();
            Ventas = new ObservableCollection<Ventas>(datos);

            var datosv = reposVendedores.GetAll();
            Vendedores = new ObservableCollection<Vendedores>(datosv);


            var datosp = reposProductos.GetAll();
            Productos = new ObservableCollection<Productos>(datosp);

            var comision = reposVendedores.GetComisiones();
            Comision = new ObservableCollection<Comisiones>(comision);

            Vendedores = new ObservableCollection<Vendedores>(reposVendedores.GetNombre());
            Poblacion = new ObservableCollection<Poblacion>(reposVendedores.GetPoblacion());
            EstadoCivil = new ObservableCollection<Estadocivil>(reposVendedores.GetEstados());
            Productos = new ObservableCollection<Productos>(reposVendedores.GetProducto());
            Grupos = new ObservableCollection<Grupos>(reposProductos.GetGrupo());

            VerComisionFechaCommand = new RelayCommand<DateTime>(VerComisionFecha);
            VerAgregarVentaCommand = new RelayCommand(VerAgregarVenta);
            VerAgregarVendedorCommand = new RelayCommand(VerAgregarVendedor);
            VerAgregarProductoCommand = new RelayCommand(VerAgregarProducto);
            VenderCommand = new RelayCommand(Agregar);
            AgregarVendedorCommand = new RelayCommand(AgregarVendedor);
            AgregarProductoCommand = new RelayCommand(AgregarProducto);
            VerComisionCommand = new RelayCommand(VerComisiones);
            VerVendedoresCommand = new RelayCommand(VerVendedores);
            VerProductosCommand = new RelayCommand(VerProductos);
            VerEditarCommand = new RelayCommand(VerEditar);
            VerEditarVendedorCommand = new RelayCommand(VerEditarVendedor);
            VerEditarProductoCommand = new RelayCommand(VerEditarProducto);
            EditarCommand = new RelayCommand(Editar);
            EditarVendedorCommand = new RelayCommand(EditarVendedor);
            EditarProductoCommand = new RelayCommand(EditarProducto);
            RegresarCommand = new RelayCommand(Regresar);
            VerEliminarCommand = new RelayCommand(VerEliminar);
            EliminarCommand = new RelayCommand(Eliminar);
            CancelarEliminarCommand = new RelayCommand(CancelarDelete);
        }
    }
}
