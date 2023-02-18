using Customer.Domain.Aggregates;
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.ValueObjects;

namespace Customer.Infra.Repositories
{
    public class DeliveryAddressRepository : IDeliveryAddressRepository
    {
        public Task<DeliveryAddress> GetDeliveryAddressFromCepAsync(Cep cep)
        {
            throw new NotImplementedException();
        }
    }
}
