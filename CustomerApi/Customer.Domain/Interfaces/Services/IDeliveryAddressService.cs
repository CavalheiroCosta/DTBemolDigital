using Customer.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Services
{
    public interface IDeliveryAddressService
    {
        Task<AddressDetailResponse> GetAddressDetailFromCepAsync(string cep); 
    }
}
