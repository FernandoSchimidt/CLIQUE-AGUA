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
    public partial class frmCadastroProdutos : Form
    {
        public ProdutoModel produtoModel = new ProdutoModel();
        ProdutoController produtoController = new ProdutoController();
        public frmCadastroProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            frmConsultaProdutos f = new frmConsultaProdutos();
            f.ShowDialog();

            if (f.produtoModel.Id > 0)
            {
                txtId.Text = f.produtoModel.Id.ToString();
                txtCodigo.Text = f.produtoModel.Codigo.ToString();
                txtNome.Text = f.produtoModel.Nome.ToString();
                txtPrecoCusto.Text = f.produtoModel.PrecoCusto.ToString();
                txtPrecoVenda.Text = f.produtoModel.PrecoVenda.ToString();
                txtSaldo.Text = f.produtoModel.Saldo.ToString();
                txtEstoqueMinimo.Text = f.produtoModel.EstoqueMinimo.ToString();
            }


            // incluir rotina de preencher os campos

            f.Dispose();

            //apos ter puxado o dado
            alteraBotoes(3);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(null))
            {
                try
                {
                    DialogResult d = MessageBox.Show("Deseja excluir o produto?", "Aviso", MessageBoxButtons.YesNo);
                    if (d.ToString().Equals("Yes"))
                    {
                        produtoModel.Id = Convert.ToInt32(txtId.Text);
                        produtoController.Excluir(produtoModel);
                        MessageBox.Show("Produto excluido com sucesso!");
                        this.Limpartela();
                        this.alteraBotoes(1);
                    }
                }
                catch
                {
                    MessageBox.Show("Impossivel excluir o produto\n O registro esta sendo utilido em outro lugar");
                    this.alteraBotoes(3);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Trim().Equals(""))
            {
                if (!txtNome.Text.Trim().Equals(""))
                {
                    if (!txtPrecoCusto.Text.Trim().Equals(""))
                    {
                        if (!txtPrecoVenda.Text.Trim().Equals(""))
                        {
                            try
                            {
                                produtoModel.Codigo = txtCodigo.Text;
                                produtoModel.Nome = txtNome.Text;
                                produtoModel.PrecoCusto = Convert.ToDecimal(txtPrecoCusto.Text);
                                produtoModel.PrecoVenda = Convert.ToDecimal(txtPrecoVenda.Text);
                                produtoModel.Saldo = Convert.ToDecimal(txtSaldo.Text);
                                produtoModel.EstoqueMinimo = Convert.ToInt64(txtEstoqueMinimo.Text);

                                produtoController.Gravar(produtoModel);
                                MessageBox.Show("Produto cadastrado com sucesso!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao cadastrar o produto " + ex);
                            }
                            alteraBotoes(1);
                        }
                        else
                        {
                            MessageBox.Show("O campo preço de venda é obrigatório!");
                            txtPrecoVenda.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("O campo preço de custo é obrigatório!");
                        txtPrecoCusto.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("O campo nome é obrigatório!");
                    txtNome.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("O campo código é obrigatório!");
                txtCodigo.Focus();
                return;
            }



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            alteraBotoes(1);
            Limpartela();
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
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Enabled = false;
                btnSalvar.Enabled = false;
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
        public void Limpartela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtSaldo.Clear();
            txtPrecoVenda.Clear();
            txtPrecoCusto.Clear();
            txtEstoqueMinimo.Clear();

        }
    }
}
