﻿namespace AutoMapperMVC.Models.ORM;

public class Category
{
	public int CategoryId { get; set; }
	public string CategoryName { get; set; }
	public List<Category> Categories { get; set;}
}
