using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PessoaFisicaController
    {
        ControllerHelper<PessoaFisicaModel> helper;

        public PessoaFisicaController()
        {
            helper = new ControllerHelper<PessoaFisicaModel>();
        }

        public PessoaFisicaModel Gravar(PessoaFisicaModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PessoaFisicaModel model)
        {
            helper.Excluir(model.Id);
        }
        public IEnumerable<PessoaFisicaModel> Listar()
        {
            return helper.Listar();
        }
        public PessoaFisicaModel Consultar(PessoaFisicaModel model)
        {
            return helper.Consultar(model.Id);
        }

    }
}