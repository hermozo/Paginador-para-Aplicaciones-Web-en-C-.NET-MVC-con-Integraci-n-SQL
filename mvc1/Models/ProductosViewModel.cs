using mvc1.Helpers;

namespace mvc1.Models
{
    public class ProductosViewModel
    {
        public List<Productos> Productos { get; set; }
        public Paginacion Pagination { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
