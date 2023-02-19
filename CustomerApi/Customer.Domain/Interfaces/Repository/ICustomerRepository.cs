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
        Task<Company> GetCompanyAsync(Cnpj cnpj);
        Task<Guid> CreateAsync(Person person);
        Task<Guid> CreateAsync(Company company);
    }
}
