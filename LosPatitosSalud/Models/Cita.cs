using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LosPatitosSalud.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [Display(Name = "Nombre de la Persona")]
        public string NombreDeLaPersona { get; set; } = string.Empty;

        [Required(ErrorMessage = "La identificación es obligatoria")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Phone(ErrorMessage = "Teléfono inválido")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = string.Empty;

        public decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
        [Display(Name = "Fecha de la Cita")]
        [DataType(DataType.Date)]
        public DateTime FechaDeLaCita { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un servicio")]
        [ForeignKey("Servicio")]
        public int IdServicio { get; set; }

        public Servicio? Servicio { get; set; }
    }
}
