using Customer.Domain.Aggregates;
using Customer.Domain.Requests;

namespace Customer.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Guid> CreateCompanyAsync(CreateCompanyRequest request);
        Task<Guid> CreatePersonAsync(CreatePersonRequest request);
        Task<Company> GetCompanyAsync(Guid id);
        Task<Person> GetPersonAsync(Guid id);
    }
}
