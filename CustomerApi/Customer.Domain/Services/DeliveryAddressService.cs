
using Customer.Domain.DomainObjects;
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Responses;

namespace Customer.Domain.Services
{
    public class DeliveryAddressService : IDeliveryAddressService
    {
        private readonly IDeliveryAddressRepository _deliveryAddressRepository;

        public DeliveryAddressService(IDeliveryAddressRepository deliveryAddressRepository)
        {
            _deliveryAddressRepository = deliveryAddressRepository;
        }

        public async Task<AddressDetailResponse> GetAddressAsync(Cep cep)
        {
            var deliveryAddress = await _deliveryAddressRepository.GetAddressAsync(cep);
            return deliveryAddress.GetAddressDetail();
        }

        public Task<AddressDetailResponse> GetAddressAsync(string cep)
        {
            return GetAddressAsync(new Cep(cep));
        }
    }
}
