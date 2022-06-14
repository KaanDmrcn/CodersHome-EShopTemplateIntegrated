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
        private readonly IFixUriService _fixUriService;

        private const string ApiUrlBase = "categories";
        public CategoryService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<Category>> GetCategoriesAsync()
        {
            string uri = UriHelper.CombineUri(GlobalSetting.Instance.DefaultEndpointAPI, ApiUrlBase);
            IEnumerable<Category> items = await _requestProvider.GetAsync<IEnumerable<Category>>(uri);
            return items?.ToObservableCollection();
        }

        
    }
}
