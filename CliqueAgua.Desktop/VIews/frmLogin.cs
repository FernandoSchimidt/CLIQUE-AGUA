using CliqueAgua.Data.Controllers;
using CliqueAgua.Data.Models;
using System;
using System.Windows.Forms;

namespace CliqueAgua.Desktop.VIews
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text != "")
            {
                if (txtSenha.Text != "")
                {

                    var modelPessoa = new PessoaModel();
                    modelPessoa.Email = txtEmail.Text;
                    var objPessoa = new PessoaController().ConsultarPorEmail(modelPessoa);
                    if (objPessoa == null || objPessoa.Id == 0)
                    {
                        MessageBox.Show("Email não cadastrado.");
                        txtEmail.Focus();
                        return;
                    }
                    if (objPessoa.Senha != txtSenha.Text)
                    {
                    MessageBox.Show("Senha inválida.");
                        txtSenha.Focus();
                        return;
                    }
                    else
                    {

                        frmPrincipal f = new frmPrincipal();
                        f.Show();
                    }

                }
                else
                {
                    MessageBox.Show("O campo senha não pode ser vazio!");
                    txtSenha.Focus();
                }
            }
            else
            {
                MessageBox.Show("O campo email não pode ser vazio!");
                txtEmail.Focus();
            }



        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
