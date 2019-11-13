using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CliqueAgua.Data.Models
{
    [Table("Pessoa")]
    public partial class PessoaModel
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public bool Fisica { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public int IdEndereco { get; set; }
    }
}