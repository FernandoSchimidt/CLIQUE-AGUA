using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("Produto")]
    public partial class ProdutoModel
    {
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Nome { get; set; }
		public decimal PrecoVenda { get; set; }
		public decimal PrecoCusto { get; set; }
		public decimal Saldo { get; set; }
		public int IdGrupo { get; set; }
		public decimal EstoqueMinimo { get; set; }

    }
}