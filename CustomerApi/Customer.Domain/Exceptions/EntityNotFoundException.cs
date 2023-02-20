using Customer.Domain.Constants;

namespace Customer.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entity) : base(ExpectedErrorMessages.EntityNotFound(entity))
        {
        }
    }
}
