using Core.Entities;

namespace Core.Specifications;

public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
{
	public ProductWithFiltersForCountSpecification(ProductSpecificationParameters productSpecificationParameters) 
		: base(x =>
			(string.IsNullOrEmpty(productSpecificationParameters.Search) || x.Name.ToLower()
				.Contains(productSpecificationParameters.Search)) &&
			(!productSpecificationParameters.BrandId.HasValue || x.ProductBrandId == productSpecificationParameters.BrandId) &&
			(!productSpecificationParameters.TypeId.HasValue || x.ProductTypeId == productSpecificationParameters.TypeId)
		)
	{
	}
}