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

        public async Task<Guid> CreatePersonAsync(Person person)
        {
            _customerContext.Persons.Add(person);
            await _customerContext.SaveChangesAsync();

            return person.Id;
        }

        public async Task<Guid> CreateCompanyAsync(Company company)
        {
            _customerContext.Companies.Add(company);
            await _customerContext.SaveChangesAsync();

            return company.Id;
        }

        public async Task<Company> GetCompanyAsync(Cnpj cnpj)
        {
            return await _customerContext.Companies.FirstOrDefaultAsync(company => company.Cnpj.Value == cnpj.Value);
        }

        public async Task<Person> GetPersonAsync(Cpf cpf)
        {
            return await _customerContext.Persons.FirstOrDefaultAsync(person => person.Cpf.Value == cpf.Value);
        }

        public async Task<Person> GetPersonAsync(Guid id)
        {
            return await _customerContext.Persons.
                Include(customer => customer.DeliveryAddress).
                FirstOrDefaultAsync(person => person.Id == id);
        }

        public async Task<Company> GetCompanyAsync(Guid id)
        {
            return await _customerContext.Companies.
                Include(customer => customer.DeliveryAddress).
                FirstOrDefaultAsync(company => company.Id == id);
        }
    }
}
