using AutoMapper;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;

namespace AutoMapperMVC.Mapping;

public class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
	}
}
