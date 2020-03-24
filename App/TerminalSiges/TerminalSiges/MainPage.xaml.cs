using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Views.Pages.Users;
using Xamarin.Forms;

namespace TerminalSiges
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var url = App.Current.Properties.ContainsKey("BASEURL") ? App.Current.Properties["BASEURL"].ToString() : "";
            var varserie = App.Current.Properties.ContainsKey("Serie") ?  App.Current.Properties["Serie"].ToString() : "";
            var varnomimprimir = App.Current.Properties.ContainsKey("IMPRIMIR") ? App.Current.Properties["IMPRIMIR"].ToString().Equals("T") : false;
            this.txtUrlBase.Text = url;
            this.txtCodPos.Text = varserie;
            this.cCheckImprimir.IsChecked = varnomimprimir;
        }
        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }
        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["BASEURL"] = this.txtUrlBase.Text;
            App.Current.Properties["Serie"] = this.txtCodPos.Text;
            App.Current.Properties["IMPRIMIR"] = (this.cCheckImprimir.IsChecked ?? false) ? "T" : "F";
            App.Current.MainPage = new NavigationPage( new Login());
        }
    }
}
