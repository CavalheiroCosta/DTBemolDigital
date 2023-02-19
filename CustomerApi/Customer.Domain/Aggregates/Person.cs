using Customer.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Aggregates
{
    public class Person
    {
        public Person(Guid id, string name, DateTime birthDate, string cpf, string email, Guid deliveryAddresId)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddresId;
        }

        public Person(string name, DateTime birthDate, string cpf, string email, DeliveryAddress deliveryAddres) 
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddres.Id;
            DeliveryAddress = deliveryAddres;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; private set; }
        public Guid DeliveryAddresId { get; private set; }

        public DeliveryAddress? DeliveryAddress { get; set; } = null;
    }
}
