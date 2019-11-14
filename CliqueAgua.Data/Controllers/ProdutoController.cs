using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class ProdutoController
    {
        ControllerHelper<ProdutoModel> helper;

        public ProdutoController()
        {
            helper = new ControllerHelper<ProdutoModel>();
        }

        public ProdutoModel Gravar(ProdutoModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(ProdutoModel model)
        {
            helper.Excluir(model.Id);
        }

        public ProdutoModel Consultar(ProdutoModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<ProdutoModel> ConsultarPorNome(ProdutoModel model)
        {
            var lstModel = helper.Listar($"nome like '%{model.Nome}%'", "nome", null);
            return lstModel;
        }
        public ProdutoModel ConsultarPorCodigo(ProdutoModel model)
        {
            var lstModel = helper.Listar($"codigo = '{model.Codigo}'", "", 1);
            return lstModel.FirstOrDefault();
        }

        public IEnumerable<ProdutoModel> Listar()
        {
            return helper.Listar();
        }
    }
}