using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TerminalSiges.Lib.Sales;
using TerminalSIGES.Models;
using Xamarin.Forms;

namespace TerminalSiges.ViewModels
{
    public class BindingAutomatic : INotifyPropertyChanged
    {
        private GridLength _TituloFacturacion = GridLength.Auto;
        private GridLength _TituloCliente = new GridLength(0);
        private string _Titulo;
        private bool _IsVisibleClientes;


        public ObservableCollection<Lado> Productos { get; set; }

        public BindingAutomatic()
        {
            Productos = new ObservableCollection<Lado>();
            _TituloFacturacion = GridLength.Auto;
            _TituloCliente = new GridLength(0);
            _Titulo = "";
            _IsVisibleClientes = false;
        }
        public bool IsVisibleClientes
        {
            get { return _IsVisibleClientes; }
            set
            {
                _IsVisibleClientes = value;
                OnPropertyChanged();
            }
        }
        public void MostrarTituloFacturacion()
        {
            this.TituloCliente = new GridLength(0);
            this.TituloFacturacion = GridLength.Auto;
            this.IsVisibleClientes = false;
        }
        public void MostrarTituloCliente()
        {
            this.TituloFacturacion = new GridLength(0);
            this.TituloCliente = GridLength.Auto;
            this.IsVisibleClientes = true;
        }
        public string Titulo
        {
            get { return _Titulo; }
            set
            {
                _Titulo = value;
                OnPropertyChanged();
            }
        }

        public GridLength TituloFacturacion
        {
            get { return _TituloFacturacion; }
            set
            {
                _TituloFacturacion = value;
                OnPropertyChanged();
            }
        }
        public GridLength TituloCliente
        {
            get { return _TituloCliente; }
            set
            {
                _TituloCliente = value;
                OnPropertyChanged();
            }
        }

        public void AutomaticAllStart()
        {
            foreach(Lado lado in Productos)
            {
                lado.Estado.estado = true;
            }
        }
        public void AutomaticAllStop()
        {
            foreach (Lado lado in Productos)
            {
                lado.Estado.estado = false;
            }
        }
        public void AutomaticChangeStatus(string cara)
        {
            foreach(Lado lado in Productos)
            {
                if (lado.Cara.Equals(cara))
                {
                    lado.Estado.estado = !lado.Estado.estado;
                }
            }
        }
        public void AutomaticStopped(string cara)
        {
            foreach (Lado lado in Productos)
            {
                if (lado.Cara.Equals(cara))
                {
                    lado.Estado.estado = false;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
