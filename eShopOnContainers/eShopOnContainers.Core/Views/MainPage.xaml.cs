using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopOnContainers.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPageBase
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //var loginPage = new LoginPage();
            //Application.Current.MainPage.Navigation.PushAsync(loginPage);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var productsPage = new ProductsPage();
            //Application.Current.MainPage.Navigation.PushAsync(productsPage);
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            //var boxPage = new BoxPage();
            //Application.Current.MainPage.Navigation.PushAsync(boxPage);
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            //var testPage = new TestPage();
            //Application.Current.MainPage.Navigation.PushAsync(testPage);
        }
    }
}