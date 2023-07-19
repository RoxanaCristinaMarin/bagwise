using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

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
	public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts(
		[FromQuery]ProductSpecificationParameters productParams)
	{
		var specifications = new ProductsWithTypesAndBrandsSpecification(productParams);

		var countSpecification = new ProductWithFiltersForCountSpecification(productParams);
		var totalItems = await _productsRepo.CountAsync(countSpecification);
		
		var products = await _productsRepo.ListAsync(specifications);
		var data = _mapper
			.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);

		return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
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