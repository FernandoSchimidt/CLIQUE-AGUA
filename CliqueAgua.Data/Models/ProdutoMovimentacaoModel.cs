using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("ProdutoMovimentacao")]
    public partial class ProdutoMovimentacaoModel
    {
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public int IdProduto { get; set; }
		public decimal Quantidade { get; set; }
		public decimal SaldoAnterior { get; set; }

    }
}