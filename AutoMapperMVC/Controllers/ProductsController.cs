using AutoMapper;
using AutoMapperMVC.Models;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperMVC.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly AutoMapperDbContext _context;
	private readonly IValidator<Product> _productValidator;
	private readonly IMapper _mapper;

	public ProductsController(AutoMapperDbContext context,IValidator<Product> productValidator,IMapper mapper)
	{
		_context = context;
		_productValidator = productValidator;
		_mapper = mapper;
	}

	[HttpGet]
	public IActionResult GetAllProducts()
	{
		var products = _context.Products.ToList();
		if (products == null)
		{
			return NotFound("Page not found...");
		}
		return Ok(_mapper.Map<List<ProductDto>>(products));
	}

	[HttpGet("{id}")]
	public IActionResult GetProduct(int id)
	{
		var product = _context.Products.FirstOrDefault(p =>p.ProductId == id);
		return Ok(_mapper.Map<ProductDto>(product));
	}

	[HttpPost]
	public IActionResult CreateProduct(ProductDto productDto)
	{
		_context.Products.Add(_mapper.Map<Product>(productDto));
		_context.SaveChanges();
		return Ok();
	}

	[HttpPut]
	public IActionResult UpdateProduct(ProductDto productDto)
	{
		_context.Entry(_mapper.Map<Product>(productDto)).State = EntityState.Modified;
		_context.SaveChanges();
		return Ok();
	}
}
