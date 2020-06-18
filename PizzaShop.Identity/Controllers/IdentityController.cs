using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Identity.Models;
using PizzaShop.Identity.Services.Identity;
using PizzaShop.Services.Identity;

namespace PizzaShop.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;

        public IdentityController(IIdentityService identity, ICurrentUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return await Login(input);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<UserOutputModel>> Login(UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserOutputModel(result.Data.Token);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordInputModel input)
        {
             var result =  await this.identity.ChangePassword(this.currentUser.UserId, new ChangePasswordInputModel
                {
                    CurrentPassword = input.CurrentPassword,
                    NewPassword = input.NewPassword
                });

            return result;
        }
    }
}
