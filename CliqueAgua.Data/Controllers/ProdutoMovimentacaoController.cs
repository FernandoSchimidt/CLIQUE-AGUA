using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class ProdutoMovimentacaoController
    {
        ControllerHelper<ProdutoMovimentacaoModel> helper;

        public ProdutoMovimentacaoController()
        {
            helper = new ControllerHelper<ProdutoMovimentacaoModel>();
        }

        public ProdutoMovimentacaoModel Gravar(ProdutoMovimentacaoModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(ProdutoMovimentacaoModel model)
        {
            helper.Excluir(model.Id);
        }
        public IEnumerable<ProdutoMovimentacaoModel> Listar()
        {
            return helper.Listar();
        }
        public ProdutoMovimentacaoModel Consultar(ProdutoMovimentacaoModel model)
        {
            return helper.Consultar(model.Id);
        }

    }
}