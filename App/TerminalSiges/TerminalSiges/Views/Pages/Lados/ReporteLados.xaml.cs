using ITBCP.ServiceSIGES.Domain.Entities;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Lib;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Lados
{
 
    public partial class ReporteLados : ContentPage
    {

        private int itemIndex = -1;
        private BindingContextLados contexto;
        

        public ReporteLados()
        {
            contexto = new BindingContextLados();
            InitializeComponent();
            BindingContext = contexto;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (contexto.IsCargado) { return; }
            contexto.IsCargado = true;
            ObtenerLadosInicio();
        }
        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = e.ItemIndex;
        }

        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = e.ItemIndex;
        }

        private void Delete(Lado item)
        {
            if (contexto.IsDeleting) { return; }
            contexto.IsDeleting = true;
            EliminarLadoInicio(item.lado);
        }

        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            
            Image rightImage = sender as Image;
            Grid grid1 = (Grid)rightImage.Parent;
            Grid grid2 = (Grid)grid1.Parent;
            Grid grid3 = (Grid)grid2.Parent;
            SwipeView swipeView = (SwipeView)grid3.Parent;
            VisualContainer visualContainer = (VisualContainer)swipeView.Parent;
            ExtendedScrollView extendedScrollView = (ExtendedScrollView)visualContainer.Parent;
            SfListView sfListView = (SfListView)extendedScrollView.Parent;
            Collection<Lado> Source = (Collection<Lado>)sfListView.ItemsSource;
            Lado item = Source[itemIndex];

            DeleteEvent evento = new DeleteEvent(item);
            evento.executeEvent += Evento_executeEvent;
            (rightImage.Parent as View).GestureRecognizers.Clear();
            (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = evento });
            rightImage.Source = "Delete.png";
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void Evento_executeEvent(Lado input)
        {
            Delete(input);
        }

        private void ListView_QueryItemSize(object sender, Syncfusion.ListView.XForms.QueryItemSizeEventArgs e)
        {
            SfListView view = (SfListView)sender;
            Collection <ItemModel> Source = (Collection<ItemModel>)view.ItemsSource;
            int height =  (Source == null ? 1 : (Source.Count < e.ItemIndex ? 1 : Source[e.ItemIndex].Items.Count));
            e.ItemSize = 110 +  ( 45 * height);
            e.Handled = true;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public async void ObtenerLadosInicio()
        {

            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(()=>
            {
                TSSalesApp.ObtenerLados += _ObtenerLados;
                resultado = TSSalesApp._ObtenerLados().Result;
            });
            if (resultado != SalesEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case SalesEstado.ErrorInternet:
                        contexto.IsDeleting = false;
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case SalesEstado.ErrorSistema:
                        contexto.IsDeleting = false;
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }

        private void _ObtenerLados(TSSales respuesta)
        {
            TSSalesApp.ObtenerLados -= _ObtenerLados;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    contexto.Elementos.Clear();

                    foreach (TS_BELado lado in respuesta.vLados.cLados)
                    {
                        bool inserted = false;
                        foreach (ItemModel model in contexto.Elementos)
                        {
                            if (model.nropos.Equals(lado.nropos))
                            {
                                inserted = true;
                            }
                        }
                        if (inserted == false)
                        {
                            contexto.Elementos.Add(new ItemModel(lado.nropos));
                        }

                    }
                    foreach (TS_BELado lado in respuesta.vLados.cLados)
                    {
                        
                        foreach (ItemModel model in contexto.Elementos)
                        {
                            if (model.nropos.Equals(lado.nropos))
                            {
                                model.Items.Add(new Lado(lado.lado));
                            }
                        }

                    }
                }
                if (respuesta.EstadoRespuesta != SalesEstado.InformacionObtenida)
                {
                    await DisplayAlert("Aviso", "Hubo un error al obtener la información, por favor intente mas tarde", "Aceptar");
                }
                contexto.IsSearch = false;
            });
        }

        public async void EliminarLadoInicio(string lado)
        {
            contexto.IsSearch = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(()=>
            {
                TSSalesApp.EliminarLado += _EliminarLado;
                resultado = TSSalesApp._EliminarLado(lado).Result;
            });
            if (resultado != SalesEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case SalesEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case SalesEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }

        private void _EliminarLado(TSSales respuesta)
        {
            TSSalesApp.EliminarLado -= _EliminarLado;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    App.Current.MainPage = new NavigationPage(new ReporteLados());
                }
                if (respuesta.EstadoRespuesta != SalesEstado.InformacionObtenida)
                {
                    await DisplayAlert("Aviso", "Hubo un error al procesar la transacción, por favor intente mas tarde", "Aceptar");
                }
                contexto.IsSearch = false;
                contexto.IsDeleting = false;
            });
        }


    }
    public class BindingContextLados : INotifyPropertyChanged
    {
        public ObservableCollection<ItemModel> Elementos { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private bool cIsSearch;
        private bool cIsLoading;
        private bool cIsCargado;
        private bool cIsDeleting;
        public BindingContextLados()
        {
            this.Elementos = new ObservableCollection<ItemModel>();
            this.IsSearch = true;
            this.cIsLoading = false;
            this.cIsCargado = false;
            this.cIsDeleting = false;
        }

        public bool IsSearch
        {
            get { return cIsSearch; }
            set
            {
                cIsSearch = value;
                OnPropertyChanged();
                IsLoading = !value;
                
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
        public bool IsCargado
        {
            get { return cIsCargado; }
            set
            {
                cIsCargado = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeleting
        {
            get { return cIsDeleting; }
            set
            {
                cIsDeleting = value;
                OnPropertyChanged();
            }
        }
        

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class ItemModel
    {
        public string nropos { get; set; }
        public ObservableCollection<Lado> Items { get; set; }
        public ItemModel(string nropos)
        {
            this.nropos = nropos;
            this.Items = new ObservableCollection<Lado>();
        }
    }
    public class Lado
    {
        public Lado(string lado)
        {
            this.lado = lado;
        }
        public string lado { get; set; }
    }
}