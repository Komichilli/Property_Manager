using PropiedadWEB.Models;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesWEB.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }
        public int Deposito { get; set; }
        public string? Terminos { get; set; }
        public int InquilinoId { get; set; }
        public Inquilino? Inquilino { get; set; }
        public int PropiedadId { get; set; }
        public Propiedad? Propiedad { get; set; }
        public ICollection<Pago>? Pagos { get; set; }
    }
}