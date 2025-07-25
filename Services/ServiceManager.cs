using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        public ServiceManager(IUserService userService)
        {
            _userService = new Lazy<IUserService>(() => userService ?? throw new ArgumentNullException(nameof(userService)));
        }
        public IUserService UserService => _userService.Value;

    }
}
