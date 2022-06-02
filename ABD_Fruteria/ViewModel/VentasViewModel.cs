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

        public ICommand VerAgregarVentaCommand { get; set; }
        public ICommand VenderCommand { get; set; }
        public ICommand VerEditarCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand VerComisionCommand { get; set; }
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

        private ObservableCollection<Productos> producto;

        public ObservableCollection<Productos> Productos
        {
            get { return producto; }
            set { producto = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Productos")); }
        }

        private ObservableCollection<Vendedores> vendedores;

        public ObservableCollection<Vendedores> Vendedores
        {
            get { return vendedores; }
            set { vendedores = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vendedores")); }
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

        private Comisiones comisiones;

        public Comisiones Comisiones
        {
            get { return comisiones; }
            set { comisiones = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Comisiones")); }
        }


        public void VerAgregarVenta()
        {
            Operacion = Operacion.venta;
            Venta = new Ventas();
        }

        public void VerComisiones()
        {
            Operacion = Operacion.comision;
        }

        public void Regresar()
        {
            Operacion = Operacion.ver;
        }

        VentaRepository reposVenta = new VentaRepository();
        VendedoresRepository reposVendedores = new VendedoresRepository();
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

            var comision = reposVendedores.GetComisiones();
            Comision = new ObservableCollection<Comisiones>(comision);

            Vendedores = new ObservableCollection<Vendedores>(reposVendedores.GetNombre());
            Productos = new ObservableCollection<Productos>(reposVendedores.GetProducto());

            VerComisionFechaCommand = new RelayCommand<DateTime>(VerComisionFecha);
            VerAgregarVentaCommand = new RelayCommand(VerAgregarVenta);
            VenderCommand = new RelayCommand(Agregar);
            VerComisionCommand = new RelayCommand(VerComisiones);
            VerEditarCommand = new RelayCommand(VerEditar);
            EditarCommand = new RelayCommand(Editar);
            RegresarCommand = new RelayCommand(Regresar);
            VerEliminarCommand = new RelayCommand(VerEliminar);
            EliminarCommand = new RelayCommand(Eliminar);
            CancelarEliminarCommand = new RelayCommand(CancelarDelete);
        }
    }
}
