namespace ITManager.Application.Services
{
    public interface IUserService
    {
        bool Authenticate(string email, string password);
    }
}