using Customer.Domain.Interfaces.Services;
using Customer.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDeliveryAddressService _deliveryAddressService;

        public CustomerController(IDeliveryAddressService deliveriesAddressService)
        {
            _deliveryAddressService = deliveriesAddressService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer()
        {
            return Ok();
        }


        [HttpGet("/delivery-address/cep")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDetailResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromQuery] string cep)
        {
            return Ok(await _deliveryAddressService.GetAddressDetailFromCepAsync(cep));
        }
    }
}
