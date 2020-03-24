using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSIGES.Views.Lib
{
    public class Estilos
    {
        public static string FuenteLight
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Lato-Light.ttf#Lato-Light";
                    case Device.Android:
                        return "Lato-Light";
                    default:
                        return "Lato-Light";
                }
            }
        }
        public static string FuenteRegular
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Lato-Regular.ttf#Lato-Regular";
                    case Device.Android:
                        return "Lato-Regular";
                    default:
                        return "Lato-Regular";
                }
            }
        }
        public static string FuenteBold
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Lato-Bold.ttf#Lato-Bold";
                    case Device.Android:
                        return "Lato-Bold";
                    default:
                        return "Lato-Bold";
                }
            }

        }
        public static string FuenteSegoe
        {
            get
            {
                return Device.OnPlatform("Segoe_MDL2", "Segoe-MDL2-Assets.ttf#Segoe-MDL2-Assets", "");
            }

        }
        public static string IcoMoonFree
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "IcoMoonFree.ttf.ttf#IcoMoonFree";
                    case Device.Android:
                        return "IcoMoonFree";
                    default:
                        return "";
                }
            }
        }
        public static Thickness MargenInputs
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return new Thickness(0, 15, 0, 0);
                    case Device.Android:
                        return new Thickness(0, 15, 0, 0);
                    default:
                        return new Thickness(0, 0, 0, 0);
                }
            }
        }
    }
}


/*

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TerminalSIGES.Views.Lib
{
    public class Estilos
    {

        public static string FuenteLight
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Lato-Light.ttf#Lato-Light";
                    case Device.Android:
                        return "Lato-Light";
                    default:
                        return "";
                }
            }
        }
        public static string FuenteRegular
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Lato-Regular.ttf#Lato-Regular";
                    case Device.Android:
                        return "Lato-Regular";
                    default:
                        return "";
                }
            }
        }
        public static string FuenteBold
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Lato-Bold.ttf#Lato-Bold";
                    case Device.Android:
                        return "Lato-Bold";
                    default:
                        return "";
                }
            }

        }
        public static string FuenteSegoe
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Segoe-MDL2-Assets.ttf#Segoe-MDL2-Assets";
                    case Device.Android:
                        return "Segoe_MDL2";
                    default:
                        return "";
                }
            }
        }
        public static string IcoMoonFree
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "IcoMoonFree.ttf.ttf#IcoMoonFree";
                    case Device.Android:
                        return "IcoMoonFree";
                    default:
                        return "";
                }
            }
        }
        public static Thickness MargenInputs
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return new Thickness(0, 15, 0, 0);
                    case Device.Android:
                        return new Thickness(0, 15, 0, 0);
                    default:
                        return new Thickness(0, 0, 0, 0);
                }
            }
        }
    }
}

    */
