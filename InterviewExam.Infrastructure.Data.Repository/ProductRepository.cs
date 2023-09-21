using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExam.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InterviewExamContext _context;
        public ProductRepository(InterviewExamContext context)
        {
            this._context = context;        
        }

        public Task<Product> GetByIdAsync(long productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
