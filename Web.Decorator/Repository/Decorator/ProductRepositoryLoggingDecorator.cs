using Web.Decorator.Models;

namespace Web.Decorator.Repository.Decorator
{
    public class ProductRepositoryLoggingDecorator : BaseProductRepositoryDecorator
    {
        private readonly ILogger<ProductRepositoryLoggingDecorator> _logger;
        public ProductRepositoryLoggingDecorator(IProductRepostiory context, ILogger<ProductRepositoryLoggingDecorator> logger) : base(context)
        {
            _logger = logger;
        }

        public override Task<List<Product>> GetAll()
        {
            _logger.LogInformation("Get all");

            return base.GetAll();
        }

        public override Task<List<Product>> GetAll(string userId)
        {
            _logger.LogInformation("Get(userId) all");

            return base.GetAll(userId);
        }

        public override Task<Product> GetById(int id)
        {
            _logger.LogInformation("GetById all");

            return base.GetById(id);
        }

        public override Task<Product> Save(Product product)
        {
            _logger.LogInformation("Save");

            return base.Save(product);
        }

        public override Task Update(Product product)
        {
            _logger.LogInformation("Update");

            return base.Update(product);
        }

        public override Task Delete(Product product)
        {
            _logger.LogInformation("Delete");

            return base.Delete(product);
        }

    }
}
