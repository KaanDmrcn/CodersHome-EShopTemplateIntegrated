using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.Cart
{
    public interface ICartService
    {
        ObservableCollection<CartItem> GetCartItems();
        void SaveCarts(ObservableCollection<CartItem> carts);

        void AddToCart(Product product);
        void RemoveFromCart(int CartID);
        void ClearAll();
    }
}
