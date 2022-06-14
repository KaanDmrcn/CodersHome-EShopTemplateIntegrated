using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Models.Product;
using eShopOnContainers.Core.Services.FixUri;
using eShopOnContainers.Core.Services.RequestProvider;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace eShopOnContainers.Core.Services.Cart
{
    public class CartService:ICartService
    {
        private string CartKey = "UserCart";
        public ObservableCollection<CartItem> GetCarts()
        {
            var cartD = Preferences.Get(CartKey, "");
            if (cartD == "") return new ObservableCollection<CartItem>();
            Console.WriteLine("test");
            return JsonConvert.DeserializeObject<ObservableCollection<CartItem>>(cartD);
        }
        public void PostCarts(ObservableCollection<CartItem> carts)
        {

            Preferences.Set(CartKey, JsonConvert.SerializeObject(carts));
        }
        public void AddToCart(Product product)
        {
            var carts = GetCarts();
            if (carts.Any(x => x.ProductID == product.Id)) return;
            carts.Add(new CartItem() { CartItemID = carts[carts.Count - 1].CartItemID + 1, Price = product.Cost, ProductID = product.Id, ProductName = product.Name });
            PostCarts(carts);
        }
        public void RemoveFromCart(int CartID)
        {
            var carts = GetCarts();
            carts.Remove(carts.First(x => x.CartItemID == CartID));
            PostCarts(carts);
        }
        public void ClearAll()
        {
            PostCarts(new ObservableCollection<CartItem>());
        }
    }
}
