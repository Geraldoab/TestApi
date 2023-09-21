using AutoMapper;
using InterviewExam.Application.Customers;
using InterviewExam.Api.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;
using InterviewExam.Domain.Models;
using System.Net;

namespace InterviewExam.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiVersion("1.0")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            this._customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerGetResponse>> GetCustomerAsync([FromRoute(Name = "id")] int customerId, CancellationToken cancellationToken)
        {
            var result = await _customerService.GetAsync(customerId, cancellationToken);
            return Ok(_mapper.Map<CustomerGetResponse>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CustomerPostRequest request, CancellationToken cancellationToken)
        {
            var newCustomer = _mapper.Map<Customer>(request);
            var insertedCustomer = await _customerService.CreateAsync(newCustomer, cancellationToken);

            Response.StatusCode = (int)HttpStatusCode.Created;
            return new JsonResult(_mapper.Map<CustomerPostResponse>(insertedCustomer));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] int customerId, [FromBody] CustomerPutRequest request, 
            CancellationToken cancellationToken)
        {
            var updatedCustomer = _mapper.Map<Customer>(request);
            updatedCustomer.CustomerId = customerId;

            await _customerService.UpdateAsync(updatedCustomer, cancellationToken);
            return Ok();
        }
    }
}
