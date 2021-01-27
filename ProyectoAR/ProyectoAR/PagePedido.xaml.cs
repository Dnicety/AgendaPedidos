using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePedido : ContentPage
    {
        public PagePedido()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadList();            
        }

        private async void loadList()
        {
            List<Pedido> listaPedidos = await App.Database.GetPedidosAsync();
            if (listaPedidos.Count <= 0)
            {
                List<Pedido> listaEmpty = new List<Pedido> { new Pedido {
                    ID = 0,
                    Cliente = "",
                    FechaPedido = DateTime.UtcNow,
                    FechaEntrega = DateTime.UtcNow,
                    Producto = "",
                    Total = 0,
                    }
                };
                lvPedidos.ItemsSource = listaEmpty;
                lvPedidos.ItemTemplate = new DataTemplate(typeof(CellEmpty));
                lvPedidos.IsEnabled = false; 
            } else
            {
                lvPedidos.ItemsSource = listaPedidos;
                lvPedidos.ItemTemplate = new DataTemplate(typeof(CellPedido));
                lvPedidos.IsEnabled = true;
            }
        }

        private async void lvPedidos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var respuesta = await DisplayActionSheet("Opciones", null, "Cancelar", "Eliminar", "Marcar como entregado");
            var pedido = e.Item as Pedido;
            Pedido miPedido = await App.Database.GetPedidoAsync(pedido.ID);

            switch (respuesta)
            {
                case "Eliminar":
                    await App.Database.DeletePedidoAsync(miPedido);
                    loadList();
                    break;
                case "Marcar como entregado":
                    var nuevaVenta = new Venta
                    {
                        ID = miPedido.ID,
                        Cliente = miPedido.Cliente,
                        FechaPedido = miPedido.FechaPedido,
                        FechaEntrega = miPedido.FechaEntrega,
                        Producto = miPedido.Producto,
                        Total = miPedido.Total
                    };

                    await App.Database.InsertNuevaVenta(nuevaVenta);
                    await App.Database.DeletePedidoAsync(miPedido);
                    await DisplayAlert("Pedido Entregado", null, "Entendido");
                    loadList();
                    break;
            }
        }
    }
}