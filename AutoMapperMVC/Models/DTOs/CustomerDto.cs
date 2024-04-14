using AutoMapperMVC.Models.ORM;

namespace AutoMapperMVC.Models.DTOs;

public class CustomerDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public int Age { get; set; }

	public string FullName { get; set; }
}
