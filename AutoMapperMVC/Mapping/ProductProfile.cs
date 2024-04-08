using AutoMapper;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;

namespace AutoMapperMVC.Mapping;

public class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductDto>().ReverseMap();
	}
}
