using Web.Decorator.Models;

namespace Web.Decorator.Repository
{
    public interface IProductRepostiory
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAll(string userId);
        Task<Product> GetById(int id);
        Task<Product> Save(Product product);
        Task  Update(Product product);
        Task Delete(Product product);
    }
}
