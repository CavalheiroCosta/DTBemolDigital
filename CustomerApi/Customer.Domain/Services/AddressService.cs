
using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.Interfaces.Services;

namespace Customer.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _deliveryAddressRepository;

        public AddressService(IAddressRepository deliveryAddressRepository)
        {
            _deliveryAddressRepository = deliveryAddressRepository;
        }

        public async Task<Address> GetAddressAsync(Cep cep)
        {
            return await _deliveryAddressRepository.GetAddressAsync(cep);
        }

        public Task<Address> GetAddressAsync(string cep)
        {
            return GetAddressAsync(new Cep(cep));
        }
    }
}
