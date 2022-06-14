using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.Cart;
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

        public ObservableCollection<CartItem> _cart { get; set; } = new ObservableCollection<CartItem>();
        public ObservableCollection<CartItem> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                RaisePropertyChanged(() => Cart);
            }
        }

        private ICartService _service;
        public CartViewModel()
        {
            _service = DependencyService.Get<ICartService>();
            MultipleInitialization = true;
        }

        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            Cart =  _service.GetCartItems();
            
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
        public ICommand ClearCart => new Command(() =>
        {
            _service.ClearAll();
        });
        public ICommand RemoveFromCart => new Command<int>((id) =>
        {
            _service.RemoveFromCart(id);
            Cart = _service.GetCartItems();
        });
    }
}
