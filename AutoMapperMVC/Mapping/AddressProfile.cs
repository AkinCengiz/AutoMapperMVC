using AutoMapper;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;

namespace AutoMapperMVC.Mapping;

public class AddressProfile : Profile
{
	public AddressProfile()
	{
		CreateMap<Address, AddressDto>().ReverseMap();
	}
}
