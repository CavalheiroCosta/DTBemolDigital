using Customer.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace Customer.Infra.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Address> DeliveryAddresses => Set<Address>();
        public virtual DbSet<Person> Persons => Set<Person>();
        public virtual DbSet<Company> Companies => Set<Company>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(address =>
            {
                address.OwnsOne(a => a.Cep, cep => cep.Property(c => c.Value).HasColumnName("cep"));
            });

            modelBuilder.Entity<Person>(person =>
            {
                person.OwnsOne(p => p.Cpf, cpf => cpf.Property(c => c.Value).HasColumnName("cpf"));
                person.OwnsOne(p => p.Email, email => email.Property(c => c.Value).HasColumnName("email"));
            });

            modelBuilder.Entity<Company>(company =>
            {
                company.OwnsOne(c => c.Cnpj, cnpj => cnpj.Property(c => c.Value).HasColumnName("cnpj"));
                company.OwnsOne(c => c.Email, email => email.Property(e => e.Value).HasColumnName("email"));
            });
        }
    }
}
