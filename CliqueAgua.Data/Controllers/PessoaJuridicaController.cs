using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PessoaJuridicaController
    {
        ControllerHelper<PessoaJuridicaModel> helper;

        public PessoaJuridicaController()
        {
            helper = new ControllerHelper<PessoaJuridicaModel>();
        }

        public PessoaJuridicaModel Gravar(PessoaJuridicaModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PessoaJuridicaModel model)
        {
            helper.Excluir(model.Id);
        }
        public IEnumerable<PessoaJuridicaModel> Listar()
        {
            return helper.Listar();
        }
        public PessoaJuridicaModel Consultar(PessoaJuridicaModel model)
        {
            return helper.Consultar(model.Id);
        }

    }
}