using Event_Registration_System.Models;
using Event_Registration_System.Models.DTO;
using Event_Registration_System.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Event_Registration_System.Services
{
    public class IdentityUserService : IUser
    {

        private UserManager<UserAuth> _userManager;
        private SignInManager<UserAuth> _signInManager;

        public IdentityUserService(UserManager<UserAuth> userManager, SignInManager<UserAuth> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public Task<UserDto> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Register(RegisterUserDto userData, ModelStateDictionary modelState)
        {
            var user = new UserAuth()
            {
                UserName = userData.Username,
                Email = userData.Email,

            };

            var result = await _userManager.CreateAsync(user, userData.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Name = user.UserName
                };
            }


            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(userData.Password) :
                                error.Code.Contains("Email") ? nameof(userData.Password) :
                                 error.Code.Contains("Username") ? nameof(userData.Password) : "";


                modelState.AddModelError(errorCode, error.Description);
            }

            return null;

        }

        public Task<UserDto> userProfile(string username)
        {
            throw new NotImplementedException();
        }
    }
}
