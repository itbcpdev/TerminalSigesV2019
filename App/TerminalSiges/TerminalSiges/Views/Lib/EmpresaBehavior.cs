using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSiges.Views.Lib
{
    public class EmpresaBehavior : Behavior<SfComboBox>
    {
        SfComboBox combo;
        protected override void OnAttachedTo(SfComboBox bindable)
        {
            base.OnAttachedTo(bindable);
            combo = bindable;
            bindable.SelectionChanged += Bindable_SelectionChanged;
        }
        async private void Bindable_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            var answer = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Selection Changed", "Selected Index: " + combo.SelectedValue.ToString(), null, "OK");
        }
        protected override void OnDetachingFrom(SfComboBox bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
