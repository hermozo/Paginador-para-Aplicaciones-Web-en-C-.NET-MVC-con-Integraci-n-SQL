using mvc1.Models;

namespace mvc1.Interfaces
{
    public interface IProductoRepository
    {
        IQueryable<Productos> GetProductos(string nombre);
    }
}
