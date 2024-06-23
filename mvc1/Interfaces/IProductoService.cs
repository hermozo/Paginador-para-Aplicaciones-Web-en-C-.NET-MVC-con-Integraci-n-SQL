using mvc1.Models;

namespace mvc1.Interfaces
{
    public interface IProductoService
    {
        ProductosViewModel GetProductosViewModel(int page, string nombre);
    }
}
