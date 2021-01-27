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
    public partial class NuevoPedido : StackLayout
    {
        public NuevoPedido()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }
    }
}