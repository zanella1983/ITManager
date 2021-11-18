using ITManager.Domain.Repositories;

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
    }
}
