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
    public partial class MinhaConta : System.Web.UI.Page
    {
        PessoaController ctrPessoa;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var objPessoa = (PessoaModel)Session["pessoa"];
                txtEmail.Text = objPessoa.Email;
                txtNome.Text = objPessoa.Nome;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                lblMensagem.Text = "Nome e/ou email invalido";
                return;
            }
            if (string.IsNullOrEmpty(txtSenha1.Text) || txtSenha1.Text != txtSenha2.Text)
            {
                lblMensagem.Text = "Senha invalida ou não coincidem";
                return;
            }

            var modelPessoa = (PessoaModel)Session["pessoa"];
            ctrPessoa = new PessoaController();
            modelPessoa = ctrPessoa.Consultar(modelPessoa);
            modelPessoa.Nome = txtNome.Text;
            modelPessoa.Email = txtEmail.Text;
            modelPessoa.Senha = txtSenha1.Text;
            modelPessoa = ctrPessoa.Gravar(modelPessoa);
            Session["pessoa"] = modelPessoa;
            Response.Redirect("home.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx", false);
        }
    }
}