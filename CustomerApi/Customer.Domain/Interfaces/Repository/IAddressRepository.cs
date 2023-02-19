using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;

namespace Customer.Domain.Interfaces.Repository
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(Cep cep);
    }
}
