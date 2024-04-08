using AutoMapper;
using AutoMapperMVC.Models;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperMVC.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
	private readonly AutoMapperDbContext _context;
	private readonly IValidator<Address> _addressValidator;
	private readonly IMapper _mapper;

	public AddressesController(AutoMapperDbContext context,IValidator<Address> addressValidator, IMapper mapper)
	{
		_context = context;
		_addressValidator = addressValidator;
		_mapper = mapper;
	}

	[HttpGet]
	public IActionResult GetAllAddress()
	{
		var addresses = _context.Addresses.ToList();
		if (addresses == null)
		{
			return NotFound("Page not found");
		}

		return Ok(_mapper.Map<List<AddressDto>>(addresses));
	}

	[HttpGet("{id}")]
	public IActionResult GetByIdAddress(int id)
	{
		var address = _context.Addresses.FirstOrDefault(a => a.Id == id);
		if (address == null)
		{
			return NotFound("Address not found...");
		}

		return Ok(_mapper.Map<AddressDto>(address));
	}

	[HttpPost]
	public IActionResult CreateAddress(AddressDto addressDto)
	{
		_context.Addresses.Add(_mapper.Map<Address>(addressDto));
		_context.SaveChanges();
		return Ok("Create success");
	}
}
