using AutoMapper;
using GraphLesson.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using StoreMarketApp.Contexts;
using StoreMarketApp.Contracts.Requests;
using StoreMarketApp.Contracts.Responses;
using StoreMarketApp.Models;
using System.Text;

namespace GraphLesson.Services
{
    public class CategoryServices: ICategoryService
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public CategoryServices(StoreContext storeContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _storeContext = storeContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public int AddCategory(CategoryCreateRequest category)
        {
            var entity = _mapper.Map<Category>(category);
            _storeContext.Categories.Add(entity);
            _storeContext.SaveChanges();

            _memoryCache.Remove("categories");

            return entity.Id;

        }

        public string GetCsv(IEnumerable<CategoryResponse> categories)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var category in categories)
            {
                stringBuilder.AppendLine(category.Id + ";" + category.Name + ";" + category.Description + "\n");
            }

            return stringBuilder.ToString();
        }

        public CategoryResponse? GetCategoryById(int categoryId)
        {
            var category = _storeContext.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<CategoryResponse>(category);

        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            if (_memoryCache.TryGetValue("categories", out IEnumerable<CategoryResponse> cats))
            {
                return cats;
            }

            IEnumerable<CategoryResponse> categories = _storeContext.Categories.Select(x => _mapper.Map<CategoryResponse>(x)).ToList();

            _memoryCache.Set("categories", categories, TimeSpan.FromMinutes(30));

            return categories;
        }
    }
}
