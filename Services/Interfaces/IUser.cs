using Event_Registration_System.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Event_Registration_System.Services.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDto userData, ModelStateDictionary modelState);

        public Task<UserDto> Login(string username, string password);

        public Task<UserDto> userProfile(string username);
    }
}
