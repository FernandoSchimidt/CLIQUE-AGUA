using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PessoaEnderecoController
    {
        ControllerHelper<PessoaEnderecoModel> helper;

        public PessoaEnderecoController()
        {
            helper = new ControllerHelper<PessoaEnderecoModel>();
        }

        public PessoaEnderecoModel Gravar(PessoaEnderecoModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PessoaEnderecoModel model)
        {
            helper.Excluir(model.Id);
        }
        public IEnumerable<PessoaEnderecoModel> Listar()
        {
            return helper.Listar();
        }
        public PessoaEnderecoModel Consultar(PessoaEnderecoModel model)
        {
            return helper.Consultar(model.Id);
        }

    }
}