
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Lib;
using Xamarin.Forms;

namespace TerminalSiges.Helpers
{
    public enum RegexType
    {
        [StringValue(@"^[0-9a-zA-Z]+$")]
        Codigo = 0,
        [StringValue(@"^[0-9A-Za-zñÑ\s.,-]+$")]
        Nombre = 1,
        [StringValue(@"^[0-9A-Za-zñÑ\s.,-]+$")]
        RazonSocial = 2,
        [StringValue("^[0-9]*$")]
        Tarjeta = 3,
        [StringValue(@"^[0-9A-Za-zñÑ\s;:=().,-/]+$")]
        Direccion = 4,
        [StringValue(@"^[a-zA-Z0-9@._-]+$")]
        Correo = 5,
        [StringValue("^[0-9]*$")]
        Numerico = 6,
        [StringValue("")]
        None = 7
    }
    public enum MaxLength
    {
        cliente_codigo = 20,
        cliente_ruc= 11,
        cliente_tarjeta_afiliacion = 20,
        cliente_razon_social = 120,
        cliente_tarjeta_credito = 20,
        cliente_direccion = 120,
        cliente_correo = 60,
        cliente_chofer = 20,
        cliente_placa = 8,
        cliente_odometro = 8,
        lado_limite = 2
        
    }
    public static class RegexExpresion
    {
        public static string OnTextChange(string text, RegexType regexType, MaxLength maxLength)
        {

                if (text.Trim().Length > (int)maxLength)
                {
                    text = text.Substring(0, (int)maxLength);
                    return text;
                }
                var NombreRegex = regexType.GetStringValue();
                text = text.TrimStart().ToUpper().Replace("  ", " ");

                bool EsValido = (Regex.IsMatch(text, NombreRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (!EsValido)
                {
                    if (text.Length > 1)
                    {
                        text = text.Remove(text.Length - 1);
                    }
                    else
                    {
                        text = "";
                    }
                }
            return text;
        }

        /*
        public static void OnTextChange(SfAutoComplete entry, RegexType regexType, MaxLength maxLength)
        {


            entry.ValueChanged += async (s, e) =>
            {
                string text = (entry.Text ?? "");
                if (text.Trim().Length > (int)maxLength)
                {
                    entry.Text = text.Substring(0, (int)maxLength);
                    return;
                }
                var NombreRegex = regexType.GetStringValue();
                entry.Text = e.Value.TrimStart().ToUpper().Replace("  ", " ");

                bool EsValido = (Regex.IsMatch(e.Value, NombreRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (!EsValido)
                {
                    if (text.Length > 1)
                    {
                        text = text.Remove(text.Length - 1);
                        entry.Text = text;
                    }
                    else
                    {
                        entry.Text = "";
                    }
                }
            };
        }
        */
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static Task<string> SolicitarPlaca(INavigation navigation)
        {
            // wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<string>();

            var lblTitle = new Label { Text = "Ingrese la placa y odómetro \n\n", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblPlaca = new Label { Text = "Placa", FontSize = 26 };
            var lblOdometro = new Label { Text = "Odómetro", FontSize = 24 };
            var uppertext = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
            var txtplaca = new Entry { Text = "", Keyboard = uppertext, FontSize = 24 };
            var txtodometro = new Entry { Text = "0", Keyboard = Keyboard.Numeric, FontSize = 24 };

            txtplaca.TextChanged += async (s, e) =>
            {

                if (txtplaca.Text.Trim().Length > 30)
                {
                    return;
                }
                var NombreRegex = @"^[\p{L}\p{N}\s-]+$";
                txtplaca.Text = e.NewTextValue.TrimStart().ToUpper().Replace("  ", " ");
                string _text = txtplaca.Text;
                bool EsValido = (Regex.IsMatch(e.NewTextValue, NombreRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (!EsValido)
                {
                    if (_text.Length > 1)
                    {
                        _text = _text.Remove(_text.Length - 1);
                        txtplaca.Text = _text;
                    }
                    else
                    {
                        txtplaca.Text = "";
                    }
                }
            };
            var btnOk = new Button
            {
                Text = "Aceptar",
                WidthRequest = 100,
                BackgroundColor = Color.FromHex("#038cfc"),
            };
            btnOk.Clicked += async (s, e) =>
            {
                // close page
                TSSalesApp.vCabecera.nroplaca = txtplaca.Text;
                TSSalesApp.vCabecera.odometro = txtodometro.Text;
                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult("ok");
            };

            var btnCancel = new Button
            {
                Text = "Cancelar",
                WidthRequest = 100,
                BackgroundColor = Color.FromHex("#9e1919")

            };
            btnCancel.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                TSSalesApp.vCabecera.nroplaca = "";
                TSSalesApp.vCabecera.odometro = "";
                tcs.SetResult(null);
            };

            var slButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnOk, btnCancel },
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 40, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, lblPlaca, txtplaca, lblOdometro, txtodometro, slButtons },
            };

            // create and show page
            var page = new ContentPage();
            page.Content = layout;
            navigation.PushModalAsync(page);
            // open keyboard
            txtplaca.Focus();

            // code is waiting her, until result is passed with tcs.SetResult() in btn-Clicked
            // then proc returns the result
            return tcs.Task;
        }

    } }
