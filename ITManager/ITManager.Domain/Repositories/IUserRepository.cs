using ITManager.Domain.Entities;

namespace ITManager.Domain.Repositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
        User GetByEmailAndPassword(string email, string password);
    }
}
