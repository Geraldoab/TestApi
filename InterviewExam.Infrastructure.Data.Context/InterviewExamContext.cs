using InterviewExam.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InterviewExam.Infrastructure.Data.Context
{
    public class InterviewExamContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public InterviewExamContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
