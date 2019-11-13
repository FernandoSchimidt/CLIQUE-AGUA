using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("PessoaEndereco")]
    public partial class PessoaEnderecoModel
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
		public int IdEndereco { get; set; }

    }
}