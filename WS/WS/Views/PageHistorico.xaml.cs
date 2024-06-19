using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHistorico : ContentPage
    {
        public PageHistorico()
        {
            string dbPath = "";
            ServiceDBCardio dBCardio = new ServiceDBCardio(dbPath);
            InitializeComponent();
            lsvHistorico.ItemsSource = dBCardio.Listar();

        }

        
    }
}