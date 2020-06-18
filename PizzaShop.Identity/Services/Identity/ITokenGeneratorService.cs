using PizzaShop.Identity.Data.Models;

namespace PizzaShop.Identity.Services.Identity
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
