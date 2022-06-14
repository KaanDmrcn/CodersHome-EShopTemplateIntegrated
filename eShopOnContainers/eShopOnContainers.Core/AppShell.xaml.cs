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
            Routing.RegisterRoute("Cart", typeof(CartPage)); 
            Routing.RegisterRoute("Products", typeof(ProductsPage));
            Routing.RegisterRoute("ProductDetail", typeof(ProductDetailPage));
        }


    }
}
