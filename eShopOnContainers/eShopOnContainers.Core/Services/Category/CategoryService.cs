using eShopOnContainers.Core.Extensions;
using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.PageCategory;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.PageCategory
{
    class CategoryService:ICategoryService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "categories";
        public CategoryService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<Category>> GetCategoriesAsync()
        {
            // ürünler linki eshopta bulunan uri helper ile oluştu
            string uri = UriHelper.CombineUri(GlobalSetting.Instance.DefaultEndpointAPI, ApiUrlBase);
            // eshopta bulunan getasync fonksiyonu ile http get isteği atabildik
            IEnumerable<Category> items = await _requestProvider.GetAsync<IEnumerable<Category>>(uri);
            return items?.ToObservableCollection();
        }

        
    }
}
