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
    public partial class MeusPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var modelPessoa = (PessoaModel)Session["pessoa"];
            var modelPedidoVenda = new PedidoVendaModel();
            modelPedidoVenda.IdPessoa = modelPessoa.Id;
            var dt = new PedidoVendaController().ConsultarRawPorCliente(modelPedidoVenda);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void btnNovoPedido_Click(object sender, EventArgs e)
        {
            Session["idPedidoAlteracao"] = 0;
            Response.Redirect("PedidoVenda.aspx", false);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            var pessoa = (PessoaModel)Session["pessoa"];
            var modelPedidoVenda = new PedidoVendaModel();
            modelPedidoVenda.IdPessoa = pessoa.Id;
            var dt = new PedidoVendaController().ConsultarRawPorCliente(modelPedidoVenda);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var key = this.GridView1.DataKeys[e.NewEditIndex].Value.GetDBInt64();
            Session["idPedidoAlteracao"] = key;
            Response.Redirect("PedidoVenda.aspx", false);
        }
    }
}