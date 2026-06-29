using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityWebSelect.Model
{
    [Table("TBL_PEDIDO")]
    public class PedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [Required]
        [Column("idCliente")]
        public int IdCliente { get; set; }

        [Required]
        [Column("ValorTot", TypeName = "money")]
        public decimal ValorTot { get; set; }

        [Required]
        [Column("DtVenda", TypeName = "date")]
        public DateTime DtVenda { get; set; }

        [JsonIgnore]
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; } = null!;
        public ICollection<ItemPedidoModel> ItensPedido { get; set; } = new List<ItemPedidoModel>();
    }
}
