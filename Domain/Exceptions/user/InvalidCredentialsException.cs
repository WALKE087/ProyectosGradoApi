using System;

namespace Domain.Exceptions
{
    public sealed class InvalidCredentialsException : BadRequestException
    {
        public InvalidCredentialsException(string v)
            : base("Credenciales inválidas.")
        {
        }
    }
}
