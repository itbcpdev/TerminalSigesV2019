using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSIGES.Views.Lib {
  public class BordeEntry : Entry {
      public new event EventHandler<EventArgs> Completed;

        [Obsolete]
        public new static readonly BindableProperty ReturnTypeProperty =
          BindableProperty.Create<BaseEntry, ReturnType>(s => s.ReturnType, ReturnType.Done);

        [Obsolete]
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
