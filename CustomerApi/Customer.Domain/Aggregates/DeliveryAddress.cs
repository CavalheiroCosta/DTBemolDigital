﻿using Customer.Domain.Responses;
using Customer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Aggregates
{
    public class DeliveryAddress
    {
        public DeliveryAddress(string identifier, string cep, string address, long number, string neighborhood, string city, string state, string complement, string reference)
        {
            Identifier = identifier;
            Cep = new Cep(cep);
            Address = address;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
            Reference = reference;
        }

        public string Identifier { get; set; }
        public Cep Cep { get; set; }
        public string Address { get; set; }
        public long Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }

        public AddressDetailResponse GetAddressDetail()
        {
            return new AddressDetailResponse(Cep.Number, Address, Neighborhood, City, State);
        }

    }
}