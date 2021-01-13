using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Print;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TerminalSIGES.Droid.Services;
using TerminalSIGES.Services;
using DroidWebView = Android.Webkit.WebView;
using System.Threading.Tasks;
using System.IO;
using Android.Provider;
using Android.Content.PM;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

[assembly: Dependency(typeof(AndroidFeatureService))]
namespace TerminalSIGES.Droid.Services
{
    public class AndroidFeatureService : IFeatureService
    {
        PackageInfo _appInfo;

        public AndroidFeatureService()
        {
            var context = Android.App.Application.Context;
            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }

        public string GetVersionNumber()
        {
            return _appInfo.VersionName;
        }
        public string GetBuildNumber()
        {
            return _appInfo.VersionCode.ToString();
        }

        public string GetIdentifier()
        {
            return Settings.Secure.GetString(Forms.Context.ContentResolver, Settings.Secure.AndroidId);

        }

        public void Print(WebView viewToPrint)
        {
            var renderer = Platform.CreateRenderer(viewToPrint);
            var webView = renderer.ViewGroup.GetChildAt(0) as DroidWebView;

            if (webView != null)
            {
                var version = Build.VERSION.SdkInt;

                if (version >= BuildVersionCodes.Kitkat)
                {
                    PrintDocumentAdapter documentAdapter = webView.CreatePrintDocumentAdapter();
                    var printMgr = (PrintManager)Forms.Context.GetSystemService(Context.PrintService);
                    printMgr.Print("Forms-EZ-Print", documentAdapter, null);
                }
            }
        }

        public async Task<string> SaveFile(string filename, byte[] bytes)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllBytes(filePath, bytes);
            return filePath;
        }

        public string GetGeneralSetting(string settingsKey, string settingsDefault = null)
        {
            return AppSettings.GetValueOrDefault(settingsKey, settingsDefault ?? "");
        }

        public void SetGeneralSetting(string settingsKey, string value)
        {
            AppSettings.AddOrUpdateValue(settingsKey, value);
        }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
    }

}