using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private readonly IGenericRepository<Product> _productsRepo;
	private readonly IGenericRepository<ProductBrand> _productBrandRepo;
	private readonly IGenericRepository<ProductType> _productTypeRepo;

	public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)
	{
		_productsRepo = productsRepo;
		_productBrandRepo = productBrandRepo;
		_productTypeRepo = productTypeRepo;
	}
	[HttpGet]
	public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
	{
		var specifications = new ProductsWithTypesAndBrandsSpecification();
		return Ok(await _productsRepo.ListAsync(specifications));
	}
	
	[HttpGet("{id}")]
	public async Task<ActionResult<Product>> GetProduct(int id)
	{
		var specifications = new ProductsWithTypesAndBrandsSpecification(id);
		return await _productsRepo.GetEntityWithSpecification(specifications);
	}

	[HttpGet("brands")]
	public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
	{
		return Ok(await _productBrandRepo.ListAllAsync());
	}
	
	[HttpGet("types")]
	public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
	{
		return Ok(await _productTypeRepo.ListAllAsync());
	}
}