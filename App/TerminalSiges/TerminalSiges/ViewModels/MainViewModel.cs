using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using TerminalSIGES.Models;
using ITBCP.ServiceSIGES.Domain.Entities.Users;

namespace TerminalSIGES.ViewModels
{
    public class MainViewModel
    {
        private Detalle _odlDetalle;
        public ObservableCollection<Detalle> Detalles { get; set; }
        public ObservableCollection<Detalle> Productos { get; set; }
        public ObservableCollection<TransPendiente> TransacPendientes { get; set; }
        public ObservableCollection<TipoTarjeta> TipoTarjetas { get; set; }
        public ObservableCollection<Factura> Facturas { get; set; }
        public ObservableCollection<TS_BEEmpresaUser> Empresas { get; set; }
        public ObservableCollection<SfSegmentItem> ImageTextCollection { get; set; }
        public ObservableCollection<SfSegmentItem> ImageTextCollectionDocuments { get; set; }
        public ObservableCollection<SfSegmentItem> ImageTextCollectionProducto { get; set; }
        public ObservableCollection<Cara> CaraCollection { get; set; }
        
        public int HeightList { get; set; }
        public MainViewModel()
        {
            CaraCollection = new ObservableCollection<Cara>
            {
                new Cara(){Id=1, Description="01"},
                new Cara(){Id=2, Description="02"},
                new Cara(){Id=3, Description="03"},
                new Cara(){Id=4, Description="04"}, 
            };
            ImageTextCollectionDocuments = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "files", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Anular"},
                new SfSegmentItem(){IconFont = "codepen",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Re-Imprimir"} ,
                    new SfSegmentItem(){IconFont = "undo",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Cancelar"}
            };
            ImageTextCollectionProducto = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "files", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Agregar"},
                new SfSegmentItem(){IconFont = "codepen",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Eliminar"},
                 new SfSegmentItem(){IconFont = "checkmark",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Aceptar"},
                       new SfSegmentItem(){IconFont = "undo",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Cancelar"}
            };
            ImageTextCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "pen", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Creditos"},
                new SfSegmentItem(){IconFont = "files",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Document"},
                 new SfSegmentItem(){IconFont = "save",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Pagos"},
                new SfSegmentItem(){IconFont = "print",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "ReImpresión"},
                new SfSegmentItem(){IconFont = "cogs",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Tranf Grat" },
                new SfSegmentItem(){IconFont = "database",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Serafin"},
                new SfSegmentItem(){IconFont = "file-empty",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text = "Otro", IsEnabled = false},
            };
          
            Productos = new ObservableCollection<Detalle>
            { new Detalle()
                {

                Item = 1,
                Codigo = "05",
              Tipo="PROMOCIÒN",
                  Hora="15:01",
                Descripcion = "GASEOSA COCA K",
                Precio = 1.30,
                Cantidad = 15.00,
                Total = 20.00,
                IsVisble = false
            },
                new Detalle()
                {
                    Item = 2,
                    Codigo = "",
                     Tipo="PROMOCIÒN",
                     Hora="15:01",
                    Descripcion = "AGUA MINERAL",
                    Precio = 5,
                    Cantidad = 5,
                    Total = 25.00,
                    IsVisble = false
                },
                new Detalle()
                {
                    Item = 3,
                    Codigo = "",
                     Tipo="PROMOCIÒN",
                     Hora="15:01",
                    Descripcion = "GALLETA CRACK",
                    Precio = 5,
                    Cantidad = 1,
                    Total = 12.00,
                    IsVisble = false
                },
                new Detalle()
                {
                    Item = 4,
                    Codigo = "",
                     Tipo="PROMOCIÒN",
                     Hora="15:01",
                    Descripcion = "DONOFRIO CRACK",
                    Precio = 5,
                    Cantidad = 3.5,
                    Total = 7.00,
                    IsVisble = false
                }
            };
            TransacPendientes = new ObservableCollection<TransPendiente>
            {
                new TransPendiente()
                {
                    TransactionId = 1,
                    Cara ="01",
                    Codigo ="01",
                    Fecha ="21-01-2019",
                    Hora ="12:45 am",
                    Descripcion ="DIESEL DB5",
                    Precio ="1.300",
                    Galones = "15.3850",
                    Total ="20.00"
                },new TransPendiente()
                {
                    TransactionId = 2,
                    Cara ="01",
                    Codigo ="01",
                    Fecha ="21-01-2019",
                    Hora ="12:45 am",
                    Descripcion ="DIESEL DB5",
                    Precio ="1.300",
                    Galones = "20.3850",
                    Total ="40.00"
                }

            };
            TipoTarjetas = new ObservableCollection<TipoTarjeta>
            {
                new TipoTarjeta()
                {
                  Codigo  = "1",
                  Descripcion = "AMERICAN EXPRESS"
                },
                new TipoTarjeta()
                {
                    Codigo  = "2",
                    Descripcion = "DINNERS"
                },
                new TipoTarjeta()
                {
                    Codigo  = "3",
                    Descripcion = "MASTERCARD"
                },
                new TipoTarjeta()
                {
                    Codigo  = "4",
                    Descripcion = "VISA"
                },
            };
            Facturas = new ObservableCollection<Factura>
            {
                new Factura()
                {
                    Cara = "01",
                    Ruc = "205345125421",
                    RazonSocial = "PERU CAMPEON SAC",
                    Direccion = "TACNA",
                    Placa = "ZA5234"
                },
                new Factura()
                {
                    Cara = "02",
                    Ruc = "12345678904",
                    RazonSocial = "GLOBAL TITAN SAC",
                    Direccion = "TACNA",
                    Placa = "Z1A1E5"
                }
            };
            Empresas = new ObservableCollection<TS_BEEmpresaUser>();
            //{
            //    new Empresa()
            //    {
            //        RUC = "123456789",
            //        RazonSocial = "ITBCP Consultores SAC"
            //    },
            //    new Empresa()
            //    {
            //        RUC = "25346645",
            //        RazonSocial = "LOS CAMPEONES EN SOFT SAC"
            //    }
            //};
           // HeightList = (Detalles.Count * 40);
        }

        public void HideOrShowProducto(Detalle detalle)
        {
            if (_odlDetalle == detalle)
            {
                detalle.IsVisble = !detalle.IsVisble;
                UpdateDetalle(detalle);
            }
            else
            {
                if (_odlDetalle != null)
                {
                    _odlDetalle.IsVisble = false;
                    UpdateDetalle(_odlDetalle);
                }
                detalle.IsVisble = true;
                UpdateDetalle(detalle);
            }
            _odlDetalle = detalle;
            if (detalle.IsVisble)
            {
                HeightList += 15;
            }
            else
            {
                HeightList -= 15;
            }
        }

        private void UpdateDetalle(Detalle detalle)
        {
            var index = Detalles.IndexOf(detalle);
            Detalles.Remove(detalle);
            Detalles.Insert(index, detalle);
        }
    }
}
