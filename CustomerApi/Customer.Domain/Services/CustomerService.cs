using Customer.Domain.Aggregates;
using Customer.Domain.Constants;
using Customer.Domain.DomainObjects;
using Customer.Domain.Exceptions;
using Customer.Domain.Interfaces.Repository;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Customer.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAddressService _deliveryAddressService;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IAddressService deliveryAddressService, ICustomerRepository customerRepository)
        {
            _deliveryAddressService = deliveryAddressService;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> CreateCompanyAsync(CreateCompanyRequest request)
        {
            var address = await GetAddress(request.DeliveryAddress);
            var company = new Company(request.Name, request.CorporateName, request.Cnpj, request.Email, address);

            if (await HasCompanyWithCnpj(company.Cnpj))
                throw new DomainException(ExpectedErrorMessages.DuplicateDataWithTheData("CNPJ"));

            return await _customerRepository.CreateCompanyAsync(company);
        }

        public async Task<Guid> CreatePersonAsync(CreatePersonRequest request)
        {
            var address = await GetAddress(request.DeliveryAddress);
            var person = new Person(request.Name, request.BirthDate, request.Cpf, request.Email, address);

            if (await HasPersonWithCpf(person.Cpf)) 
                throw new DomainException(ExpectedErrorMessages.DuplicateDataWithTheData("CPF"));

            return await _customerRepository.CreatePersonAsync(person);
        }

        private async Task<Address> GetAddress(CreateDeliveryAddressRequest request)
        {
            var address = await _deliveryAddressService.GetAddressAsync(request.Cep);
            address.AddSpecifications(request.Identifier, request.Number, request.Complement, request.Reference);
            return address;
        }

        private async Task<bool> HasPersonWithCpf(Cpf cpf) 
        {
            var person = await _customerRepository.GetPersonAsync(cpf);
            return person is { };
        }

        private async Task<bool> HasCompanyWithCnpj(Cnpj cnpj)
        {
            var company = await _customerRepository.GetCompanyAsync(cnpj);
            return company is { };
        }

        public async Task<Company> GetCompanyAsync(Guid id)
        {
            var company = await _customerRepository.GetCompanyAsync(id);
            return company is null ? throw new EntityNotFoundException("Company") : company;
        }

        public async Task<Person> GetPersonAsync(Guid id)
        {
            var person = await _customerRepository.GetPersonAsync(id);
            return person is null ? throw new EntityNotFoundException("Person") : person;
        }
    }
}
