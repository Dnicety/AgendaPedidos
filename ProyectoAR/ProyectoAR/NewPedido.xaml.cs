using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPedido : ContentPage
    {
        DateTime Fecha = DateTime.UtcNow;

        public NewPedido()
        {
            InitializeComponent();
            Fecha.AddDays(1);
            dpEntrega.MinimumDate = Fecha;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        async private void btn_addPedido_Clicked(object sender, EventArgs e)
        {
            if (txtCliente.Text != null)
            {
                var pedido = (Pedido)BindingContext;
                pedido.Cliente = txtCliente.Text;
                pedido.FechaPedido = DateTime.UtcNow;
                pedido.FechaEntrega = dpEntrega.Date;
                pedido.Producto = Application.Current.Properties["productosPedidos"].ToString();
                pedido.Total = Convert.ToDouble(Application.Current.Properties["totalTotal"].ToString());

                await App.Database.InsertPedidoAsync(pedido);
                await Navigation.PopAsync();
                Application.Current.Properties["ProductosPedidos"] = "";
            } else
            {
                await DisplayAlert("Error", "Completar campo faltante", "Entendido");
            }
        }
    }
}