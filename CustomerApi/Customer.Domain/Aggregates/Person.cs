using Customer.Domain.DomainObjects;

namespace Customer.Domain.Aggregates
{
    public class Person
    {
        protected Person(string name, DateTime birthDate) 
        {
            Name = name;
            BirthDate = birthDate;
        }  
        public Person(string name, DateTime birthDate, string cpf, string email, Address deliveryAddres) : this(name, birthDate)
        {
            Id = Guid.NewGuid();
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            DeliveryAddressId = deliveryAddres.Id;
            DeliveryAddress = deliveryAddres;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Guid DeliveryAddressId { get; private set; }

        public Address DeliveryAddress { get; private set; }
    }
}
