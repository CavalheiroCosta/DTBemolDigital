
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Responses;
using Customer.Domain.ValueObjects;

namespace Customer.Domain.Services
{
    public class DeliveryAddressService : IDeliveryAddressService
    {
        private readonly IDeliveryAddressRepository _deliveryAddressRepository;

        public DeliveryAddressService(IDeliveryAddressRepository deliveryAddressRepository)
        {
            _deliveryAddressRepository = deliveryAddressRepository;
        }

        public async Task<AddressDetailResponse> GetAddressDetailFromCepAsync(string cep)
        {
            var deliveryAddress = await _deliveryAddressRepository.GetDeliveryAddressFromCepAsync(new Cep(cep));
            return deliveryAddress.GetAddressDetail();
        }
    }
}
