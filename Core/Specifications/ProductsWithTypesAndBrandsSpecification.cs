using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
                (productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId)
            )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x => x.ProductBrand);

            // Example of multi heirarchy include
            // AddInclude(“CountyOfOrigin.DefaultCountryLanguage”);

            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(productParams.sort))
            {
                switch  (productParams.sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default :
                        AddOrderBy(n => n.Name);
                        break;
                }
            }

            ApplyPaging(productParams.PageSize*(productParams.PageIndex-1)
                ,productParams.PageSize);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}