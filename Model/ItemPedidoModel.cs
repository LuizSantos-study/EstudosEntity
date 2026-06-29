using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityWebSelect.Model
{
    [Table("TBL_ITEM_PEDIDO")]
    public class ItemPedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_Itens")]
        public int IdItens { get; set; }

        [Required]
        [Column("idPedido")] 
        public int IdPedido { get; set; }

        [Required]
        [Column("DescIten")]
        public string DescIten { get; set; } = string.Empty;

        [Required]
        [Column("ValorUni", TypeName = "money")]
        public decimal ValorUni { get; set; }

        [Required]
        [Column("QtdeEstoque")]
        public int QtdeEstoque { get; set; }

        [JsonIgnore]
        [ForeignKey("IdPedido")]
        public PedidoModel Pedido { get; set; } = null!;
    }
}
