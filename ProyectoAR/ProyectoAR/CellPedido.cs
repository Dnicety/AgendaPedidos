using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAR
{
    class CellPedido: ViewCell
    {

        public CellPedido()
        {
            // Seccion Informacion del cliente
            var lblCliente = new Label
            {
                Text = "Cliente: "
            };
            var lblClienteB = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            }; lblClienteB.SetBinding(Label.TextProperty, "Cliente");
            var capaCliente = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblCliente, lblClienteB }
            };

            //Seccion Fecha Pedido
            var lblFechaP = new Label
            {
                Text = "Fecha Pedido: "
            };
            var lblFechaPB = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            }; lblFechaPB.SetBinding(Label.TextProperty, "FechaPedido");
            var capaFechaP = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblFechaP, lblFechaPB }
            };

            //Seccion Fecha Entrega
            var lblFechaE = new Label
            {
                Text = "Fecha Entrega: "
            };
            var lblFechaEB = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            }; lblFechaEB.SetBinding(Label.TextProperty, "FechaEntrega");
            var capaFechaEntrega = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblFechaE, lblFechaEB }
            };

            //Seccion Productos
            var lblProductos = new Label
            {
                Text = "Productos: "
            };
            var lblProductosB = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            }; lblProductosB.SetBinding(Label.TextProperty, "Producto");
            var capaProductos = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblProductos, lblProductosB }
            };

            //Seccion Total
            var lblTotal = new Label
            {
                Text = "Total: $"
            };
            var lblTotalB = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            }; lblTotalB.SetBinding(Label.TextProperty, "Total");
            var capaTotal = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblTotal, lblTotalB }
            };

            var capaVista = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { capaCliente, capaFechaP, capaFechaEntrega, capaProductos, capaTotal},
                Padding = new Thickness(10),
                BackgroundColor = Color.Beige,
            };

             View = capaVista;
        }
    }
}
