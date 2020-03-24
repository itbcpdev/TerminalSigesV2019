using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSiges.Views.Lib
{
    public class CustomWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(nameof(Uri), typeof(string), typeof(CustomWebView));
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
     
      
    }
}
