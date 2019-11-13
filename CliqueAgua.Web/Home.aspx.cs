using CliqueAgua.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CliqueAgua.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objPessoa = (PessoaModel)Session["pessoa"];
            lblUsuario.Text = objPessoa.Nome;
        }

    }
}