using AutoMapper;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;

namespace AutoMapperMVC.Mapping;

public class CustomerProfile : Profile
{
	public CustomerProfile()
	{
		CreateMap<Customer, CustomerDto>();
		CreateMap<CustomerDto, Customer>();
	}
}
