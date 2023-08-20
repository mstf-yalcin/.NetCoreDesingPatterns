using Web.Decorator.Models;

namespace Web.Decorator.Repository.Decorator
{
    public abstract class BaseProductRepositoryDecorator : IProductRepostiory
    {
        private readonly IProductRepostiory _productRepostiory;

        public BaseProductRepositoryDecorator(IProductRepostiory context)
        {
            _productRepostiory = context;
        }

        public virtual async Task Delete(Product product)
        {
            await _productRepostiory.Delete(product);
        }

        public virtual async Task<List<Product>> GetAll()
        {
            return await _productRepostiory.GetAll();
        }

        public virtual async Task<List<Product>> GetAll(string userId)
        {
            return await _productRepostiory.GetAll(userId);
        }

        public virtual async Task<Product> GetById(int id)
        {
            return await _productRepostiory.GetById(id);
        }

        public virtual async Task<Product> Save(Product product)
        {

            return await _productRepostiory.Save(product);
        }

        public virtual async Task Update(Product product)
        {
            await _productRepostiory.Update(product);
        }
    }
}
