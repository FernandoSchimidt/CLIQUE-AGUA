using CliqueAgua.Data.Controllers;
using CliqueAgua.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CliqueAgua.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["pessoa"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var modelPessoa = new PessoaModel();
            modelPessoa.Email = txtEmail.Text;
            var objPessoa = new PessoaController().ConsultarPorEmail(modelPessoa);
            if (objPessoa == null || objPessoa.Id == 0)
            {
                lblMensagem.Text = "Email não cadastrado.";
                return;
            }
            if (objPessoa.Senha != txtSenha.Text)
            {
                lblMensagem.Text = "Senha inválida.";
                return;
            }
            Session["pessoa"] = objPessoa;
            Response.Redirect("home.aspx", false);
        }
    }
}