using AutoMapper;
using InterviewExam.Api.Contracts.Products;
using InterviewExam.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace InterviewExam.Controllers
{
    [Route("api/v{version:apiversion}/products")]
    [ApiVersion("1.0")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            this._mapper = mapper;
            this._productService = productService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] int productId, CancellationToken cancellationToken)
        {
            var result = await _productService.GetByIdAsync(productId, cancellationToken);
            return Ok(_mapper.Map<ProductGetResponse>(result));
        }
    }
}
