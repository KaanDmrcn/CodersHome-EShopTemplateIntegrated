using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.Cart;
using eShopOnContainers.Core.Services.Products;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class ProductDetailViewModel: ViewModelBase
    {

        private Product _product = new Product();
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                RaisePropertyChanged(() => Product);
            }
        }
        private IProductsService _productsService;
        private ICartService _cartService;
        public ProductDetailViewModel()
        {
            _cartService = DependencyService.Get<ICartService>();
            _productsService = DependencyService.Get<IProductsService>();
        }

        public async override Task InitializeAsync(IDictionary<string, string> query)
        {
            int id = query.GetValueAsInt("Product").Value;
            Product = await _productsService.GetProductWithIDAsync(id);
        }
        public ICommand NavigateLogin => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateCart => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Cart");
        });

        public ICommand AddToCartCommand => new Command(async (item) => await AddToCart());
        private async Task AddToCart()
        {
            _cartService.AddToCart(Product);
        }
    }
}
