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
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
            string dbPath = "";
            ServiceDBCardio dBCardio = new ServiceDBCardio(dbPath);

            lblSistole.Text = dBCardio.MediaSis().ToString("F");
            lblDiastole.Text = dBCardio.MediaDias().ToString("F");
        }

        private void btnMarcar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new PageMarcar());
        }

        private void btnHistorico_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageHistorico());
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch
            {
            }
        }
    }
}