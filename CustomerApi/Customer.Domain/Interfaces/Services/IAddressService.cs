using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;

namespace Customer.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        Task<Address> GetAddressAsync(Cep cep);
        Task<Address> GetAddressAsync(string cep);
    }
}
