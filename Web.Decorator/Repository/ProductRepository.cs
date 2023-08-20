
using BaseProject.Models;
using Microsoft.EntityFrameworkCore;
using Web.Decorator.Models;

namespace Web.Decorator.Repository
{
    public class ProductRepository : IProductRepostiory
    {

        private readonly AppIdentityDbContext _context;

        public ProductRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAll(string userId)
        {
            return await _context.Products.Where(x=>x.UserId== userId).ToListAsync();   
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);   
        }

        public async Task<Product> Save(Product product)
        {
            await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
