using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PedidoCompraController
    {
        ControllerHelper<PedidoCompraModel> helper;

        public PedidoCompraController()
        {
            helper = new ControllerHelper<PedidoCompraModel>();
        }

        public PedidoCompraModel Gravar(PedidoCompraModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PedidoCompraModel model)
        {
            helper.Excluir(model.Id);
        }

        public PedidoCompraModel Consultar(PedidoCompraModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<PedidoCompraModel> Listar()
        {
            return helper.Listar();
        }
    }
}