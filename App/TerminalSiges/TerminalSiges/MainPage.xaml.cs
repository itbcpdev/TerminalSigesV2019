using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Include;
using TerminalSiges.Views.Pages.Users;
using TerminalSIGES.Services;
using Xamarin.Forms;

namespace TerminalSiges
{
    public partial class MainPage : ContentPage
    {
        private IFeatureService _featureService;

        public MainPage()
        {
            InitializeComponent();

            _featureService = DependencyService.Get<IFeatureService>();
            var url = _featureService.GetGeneralSetting(Config.Services.ServiceUrlKey);
            var varserie = _featureService.GetGeneralSetting(Config.Services.SerieHdKey);
            var varnomimprimir = _featureService.GetGeneralSetting(Config.Services.PrintKey).Equals("T");
            txtUrlBase.Text = url;
            txtCodPos.Text = varserie;
            cCheckImprimir.IsChecked = varnomimprimir;
        }
        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }
        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            _featureService.SetGeneralSetting(Config.Services.ServiceUrlKey, txtUrlBase.Text);
            _featureService.SetGeneralSetting(Config.Services.SerieHdKey, txtCodPos.Text);
            _featureService.SetGeneralSetting(Config.Services.PrintKey, (cCheckImprimir.IsChecked ?? false) ? "T" : "F");
            App.Current.MainPage = new NavigationPage( new Login());
        }
    }
}
