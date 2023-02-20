using Customer.Domain.Aggregates;
using Customer.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
