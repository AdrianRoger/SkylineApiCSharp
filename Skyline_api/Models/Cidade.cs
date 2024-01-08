using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Skyline_api.Models
{
    public class Cidade
    {
        [Key]
        public int id { get; set; }
        [Column("cidade")]
        public string NomeCidade { get; set; }
        [Column("estado")]
        public string Estado { get; set; }
        [Column("pais")]
        public string Pais { get; set; }
        [Column("aeroporto")]
        public string Aeroporto { get; set; }

        [JsonIgnore]
        public List<Voo> VoosOrigem { get; set; }
        [JsonIgnore]
        public List<Voo> VoosDestino { get; set; }

    }
}
