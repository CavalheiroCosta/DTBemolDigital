using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<Guid> CreateAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyAsync(Cnpj cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPersonAsync(Cpf cpf)
        {
            throw new NotImplementedException();
        }
    }
}
