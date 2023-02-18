using Customer.Domain.Aggregates;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.ValueObjects;
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

        public async Task<DeliveryAddress> GetDeliveryAddressFromCepAsync(Cep cep)
        {
            var gettedAddress = await _viaCepClient.GetAddressDataAsync(cep.Number);

            return gettedAddress.erro ?
                throw new ExternalAddressNotFoundException(cep.Number) :
                new DeliveryAddress(cep, gettedAddress.Logradouro, gettedAddress.bairro, gettedAddress.localidade, gettedAddress.uf);
        }
    }
}
