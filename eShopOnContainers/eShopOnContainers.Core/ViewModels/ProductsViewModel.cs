using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.Products;
using eShopOnContainers.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class ProductsViewModel: ViewModelBase
    {
        private ObservableCollection<Product> AllProducts = new ObservableCollection<Product>();

        private IProductsService _productsService;
        public ProductsViewModel()
        {
            _productsService = DependencyService.Get<IProductsService>();
            this.MultipleInitialization = true;
        }

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

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            if (query != null)
            {
                if (query.ContainsKey("CategoryID"))
                    CategoryID = query.GetValueAsInt("CategoryID").Value;

                if (query.ContainsKey("SearchQuery"))
                    SearchQuery = query["SearchQuery"];
            }
            AllProducts = await _productsService.GetProductsAsync(-1, "");
            Filter();
        }

        public ICommand NavigateLogin => new Command<string>(async (string query) =>
        {
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateCart => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Cart");
        });

        public ICommand Search => new Command<string>((string query) =>
        {

            SearchQuery = query;
            IsBusy = true;
            Filter();
            IsBusy = false;
        });

        public string SearchQuery { get; private set; } = "";
        public int CategoryID { get; private set; } = -1;

        void Filter()
        {
            Products = AllProducts.Where(x => (CategoryID < 0 || CategoryID == x.CategoryID) && x.Name.ToLower().Contains(SearchQuery.ToLower())).ToObservableCollection();
        }


        public ICommand NavigateProductDetail => new Command<Product>(async (item) =>
        {
            await NavigationService.NavigateToAsync("ProductDetail", new Dictionary<string, string> { { "Product", item.Id.ToString() } });
        });
    }
}
