using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class GrupoProdutoController
    {
        ControllerHelper<GrupoProdutoModel> helper;

        public GrupoProdutoController()
        {
            helper = new ControllerHelper<GrupoProdutoModel>();
        }

        public GrupoProdutoModel Gravar(GrupoProdutoModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(GrupoProdutoModel model)
        {
            helper.Excluir(model.Id);
        }

        public GrupoProdutoModel Consultar(GrupoProdutoModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<GrupoProdutoModel> Listar()
        {
            return helper.Listar();
        }
    }
}