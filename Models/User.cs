using System.ComponentModel.DataAnnotations;

namespace PropiedadWEB.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required] // Verificar que se importo using System.ComponentModet.DataAnotations
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}