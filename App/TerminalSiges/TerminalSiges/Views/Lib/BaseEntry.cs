using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace TerminalSIGES.Views.Lib
{
   public class BaseEntry : Entry
    {
        public new event EventHandler Completed;

        public new static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
            nameof(ReturnType),
            typeof(ReturnType),
            typeof(BaseEntry),
            ReturnType.Done,
            BindingMode.OneWay
        );

        public new ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
        }
    }
}
