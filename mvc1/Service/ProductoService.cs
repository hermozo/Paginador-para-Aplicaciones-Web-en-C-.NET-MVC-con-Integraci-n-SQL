using mvc1.Helpers;
using mvc1.Interfaces;
using mvc1.Models;

namespace mvc1.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public ProductosViewModel GetProductosViewModel(int page, string nombre)
        {
            IQueryable<Productos> query = _productoRepository.GetProductos(nombre);

            int totalProductos = query.Count();
            Paginacion pagination = new Paginacion(page, totalProductos);
            List<Productos> productos = query
                .Skip(pagination.StartIndex)
                .Take(pagination.ItemsPerPage)
                .ToList();

            return new ProductosViewModel
            {
                Productos = productos,
                Pagination = pagination,
                Nombre = nombre
            };
        }
    }
}
