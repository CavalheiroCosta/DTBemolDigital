using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Requests;
using Customer.Domain.Responses;

namespace Customer.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        Task<Address> GetAddressAsync(Cep cep);
        Task<Address> GetAddressAsync(string cep);
    }
}
