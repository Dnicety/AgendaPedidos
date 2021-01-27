using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAR
{
    class CellProducto: ViewCell
    {
        public CellProducto()
        {
            var imagen = new Image
            {
                HorizontalOptions = LayoutOptions.Start
            };
            imagen.SetBinding(Image.SourceProperty, new Binding("ImageURI"));
            imagen.WidthRequest = imagen.HeightRequest = 80;

            var capaLabel = CrearCapaLabel();
            var capaVista = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(16, 0),
                Children = { imagen, capaLabel }
            };

            View = capaVista;
        }

        public StackLayout CrearCapaLabel()
        {
            var lblTitulo = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Blue,
                FontSize = 20
            };
            lblTitulo.SetBinding(Label.TextProperty, "NombreProducto");

            var lblDesc = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Gray
            };
            lblDesc.SetBinding(Label.TextProperty, "DescProducto");

            var lblPrecio = new Label
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                TextColor = Color.Green
            };
            lblPrecio.SetBinding(Label.TextProperty, "PrecProducto");

            var CapaLabel = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(32),
                Children = { lblTitulo, lblDesc, lblPrecio }
            };

            return CapaLabel;
        }

    }
}
