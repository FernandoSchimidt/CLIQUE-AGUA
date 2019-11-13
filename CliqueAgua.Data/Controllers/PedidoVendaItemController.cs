using CliqueAgua.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PedidoVendaItemController
    {
        ControllerHelper<PedidoVendaItemModel> helper;

        public PedidoVendaItemController()
        {
            helper = new ControllerHelper<PedidoVendaItemModel>();
        }

        public PedidoVendaItemModel Gravar(PedidoVendaItemModel model)
        {
            var modelItem = helper.Gravar(model, model.Id);
            if (modelItem.Id == 0)
                throw new Exception("Registro não cadastrado");
            AtualizarTotais(modelItem);
            return modelItem;
        }
        
        public void Excluir(PedidoVendaItemModel model)
        {
            var modelItem = Consultar(model);
            if (modelItem.Id == 0)
                throw new Exception("Registro não cadastrado");
            helper.Excluir(modelItem.Id);
            AtualizarTotais(modelItem);
        }
        
        public PedidoVendaItemModel Consultar(PedidoVendaItemModel model)
        {
            return helper.Consultar(model.Id);
        }
        
        public IEnumerable<PedidoVendaItemModel> ListarPorPedido(PedidoVendaItemModel model)
        {
            return helper.Listar($"idpedidovenda = {model.IdPedidoVenda}", $"", null);
        }
        
        private void AtualizarTotais(PedidoVendaItemModel model)
        {
            var ctrPedidoVenda = new PedidoVendaController();
            var lstPedidoVendaItem = ListarPorPedido(model);
            var modelPedidoVenda = new PedidoVendaModel();
            modelPedidoVenda.Id = model.IdPedidoVenda;
            modelPedidoVenda = ctrPedidoVenda.Consultar(modelPedidoVenda);
            modelPedidoVenda.Total = lstPedidoVendaItem.Sum(s => s.Preco * s.Quantidade);
            modelPedidoVenda = ctrPedidoVenda.Gravar(modelPedidoVenda);
        }
        public IEnumerable<PedidoVendaItemModel> Listar()
        {
            return helper.Listar();
        }
        public DataTable ListarRawPorPedidoVenda(PedidoVendaItemModel model)
        {
            string query = $@"
select 
	pro.Codigo as Produto_Codigo, pro.nome as Produto_Nome,
    (Quantidade * Preco) as Total,
	ite.*
from PedidoVendaItem as ite
inner join Produto as pro on pro.id = ite.IdProduto
where
    idpedidovenda = {model.IdPedidoVenda}";

            return helper.ListarRaw(query);
        }

    }
}