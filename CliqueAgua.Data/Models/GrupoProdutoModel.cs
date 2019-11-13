using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("GrupoProduto")]
    public partial class GrupoProdutoModel
    {
		public int Id { get; set; }
		public string Nome { get; set; }

    }
}