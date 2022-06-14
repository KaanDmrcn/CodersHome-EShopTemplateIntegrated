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

        private IProductsService _productsService;
        public ProductsViewModel()
        {
            // Eshop içerisinde bulunan Dependency servis yardımıyla diğer ViewModelLocator'a tanımlı servisler çekilebiliyor örneğin ProductService
            _productsService = DependencyService.Get<IProductsService>();
            this.MultipleInitialization = true;
        }
        //Filteleme için tüm sınıflar tutulması gerekliydi yoksa sürekli api servere istek atacaktık.
        private ObservableCollection<Product> AllProducts = new ObservableCollection<Product>();

        //Filtelenmiş Product Listesini tutuyoruz burada
        private ObservableCollection<Product> filteredProducts = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get => filteredProducts;
            set
            {
                filteredProducts = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            if (query != null)
            {
                // Sayfaya gönderilen CategoryID adındaki parametreyi böyle çektik, Kategoriler sayfasından gönderildi bu parametre
                if (query.ContainsKey("CategoryID"))
                    CategoryID = query.GetValueAsInt("CategoryID").Value;
            }
            AllProducts = await _productsService.GetProductsAsync();
            Filter();
        }

        public ICommand NavigateLogin => new Command<string>(async (string query) =>
        {
            //Navigation Servisi Eshop a ait bir servise sayfalara yönlendirebilmemizi sağlar.
            await NavigationService.NavigateToAsync("Login");
        });

        public ICommand NavigateCart => new Command(async () =>
        {
            await NavigationService.NavigateToAsync("Cart");
        });

        // Arama çubuğu değişince çalışır
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
            // CategoryID 0 dan küçükse belirtilmemiştir. İstenilen  ID ye göre filteler
            Products = AllProducts.Where(x => CategoryID < 0 || CategoryID == x.CategoryID).ToObservableCollection();
            // İsiminde Search Query bulunan ürünler filtelenir.
            Products = Products.Where(x => x.Name.ToLower().Contains(SearchQuery.ToLower())).ToObservableCollection();
        }


        public ICommand NavigateProductDetail => new Command<Product>(async (item) =>
        {
            // ProductID PRoduct Detay Sayfasına böyle gönderiliyor.
            await NavigationService.NavigateToAsync("ProductDetail", new Dictionary<string, string> { { "ProductID", item.Id.ToString() } });
        });
    }
}
