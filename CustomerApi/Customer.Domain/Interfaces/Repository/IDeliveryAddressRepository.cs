using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;

namespace Customer.Domain.Interfaces.Repository
{
    public interface IDeliveryAddressRepository
    {
        Task<DeliveryAddress> GetAddressAsync(Cep cep);
    }
}
