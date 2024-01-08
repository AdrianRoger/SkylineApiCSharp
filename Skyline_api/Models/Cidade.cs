using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public List<Voo> VoosOrigem { get; set; }
        public List<Voo> VoosDestino { get; set; }

    }
}
