using PropiedadWEB.Models;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesWEB.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public string FechaPago { get; set; }
        public int Monto { get; set; }
        public string Estado { get; set; }

        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
    }
}
