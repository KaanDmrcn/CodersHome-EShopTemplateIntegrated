
using eShopOnContainers.Core.Services.Cart;
using eShopOnContainers.Core.Services.Dependency;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.Identity;
using eShopOnContainers.Core.Services.Location;
using eShopOnContainers.Core.Services.OpenUrl;
using eShopOnContainers.Core.Services.PageCategory;
using eShopOnContainers.Core.Services.Products;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Services.Settings;
using eShopOnContainers.Services;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator() // Burada servisler Xamarin forms içerisine kayıt edilir Daha sonra DependencyService ile çağrılabilir.
        {
            // Services - by default, TinyIoC will register interface registrations as singletons.
            var settingsService = new SettingsService ();
            var requestProvider = new RequestProvider ();
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(settingsService);
            Xamarin.Forms.DependencyService.RegisterSingleton<INavigationService>(new NavigationService(settingsService));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDialogService>(new DialogService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IOpenUrlService>(new OpenUrlService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IRequestProvider>(requestProvider);
            Xamarin.Forms.DependencyService.RegisterSingleton<IIdentityService>(new IdentityService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDependencyService>(new Services.Dependency.DependencyService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IFixUriService>(new FixUriService(settingsService));
            Xamarin.Forms.DependencyService.RegisterSingleton<ILocationService>(new LocationService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<ICartService>(new CartService());

            Xamarin.Forms.DependencyService.RegisterSingleton<IProductsService>(new ProductMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<ICategoryService>(new CategoryMockService());


            // View models - by default, TinyIoC will register concrete classes as multi-instance.

            Xamarin.Forms.DependencyService.Register<ProductsViewModel>();
            Xamarin.Forms.DependencyService.Register<ProductDetailViewModel>();
            Xamarin.Forms.DependencyService.Register<CategoriesViewModel>();
            Xamarin.Forms.DependencyService.Register<CartViewModel>();
            Xamarin.Forms.DependencyService.Register<MainPageViewModel>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {

                Xamarin.Forms.DependencyService.RegisterSingleton<IProductsService>(new ProductMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<ICategoryService>(new CategoryMockService());

                UseMockService = true;
            }
            else
            {
                var requestProvider = Xamarin.Forms.DependencyService.Get<IRequestProvider> ();
                var fixUriService = Xamarin.Forms.DependencyService.Get<IFixUriService> ();

                Xamarin.Forms.DependencyService.RegisterSingleton<IProductsService>(new ProductService(requestProvider));
                Xamarin.Forms.DependencyService.RegisterSingleton<ICategoryService>(new CategoryService(requestProvider));
                Xamarin.Forms.DependencyService.RegisterSingleton<ICartService>(new CartService());

                UseMockService = false;
            }
        }

        public static T Resolve<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = Activator.CreateInstance (viewModelType);

            view.BindingContext = viewModel;
        }
    }
}