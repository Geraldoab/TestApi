using InterviewExam.Domain.Models;

namespace InterviewExam.Application.Products
{
    public interface IProductService
    {
        Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken);
        Task UpdateStockAsync(int productId, int newQuantity, CancellationToken cancellationToken);
    }
}
