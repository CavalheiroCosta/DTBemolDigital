using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Repository;
using Customer.Infra.HttpClients.ViaCep;

namespace Customer.Infra.Repositories
{
    public class DeliveryAddressRepository : IDeliveryAddressRepository
    {
        private readonly IViaCepClient _viaCepClient;

        public DeliveryAddressRepository(IViaCepClient viaCepClient)
        {
            _viaCepClient = viaCepClient;
        }

        public async Task<DeliveryAddress> GetAddressAsync(Cep cep)
        {
            var gettedAddress = await _viaCepClient.GetAddressAsync(cep.Value);

            return gettedAddress.Erro ?
                throw new ExternalAddressNotFoundException(cep.Value) :
                new DeliveryAddress(cep, gettedAddress.Logradouro, gettedAddress.Bairro, gettedAddress.Localidade, gettedAddress.Uf);
        }
    }
}
