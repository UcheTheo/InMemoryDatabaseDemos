﻿using System.ComponentModel.DataAnnotations;

namespace EFCoreInMemoryDemo.DataModels;

public class ProductDataModel
{
	[Key]
	public Guid Id { get; set; }
	public string ProductName { get; set; }
	public string Category { get; set; }
	public float Price { get; set; }
}
