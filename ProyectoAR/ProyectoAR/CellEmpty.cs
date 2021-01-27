using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAR
{
    class CellEmpty: ViewCell
    {

        public CellEmpty()
        {
            var capaEmpty = CrearCapaVacia();
            var capaVista = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { capaEmpty },
            };

            View = capaVista;
        }

        static StackLayout CrearCapaVacia()
        {
            var txtEmpty = new Label
            {
                Text = "No hay pedidos pendientes"
            };

            var capaEmpty = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { txtEmpty }
            };

            return capaEmpty;
        }

    }
}
