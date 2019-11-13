using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("Cidade")]
    public partial class CidadeModel
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Uf { get; set; }

    }
}