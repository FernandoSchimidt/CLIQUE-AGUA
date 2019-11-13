using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("Pessoa")]
    public partial class PessoaJuridicaModel  : PessoaModel
    {
		public string Cnpj { get; set; }
		public string InsEstadual { get; set; }

    }
}