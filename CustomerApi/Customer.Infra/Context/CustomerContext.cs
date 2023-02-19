using Customer.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace Customer.Infra.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryAddress>(address =>
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
