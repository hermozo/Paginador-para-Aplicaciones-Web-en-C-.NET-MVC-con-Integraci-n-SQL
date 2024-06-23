using mvc1.Interfaces;
using mvc1.Models;
using System;

namespace mvc1.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDBContext _appDbContext;
        public ProductoRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Productos> GetProductos(string nombre)
        {
            IQueryable<Productos> query = _appDbContext.Productos;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }
            return query;
        }
    }
}
