using GraphLesson.Abstractions;
using StoreMarketApp.Abstractions;
using StoreMarketApp.Contracts.Responses;

namespace GraphLesson.GraphQL
{
    public class Query
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryService _categoryServices;

        public Query(IProductServices productServices, ICategoryService categoryService) {
        
            _productServices = productServices;
            _categoryServices = categoryService;

        }

        public IEnumerable<ProductResponse> GetProducts() => _productServices.GetProducts();

        public ProductResponse GetProductById(int id) => _productServices.GetProductById(id);
        public string GetCSV(IEnumerable<ProductResponse> products) => _productServices.GetCsv(products);


        public IEnumerable<CategoryResponse> GetCategories() => _categoryServices.GetCategories();

        public CategoryResponse GetCategoryById(int id) => _categoryServices.GetCategoryById(id);
        public string GetCSV(IEnumerable<CategoryResponse> categories) => _categoryServices.GetCsv(categories);

    }
}
