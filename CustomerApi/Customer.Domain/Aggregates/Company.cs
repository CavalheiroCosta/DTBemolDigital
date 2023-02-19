using Customer.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Aggregates
{
    public class Company
    {
        public Company(Guid id, string name, string corporateName, string cnpj, string email, Guid deliveryAddresId)
        {
            Id = id;
            Name = name;
            CorporateName = corporateName;
            Cnpj = new Cnpj(cnpj);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddresId;
        }

        public Company(string name, string corporateName, string cnpj, string email, DeliveryAddress deliveryAddress) 
        {
            Name = name;
            CorporateName = corporateName;
            Cnpj = new Cnpj(cnpj);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddress.Id;
            DeliveryAddress = deliveryAddress;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string CorporateName { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Email Email { get; private set; }
        public Guid DeliveryAddresId { get; private set; }


        public DeliveryAddress? DeliveryAddress { get; set; } = null;
    }
}
