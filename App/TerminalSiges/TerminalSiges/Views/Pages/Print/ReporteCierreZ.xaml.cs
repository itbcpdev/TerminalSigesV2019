using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Print
{

    public partial class ReporteCierreZ : ContentPage
    {
        public bool Cargado = false;
        public ReporteCierreZ()
        {
            InitializeComponent();
        }
        private void OnImprimir(object sender, EventArgs e)
        {
            if (Cargado) return;
            Cargado = true;
            App.Current.MainPage = (new PrintCierreZCompleted());
        }

        private void OnReportes(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new PrintReporteCierreZ());
        }
        private void OnCancelar(object sender, EventArgs e)
        {
            App.Current.MainPage = (new Home());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = (new Home());
            return true;
        }
    }
}