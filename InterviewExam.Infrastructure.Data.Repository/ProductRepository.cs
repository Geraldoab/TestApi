using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Products.FirstOrDefaultAsync(w=> w.ProductId == productId, cancellationToken: cancellationToken);
        }
    }
}
