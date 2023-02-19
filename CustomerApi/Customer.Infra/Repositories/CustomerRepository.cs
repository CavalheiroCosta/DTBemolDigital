using Customer.Domain.Aggregates;
using Customer.Domain.DomainObjects;
using Customer.Domain.Interfaces.Repository;
using Customer.Infra.Context;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<Guid> CreateAsync(Person person)
        {
            _customerContext.Persons.Add(person);
            await _customerContext.SaveChangesAsync();

            return person.Id;
        }

        public async Task<Guid> CreateAsync(Company company)
        {
            _customerContext.Companies.Add(company);
            await _customerContext.SaveChangesAsync();

            return company.Id;
        }

        public async Task<Company> GetCompanyAsync(Cnpj cnpj)
        {
            return await _customerContext.Companies.FirstOrDefaultAsync(company => company.Cnpj == cnpj);
        }

        public async Task<Person> GetPersonAsync(Cpf cpf)
        {
            return await _customerContext.Persons.FirstOrDefaultAsync(person => person.Cpf == cpf);
        }
    }
}
