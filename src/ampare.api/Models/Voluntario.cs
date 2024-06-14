using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ampare.api.Models
{
    [Table("Voluntarios")]
    public class Voluntario
    {
        [Key]
        public int VoluntarioId { get; set; }
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inv�lido")]
        public string Cpf { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<ProjetoVoluntario> ProjetoVoluntario { get; set; }
        
    }
}
