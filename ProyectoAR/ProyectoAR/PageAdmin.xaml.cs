using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAdmin : ContentPage
    {
        string Reporte = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reporte.txt");

        public PageAdmin()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Editor.Text = null;
        }

        private async void btnReporte_Clicked(object sender, EventArgs e)
        {
            List<Pedido> listaPedidos = await App.Database.GetPedidosAsync();
            List<Venta> listaVenta = await App.Database.GetVentasAsync();
            double totalTotal = 0.0;
            var produtos = "";

            foreach(Venta venta in listaVenta)
            {
                totalTotal = totalTotal + venta.Total;
                produtos = produtos + "* " + venta.Producto + "\n";
            }

            File.WriteAllText(Reporte, "Fecha generacion del reporte: " + DateTime.UtcNow + "\n\n" +
                "Total de pedidos disponibles: " + listaPedidos.Count + "\n" +
                "Total de ventas entregadas: " + listaVenta.Count + "\n" +
                "Total de ingresos: $" + totalTotal + "\n" +
                "Productos vendidos: " + "\n" +
                produtos);
            await DisplayAlert("Reporte", "Se genero el reporte correctamente", "Entendido");
        }

        private void btnVer_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(Reporte))
            {
                Editor.Text = File.ReadAllText(Reporte);
            } else
            {
                Editor.Text = "No hay reporte previo";
            }
        }
    }
}