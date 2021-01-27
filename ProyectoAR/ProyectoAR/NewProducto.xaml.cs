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
    public partial class NewProducto : ContentPage
    {
        public NewProducto()
        {
            InitializeComponent();
        }

        private async void btn_AddProducto_Clicked(object sender, EventArgs e)
        {

            if(txtNombreProducto.Text != null && editorDesc.Text != null && txtPrecio.Text != null && pickerCaratula.SelectedItem != null)
            {
                var producto = (Producto)BindingContext;

                producto.NombreProducto = txtNombreProducto.Text;
                producto.DescProducto = editorDesc.Text;
                producto.PrecProducto = txtPrecio.Text;
                producto.TipoProducto = pickerCaratula.SelectedItem.ToString();

                await App.Database.InsertProductoAsync(producto);
                await Navigation.PopAsync();
            } else
            {
                await DisplayAlert("Error", "Completar todos los campos", "Entendido");
            }
            
        }
    }
}