using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace ProyectoAR
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public MultiSelectObservableCollection<Producto> Productos { get; set; }

        public ICommand DisplayNameCommand => new Command<Producto>(async producto =>
        {
            double total = 0.0;
            string productosPedidos = "";
            foreach(Producto producto1 in Productos.SelectedItems)
            {
                total = total + Convert.ToDouble(producto1.PrecProducto);
                productosPedidos = productosPedidos + producto1.NombreProducto + ", ";
            }
            Application.Current.Properties["totalTotal"] = total;
            Application.Current.Properties["productosPedidos"] = productosPedidos;
        });

        public MainViewModel()
        {
            LoadList();
        }
        
        public async void LoadList()
        {
            Productos = new MultiSelectObservableCollection<Producto>();
            List<Producto> listaProducto = await App.Database.GetProductosAsync();
            foreach (Producto producto in listaProducto)
            {
                Producto producto1 = new Producto();
                producto1.ID = producto.ID;
                producto1.NombreProducto = producto.NombreProducto;
                producto1.DescProducto = producto.DescProducto;
                producto1.PrecProducto = producto.PrecProducto;
                producto1.TipoProducto = producto.TipoProducto;

                Productos.Add(producto1);
            }
        }
    }
}
