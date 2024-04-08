using AutoMapper;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;

namespace AutoMapperMVC.Mapping;

public class AddressProfile : Profile
{
	public AddressProfile()
	{
		CreateMap<Address, AddressDto>().ForMember(dest => dest.Aciklama, opt => opt.MapFrom(x => x.Content))
			.ForMember(dest => dest.PostaKodu, opt => opt.MapFrom(x => x.PostalCode))
			.ForMember(dest => dest.Sehir, opt => opt.MapFrom(x => x.Province))
			.ForMember(dest => dest.MusteriId,opt => opt.MapFrom(x => x.CustomerId)).ReverseMap();
		//CreateMap<AddressDto, Address>().ForMember(dest => dest.Content, opt => opt.MapFrom(x => x.Aciklama))
		//	.ForMember(dest => dest.PostalCode, opt => opt.MapFrom(x => x.PostaKodu))
		//	.ForMember(dest => dest.Province, opt => opt.MapFrom(x => x.Sehir));
	}
}
