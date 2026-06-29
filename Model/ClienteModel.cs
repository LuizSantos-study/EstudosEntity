using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWebSelect.Model
{
    [Table("TBL_CLIENTE")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(14)]
        [Column("CPF")]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        [Column("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("DtNasc", TypeName = "date")]
        public DateTime? DtNasc { get; set; }

        public ICollection<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
    }
}

