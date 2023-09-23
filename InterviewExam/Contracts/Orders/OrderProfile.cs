using AutoMapper;
using InterviewExam.Domain.Models;

namespace InterviewExam.Api.Contracts.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderGetResponse>()
                .ForMember(d => d.OrderId, m => m.MapFrom(s => s.OrderId))
                .ForMember(d => d.CustomerId, m => m.MapFrom(s => s.CustomerId))
                .ForMember(d => d.OrderDate, m => m.MapFrom(s => s.OrderDate))
                .ForMember(d => d.LineItems, m => m.MapFrom((s, d) => 
                {
                    var ordersProducts = s.OrderProducts.ToList();
                    var items = ordersProducts.Select(s => new LineItemResponse
                    {
                        ProductId = s.ProductId,
                        ProductName = s.Product.Name,
                        QuantityPurchased = s.Quantity,
                        TotalCost = s.Quantity * s.Product.Price
                    }).ToList();

                    d.Total = items.Sum(i=> i.TotalCost);

                    return items;
                }));
        }
    }
}
