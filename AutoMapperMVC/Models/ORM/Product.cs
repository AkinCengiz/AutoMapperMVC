﻿namespace AutoMapperMVC.Models.ORM;

public class Product
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public int CategoryId { get; set; }
	public string QuantityPerUnit { get; set; }
	public decimal UnitPrice { get; set; }
	public int UnitsInStock { get; set; }
	public Category Category { get; set; }
}
