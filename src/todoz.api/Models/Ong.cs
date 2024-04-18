using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ampare.api.Models
{
    [Table("Cadastros")]
    public class Ong
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inv�lido")]
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Project> Projetos { get; set; }
        
    }
}
