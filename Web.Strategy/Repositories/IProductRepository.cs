﻿using Web.Strategy.Models;

namespace Web.Strategy.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(string id);
        Task<List<Product>> GetAllByUserId(string id);
        Task<Product> Save(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
