using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skyline_api.Models
{
    public class Reserva
    {
        [Key]
        public int id { get; set; }

        [Column("data_reserva")]
        public DateOnly DataReserva { get; set; }

        [Column("num_pessoas")]
        public int NumPessoas { get; set; }

        [Column("cancelada")]
        public bool? Cancelada { get; set; }

        [ForeignKey("UsuarioCpf")]
        [Column("usuario_cpf")]
        public string UsuarioCpf { get; set; }

        [ForeignKey("VooId")]
        [Column("voo_id")]
        public int VooId { get; set; }
    }
}
