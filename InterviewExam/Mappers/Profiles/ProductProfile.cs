using AutoMapper;
using InterviewExam.Api.Contracts.Products;
using InterviewExam.Domain.Models;

namespace InterviewExam.Api.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetResponse>();
        }
    }
}
