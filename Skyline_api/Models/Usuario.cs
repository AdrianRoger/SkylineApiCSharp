using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Skyline_api.Models
{
    public class Usuario
    {
        [Key]
        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("ativo")]
        public bool? Ativo { get; set; }

        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
    }
}
