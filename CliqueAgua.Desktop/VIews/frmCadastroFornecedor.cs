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
    public partial class frmCadastroFornecedor : Form
    {
        public frmCadastroFornecedor()
        {
            InitializeComponent();
        }

        private void frmCadastroFornecedor_Load(object sender, EventArgs e)
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
        public void Limpartela()
        {
            //Limpa os campos 

            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
            txtEndereco.Clear();
            mskFone.Clear();
            mskCep.Clear();
            txtCpfCnpj.Clear();
            txtRgIe.Clear();
            txtNumero.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.Limpartela();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor();
            f.ShowDialog();
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
            alteraBotoes(1);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            alteraBotoes(1);
            Limpartela();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            alteraBotoes(1);
            Limpartela();
        }
    }
}
