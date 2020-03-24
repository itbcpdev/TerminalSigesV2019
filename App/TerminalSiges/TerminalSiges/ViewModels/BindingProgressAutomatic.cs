using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using TerminalSIGES.Models;
using Xamarin.Forms;

namespace TerminalSiges.ViewModels
{
    public class BindingProgressAutomatic : INotifyPropertyChanged
    {
        private string _Mensaje;
        private string _Progreso;
        public ObservableCollection<BindingDocument> Documentos { get; set; }

        public BindingProgressAutomatic()
        {
            _Mensaje = "";
            _Progreso = "";
            Documentos = new ObservableCollection<BindingDocument>();
        }

        public string Mensaje
        {
            get { return _Mensaje; }
            set
            {
                _Mensaje = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Progreso
        {
            get { return _Progreso; }
            set
            {
                _Progreso = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
      
    }
}