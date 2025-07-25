using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
