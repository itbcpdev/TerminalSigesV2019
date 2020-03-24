using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSIGES.Views.Lib
{
    
    public class ListViewHighlightEffect : RoutingEffect
    {
        public const string EffectNamespaced = "Example";
        public ListViewHighlightEffect() : base($"{EffectNamespaced}.{nameof(ListViewHighlightEffect)}")
        {
        }
    }
}
