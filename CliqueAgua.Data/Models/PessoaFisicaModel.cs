using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("Pessoa")]
    public partial class PessoaFisicaModel : PessoaModel
    {
		public string Cpf { get; set; }
		public string Rg { get; set; }
    }
}