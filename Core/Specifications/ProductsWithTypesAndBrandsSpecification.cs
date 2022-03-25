using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x => x.ProductBrand);

            // Example of multi heirarchy include
            // AddInclude(“CountyOfOrigin.DefaultCountryLanguage”);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}