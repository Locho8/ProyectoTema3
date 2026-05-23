using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTema3.Models
{
    public class Articulo
    {
        [Key]
        public int IdArticulo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        [Display(Name = "Nombre del Artículo")]
        public string Nombre { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [StringLength(50)]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        [StringLength(255)]
        [Display(Name = "URL Imagen")]
        public string Imagen { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public bool Activo { get; set; }
    }
}
