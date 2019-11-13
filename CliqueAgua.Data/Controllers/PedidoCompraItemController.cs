using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PedidoCompraItemController
    {
        ControllerHelper<PedidoCompraItemModel> helper;

        public PedidoCompraItemController()
        {
            helper = new ControllerHelper<PedidoCompraItemModel>();
        }

        public PedidoCompraItemModel Gravar(PedidoCompraItemModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PedidoCompraItemModel model)
        {
            helper.Excluir(model.Id);
        }

        public PedidoCompraItemModel Consultar(PedidoCompraItemModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<PedidoCompraItemModel> Listar()
        {
            return helper.Listar();
        }
    }
}