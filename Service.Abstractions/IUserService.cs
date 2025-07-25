using Domain.Entities;

namespace Service.Abstractions
{
    public interface IUserService
    {
        Task<User> LoginAsync(string email, string password);
    }
}
