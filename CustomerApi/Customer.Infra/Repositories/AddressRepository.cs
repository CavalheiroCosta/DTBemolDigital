using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.Util;
using Customer.Infra.HttpClients.ViaCep;

namespace Customer.Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IViaCepClient _viaCepClient;
        private readonly ICacheUtil _cache;

        public AddressRepository(IViaCepClient viaCepClient, ICacheUtil cache)
        {
            _viaCepClient = viaCepClient;
            _cache = cache;
        }

        public async Task<Address> GetAddressAsync(Cep cep)
        {
            var address = _cache.GetValue<ViaCepResponse>(cep.Value);
            if (address == null)
            {
                address = await _viaCepClient.GetAddressAsync(cep.Value);
                if (address.Erro)
                    throw new ExternalAddressNotFoundException(cep.Value);

                _cache.SetValue(cep.Value, address);
            }

            return new Address(cep, address.Logradouro, address.Bairro, address.Localidade, address.Uf);
        }
    }
}
