﻿using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Domain.Core.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        Task Add(Product user);

        Task Update(Product user);

        Task Delete(Product user);

        Task<Product> Get(int id);

        Task<IEnumerable<Product>> GetAll(string filter);

        Task<IEnumerable<Product>> GetProductsBySupplierId(int id);

        void Detach(Product user);
    }
}
