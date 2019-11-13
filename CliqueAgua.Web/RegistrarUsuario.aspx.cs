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
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var modelPessoa = new PessoaModel();
            modelPessoa.Email = txtEMail.Text;
            modelPessoa = new PessoaController().ConsultarPorEmail(modelPessoa);
            if (modelPessoa != null && modelPessoa.Id > 0)
            {
                lblMensagem.Text = "Email já cadastrado em nosso sistema.";
                return;
            }
            if (string.IsNullOrEmpty(txtEMail.Text))
            {
                lblMensagem.Text = "Email invalido.";
                return;
            }
            if (string.IsNullOrEmpty(txtSenha1.Text) || txtSenha1.Text != txtSenha2.Text)
            {
                lblMensagem.Text = "Senha invalida.";
                return;
            }

            modelPessoa = new PessoaModel();
            modelPessoa.Nome = txtNome.Text;
            modelPessoa.Email = txtEMail.Text;
            modelPessoa.Senha = txtSenha1.Text;
            Session["pessoa"] = new PessoaController().Gravar(modelPessoa);
            
            Response.Redirect("login.aspx", false);

        }

        protected void btnRegistrar0_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx", false);
        }
    }
}