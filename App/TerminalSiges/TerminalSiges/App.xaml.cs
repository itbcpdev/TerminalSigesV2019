using Matcha.BackgroundService;
using TerminalSiges.Services;
using TerminalSiges.Views;
using TerminalSiges.Views.Pages.Afiliacion;
using TerminalSiges.Views.Pages.Articulo;
using TerminalSiges.Views.Pages.Users;
using Xamarin.Forms;
/*
#if !DEBUG
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
#endif*/
namespace TerminalSiges
{

    public partial class App : Application
    {
        public static string BASEURL;
        public static string Serie;
        public static Color Color = Color.FromHex("#2196F3");
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjY2MDJAMzEzNjJlMzQyZTMwVEVTbEdXNjRGRTYwTkNEbHRRR05XU2ErcXpNSzRXM0FyOVdkVVFSb25kQT0=");
            InitializeComponent();
            NavigationPage Page = new NavigationPage(new Login());
            Page.BarBackgroundColor = Color;
            //MainPage = new NavigationPage(new SearchArticuloByAfiliacion());
            MainPage = Page;
            //MainPage = new NavigationPage(new Automatic());
/*
#if DEBUG
            HotReloader.Current.Run(this);
#endif
*/
        }

        protected override void OnStart()
        {
            BackgroundAggregatorService.Add(() => new AutomaticService(500));
            BackgroundAggregatorService.StartBackgroundService();
            //Start the background service
        }

        protected override void OnSleep()
        {
            BackgroundAggregatorService.StopBackgroundService();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            BackgroundAggregatorService.StartBackgroundService();
            // Handle when your app resumes
        }
    }
}
