using CliqueAgua.Data.Controllers;
using CliqueAgua.Data.Models;
using CliqueAgua.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CliqueAgua.Web
{

    public partial class PedidoVenda : System.Web.UI.Page
    {
        PedidoVendaItemController ctrPedidoVendaItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var statePedidoId = Session["idPedidoAlteracao"];
                if (statePedidoId != null)
                {
                    var objPedidoVenda = new PedidoVendaModel();
                    objPedidoVenda.Id = statePedidoId.GetDBInt32();
                    Session["pedidoVenda"] = new PedidoVendaController().Consultar(objPedidoVenda);
                }
                lblPedido.Text = $"Pedido de Venda: {statePedidoId}";
                cmbProduto.DataSource = new ProdutoController().Listar();
                cmbProduto.DataBind();
                CargaGrid();
            }

        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            var statePedidoVenda = (PedidoVendaModel)Session["pedidoVenda"];
            var statePessoa = (PessoaModel)Session["pessoa"];

            if (statePedidoVenda == null || statePedidoVenda.Id == 0)
            {
                statePedidoVenda = new PedidoVendaModel();
                statePedidoVenda.IdPessoa = statePessoa.Id;
                statePedidoVenda.IdEnderecoEntrega = statePessoa.IdEndereco;
                statePedidoVenda = new PedidoVendaController().Gravar(statePedidoVenda);
                Session["pedidoVenda"] = statePedidoVenda;
                Session["idPedidoAlteracao"] = statePedidoVenda.Id;
            }

            lblPedido.Text = $"Pedido de Venda: {statePedidoVenda.Id}";

            var objProduto = new ProdutoModel();
            objProduto.Id = cmbProduto.SelectedValue.GetDBInt32();
            objProduto = new ProdutoController().Consultar(objProduto);

            var objPedidoVendaItem = new PedidoVendaItemModel();
            objPedidoVendaItem.IdPedidoVenda = statePedidoVenda.Id;
            objPedidoVendaItem.IdProduto = objProduto.Id;
            objPedidoVendaItem.Preco = objProduto.PrecoVenda;
            objPedidoVendaItem.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            new PedidoVendaItemController().Gravar(objPedidoVendaItem);

            CargaGrid();
            Limpar();
            cmbProduto.Focus();
            lblMensagem.Text = "";
        }

        private void CargaGrid()
        {
            ctrPedidoVendaItem = new PedidoVendaItemController();
            var statePedidoVenda = (PedidoVendaModel)Session["pedidoVenda"];
            var objPedidoVendaItem = new PedidoVendaItemModel();
            if (statePedidoVenda != null && statePedidoVenda.Id > 0)
            {
                objPedidoVendaItem.IdPedidoVenda = statePedidoVenda.Id;
                GridView1.DataSource = ctrPedidoVendaItem.ListarRawPorPedidoVenda(objPedidoVendaItem);
                GridView1.DataBind();
            }
            else
            {
                objPedidoVendaItem.IdPedidoVenda = -1;
                GridView1.DataSource = ctrPedidoVendaItem.ListarRawPorPedidoVenda(objPedidoVendaItem);
                GridView1.DataBind();
            }
        }

        private void Limpar()
        {
            cmbProduto.SelectedIndex = 0;
            txtPreco.Text = "";
            txtQuantidade.Text = "";
        }

        protected void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objProduto = new ProdutoModel();
            objProduto.Id = cmbProduto.SelectedValue.GetDBInt32();
            objProduto = new ProdutoController().Consultar(objProduto);
            txtPreco.Text = objProduto.PrecoVenda.ToString("c2");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var key = this.GridView1.DataKeys[e.RowIndex].Value.GetDBInt64();
            var objPedidoVendaItem = new PedidoVendaItemModel();
            objPedidoVendaItem.Id = key.GetDBInt32();
            new PedidoVendaItemController().Excluir(objPedidoVendaItem);
            CargaGrid();
        }

        protected void btnEncerrar_Click(object sender, EventArgs e)
        {
            var statePedido = (PedidoVendaModel)Session["pedidoVenda"];
            var objPedidoVenda = new PedidoVendaController().Consultar(statePedido);
            if (objPedidoVenda == null || objPedidoVenda.Id == 0)
            {
                lblMensagem.Text = "Não existe pedido para encerrar.";
                return;
            }
            if (objPedidoVenda.DataEncerramento != DateTime.MinValue)
            {
                lblMensagem.Text = "Pedido já foi encerrado.";
                return;
            }
            objPedidoVenda.DataEncerramento = DateTime.Now;
            new PedidoVendaController().Gravar(objPedidoVenda);
            lblMensagem.Text = "Pedido encerrado com sucesso!";
            Response.Redirect("meuspedidos.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            var statePedidoVenda = (PedidoVendaModel)Session["pedidoVenda"];
            var objPedidoVenda = new PedidoVendaController().Consultar(statePedidoVenda);
            if (objPedidoVenda == null || objPedidoVenda.Id == 0)
            {
                lblMensagem.Text = "Não existe pedido para cancelar.";
                return;
            }
            if (objPedidoVenda.DataCancelamento != DateTime.MinValue)
            {
                lblMensagem.Text = "Pedido já foi cancelado.";
                return;
            }

            objPedidoVenda.DataCancelamento = DateTime.Now;
            new PedidoVendaController().Gravar(objPedidoVenda);
            lblMensagem.Text = "Pedido cancelado com sucesso!";
            Response.Redirect("meuspedidos.aspx", false);

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("meuspedidos.aspx", false);
        }
    }
}