using AutoMapper;
using InterviewExam.Api.Contracts.Orders;
using InterviewExam.Application.Orders;
using Microsoft.AspNetCore.Mvc;

namespace InterviewExam.Controllers
{
    [Route("api/v{version:apiversion}/orders")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiVersion("1.0")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            this._mapper = mapper;
            this._orderService = orderService;
        }

        [HttpGet("/customers/{id:int}/orders")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] int customerId, DateTime? startDate, DateTime? endDate,
            CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAsync(customerId, startDate, endDate, cancellationToken);
            return Ok(_mapper.Map<List<OrderGetResponse>>(result));
        }
    }
}
