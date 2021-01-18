using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.Interfaces.Services
{
    public interface ICartService
    {
        void AddToCart(int id);
        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void Clear();
        CartViewModel TransformFromCart();

    }
}
