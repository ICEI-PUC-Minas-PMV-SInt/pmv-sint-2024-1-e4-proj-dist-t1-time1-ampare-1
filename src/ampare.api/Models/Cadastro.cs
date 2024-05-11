using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ampare.api.Models
{
    [Table("Cadastros")]
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inválido")]
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
