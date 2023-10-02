using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;

namespace InterviewExam.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(productId, cancellationToken);
        }

        public async Task UpdateStockAsync(int productId, int newQuantity, CancellationToken cancellationToken)
        {
            await _repository.UpdateStockAsync(productId, newQuantity, cancellationToken);
        }
    }
}
