using Customer.Domain.Aggregates;
using Customer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Repository
{
    public interface IDeliveryAddressRepository
    {
        Task<DeliveryAddress> GetDeliveryAddressFromCepAsync(Cep cep);
    }
}
