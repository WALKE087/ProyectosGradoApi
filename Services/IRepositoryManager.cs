using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Service.Abstractions;
using Shared.LoginDto;

namespace Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;

        public UserService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _repository.User.GetByEmailAsync(email)
                       ?? throw new UserNotFoundException("Usuario no encontrado.");

            if (user.Password != password) 
                throw new InvalidCredentialsException("Credenciales inválidas.");

            return user;
        }
    }
}
