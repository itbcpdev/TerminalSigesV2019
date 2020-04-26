using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 
namespace TerminalSIGES.Services
{
    public interface IFeatureService
    {
        string GetVersionNumber();
        string GetBuildNumber();
        string GetIdentifier();
        void Print(WebView viewToPrint);
        Task<string> SaveFile(string filename, byte[] bytes);
    }
}
