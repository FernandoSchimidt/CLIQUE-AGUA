using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CliqueAgua.Web
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMinhaConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("MinhaConta.aspx", false);
        }

        protected void btnMeusPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeusPedidos.aspx", false);
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}