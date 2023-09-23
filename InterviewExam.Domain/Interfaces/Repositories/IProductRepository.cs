﻿using InterviewExam.Domain.Models;

namespace InterviewExam.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken);
    }
}
