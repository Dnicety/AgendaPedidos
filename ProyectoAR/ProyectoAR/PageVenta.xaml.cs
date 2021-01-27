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
    public partial class PageVenta : ContentPage
    {
        public PageVenta()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            double totalTotal = 0.0;
            List<Venta> listaVentas = await App.Database.GetVentasAsync();
            foreach(Venta venta in listaVentas)
            {
                totalTotal = totalTotal + venta.Total;
            }
            lblTotal.Text = "$" + Convert.ToString(totalTotal) + " MXN";
            lvVentas.ItemsSource = listaVentas;
            lvVentas.ItemTemplate = new DataTemplate(typeof(CellPedido));
        }
    }
}