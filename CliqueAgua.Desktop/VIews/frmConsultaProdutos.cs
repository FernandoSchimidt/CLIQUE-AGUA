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
    public partial class frmConsultaProdutos : Form
    {
        ProdutoController controller = new ProdutoController();
       public ProdutoModel produtoModel = new ProdutoModel();
        public frmConsultaProdutos()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            var controller = new ProdutoController();
            var model = new ProdutoModel();
            model.Nome = txtPesquisar.Text;
            dgvDados.DataSource = controller.ConsultarPorNome(model);
        }

        private void frmConsultaProdutos_Load(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
        }

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {

            var linhasSelecionadas = dgvDados.SelectedRows;
            if (linhasSelecionadas == null || linhasSelecionadas.Count == 0) return;
            var idRegistro = Convert.ToInt32(linhasSelecionadas[0].Cells["Id"].Value);
            var model = new ProdutoModel();
            model.Id = idRegistro;
            produtoModel = new ProdutoController().Consultar(model);

            this.Close();

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
        }
    }
}
