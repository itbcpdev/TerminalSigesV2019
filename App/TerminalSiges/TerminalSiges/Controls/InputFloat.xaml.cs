using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputFloat : ContentView
    {
        int _topMargin = -38;

        public event EventHandler Completed;

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);
        public static readonly BindableProperty FontSizeEntryProperty = BindableProperty.Create("FontSizeEntry", typeof(double), typeof(InputFloat), 24.00);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(InputFloat), 24.00);
        public static readonly BindableProperty FontSizeLabelProperty = BindableProperty.Create("FontSizeLabel", typeof(double), typeof(InputFloat), 20.00);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null);
        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(InputFloat), ReturnType.Default);
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create("IsPassword", typeof(bool), typeof(InputFloat), default(bool));
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(InputFloat), Keyboard.Default, coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

        static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as InputFloat;
            if (!control.EntryField.IsFocused)
            {
                if (!string.IsNullOrEmpty((string)newValue))
                {
                    await control.TransitionToTitle(false);
                }
                else
                {
                    await control.TransitionToPlaceholder(false);
                }
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        public double FontSizeEntry
        {
            get => (double)GetValue(FontSizeEntryProperty);
            set => SetValue(FontSizeEntryProperty, value);
        }

        public double FontSizeLabel
        {
            get => (double)GetValue(FontSizeLabelProperty);
            set => SetValue(FontSizeLabelProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public InputFloat()
        {
            InitializeComponent();
            this.BindingContext = this;
            LabelTitle.TranslationX = 10;
        }

        public new void Focus()
        {
            if (IsEnabled)
            {
                EntryField.Focus();
            }
        }

        async void Handle_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                EntryField.Focus();
                await TransitionToTitle(true);
            }
        }

        async void Handle_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                await TransitionToPlaceholder(true);
            }
        }

        async Task TransitionToTitle(bool animated)
        {
            if (animated)
            {
                var t1 = LabelTitle.TranslateTo(0, _topMargin - ( (FontSizeLabel - 14) * 0.65), 100);
                var t2 = SizeTo(FontSizeLabel);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                LabelTitle.TranslationX = 0;
                LabelTitle.TranslationY = (_topMargin - ((FontSizeLabel - 14) * 0.65));
                LabelTitle.FontSize = FontSizeLabel;
            }
        }

        async Task TransitionToPlaceholder(bool animated)
        {
            if (animated)
            {
                var t1 = LabelTitle.TranslateTo(10, 0, 100);
                var t2 = SizeTo(FontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                LabelTitle.TranslationX = 10;
                LabelTitle.TranslationY = 0;
                LabelTitle.FontSize = FontSize;
            }
        }

        async void Handle_Tapped(object sender, EventArgs e)
        {
            if (IsEnabled)
            {
                await Task.Delay(100);
                EntryField.Focus();
            }
        }

        Task SizeTo(Double fontSize)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            // setup information for animation
            Action<double> callback = input => { LabelTitle.FontSize = input; };
            double startingHeight = LabelTitle.FontSize;
            double endingHeight = fontSize;
            uint rate = 5;
            uint length = 100;
            Easing easing = Easing.Linear;

            // now start animation with all the setup information
            LabelTitle.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        void Handle_Completed(object sender, EventArgs e)
        {
            Completed?.Invoke(this, e);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsEnabled))
            {
                EntryField.IsEnabled = IsEnabled;
            }
        }
    }
}