using PizzaShop.Identity.Data.Models;
using PizzaShop.Identity.Models;
using PizzaShop.Services;
using System.Threading.Tasks;

namespace PizzaShop.Identity.Services.Identity
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
