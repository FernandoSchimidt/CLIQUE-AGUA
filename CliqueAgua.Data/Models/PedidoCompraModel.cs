using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("PedidoCompra")]
    public partial class PedidoCompraModel
    {
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public int IdPessoa { get; set; }
		public DateTime DataEntrega { get; set; }
		public DateTime DataCancelamento { get; set; }

    }
}