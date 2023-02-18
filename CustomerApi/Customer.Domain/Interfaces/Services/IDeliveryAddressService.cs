using Customer.Domain.Responses;

namespace Customer.Domain.Interfaces.Services
{
    public interface IDeliveryAddressService
    {
        Task<AddressDetailResponse> GetAddressDetailFromCepAsync(string cep);
    }
}
