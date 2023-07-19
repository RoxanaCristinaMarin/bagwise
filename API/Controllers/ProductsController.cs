using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class ProductsController : BaseApiController
{
	private readonly IGenericRepository<Product> _productsRepo;
	private readonly IGenericRepository<ProductBrand> _productBrandRepo;
	private readonly IGenericRepository<ProductType> _productTypeRepo;
	private readonly IMapper _mapper;

	public ProductsController(IGenericRepository<Product> productsRepo, 
		IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,
		IMapper mapper)
	{
		_productsRepo = productsRepo;
		_productBrandRepo = productBrandRepo;
		_productTypeRepo = productTypeRepo;
		_mapper = mapper;
	}
	[HttpGet]
	public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
	{
		var specifications = new ProductsWithTypesAndBrandsSpecification();
		var products = await _productsRepo.ListAsync(specifications);

		return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products));
	}
	
	[HttpGet("{id}")]
	public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
	{
		var specifications = new ProductsWithTypesAndBrandsSpecification(id);
		var product = await _productsRepo.GetEntityWithSpecification(specifications);

		return _mapper.Map<Product, ProductToReturnDTO>(product);
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