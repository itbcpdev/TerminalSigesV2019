using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TerminalSIGES.Models
{
    public enum EDocumento
    {
        BoletaFactura = 1,
        NotaDespacho = 2,
        TranferenciaGratuita = 3,
        Serafin = 4,
        Canje = 5

    }
    public class Lado : INotifyPropertyChanged
    {
        public event OnError ExceptionEvent;
        public delegate void OnError(string mensaje);

        private string cara { get; set; }
        private string codigo { get; set; }
        private string ruc { get; set; }
        private string razonsocial { get; set; }
        private string correo { get; set; }
        private string direccion { get; set; }
        private string placa { get; set; }
        private string odometro { get; set; }
        private string chofer { get; set; }
        private string tarjeta_afiliacion { get; set; }
        private string tarjeta { get; set; }
        private string pago { get; set; }
        private string image { get; set; }
        private string telefono { get; set; }
        private string marca { get; set; }
        private string modelo { get; set; }
        private double size { get; set; }
        private string mensaje { get; set; }
        private bool   imprimir { get; set; }
        private bool   automaticbutton { get; set; }
        private DateTime? fecha_nacimiento { get; set; }
        public EDocumento Documento { get; set; }
        public Estado Estado { get; set; }

        public Lado()
        {
            this.codigo = "";
            this.ruc = "";
            this.razonsocial = "";
            this.correo = "";
            this.direccion = "";
            this.placa = "";
            this.odometro = "";
            this.chofer = "";
            this.tarjeta_afiliacion = "";
            this.pago = "";
            this.image = "play.png";
            this.fecha_nacimiento = null;
            this.marca = "";
            this.modelo = "";
            this.tarjeta = "";
            this.Documento = EDocumento.BoletaFactura;
            this.Pagos = new ObservableCollection<Pago>();
            this.size = 100.00;
            this.mensaje = "";
            this.imprimir = true;
            this.automaticbutton = false;
        }

        public string Cara
        {
            get { return cara; }
            set
            {
                cara = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Codigo {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Ruc {
            get { return ruc; }
            set
            {
                ruc = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string RazonSocial {
            get { return razonsocial; }
            set
            {
                razonsocial = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Correo {
            get { return correo; }
            set
            {
                correo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Direccion {
            get { return direccion; }
            set
            {
                direccion = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Placa {
            get { return placa; }
            set
            {
                placa = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Odometro {
            get { return odometro; }
            set
            {
                odometro = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Chofer {
            get { return chofer; }
            set
            {
                chofer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Tarjeta_afiliacion {
            get { return tarjeta_afiliacion; }
            set
            {
                tarjeta_afiliacion = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Pago {
            get { return pago; }
            set
            {
                pago = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Tarjeta
        {
            get { return tarjeta; }
            set
            {
                tarjeta = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public DateTime? Fecha_Nacimiento
        {
            get { return fecha_nacimiento; }
            set
            {
                fecha_nacimiento = value;
                OnPropertyChanged();
            }
        }
        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Marca
        {
            get { return marca; }
            set
            {
                marca = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Modelo
        {
            get { return modelo; }
            set
            {
                modelo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public double Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set
            {
                mensaje = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }
        public bool IsImprimir
        {
            get { return imprimir; }
            set
            {
                imprimir = value;
                OnPropertyChanged();
            }
        }
        public bool AutomaticButton
        {
            get { return automaticbutton; }
            set
            {
                automaticbutton = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Pago> Pagos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void Exception(string exception)
        {
            ExceptionEvent(exception);
        }
    }
    public class Pago
    {
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Referencia { get; set; }
        public Decimal Soles { get; set; }
        public Decimal Dolares { get; set; }
    }
    public class Estado
    {
        public bool estado { get; set; }
        public string cara { get; set; }

        public Estado(string cara, bool estado) 
        {
            this.cara = cara;
            this.estado = estado;
        }
    }
    public class Cara
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class Factura
    {
        public int Id { get; set; } 
        public string Cara { get; set; }
        public DateTime Fecha { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string TipoPago { get; set; }
        public string Tarjeta { get; set; }
        public string Placa { get; set; }
        public List<Producto> Productos { get; set; }
        public double Total => Productos.Sum(p => p.Total);
    }
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Total { get; set; }
    }

    public class Detalle
    {   public int Item { get; set; }

        public string Tipo { get; set; }
        public string Hora { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }
        public bool IsVisble { get;set; }
    }

    public class TransPendiente
    {
        public int TransactionId { get; set; }
        public string Cara { get; set; }
        public string Codigo { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Galones { get; set; }
        public string Total { get; set; }
    }

    public class TipoTarjeta
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }

    public class Empresa
    {
        public string RUC { get; set; }
        public string RazonSocial { get; set; }
    }
}
