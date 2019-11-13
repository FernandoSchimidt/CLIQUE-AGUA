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
    public partial class frmConsultaCliente : Form
    {
        public PessoaModel pessoaModel = new PessoaModel();
        PessoaController pessoaCont = new PessoaController();

        public frmConsultaCliente()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            var controller = new PessoaController();
            var model = new PessoaModel();
            model.Nome = txtPesquisarPornome.Text;
            dgvDados.DataSource = controller.ConsultarPorNome(model);
        }

        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {

        }

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            
                var linhasSelecionadas = dgvDados.SelectedRows;
                if (linhasSelecionadas == null || linhasSelecionadas.Count == 0) return;
                var idRegistro = Convert.ToInt32(linhasSelecionadas[0].Cells["Id"].Value);
                var model = new PessoaModel();
                model.Id = idRegistro;
                pessoaModel = new PessoaController().Consultar(model);

                this.Close();
            
          

        }

        private void txtPesquisarPornome_TextChanged(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
        }
    }
}
