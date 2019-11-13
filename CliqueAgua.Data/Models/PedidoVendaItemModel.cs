using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("PedidoVendaItem")]
    public partial class PedidoVendaItemModel
    {
		public int Id { get; set; }
		public int IdPedidoVenda { get; set; }
		public int IdProduto { get; set; }
		public decimal Quantidade { get; set; }
		public decimal Preco { get; set; }

    }
}