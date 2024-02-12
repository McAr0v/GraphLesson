using StoreMarketApp.Contracts.Requests;
using StoreMarketApp.Contracts.Responses;

namespace GraphLesson.Abstractions
{
    public interface ICategoryService
    {
        int AddCategory(CategoryCreateRequest categoryCreateRequest);

        IEnumerable<CategoryResponse> GetCategories();
        CategoryResponse GetCategoryById(int categoryId);

        string GetCsv(IEnumerable<CategoryResponse> categories);
    }
}
