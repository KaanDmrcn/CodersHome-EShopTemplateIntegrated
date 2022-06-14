using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.Products;
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
    public class MainPageViewModel:ViewModelBase
    {


        private ObservableCollection<Product> products = new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        private IProductsService _productsService;
        public MainPageViewModel()
        {
            _productsService = DependencyService.Get<IProductsService>();

        }
        public async override Task InitializeAsync(IDictionary<string, string> query)
        {
            Products = await _productsService.GetProductsAsync(-1,"");
        }


        public ICommand NavigateLogin => new Command<string>(async (string query) =>
        {
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateCart => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Cart");
        });
        public ICommand NavigateProducts => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Products");
        });

        public ICommand NavigateProductDetail => new Command<Product>(async (item) =>
        {
            await NavigationService.NavigateToAsync("ProductDetail", new Dictionary<string, string> { { "ProductID", item.Id.ToString() } });
        });

    }
}
