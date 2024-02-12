using GraphLesson.Abstractions;
using StoreMarketApp.Abstractions;
using StoreMarketApp.Contracts.Requests;

namespace GraphLesson.GraphQL
{
    public class Mutation
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryService _categoryService;

        public Mutation (IProductServices productServices, ICategoryService categoryService)
        {
            _productServices = productServices;
            _categoryService = categoryService;
        }

        public int AddProduct(ProductCreateRequest input) => _productServices.AddProduct(input);
        
        public int AddCategory(CategoryCreateRequest input) => _categoryService.AddCategory(input);

    }
}
