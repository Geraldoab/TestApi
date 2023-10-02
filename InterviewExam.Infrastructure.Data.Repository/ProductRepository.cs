using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;

namespace InterviewExam.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InterviewExamContext _context;
        public ProductRepository(InterviewExamContext context)
        {
            this._context = context;        
        }

        public async Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(new object[] { productId }, cancellationToken);
        }

        public async Task UpdateStockAsync(int productId, int newQuantity, CancellationToken cancellationToken)
        {
            var product = await GetByIdAsync(productId, cancellationToken);
            product!.Quantity = newQuantity;
        }
    }
}
