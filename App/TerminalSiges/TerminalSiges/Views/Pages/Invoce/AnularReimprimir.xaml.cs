using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSIGES.Models;
using TerminalSIGES.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Buttons;
using SelectionChangedEventArgs = Syncfusion.XForms.Buttons.SelectionChangedEventArgs;

namespace TerminalSiges.Views.Pages.Invoce
{

	public partial class AnularReimprimir : ContentPage
	{
		public AnularReimprimir ()
		{
			InitializeComponent ();
        }
        private void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            var detalle = e.Item as Detalle;
            vm?.HideOrShowProducto(detalle);

        }
        private async void SegmentedControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Index == 2)
            {
                await Navigation.PopAsync();
            }
        }

        private void BtnCancelarProducto_OnClicked(object sender, EventArgs e)
        {
            BackgroundColor = Color.FromHex("#ffffff");
            popupbuscarProducto.IsVisible = false;
        }

        private void BtnSearcProducts_Clicked(object sender, EventArgs e)
        {
            BackgroundColor = Color.FromHex("#a9cae0");
            popupbuscarProducto.IsVisible = true;
        }
    }
}