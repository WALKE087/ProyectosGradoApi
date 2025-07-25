using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryDbContext _context;
        private IUserRepository? _userRepository;

        public RepositoryManager(RepositoryDbContext context)
        {
            _context = context;
        }

        public IUserRepository User => _userRepository ??= new UserRepository(_context);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _context.SaveChangesAsync(cancellationToken);
    }
}
