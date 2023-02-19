using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Requests;
using Customer.Domain.Responses;

namespace Customer.Domain.Interfaces.Services
{
    public interface IDeliveryAddressService
    {
        Task<DeliveryAddress> GetAddressAsync(Cep cep);
        Task<DeliveryAddress> GetAddressAsync(string cep);
    }
}
