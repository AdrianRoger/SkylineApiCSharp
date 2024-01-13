using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Skyline_api.Models
{
    [Table("VOO")]
    public class Voo
    {
        [Key]
        public int id { get; set; }
        [Column("num_voo")]
        public int NumVoo { get; set; }
        [Column("comp_aerea")]
        public string CompAerea { get; set; }
        [Column("assentos")]
        public int Assentos { get; set; }
        [Column("preco_unit")]
        public double PrecoUnit {  get; set; }
        [Column("data_partida")]
        public DateTime DataPartida { get; set; }
        
        [ForeignKey("OrigemId")]
        [Column("origem_id")]
        public int OrigemId { get; set; }
        public Cidade Origem { get; set; }

        [ForeignKey("DestinoId")]
        [Column("destino_id")]
        public int DestinoId { get; set; }
        public Cidade Destino { get; set; }

        [JsonIgnore]
        public List<Reserva> ReservasVoo { get; set; }
    }
}
