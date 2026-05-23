using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTema3.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }
    }
}
