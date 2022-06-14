using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class CartViewModel:ViewModelBase
    {

        public ObservableCollection<CartItem> Cart { get; set; } = new ObservableCollection<CartItem>()
        {
            new CartItem() {CartItemID = 1, ProductID = 1, Price= 42.95, ProductName = "Android Studio Temalı Kupa"}
        };
        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            return base.InitializeAsync(query);
        }

        public ICommand NavigateLogin => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateProductDetail => new Command<Product>(async (item) =>
        {
            await NavigationService.NavigateToAsync("ProductDetail", new Dictionary<string, string> { { "Product", item.Id.ToString() } });
        });
        public ICommand ClearCart => new Command(async () =>
        {
            //await NavigationService.NavigateToAsync("ProductDetail", new Dictionary<string, string> { { "Product", item.Id.ToString() } });
        });
    }
}
