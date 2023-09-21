using AutoMapper;
using InterviewExam.Api.Contracts.Customers;
using InterviewExam.Domain.Models;

namespace InterviewExam.Mappers.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerGetResponse>().ReverseMap();
            CreateMap<CustomerPostRequest, Customer>();
            CreateMap<Customer, CustomerPostResponse>();
            CreateMap<CustomerPutRequest, Customer>();
        }
    }
}
