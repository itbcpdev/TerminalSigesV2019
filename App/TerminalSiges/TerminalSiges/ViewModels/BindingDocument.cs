using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TerminalSiges.ViewModels
{
    public class BindingDocument : INotifyPropertyChanged
    {
        private string documento;
        private string respuesta;
        private string estado;

        public string Documento
        {
            get { return documento; }
            set
            {
                documento = value;
                OnPropertyChanged("Documento");
            }
        }

        public string Respuesta
        {
            get { return respuesta; }
            set
            {
                respuesta = value;
                OnPropertyChanged("Respuesta");
            }
        }
        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged("Estado");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
