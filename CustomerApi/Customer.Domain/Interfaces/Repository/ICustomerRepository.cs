using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<Person> GetPersonAsync(Cpf cpf);
        Task<Person> GetPersonAsync(Guid id);
        Task<Company> GetCompanyAsync(Cnpj cnpj);
        Task<Company> GetCompanyAsync(Guid id);
        Task<Guid> CreatePersonAsync(Person person);
        Task<Guid> CreateCompanyAsync(Company company);
    }
}
