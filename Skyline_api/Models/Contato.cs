using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skyline.Models
{
    [Table("CONTATO")]
    public class Contato
    {
        [Key]
        public int id { get; set; }

        [Column("nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(80, ErrorMessage = "Este Campo é de no máximo 80 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("mensagem")]
        public string Mensagem { get; set; }

        [Column("resolvido")]
        public bool? Resolvido { get; set; }

    }
}