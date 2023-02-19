using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Repository;
using Customer.Infra.HttpClients.ViaCep;

namespace Customer.Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IViaCepClient _viaCepClient;

        public AddressRepository(IViaCepClient viaCepClient)
        {
            _viaCepClient = viaCepClient;
        }

        public async Task<Address> GetAddressAsync(Cep cep)
        {
            var gettedAddress = await _viaCepClient.GetAddressAsync(cep.Value);

            return gettedAddress.Erro ?
                throw new ExternalAddressNotFoundException(cep.Value) :
                new Address(cep, gettedAddress.Logradouro, gettedAddress.Bairro, gettedAddress.Localidade, gettedAddress.Uf);
        }
    }
}
