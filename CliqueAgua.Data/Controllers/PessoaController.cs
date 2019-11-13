using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PessoaController
    {
        ControllerHelper<PessoaModel> helper;

        public PessoaController()
        {
            helper = new ControllerHelper<PessoaModel>();
        }

        public PessoaModel Gravar(PessoaModel model)
        {
            model.Email = model.Email.ToLower();
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PessoaModel model)
        {
            helper.Excluir(model.Id);
        }

        public PessoaModel Consultar(PessoaModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<PessoaModel> Listar()
        {
            return helper.Listar();
        }
        public IEnumerable<PessoaModel> ConsultarPorNome(PessoaModel model)
        {
            var lstModel = helper.Listar($"nome like '%{model.Nome}%'", "nome", null);
            return lstModel;
        }
        public PessoaModel ConsultarPorEmail(PessoaModel model)
        {
            var lstModel = helper.Listar($"email = '{model.Email.ToLower()}'", "", 1);
            if (lstModel.Count() > 0)
                return lstModel.FirstOrDefault();
            else
                return new PessoaModel();

        }

    }
}