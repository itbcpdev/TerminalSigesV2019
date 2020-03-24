using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;

namespace TerminalSiges.ViewModels
{
    public class BindingProgressCustomers : INotifyPropertyChanged
    {
        public ObservableCollection<TS_BEClienteLista> EmployeeCollection { get; set; }
        public ObservableCollection<object> Prefijos { get; set; }
        private ObservableCollection<object> _selectedItem;
        private string cCodigo_cliente;
        private string cTarjeta_afiliacion_cliente;
        private string cRuc_cliente;
        private string cRazon_social_cliente;
        private string cDireccion_cliente;
        private string cCorreo_cliente;
        private string cPlaca;
        private string cSaldo;
        private string cTarjeta;
        private string cOdometro;
        private string cChofer;
        private string ctextTarjetaCreditoBusqueda;
        private bool cIsPlacaVisible;
        private bool cIsChoferVisible;
        private bool cIsOdometroVisible;
        private bool cIsValeVisible;
        private bool cIsPlacaEnabled;
        private bool cIsChoferEnabled;
        private bool cIsOdometroEnabled;
        private bool cIsValeEnabled;
        private bool cIsSearch;
        private bool cIsLoading;
        private bool cIsClosed;

        public event PropertyChangedEventHandler PropertyChanged;

        public BindingProgressCustomers()
        {
            EmployeeCollection = new ObservableCollection<TS_BEClienteLista>();
            Prefijos = new ObservableCollection<object>();
            getPrefijos(Prefijos);
            SelectedItem = new ObservableCollection<object> { Prefijos[0] };
            cCodigo_cliente = "";//10424402643
            cTarjeta_afiliacion_cliente = "";// 201910424402643
            cRuc_cliente = "";
            cRazon_social_cliente = "";
            cDireccion_cliente = "";
            cTextTarjetaCreditoBusqueda = "";
            IsSearch = false;
            cIsLoading = false;
            cCorreo_cliente = "";
            cPlaca = "";
            cOdometro = "";
            cSaldo = "0.00";
            cTarjeta = "";
            cChofer = "";
            cIsPlacaVisible = true;
            cIsChoferVisible = true;
            cIsOdometroVisible = true;
            cIsValeVisible = true;
            cIsPlacaEnabled = true;
            cIsChoferEnabled = true;
            cIsOdometroEnabled = true;
            cIsValeEnabled = true;
            cIsClosed = false;

           
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string cTextTarjetaCreditoBusqueda
        {
            get { return ctextTarjetaCreditoBusqueda; }
            set
            {
                ctextTarjetaCreditoBusqueda = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Odometro
        {
            get { return cOdometro; }
            set
            {
                cOdometro = RegexExpresion.OnTextChange(value, RegexType.Numerico, MaxLength.cliente_odometro);
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Tarjeta
        {
            get { return cTarjeta; }
            set
            {
                cTarjeta = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Saldo
        {
            get { return cSaldo; }
            set
            {
                cSaldo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Placa
        {
            get { return cPlaca; }
            set
            {
                cPlaca = RegexExpresion.OnTextChange(value, RegexType.Nombre, MaxLength.cliente_placa); 
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Correo
        {
            get { return cCorreo_cliente; }
            set 
            { 
                cCorreo_cliente = RegexExpresion.OnTextChange(value, RegexType.Correo, MaxLength.cliente_correo); 
                OnPropertyChanged(); 
                OnPropertyChanged(nameof(value)); 
            }
        }
        public string Codigo_cliente
        {
            get { return cCodigo_cliente; }
            set
            {
                
                cCodigo_cliente = RegexExpresion.OnTextChange(value, RegexType.Codigo, MaxLength.cliente_codigo);
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Tarjeta_afiliacion_cliente
        {
            get { return cTarjeta_afiliacion_cliente; }
            set
            {
                cTarjeta_afiliacion_cliente = RegexExpresion.OnTextChange(value, RegexType.Tarjeta, MaxLength.cliente_tarjeta_afiliacion); 
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Ruc_cliente
        {
            get { return cRuc_cliente; }
            set
            {
                cRuc_cliente = RegexExpresion.OnTextChange(value, RegexType.Numerico, MaxLength.cliente_ruc); 

                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Razon_social_cliente
        {
            get { return cRazon_social_cliente; }
            set
            {
                cRazon_social_cliente = RegexExpresion.OnTextChange(value, RegexType.None, MaxLength.cliente_razon_social); 

                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Direccion_cliente
        {
            get { return cDireccion_cliente; }
            set
            {
                cDireccion_cliente = RegexExpresion.OnTextChange(value, RegexType.None, MaxLength.cliente_direccion); 
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Chofer
        {
            get { return cChofer; }
            set
            {
                cChofer = RegexExpresion.OnTextChange(value, RegexType.Nombre, MaxLength.cliente_chofer);
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public bool IsSearch
        {
            get { return cIsSearch; }
            set
            {
                cIsSearch = !value;
                IsLoading = value;
                OnPropertyChanged();
            }
        }
        public bool IsClosed
        {
            get { return cIsClosed; }
            set
            {
                cIsClosed = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get { return cIsLoading; }
            set
            {
                cIsLoading = value;
                OnPropertyChanged();
            }
        }
        #region CAMPOS HABILITADOS CREDITO
        public bool IsPlacaEnabled
        {
            get { return cIsPlacaEnabled; }
            set
            {
                cIsPlacaEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsChoferEnabled
        {
            get { return cIsChoferEnabled; }
            set
            {
                cIsChoferEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsOdometroEnabled
        {
            get { return cIsOdometroEnabled; }
            set
            {
                cIsOdometroEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsValeEnabled
        {
            get { return cIsValeEnabled; }
            set
            {
                cIsValeEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Campos Visibles Credito
        public bool IsPlacaVisible
        {
            get { return cIsPlacaVisible; }
            set
            {
                cIsPlacaVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsChoferVisible
        {
            get { return cIsChoferVisible; }
            set
            {
                cIsChoferVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsOdometroVisible
        {
            get { return cIsOdometroVisible; }
            set
            {
                cIsOdometroVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsVale
        {
            get { return cIsValeVisible; }
            set
            {
                cIsValeVisible = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public void getPrefijos(ObservableCollection<object> Lista)
        {
            string prefLocal = (TSSalesApp.vParemetros.prefcredlocal ?? "").Trim();
            string prefCorp  = (TSSalesApp.vParemetros.prefcredcorp ?? "").Trim();
            string prefflot = (TSSalesApp.vParemetros.prefflotlocal ?? "").Trim();

            if(String.IsNullOrEmpty(prefLocal) == false)
            {
                Lista.Add(prefLocal);
            }
            if (String.IsNullOrEmpty(prefCorp) == false)
            {
                Lista.Add(prefCorp);
            }
            if (String.IsNullOrEmpty(prefflot) == false)
            {
                Lista.Add(prefflot);
            }
        }
        public ObservableCollection<object> SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }

        }
    }
}