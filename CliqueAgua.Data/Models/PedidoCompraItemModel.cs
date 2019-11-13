using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("PedidoCompraItem")]
    public partial class PedidoCompraItemModel
    {
		public int Id { get; set; }
		public int IdPedidoCompra { get; set; }
		public int IdProduto { get; set; }
		public decimal Quantidade { get; set; }
		public decimal Preco { get; set; }

    }
}