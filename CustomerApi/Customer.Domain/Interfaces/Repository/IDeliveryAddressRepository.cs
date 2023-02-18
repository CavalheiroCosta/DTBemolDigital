using Customer.Domain.Aggregates;
using Customer.Domain.ValueObjects;

namespace Customer.Domain.Interfaces.Repository
{
    public interface IDeliveryAddressRepository
    {
        Task<DeliveryAddress> GetDeliveryAddressFromCepAsync(Cep cep);
    }
}
