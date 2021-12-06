using ITManager.Application.Dtos;
using System.Collections.Generic;

namespace ITManager.Application.Services
{
    public interface IUserService
    {
        bool Authenticate(string email, string password);

        List<UserDto> List();
    }
}