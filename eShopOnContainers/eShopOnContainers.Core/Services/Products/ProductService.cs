using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.RequestProvider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopOnContainers.Core.Services.Products
{
    public class ProductService : IProductsService
    {


        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

        private const string ApiUrlBase = "products";
        public ProductService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<Product>> GetProductsAsync(int CategoryID, string searchQuery)
        {

            var uri = UriHelper.CombineUri(GlobalSetting.Instance.DefaultEndpointAPI, ApiUrlBase);
            IEnumerable<Product> items = await _requestProvider.GetAsync<IEnumerable<Product>>(uri);
            items = items.Where(x => x.Name.ToLower().Contains(searchQuery.ToLower()));
            if (CategoryID > 0)
                items = items.Where(product => product.CategoryID == CategoryID);
            if (items != null)
                return items?.ToObservableCollection();
            else
                return new ObservableCollection<Product>();
        }


        public async Task<Product> GetProductWithIDAsync(int ID)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.DefaultEndpointAPI, $"{ApiUrlBase}/{ID}");
            Product items = await _requestProvider.GetAsync<Product>(uri);
            return items;
        }
    }
}