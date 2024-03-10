using System.ComponentModel.DataAnnotations;

namespace mvc1.Models
{
    public class Productos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripción del producto es requerido.")]
        public string? Descripcion { get; set; } = string.Empty;
    }
}
