using AutoMapper;
using InterviewExam.Api.Contracts.Orders;
using InterviewExam.Application.Orders;
using InterviewExam.Domain.Models;
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
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IMapper mapper, IOrderService orderService, ILogger<OrdersController> logger)
        {
            this._mapper = mapper;
            this._orderService = orderService;
            _logger = logger;
        }

        [HttpGet("/customers/{id:int}/orders")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] int customerId, DateTime? startDate, DateTime? endDate,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($" customer selected: {customerId}");

            var result = await _orderService.GetAsync(customerId, startDate, endDate, cancellationToken);

            var response = _mapper.Map<List<OrderGetResponse>>(result);
            _logger.LogInformation("Customer orders: {@response}", response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderPostResponse request, CancellationToken cancellationToken)
        {
            var result = await _orderService.CreateAsync(_mapper.Map<Order>(request), cancellationToken);
            return Ok(_mapper.Map<OrderGetResponse>(result));
        }
    }
}
