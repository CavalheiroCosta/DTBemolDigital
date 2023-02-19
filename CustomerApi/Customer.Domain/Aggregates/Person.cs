using Customer.Domain.DomainObjects;

namespace Customer.Domain.Aggregates
{
    public class Person
    {
        protected Person() { }  
        public Person(Guid id, string name, DateTime birthDate, string cpf, string email, Guid deliveryAddresId)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            DeliveryAddresId = deliveryAddresId;
        }

        public Person(Guid id, string name, DateTime birthDate, Cpf cpf, Email email, Guid deliveryAddresId)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;
            DeliveryAddresId = deliveryAddresId;
        }

        public Person(string name, DateTime birthDate, string cpf, string email, Address deliveryAddres) 
        {
            Id = Guid.NewGuid();
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
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Guid DeliveryAddresId { get; private set; }

        public Address? DeliveryAddress { get; set; } = null;
    }
}
