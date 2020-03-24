using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSIGES.Views.Lib
{
    public class CapitalizeKeyboardEffect : RoutingEffect
    {
        public const string EffectNamespace = "Example";
        public CapitalizeKeyboardEffect() : base($"{EffectNamespace}.{nameof(CapitalizeKeyboardEffect)}")
        {
        }
    }
}
