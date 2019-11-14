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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario f = new frmCadastroUsuario();
            f.ShowDialog();
            f.Dispose();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r.Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProdutos f = new frmCadastroProdutos();
            f.ShowDialog();
            f.Dispose();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroClientes f = new frmCadastroClientes();
            f.ShowDialog();
            f.Dispose();

        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedor f = new frmCadastroFornecedor();
            f.ShowDialog();
            f.Dispose();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProdutos f = new frmCadastroProdutos();
            f.ShowDialog();
            f.Dispose();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaCadastroUsuario f = new frmConsultaCadastroUsuario();
            f.ShowDialog();
            f.Dispose();
        }

        private void cleintesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();
            f.Dispose();

        }

        private void fornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor();
            f.ShowDialog();
            f.Dispose();
        }

        private void produtosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmConsultaProdutos f = new frmConsultaProdutos();
            f.ShowDialog();
            f.Dispose();
        }

        private void grupoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroGrupoProduto f = new frmCadastroGrupoProduto();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
