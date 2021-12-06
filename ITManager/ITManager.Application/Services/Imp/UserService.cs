using ITManager.Application.Dtos;
using ITManager.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ITManager.Application.Services.Imp
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Authenticate(string email, string password)
        {
            var user = userRepository.GetByEmailAndPassword(email, password);

            return user != null;
        }

        public List<UserDto> List()
        {
            var users = userRepository.GetAll().ToList();
            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                var dto = new UserDto
                {
                    Active = user.Active,
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Password = user.Password
                };
                usersDto.Add(dto);
            }
            return usersDto;
        }
    }
}
