using System.ComponentModel.DataAnnotations;

namespace LosPatitosSalud.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El IVA es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El IVA no puede ser negativo")]
        [Display(Name = "IVA (%)")]
        public decimal IVA { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [Display(Name = "Especialidad")]
        public int Especialidad { get; set; }

        [Required(ErrorMessage = "El especialista es obligatorio")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Especialista")]
        public string Especialista { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clínica es obligatoria")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Display(Name = "Clínica")]
        public string Clinica { get; set; } = string.Empty;

        public DateTime FechaDeRegistro { get; set; }
        public DateTime? FechaDeModificacion { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();

        public string NombreEspecialidad => Especialidad switch
        {
            1 => "Medicina General",
            2 => "Imagenología",
            3 => "Microbiología",
            _ => "Desconocido"
        };
    }
}
