using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WS.Services;
using WS.Models;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMarcar : ContentPage
    {

        public PageMarcar()
        {
            InitializeComponent();
        }

        private void btnGravar_Clicked(object sender, EventArgs e)
        {
            string dbPath = "";
            Pressao pressao = new Pressao();
            pressao.Sistole = Convert.ToInt32(txtSistole.Text);
            pressao.Diastole = Convert.ToInt32(txtDiastole.Text);
            pressao.Data = DateTime.Now.ToString("dd/MM/yyyy");
            pressao.Hora = DateTime.Now.ToString("HH:mm");           
            ServiceDBCardio db = new ServiceDBCardio(dbPath);
            db.Inserir(pressao);
            Navigation.PushAsync(new PagePrincipal());
        }
    }
}