using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("PedidoVenda")]
    public partial class PedidoVendaModel
    {
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public int IdPessoa { get; set; }
		public DateTime DataEntrega { get; set; }
		public DateTime DataCancelamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataEncerramento { get; set; }
        public int IdEnderecoEntrega { get; set; }
		public int IdPessoaVendedor { get; set; }
        public decimal Total { get; set; }

    }
}