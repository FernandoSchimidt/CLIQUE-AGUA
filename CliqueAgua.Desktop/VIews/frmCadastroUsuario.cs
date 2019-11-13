using CliqueAgua.Data.Controllers;
using CliqueAgua.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CliqueAgua.Desktop.VIews
{
    public partial class frmCadastroUsuario : Form
    {
        PessoaModel pessoaModel = new PessoaModel();
        PessoaController pessoaCont = new PessoaController();
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
           
        }
        public void alteraBotoes(int op)
        {
            //op = operações que serão feitas com os botoes
            // 1 = preparar os botoes para inserir e localiza
            // 2 = prepara os botoes para inserir/alterar um registro
            // 3 = prepara a tela para excluir ou alterar

            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnPesquisar.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;

            if (op.Equals(1))
            {
                btnNovo.Enabled = true;
                btnPesquisar.Enabled = true;
            }
            if (op.Equals(2))
            {
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                btnExcluir.Enabled = false;

            }
            if (op.Equals(3))
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (!txtNome.Text.Trim().Equals(""))
            {
                if (!txtEmail.Text.Trim().Equals(""))
                {
                    if (txtSenha.Text != txtConfirmaSenha.Text)
                    {
                        MessageBox.Show("As senhas não correspondem!");

                    }
                    else
                    {
                        try
                        {
                            pessoaModel.Nome = txtNome.Text;
                            pessoaModel.Email = txtEmail.Text;
                            pessoaModel.Senha = txtSenha.Text;

                            pessoaCont.Gravar(pessoaModel);

                            MessageBox.Show("Usuario cadastrado com sucesso!");
                            alteraBotoes(1);
                            LimparTela();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Erro ao gravar o usuario " + ex);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("O campo email não pode ser vazio!");
                    txtEmail.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("O campo nome não pode ser vazio!");
                txtNome.Focus();
                return;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.LimparTela();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            alteraBotoes(1);
            LimparTela();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmConsultaCadastroUsuario f = new frmConsultaCadastroUsuario();
            f.ShowDialog();
            f.Dispose();




            //apos ter puxado o dado
            alteraBotoes(3);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            alteraBotoes(1);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
        }
        public void LimparTela()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
        }
    }
}
