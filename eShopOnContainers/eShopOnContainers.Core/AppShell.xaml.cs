using System;
using System.Collections.Generic;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Core.ViewModels.Base;
using eShopOnContainers.Core.Views;
using Xamarin.Forms;

namespace eShopOnContainers.Core
{
    public partial class AppShell : Shell
    {
        public AppShell ()
        {
            InitializeRouting ();
            InitializeComponent ();

            var settingsService = ViewModelLocator.Resolve<ISettingsService> ();
        }

        private void InitializeRouting()
        {
            Routing.RegisterRoute("ProductDetail", typeof(PageProductDetail));
            Routing.RegisterRoute("Products", typeof(PageTumUrunler));
            Routing.RegisterRoute("Categories", typeof(PageCategory));
            Routing.RegisterRoute("Register", typeof(PageKayit));
            Routing.RegisterRoute("Home", typeof(PageMain));
            Routing.RegisterRoute("Cart", typeof(PageSepet));
        }


    }
}
