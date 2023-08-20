using BaseProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Web.Decorator.Models;

namespace Web.Decorator.Repository.Decorator
{
    public class ProductRepostioryCacheDecorator : BaseProductRepositoryDecorator
    {
        private readonly IMemoryCache _memoryCache;

        private const string ProductsCacheName = "products";
        public ProductRepostioryCacheDecorator(IProductRepostiory context, IMemoryCache memoryCache) : base(context)
        {
            _memoryCache = memoryCache;
        }


        public override async Task<List<Product>> GetAll()
        {

            if (_memoryCache.TryGetValue(ProductsCacheName, out List<Product> cacheProducts))
            {
                return cacheProducts;
            }

            await UpdateCache();

            return _memoryCache.Get<List<Product>>(ProductsCacheName);
        }

        public override async Task<List<Product>> GetAll(string userId)
        {
            var products = await GetAll();
            return products.Where(p => p.UserId == userId).ToList();
        }

        public override async Task<Product> Save(Product product)
        {
            await base.Save(product);
            await UpdateCache();

            return product;
        }

        public async override Task Update(Product product)
        {
            await base.Update(product);
            await UpdateCache();

        }

        public async override Task Delete(Product product)
        {
            await base.Delete(product);
            await UpdateCache();
        }

        private async Task UpdateCache()
        {
            _memoryCache.Set(ProductsCacheName, await base.GetAll());
        }

    }
}
