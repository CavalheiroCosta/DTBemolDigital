using Customer.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace Customer.Infra.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
