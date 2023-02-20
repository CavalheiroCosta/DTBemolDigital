using Customer.Domain.DomainObjects;

namespace Customer.Domain.Aggregates
{
    public class Company
    {

        protected Company(string name, string corporateName) 
        {
            Name = name;
            CorporateName = corporateName;
        } 

        public Company(string name, string corporateName, string cnpj, string email, Address deliveryAddress) : this(name,corporateName)
        {
            Id = Guid.NewGuid();
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


        public Address DeliveryAddress { get; private set; }
    }
}
