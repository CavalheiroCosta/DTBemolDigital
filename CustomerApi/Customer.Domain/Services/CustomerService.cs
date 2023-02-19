﻿using Customer.Domain.Aggregates;
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
        private readonly IDeliveryAddressService _deliveryAddressService;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IDeliveryAddressService deliveryAddressService, ICustomerRepository customerRepository)
        {
            _deliveryAddressService = deliveryAddressService;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> CreateCompanyAsync(CreateCompanyRequest request)
        {
            var address = await GetAddres(request.DeliveryAddress);
            var company = new Company(request.Name, request.CorporateName, request.Cnpj, request.Email, address);

            if (await HasCompanyWithCnpj(company.Cnpj))
                throw new DomainException(ExpectedErrorMessages.DuplicateDataWithTheData("CNPJ"));

            return await _customerRepository.CreateAsync(company);
        }

        public async Task<Guid> CreatePersonAsync(CreatePersonRequest request)
        {
            var address = await GetAddres(request.DeliveryAddress);
            var person = new Person(request.Name, request.BirthDate, request.Cpf, request.Email, address);

            if (await HasPersonWithCpf(person.Cpf)) 
                throw new DomainException(ExpectedErrorMessages.DuplicateDataWithTheData("CPF"));

            return await _customerRepository.CreateAsync(person);
        }

        private async Task<DeliveryAddress> GetAddres(CreateDeliveryAddressRequest request)
        {
            var address = await _deliveryAddressService.GetAddressAsync(request.Cep);
            address.AddComplements(request.AddressIdentifier, request.AddressComplement, request.AddressReference);
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
    }
}