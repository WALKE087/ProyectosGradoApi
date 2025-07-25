using System;

namespace Domain.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email)
            : base($"No se encontró un usuario con el correo '{email}'.")
        {
        }
    }
}
