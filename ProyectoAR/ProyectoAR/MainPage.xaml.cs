using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoAR
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void btn_NewPedido_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPedido
            {
                BindingContext = new Pedido()
            });
        }

        async private void btn_NewProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProducto
            {
                BindingContext = new Producto()
            });
        }
    }
}
