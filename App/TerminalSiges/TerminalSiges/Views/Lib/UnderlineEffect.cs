using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSIGES.Views.Lib
{
    public class UnderlineEffect : RoutingEffect
    {
        public const string EffectNamespace = "Example";

        public UnderlineEffect() : base($"{EffectNamespace}.{nameof(UnderlineEffect)}")
        {
        }
    }
}
