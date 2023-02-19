using Customer.Domain.DomainObjects;

namespace Customer.Domain.Aggregates
{
    public class Company
    {

        protected Company() { } 
        public Company(Guid id, string name, string corporateName, string cnpj, string email, Guid deliveryAddresId)
        {
            Id = id;
            Name = name;
            CorporateName = corporateName;
            Cnpj = new Cnpj(cnpj);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddresId;
        }

        public Company(Guid id, string name, string corporateName, Cnpj cnpj, Email email, Guid deliveryAddresId)
        {
            Id = id;
            Name = name;
            CorporateName = corporateName;
            Cnpj = cnpj;
            Email = email;
            DeliveryAddresId = deliveryAddresId;
        }

        public Company(string name, string corporateName, string cnpj, string email, Address deliveryAddress) 
        {
            Id = Guid.NewGuid();
            Name = name;
            CorporateName = corporateName;
            Cnpj = new Cnpj(cnpj);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddress.Id;
            DeliveryAddress = deliveryAddress;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CorporateName { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Email Email { get; private set; }
        public Guid DeliveryAddresId { get; private set; }


        public Address? DeliveryAddress { get; set; } = null;
    }
}
