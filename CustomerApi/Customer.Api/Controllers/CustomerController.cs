using Customer.Domain.DomainObjects;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Requests;
using Customer.Domain.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAddressService _deliveryAddressService;
        private readonly ICustomerService _customerService;

        public CustomerController(IAddressService deliveriesAddressService, ICustomerService customerService)
        {
            _deliveryAddressService = deliveriesAddressService;
            _customerService = customerService;
        }

        [HttpPost("Person")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePersonCustomer([FromBody]CreatePersonRequest request)
        {
            var createdPersonId = await _customerService.CreatePersonAsync(request);
            return Ok(createdPersonId);
        }

        [HttpGet("Person/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDetailResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompanyPerson([FromRoute] Guid id)
        {
            var customer = await _customerService.GetPersonAsync(id);
            return Ok(customer);
        }

        [HttpPost("Company")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCompanyCustomer([FromBody] CreateCompanyRequest request)
        {
            var createdCompanyId = await _customerService.CreateCompanyAsync(request);
            return Ok(createdCompanyId);
        }

        [HttpGet("Company/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDetailResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompanyCustomer([FromRoute] Guid id)
        {
            var customer = await _customerService.GetCompanyAsync(id);
            return Ok(customer);
        }

        [HttpGet("Address/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDetailResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCustomer([FromRoute] string cep)
        {
            var address = await _deliveryAddressService.GetAddressAsync(cep);
            return Ok(address.GetAddressDetail());
        }

    }
}
