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

	public partial class DetailProducts : ContentPage
	{
		public DetailProducts ()
		{
			InitializeComponent ();
		}
        private void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            var detalle = e.Item as Detalle;
            vm?.HideOrShowProducto(detalle);

        }
        private void SegmentedControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Index == 3)
            {
                App.Current.MainPage = new NavigationPage(new SemiAutomatic());
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