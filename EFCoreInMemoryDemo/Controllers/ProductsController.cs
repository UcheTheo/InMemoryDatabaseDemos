using EFCoreInMemoryDemo.DatabaseContext;
using EFCoreInMemoryDemo.DataModels;
using EFCoreInMemoryDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreInMemoryDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly AppDbContext _context;

	public ProductsController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	[Route("GetProductList")]
	public async Task<IActionResult> GetProductList()
	{
		var products = _context.Products.ToList();
		return Ok(products);
	}

	[HttpPost]
	[Route("PostProduct")]
	public async Task<IActionResult> PostProduct(ProductModel obj)
	{
		ProductDataModel product = new()
		{
			Id = Guid.NewGuid(),
			ProductName = obj.ProductName,
			Category = obj.Category,
			Price = obj.Price
		};

		_context.Products.Add(product);
		await _context.SaveChangesAsync();

		return Ok(product);
	}
}


