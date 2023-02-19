using Customer.Domain.DomainObjects;
using Customer.Domain.Responses;

namespace Customer.Domain.Interfaces.Services
{
    public interface IDeliveryAddressService
    {
        Task<AddressDetailResponse> GetAddressAsync(Cep cep);
        Task<AddressDetailResponse> GetAddressAsync(string cep);
    }
}
